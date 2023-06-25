namespace GymApi.Models
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Customer(string fName, string lName, int age)
        {
            FirstName = fName;
            LastName = lName;
            Age = age;
        }
    }
}
