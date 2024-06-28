namespace Zero_Hunger_Management.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Employee()
        {
            this.AssignEmployees = new List<AssignEmployee>();
            
        }
        public virtual List<AssignEmployee> AssignEmployees { get; set; }
      
    }
}
