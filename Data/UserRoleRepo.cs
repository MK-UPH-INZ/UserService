using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Data
{
    public class UserRoleRepo : IUserRoleRepo
    {
        private readonly AppDbContext context;

        public UserRoleRepo(AppDbContext context)
        {
            this.context = context;
        }

        public void CreateUserRole(UserRole userRole)
        {
            if( userRole == null )
            {
                throw new ArgumentNullException();
            }

            context.UserRoles.Add(userRole);
        }

        public UserRole GerUserRoleById(int id)
        {
            return context.UserRoles
                .Where(ur => ur.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<UserRole> GetAllUserRoles()
        {
            return context.UserRoles.ToList();
        }

        public IEnumerable<UserRole> GetUserRolesByRestaurantId(int restaurantId)
        {
            return context.UserRoles.Where(ur => ur.RestaurantId == restaurantId).ToList();
        }

        public IEnumerable<UserRole> GetUserRolesByUserId(int userId)
        {
            return context.UserRoles.Where(ur => ur.UserId == userId).ToList();
        }

        public void RemoveUserRole(UserRole userRole)
        {
            context.UserRoles.Remove(userRole);
        }

        public bool SaveChanges()
        {
            return (context.SaveChanges() >= 0);
        }
    }
}
