using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zero_Hunger_Management.Data;
using Zero_Hunger_Management.Models;

namespace Zero_Hunger_Management.Controllers
{
    public class LoginController : Controller
    {
        private readonly ZeroHungerDBContext db;

        public LoginController(ZeroHungerDBContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        //_________________________________Login System For All User_______________________________________

        [HttpGet]
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(NGO nGO, Restaurant restaurant, Employee employee)
        {
            //var db = new Zero_Hunger_DBEntities();


            var n = (from ngo in db.NGOS
                     where ngo.Email == nGO.Email
                     select ngo).SingleOrDefault();

            //var r = new Restaurant();
            var r = (from res in db.Restaurants
                     where res.Email == restaurant.Email
                     select res).SingleOrDefault();

            //var e = new Employee();
            var e = (from emp in db.Employees
                     where emp.Email == employee.Email
                     select emp).SingleOrDefault();





            if (n != null)
            {
                if (n.Password == nGO.Password)
                {
                    //HttpContext.Session.SetString("ngoID", n.ID.ToString()) ;
                    //HttpContext.Session.SetString("ngoName", n.Name.ToString());
                    return RedirectToAction("CollectRequestList", "NGO");
                }
                else
                {
                    TempData["password"] = "Password is incorrect";
                    return RedirectToAction("login");
                }
            }
            else if (r != null)
            {
                if (r.Password == restaurant.Password)
                {

                    //HttpContext.Session.SetString("restaurantID", r.ID.ToString());
                    //HttpContext.Session.SetString("restaurantName", r.Name.ToString());
                    return RedirectToAction("CreateCollectRequest", "Restaurant");
                }
                else
                {
                    TempData["password"] = "Password is incorrect";
                    return RedirectToAction("login");
                }
            }
            else if (e != null)
            {
                if (e.Password == employee.Password)
                {
                    //HttpContext.Session.SetString("employeeID",e.ID.ToString());
                    //HttpContext.Session.SetString("employeeName", e.Name.ToString());
                    return RedirectToAction("CollectRequestsByEmployeeID", "Employee");
                }
                else
                {
                    TempData["password"] = "Password is incorrect";
                    return RedirectToAction("login");
                }
            }
            else
            {
                TempData["email"] = "Email is not registered";
                return RedirectToAction("login");
            }

        }

        //[HttpGet]
        //public ActionResult Register()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Register(Register register)
        //{
        //    if (register.Type=="Restaurant")
        //    {
        //        var restaurant = new Restaurant();

        //        restaurant.Name = register.Name;
        //        restaurant.Location = register.Location;
        //        restaurant.Email = register.Email;
        //        restaurant.Password = register.Password;

        //        db.Restaurants.Add(restaurant);
        //        db.SaveChanges();
        //        return RedirectToAction("login","Login");

        //    }
        //    else
        //    {
        //        var employee = new Employee();



        //        //employee.ID = dbe.ID;
        //        employee.Name = register.Name;
        //        employee.Location = register.Location;
        //        employee.Email = register.Email;
        //        employee.Password = register.Password;

        //        db.Employees.Add(employee);
        //        db.SaveChanges();
        //        return RedirectToAction("login","Login");

        //    }
            
        //    //return View();
        //}

    }
}
