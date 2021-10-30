using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Data
{
    public class RestaurantRepo : IRestaurantRepo
    {
        private readonly AppDbContext context;

        public RestaurantRepo(AppDbContext context)
        {
            this.context = context;
        }
        public void CreateRestaurant(Restaurant restaurant)
        {
            if( restaurant == null )
            {
                throw new ArgumentNullException();
            }

            context.Restaurants.Add(restaurant);
        }

        public bool ExternalRestaurantExists(int restaurantId)
        {
            return context.Restaurants.Where(r => r.ExternalId == restaurantId).Any();
        }

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            return context.Restaurants.ToList();
        }

        public Restaurant GetRestaurantById(int id)
        {
            return context.Restaurants.Where(r => r.Id == id).FirstOrDefault();
        }

        public void RemoveRestaurant(Restaurant restaurant)
        {
            context.Restaurants.Remove(restaurant);
        }

        public bool SaveChanges()
        {
            return (context.SaveChanges() >= 0);
        }
    }
}
