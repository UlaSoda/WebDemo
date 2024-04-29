using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

public partial class _Default : Page
{

    class Person
    {
        //private static int lastID = 0;
        public string Name { get; set; }
        public int Age { get; set; }
        public string Birthday { get; set; }
        //public int ID { get; set; }

        public Person(string name, int age, string birthday)
        {
            //ID = ++lastID;
            Name = name;
            Age = age;
            Birthday = birthday;
        }

    }

    List<Person> Persons
    {
        get
        {
            if (HttpContext.Current.Session["Persons"] == null || !(HttpContext.Current.Session["Persons"] is List<Person>))
            {
                HttpContext.Current.Session["Persons"] = new List<Person>();
            }
            return HttpContext.Current.Session["Persons"] as List<Person>;
        }
        set
        {
            HttpContext.Current.Session["Persons"] = value;
        }

    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // 在頁面首次加載時生成唯一標識符號
            string token = Guid.NewGuid().ToString();
            HiddenFieldToken.Value = token; // 將標識符號存儲在隱藏欄位中

            UpdateView();
        }
    }

    protected void FunctionButton_Click(object sender, EventArgs e)
    {
        // 在處理表單提交時驗證標識符號
        string submittedToken = Request.Form[HiddenFieldToken.UniqueID];
        string storedToken = HiddenFieldToken.Value;

        if (submittedToken == storedToken)
        {
            // 表單提交是有效的，處理表單數據
            string name = NameTextBox.Text;
            int age = 0;
            Int32.TryParse(AgeTextBox.Text, out age);
            string birthday = BirthdayTextBox.Text;
            Person person = new Person(name, age, birthday);

            if (FunctionButton.Text.Equals("建立帳號"))
            {
                Person p = Persons.Where(x => x.Name == name).FirstOrDefault();
                if (p == null)
                {
                    Persons.Add(person);
                }
                else
                {
                    string script = $"<script>alert('錯誤，人員{p.Name}已存在');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script);
                }
            }
            else
            {
                Person p = Persons.Where(x => x.Name == name).FirstOrDefault();
                if (p == null)
                {
                    string script = $"<script>alert('錯誤，人員{name}不存在');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script);
                }
                else
                {
                    p.Age = age;
                    p.Birthday = birthday;
                }
                FunctionButton.Text = "建立帳號";
            }

            UpdateView();
        }
        else
        {
            // 表單提交無效，可能是由於重新整理頁面導致的重複提交
            // 可以採取相應的措施，例如忽略此次提交或者顯示錯誤消息
        }

    }

    public void UpdateView()
    {
        GridView1.DataSource = Persons;
        GridView1.DataBind();
    }


    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //string arg = Convert.ToString(((System.Web.UI.WebControls.CommandEventArgs)(e)).CommandArgument);
        int index = Convert.ToInt32(e.CommandArgument);

        // Retrieve the row that contains the button clicked 
        // by the user from the Rows collection.
        GridViewRow row = GridView1.Rows[index];
        //Person person = new Person();
        NameTextBox.Text = row.Cells[0].Text;
        AgeTextBox.Text = row.Cells[1].Text;
        BirthdayTextBox.Text = row.Cells[2].Text;


        if (e.CommandName == "Up")
        {
            FunctionButton.Text = "修改帳號";
        }
        else if (e.CommandName == "Del")
        {
            Person p = Persons.Where(x => x.Name == NameTextBox.Text).FirstOrDefault();
            if (p == null)
            {
                string script = $"<script>alert('錯誤，人員{p.Name}不存在');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script);
            }
            else
            {
                Persons.Remove(p);
                string script = $"<script>alert('人員{p.Name}已刪除');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script);
            }
        }

        UpdateView();
    }

}