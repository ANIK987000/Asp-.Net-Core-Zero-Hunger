using Zero_Hunger_Management.Data;
using Zero_Hunger_Management.Models;

namespace Zero_Hunger_Management.Repo
{
    public class CollectRequestRepo
    {
        private readonly ZeroHungerDBContext db;

        public CollectRequestRepo(ZeroHungerDBContext context)
        {
            db = context;
        }
        //_____________________________Get Collect Requests_______________________________________________

        public  List<CollectRequest> Get()
        {
            //var db = new ZeroHungerDBContext();
            var collectRequests = new List<CollectRequest>();


            foreach (var item in db.CollectRequests)
            {
                collectRequests.Add(new CollectRequest()
                {
                    ID = item.ID,
                    PresentTime = item.PresentTime,
                    MaxPreservedTime = item.MaxPreservedTime,
                    Location = item.Location,
                    ForHowManyPersons = item.ForHowManyPersons,
                    Status = item.Status,
                    RID = item.RID
                });
            }
            return collectRequests;

        }


        //_______________________________________Get Collect Requests Details__________________________________

        public  CollectRequest CollectRequestDetails(int id)
        {
            //var db = new ZeroHungerDBContext();
            var collectRequest = new CollectRequest();

            var dbcr = db.CollectRequests.Find(id);

            collectRequest.ID = dbcr.ID;
            collectRequest.PresentTime = dbcr.PresentTime;
            collectRequest.MaxPreservedTime = dbcr.MaxPreservedTime;
            collectRequest.Location = dbcr.Location;
            collectRequest.ForHowManyPersons = dbcr.ForHowManyPersons;
            collectRequest.Status = dbcr.Status;
            collectRequest.RID = dbcr.RID;



            return collectRequest;


        }


        //________________________________Create Collect Request_________________________________________

        public  void CreateCollectRequest(CollectRequest dbcr, int id)
        {
            //var db = new ZeroHungerDBContext();
            var collectRequest = new CollectRequest();


            collectRequest.ID = dbcr.ID;
            collectRequest.PresentTime = DateTime.Now;
            collectRequest.MaxPreservedTime = dbcr.MaxPreservedTime;
            collectRequest.Location = dbcr.Location;
            collectRequest.ForHowManyPersons = dbcr.ForHowManyPersons;
            collectRequest.Status = "requested";
            collectRequest.RID = id;


            db.CollectRequests.Add(collectRequest);
            db.SaveChanges();
        }


        //_______________________________Delete Collect Request_______________________________________

        public  void DeleteCollectRequest(int id)
        {
            //var db = new ZeroHungerDBContext();
            //var restaurant = new RestaurantModel();

            var dbcr = db.CollectRequests.Find(id);

            db.CollectRequests.Remove(dbcr);
            db.SaveChanges();
        }


        //_______________________________Update Collect Request_________________________________________

        public  void UpdateCollectRequest(int id)
        {
            //var db = new ZeroHungerDBContext();

            var dbcr = db.CollectRequests.Find(id);

            dbcr.ID = dbcr.ID;
            dbcr.PresentTime = dbcr.PresentTime;
            dbcr.MaxPreservedTime = dbcr.MaxPreservedTime;
            dbcr.Location = dbcr.Location;
            dbcr.ForHowManyPersons = dbcr.ForHowManyPersons;
            dbcr.Status = "accepted";
            dbcr.RID = dbcr.RID;

            db.SaveChanges();


        }


        //_______________________________Update Collect Request By Employee_________________________________________

        public  void UpdateCollectRequestByEmployee(int id)
        {
            //var db = new ZeroHungerDBContext();

            var dbcr = db.CollectRequests.Find(id);

            dbcr.ID = dbcr.ID;
            dbcr.PresentTime = dbcr.PresentTime;
            dbcr.MaxPreservedTime = dbcr.MaxPreservedTime;
            dbcr.Location = dbcr.Location;
            dbcr.ForHowManyPersons = dbcr.ForHowManyPersons;
            dbcr.Status = "completed";
            dbcr.RID = dbcr.RID;

            db.SaveChanges();


        }




        //_______________________________Update Assign Employee Status By Employee when clicked collected_________________________________________

        public  void UpdateAssignEmployeeStatusByEmployee(int id, int eid)
        {
            //var db = new ZeroHungerDBContext();

            var dbcr = (from st in db.AssignEmployees
                        where st.CRID == id && st.EID == eid
                        select st).SingleOrDefault();


            dbcr.EID = dbcr.EID;
            dbcr.RID = dbcr.RID;
            dbcr.CRID = dbcr.CRID;
            dbcr.RName = dbcr.RName;
            dbcr.RLocation = dbcr.RLocation;
            dbcr.MaxPreservedTime = dbcr.MaxPreservedTime;
            dbcr.Status = "completed";

            db.SaveChanges();


        }


        //_______________________________Collect Request Requested By Restauarant_________________________________________

        //public static void CollectRequestRequestedByRestauarant(int id)
        //{
        //    var db = new Zero_Hunger_DBEntities();

        //    var dbcr = db.CollectRequests.Find(id);

        //    dbcr.ID = dbcr.ID;
        //    dbcr.PresentTime = dbcr.PresentTime;
        //    dbcr.MaxPreservedTime = dbcr.MaxPreservedTime;
        //    dbcr.Location = dbcr.Location;
        //    dbcr.ForHowManyPersons = dbcr.ForHowManyPersons;
        //    dbcr.Status = "completed";
        //    dbcr.RID = 5;

        //    db.SaveChanges();


        //}

    }
}
