using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcDemo.Models
{
    

    public class Person
    {
        //private static int lastID = 0;
        [Required]
        [DisplayName("姓名")]

        public string Name { get; set; }
        [Required]
        [DisplayName("年齡")]


        public int Age { get; set; }
        [Required]
        [DisplayName("生日")]
        public string Birthday { get; set; }

        //public int ID { get; set; }
        public Person()
        {
        }
        public Person(string name, int age, string birthday)
        {
            //ID = ++lastID;
            Name = name;
            Age = age;
            Birthday = birthday;
        }

    }


}
