using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Zero_Hunger_Management.Data;
using Zero_Hunger_Management.Repo;

namespace Zero_Hunger_Management.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly ZeroHungerDBContext db;

        public EmployeeController(ZeroHungerDBContext context)
        {
            db = context;
        }

        //______________________________________Assigned Collect Requests_________________________________________________

        public ActionResult AssignedCollectRequests()
        {
            var assignEmployeeRepo = new AssignEmployeeRepo(db);
            return View(assignEmployeeRepo.AssignedCollectRequests());
        }

        //______________________________________Collect Requests By Employee ID_________________________________________________
        public ActionResult CollectRequestsByEmployeeID()
        {
            //var db = new ZeroHungerDBContext();

            var str = HttpContext.Session.GetString("employeeID");
            var id = JsonSerializer.Deserialize<int>(str);

            var crbe = (from crb in db.AssignEmployees
                        where crb.EID == id && (crb.Status == "requested" || crb.Status == "accepted")
                        select crb).ToList();

            return View(crbe);
        }


        //______________________________________When clicked collected and becomes deleted from AssignEmployee Table_________________________________________________

        //public ActionResult Collected(int id)
        //{
        //    CollectRequestRepo.UpdateCollectRequestByEmployee(id);
        //    TempData["completed"]= "Collect Request is completed";

        //    var db = new Zero_Hunger_DBEntities();
        //    var crbe = (from crb in db.AssignEmployees
        //                where crb.CRID == id && crb.EID==3
        //                select crb).SingleOrDefault();

        //    AssignEmployeeRepo.DeleteAssignedCollectRequest(crbe.ID);
        //    return RedirectToAction("CollectRequestsByEmployeeID");
        //}


        //______________________________________When clicked collected and becomes status completed_________________________________________________
        public ActionResult Collected(int id)
        {
            var collectRequestRepo = new CollectRequestRepo(db);
            collectRequestRepo.UpdateCollectRequestByEmployee(id);
            TempData["completed"] = "Collect Request is completed";

            //var db = new Zero_Hunger_DBEntities();
            //var crbe = (from crb in db.AssignEmployees
            //            where crb.CRID == id && crb.EID == 3
            //            select crb).SingleOrDefault();

            //AssignEmployeeRepo.DeleteAssignedCollectRequest(crbe.ID);

            var str = HttpContext.Session.GetString("employeeID");
            var eid = JsonSerializer.Deserialize<int>(str);

            collectRequestRepo.UpdateAssignEmployeeStatusByEmployee(id, eid);
            return RedirectToAction("CollectRequestsByEmployeeID");
        }
    }
}
