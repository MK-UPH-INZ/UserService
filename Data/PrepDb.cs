using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Data
{
    public class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Restaurants.Any())
            {
                Console.WriteLine("Seeding Restaurant Data");

                context.Restaurants.AddRange(
                    new Restaurant()
                    {
                        Name = "Greenanic Smoothies",
                        ExternalId = 1
                    },
                    new Restaurant()
                    {
                        Name = "Bangalore Spices",
                        ExternalId = 2
                    },
                    new Restaurant()
                    {
                        Name = "Veganic Corner",
                        ExternalId = 3
                    }
                );

                context.Users.AddRange(
                    new User
                    {
                        Username = "admin",
                        Name = "Jan Kowalski",
                        Password = "Secret123#",
                        Email = "jan@kowalski.com",
                        Confirmed = true,
                        ConfirmationKey = null
                    },
                    new User
                    {
                        Username = "user1",
                        Name = "Adam Nowak",
                        Password = "Secret123#",
                        Email = "adam@nowak.com",
                        Confirmed = true,
                        ConfirmationKey = null
                    }
                );

                context.UserRoles.AddRange(
                    new UserRole
                    {
                        UserId = 1,
                        RestaurantId = 1,
                        Role = Role.ADMIN
                    },
                    new UserRole
                    {
                        UserId = 1,
                        RestaurantId = 3,
                        Role = Role.MODERATOR
                    },
                    new UserRole
                    {
                        UserId = 2,
                        RestaurantId = 2,
                        Role = Role.ADMIN
                    },
                    new UserRole
                    {
                        UserId = 2,
                        RestaurantId = 3,
                        Role = Role.ADMIN
                    }
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Restaurant Data is present");
            }
        }
    }
}
