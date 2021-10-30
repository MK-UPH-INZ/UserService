using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Data
{
    interface IRestaurantRepo
    {
        bool SaveChanges();
        IEnumerable<Restaurant> GetAllRestaurants();
        Restaurant GetRestaurantById(int id);
        void CreateRestaurant(Restaurant restaurant);
        void RemoveRestaurant(Restaurant restaurant);
        bool ExternalRestaurantExists(int restaurantId);
    }
}
