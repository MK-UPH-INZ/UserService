using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Data
{
    interface IUserRoleRepo
    {
        bool SaveChanges();
        IEnumerable<UserRole> GetAllUserRoles();
        UserRole GerUserRoleById(int id);
        void CreateUserRole(UserRole userRole);
        void RemoveUserRole(UserRole userRole);

        IEnumerable<UserRole> GetUserRolesByUserId(int userId);
        IEnumerable<UserRole> GetUserRolesByRestaurantId(int restaurantId);
    }
}
