using System.ComponentModel.DataAnnotations.Schema;

namespace Zero_Hunger_Management.Models
{
    public class CollectRequest
    {
        public int ID { get; set; }
        public System.DateTime PresentTime { get; set; }
        public System.DateTime MaxPreservedTime { get; set; }
        public string Location { get; set; }
        public int ForHowManyPersons { get; set; }
        public string Status { get; set; }

        [ForeignKey("Restaurants")]
        public int RID { get; set; }

        public virtual Restaurant Restaurants { get; set; }

        public CollectRequest()
        {
            this.AssignEmployees = new List<AssignEmployee>();
        }
        public virtual List<AssignEmployee> AssignEmployees { get; set; }
    }
}
