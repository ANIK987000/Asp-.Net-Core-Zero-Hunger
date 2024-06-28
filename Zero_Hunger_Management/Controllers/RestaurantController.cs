using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Zero_Hunger_Management.Data;
using Zero_Hunger_Management.Models;
using Zero_Hunger_Management.Repo;


namespace Zero_Hunger_Management.Controllers
{
    public class RestaurantController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly ZeroHungerDBContext db;

        public RestaurantController(ZeroHungerDBContext context)
        {
            db = context;
        }

        //______________________________Create Collect Request________________________

        [HttpGet]
        public ActionResult CreateCollectRequest()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCollectRequest(CollectRequest collectRequest)
        {
            if (ModelState.IsValid)
            {
                var str = HttpContext.Session.GetString("restaurantID");
                var id = JsonSerializer.Deserialize<int>(str);
                var collectRequestRepo = new CollectRequestRepo(db);

                collectRequestRepo.CreateCollectRequest(collectRequest, id);  // AddRestaurant is create function of RestaurantRepo made by me
                TempData["created"] = "Collect Request Created";
                return RedirectToAction("CollectRequestRequestedByRestauarant");
            }

            return View(collectRequest);
        }


        //_____________________________Collect Request Requested By Restauarant__________________________

        public ActionResult CollectRequestRequestedByRestauarant()
        {

            var str = HttpContext.Session.GetString("restaurantID");
            var id =  JsonSerializer.Deserialize<int>(str);

            //var db = new ZeroHungerDBContext();
            var crrbr = (from cr in db.CollectRequests
                         where cr.RID == id
                         select cr).ToList();

            return View(crrbr);
        }
        //______________________________Delete Collect Request________________________



        //______________________________Update Collect Request________________________
    }
}
