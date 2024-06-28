using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Zero_Hunger_Management.Data;
using Zero_Hunger_Management.Models;

namespace Zero_Hunger_Management.Repo
{
    public class RestaurantRepo
    {
       
        private readonly ZeroHungerDBContext db;

        public RestaurantRepo(ZeroHungerDBContext context)
        {
            db = context;
        }

        //_____________________________Get Restaurant_______________________________________________

        public  List<Restaurant> Get()
        {
            //var db = new ZeroHungerDBContext();
            var restaurants = new List<Restaurant>();

            foreach (var item in db.Restaurants)
            {
                restaurants.Add(new Restaurant()
                {
                    ID = item.ID,
                    Name = item.Name,
                    Location = item.Location,
                    Email = item.Email,
                    Password = item.Password
                });
            }
            return restaurants;

        }


        //_______________________________________Get Restaurant Details___________________________________

        public  Restaurant RestaurantDetails(int id)
        {
            //var db = new ZeroHungerDBContext();
            var restaurant = new Restaurant();

            var dbr = db.Restaurants.Find(id);


            restaurant.ID = dbr.ID;
            restaurant.Name = dbr.Name;
            restaurant.Location = dbr.Location;
            restaurant.Email = dbr.Email;
            restaurant.Password = dbr.Password;

            return restaurant;


        }


        //________________________________Add Restaurant_________________________________________

        public  void AddRestaurant(Restaurant dbr)
        {
            //var db = new ZeroHungerDBContext();
            var restaurant = new Restaurant();



            restaurant.ID = dbr.ID;
            restaurant.Name = dbr.Name;
            restaurant.Location = dbr.Location;
            restaurant.Email = dbr.Email;
            restaurant.Password = dbr.Password;

            db.Restaurants.Add(restaurant);
            db.SaveChanges();
        }


        //_______________________________Delete Restautant_______________________________________

        public  void DeleteRestaurant(int id)
        {
            //var db = new ZeroHungerDBContext();
            //var dbr = new Restaurant();
            
            //var restaurant = new RestaurantModel();

            var dbr = db.Restaurants.Find(id);

            db.Restaurants.Remove(dbr);
            db.SaveChanges();
        }

        //_______________________________Update Restaurant_________________________________________

        public  void UpdateRestaurant(int id, Restaurant restaurant)
        {
            //var db = new ZeroHungerDBContext();

            var dbr = db.Restaurants.Find(id);


            dbr.ID = restaurant.ID;
            dbr.Name = restaurant.Name;
            dbr.Location = restaurant.Location;
            dbr.Email = restaurant.Email;
            dbr.Password = restaurant.Password;

            db.SaveChanges();


        }
    }
}
