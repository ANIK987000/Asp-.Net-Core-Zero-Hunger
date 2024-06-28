namespace Zero_Hunger_Management.Models
{
    public class NGO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //public ICollection<CollectRequest> CollectRequests { get; set; }
    }
}
