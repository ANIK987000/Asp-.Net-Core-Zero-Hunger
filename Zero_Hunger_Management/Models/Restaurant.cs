namespace Zero_Hunger_Management.Models
{
    public class Restaurant
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public Restaurant()
        {
            this.AssignEmployees = new List<AssignEmployee>();
            this.CollectRequests = new List<CollectRequest>();
        }
        public virtual List<AssignEmployee> AssignEmployees { get; set; }
        public virtual List<CollectRequest> CollectRequests { get; set; }
       
    }
}
