using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace CIS174_TestCoreApp.Models
{
    public class Assgn10SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Assgn10Context(
                serviceProvider.GetRequiredService<DbContextOptions<Assgn10Context>>()))
            {
                // Look for any movies.
                if (context.People.Any())
                {
                    return;   // DB has been seeded
                }

                context.People.AddRange(
                     new Entity.Assgn10Person
                     {
                         FirstName = "George",
                         LastName = "Tree",
                         BirthDate = DateTime.Parse("1989-1-11"),
                         City = "Ames",
                         State = "Iowa",
                         SetOfAccomplishments ="Planting Award",

                     },

                     new Entity.Assgn10Person
                     {
                         FirstName = "Paul",
                         LastName = "Steel",
                         BirthDate = DateTime.Parse("1995-4-02"),
                         City = "Adel",
                         State = "Iowa",
                         SetOfAccomplishments = "Welding Award",
                     } 
                );
                context.SaveChanges();
            }
        }
    }
}
