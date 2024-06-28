using System.ComponentModel.DataAnnotations.Schema;

namespace Zero_Hunger_Management.Models
{
    public class AssignEmployee
    {
        public int ID { get; set; }

        [ForeignKey("Employees")]
        public int EID { get; set; }

        [ForeignKey("Restaurants")]
        public int RID { get; set; }

        [ForeignKey("CollectRequests")]
        public int CRID { get; set; }
        public string RName { get; set; }
        public string RLocation { get; set; }
        public System.DateTime MaxPreservedTime { get; set; }
        public string Status { get; set; }

        public virtual Employee Employees { get; set; }
        public virtual Restaurant Restaurants { get; set; }
        public virtual CollectRequest CollectRequests { get; set; }
    }
}
