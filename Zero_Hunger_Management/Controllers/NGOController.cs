using Microsoft.AspNetCore.Mvc;
using Zero_Hunger_Management.Data;
using Zero_Hunger_Management.Models;
using Zero_Hunger_Management.Repo;

namespace Zero_Hunger_Management.Controllers
{
    public class NGOController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly ZeroHungerDBContext db;

        public NGOController(ZeroHungerDBContext context)
        {
            db = context;
        }

        //________________________________________________________Restaurant Related Operation____________________________________

        //______________________________Restaurant List_______________________

        public ActionResult RestaurantList()
        {
            var restaurantRepo=new RestaurantRepo(db);
            return View(restaurantRepo.Get()); // Get() is the  function of RestaurantRepo for getting all restaurants made by me
        }


        //______________________________Add Restaurant________________________

        [HttpGet]
        public ActionResult AddRestaurant()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddRestaurant(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                var restaurantRepo = new RestaurantRepo(db);
                restaurantRepo.AddRestaurant(restaurant);  // AddRestaurant is create function of RestaurantRepo made by me
                TempData["added"] = "A new restaurant is added";
                return RedirectToAction("RestaurantList");
            }
            return View(restaurant);
        }

        //_____________________________Delete Restaurant________________________

        public ActionResult DeleteRestaurant(int id)
        {

            var restaurantRepo = new RestaurantRepo(db);
            restaurantRepo.DeleteRestaurant(id);
            return RedirectToAction("RestaurantList");
        }

        //_____________________________Update Restaurant________________________

        [HttpGet]
        public ActionResult UpdateRestaurant(int id)
        {
            //RestaurantRepo.UpdateRestaurant(id);
            var restaurantRepo = new RestaurantRepo(db);
            return View(restaurantRepo.RestaurantDetails(id));
        }


        [HttpPost]
        public ActionResult UpdateRestaurant(int id, Restaurant restaurant)
        {
            var restaurantRepo = new RestaurantRepo(db);
            restaurantRepo.UpdateRestaurant(id, restaurant);
            TempData["updated"] = "Information is updated";
            return RedirectToAction("RestaurantList");
        }


        //______________________________Restaurant Details_____________________


        public ActionResult RestaurantDetails(int id)
        {
            var restaurantRepo = new RestaurantRepo(db);
            return View(restaurantRepo.RestaurantDetails(id));
        }










        //________________________________________________________________Employee Related Operation____________________________________________


        //_________________________Employee List_______________________

        public ActionResult EmployeeList()
        {
            var employeeRepo = new EmployeeRepo(db);
            return View(employeeRepo.Get());
        }

        //_________________________Add Employee________________________

        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var employeeRepo = new EmployeeRepo(db);
                employeeRepo.AddEmployee(employee);  // AddRestaurant is create function of RestaurantRepo made by me
                TempData["added"] = "A new employee is added";
                return RedirectToAction("EmployeeList");
            }
            return View(employee);
        }




        //_____________________________Delete Employee________________________

        public ActionResult DeleteEmployee(int id)
        {
            var employeeRepo = new EmployeeRepo(db);
            employeeRepo.DeleteEmployee(id);
            return RedirectToAction("EmployeeList");
        }

        //_____________________________Update Employee________________________

        [HttpGet]
        public ActionResult UpdateEmployee(int id)
        {
            //RestaurantRepo.UpdateRestaurant(id);
            var employeeRepo = new EmployeeRepo(db);
            return View(employeeRepo.EmployeeDetails(id));
        }


        [HttpPost]
        public ActionResult UpdateEmployee(int id, Employee employee)
        {
            var employeeRepo = new EmployeeRepo(db);
            employeeRepo.UpdateEmployee(id, employee);
            TempData["updated"] = "Information is updated";
            return RedirectToAction("EmployeeList");
        }


        //________________________________Employee Details_____________________


        public ActionResult EmployeeDetails(int id)
        {
            var employeeRepo = new EmployeeRepo(db);
            return View(employeeRepo.EmployeeDetails(id));
        }












        //________________________________________________________________Collect Request Related Operation____________________________________________

        //_________________________Collect Request List_______________________

        public ActionResult CollectRequestList()
        {
            //var db = new Zero_Hunger_DBEntities();

            //var collectRequest = (from cr in db.CollectRequests
            //                      where cr.Status=="requested"
            //                      select cr).ToList();
            //return View(collectRequest);



            var collectRequestRepo=new CollectRequestRepo(db);
            return View(collectRequestRepo.Get());
        }

        //_________________________Accept Collect Request List_______________________


        public ActionResult AcceptCollectRequest(int id)
        {

            var collectRequestRepo = new CollectRequestRepo(db);
            collectRequestRepo.UpdateCollectRequest(id);
            TempData["accepted"] = "Collect Request is accepted";
            return RedirectToAction("CollectRequestList");
        }



        //_________________________Delete Collect Request_______________________


        public ActionResult DeleteCollectRequest(int id)
        {
            var collectRequestRepo = new CollectRequestRepo(db);
            collectRequestRepo.DeleteCollectRequest(id);
            return RedirectToAction("CollectRequestList");
        }


        //_________________________Delete Assigned Collect Request_______________________


        public ActionResult DeleteAssignedCollectRequest(int id)
        {
            var collectRequestRepo = new CollectRequestRepo(db);
            var assignEmployeeRepo = new AssignEmployeeRepo(db);
            assignEmployeeRepo.DeleteAssignedCollectRequest(id);
            TempData["deleted"] = "Deleted successfully";
            return RedirectToAction("AssignedCollectRequests", "Employee");
        }


        //_________________________Collect Request Details_______________________


        public ActionResult CollectRequestDetails(int id)
        {
            var collectRequestRepo = new CollectRequestRepo(db);
            var employeeRepo=new EmployeeRepo(db);
            //var db = new ZeroHungerDBContext();
            var rid = collectRequestRepo.CollectRequestDetails(id).RID;
            var d = (from res in db.Restaurants
                     where res.ID == rid
                     select res).SingleOrDefault();
            ViewBag.restaurant = d.Name;


            ViewBag.employList = employeeRepo.Get();
            return View(collectRequestRepo.CollectRequestDetails(id));
        }


        //_________________________________________________________________________Assign Employee Related Operation_____________________________________



        //__________________________Assign Employee________________________


        [HttpGet]
        public ActionResult AssignEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AssignEmployee(AssignEmployee assignEmployee)
        {
            //if (ModelState.IsValid)
            //{
            //    AssignEmployeeRepo.AssignEmployee(assignEmployee);  // AddRestaurant is create function of RestaurantRepo made by me
            //    TempData["assign"] = "Employee Is Assigned for Collect Request ID "+assignEmployee.CRID;
            //    return RedirectToAction("CollectRequestList");
            //}
            //return View(assignEmployee);
            
            //var db = new ZeroHungerDBContext();
            if (ModelState.IsValid)
            {
                //var ext = (from e in db.AssignEmployees
                //           where e.EID==assignEmployee.EID && e.CRID==assignEmployee.CRID
                //           select e).SingleOrDefault();

                var assignEmployeeRepo = new AssignEmployeeRepo(db);
                assignEmployeeRepo.AssignEmployee(assignEmployee);  // AddRestaurant is create function of RestaurantRepo made by me
                TempData["assign"] = "Employee Is Assigned for Collect Request ID " + assignEmployee.CRID;
                return RedirectToAction("CollectRequestList");
            }
            return View(assignEmployee);


        }
    }
}
