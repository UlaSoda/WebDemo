namespace MvcDemo.Models
{
    public class PersonsViewModel
    {
        public List<Person> Persons = new List<Person>();
        public Person Person { get; set; }

        public PersonsViewModel()
        {
            // 初始化 Person 物件
            Person = new Person();
        }
    }
}
