using Microsoft.AspNetCore.Mvc;
using Zero_Hunger_Management.Data;
using Zero_Hunger_Management.Models;

namespace Zero_Hunger_Management.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ZeroHungerDBContext db;

        public RegisterController(ZeroHungerDBContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Register register)
        {
            if (register.Type == "Restaurant")
            {
                var restaurant = new Restaurant();

                restaurant.Name = register.Name;
                restaurant.Location = register.Location;
                restaurant.Email = register.Email;
                restaurant.Password = register.Password;

                db.Restaurants.Add(restaurant);
                db.SaveChanges();
                return RedirectToAction("login", "Login");

            }
            else
            {
                var employee = new Employee();



                //employee.ID = dbe.ID;
                employee.Name = register.Name;
                employee.Location = register.Location;
                employee.Email = register.Email;
                employee.Password = register.Password;

                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("login", "Login");

            }

            //return View();
        }
    }
}
