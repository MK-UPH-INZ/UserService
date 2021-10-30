using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Data
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext context;

        public UserRepo(AppDbContext context)
        {
            this.context = context;
        }

        public void CreateUser(User user)
        {
            if( user == null )
            {
                throw new ArgumentNullException();
            }
            context.Users.Add(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return context.Users.Where(u => u.Id == id).FirstOrDefault();
        }

        public void RemoveUser(User user)
        {
            context.Remove(user);
        }

        public bool SaveChanges()
        {
            return (context.SaveChanges() >= 0);
        }
    }
}
