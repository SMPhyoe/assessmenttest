using assessmenttest.Context;
using assessmenttest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assessmenttest.Models
{
    public class DataGenerator
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApiContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApiContext>>()))
            {
                // Look for any board games already in database.
                if (context.Booking.Any())
                {
                    return;   // Database has been seeded
                }

                context.Booking.AddRange(
                    new Booking
                    {
                        datetime = DateTime.Now,
                        venue = "Hall 1",
                        numtickets = 1,
                        amount = 30
                    },                    
                    new Booking
                    {
                        datetime = DateTime.Now,
                        venue = "Hall 2",
                        numtickets = 4,
                        amount = 120
                    },
                    new Booking
                    {
                        datetime = DateTime.Now,
                        venue = "Hall 2",
                        numtickets = 5,
                        amount = 100
                    },
                    new Booking
                    {
                        datetime = DateTime.Now,
                        venue = "Hall 3",
                        numtickets = 2,
                        amount = 40
                    }
                    );

                context.SaveChanges();
            }
        }
    }
}
