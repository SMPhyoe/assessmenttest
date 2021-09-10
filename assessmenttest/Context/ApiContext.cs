using assessmenttest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assessmenttest.Context
{
   public class ApiContext : DbContext
    {
        public DbSet<Booking> Booking { get; set; }

        public ApiContext(DbContextOptions options) : base(options)
        {
           
            LoadBookings();
        }


        public void LoadBookings()
        {
            Booking booking = new Booking() {id=1, datetime = DateTime.Now, venue = "Hall 1", numtickets = 1, amount = 30 ,currency ="SGD"};
            Booking.Add(booking);
            booking = new Booking() {id=2, datetime = DateTime.Now, venue = "Hall 2", numtickets = 4, amount = 120, currency = "SGD" };
            Booking.Add(booking);
        }

        public List<Booking> GetBookings()
        {
            return Booking.Local.ToList<Booking>();
        }
    }
}
