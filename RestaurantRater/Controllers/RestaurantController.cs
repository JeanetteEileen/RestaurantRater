using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantRater.Controllers
{
    public class RestaurantController : Controller
    {
        private RestaurantDbContext _db = new RestaurantDbContext();

        // GET: Restaurant/Index Method
        public ActionResult Index()
        {
            return View(_db.Restaurants.ToList());
            
        }
        // GET: Restaurant/Create Method
        public ActionResult Create()
        {
            return View();
        }
        // POST: Restaurant/Create
        [HttpPost] // Only a post method
        [ValidateAntiForgeryToken] // verfies this is coming from right source
        public ActionResult Create (Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _db.Restaurants.Add(restaurant);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            //When it isnt valid it goes back to the view with info you added so you can correct it
            return View(restaurant); 
        }
    }
}