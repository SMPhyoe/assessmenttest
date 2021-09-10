using assessmenttest.Context;
using assessmenttest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace assessmenttest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : Controller
    {
        private readonly ApiContext apiContext;
        public BookingController(ApiContext apiContext)
        {
            this.apiContext = apiContext;
        }

        [HttpGet("ViewAllBooking")]
        public async Task<IActionResult> Get()
        {
            List<Booking> bookings = apiContext.GetBookings();
            return Ok(bookings);
        }
        

        [HttpGet("ViewBooking/{id}", Name = "ViewBooking")]
        public IActionResult GetById(int id)
        {
            Booking booking = apiContext.Booking.Find(id);
            return Ok(booking);
        }

        [HttpPost("AddBooking")]
        public IActionResult Post( Booking booking)
        {
            apiContext.Booking.Add(booking);
            apiContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost("DeleteBooking")]
        public IActionResult Delete(int id)
        {
            apiContext.Booking.Remove(apiContext.Booking.Find(id));
            apiContext.SaveChanges();

            return RedirectToAction("Index");
        }

       

        [HttpPost("EditBooking")] 
        public IActionResult Edit(Booking booking)
        {
            apiContext.Booking.Update(booking);
            apiContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet("XCurrency/{cur}", Name = "XCurrency")]
        public async Task<IActionResult> currencyex(string cur)
        {
            currency curr = new currency();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@1/latest/currencies/"+ cur + "/sgd.json "))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    curr = JsonConvert.DeserializeObject<currency>(apiResponse);
                }
            }
            return View(curr);
        }


    }
}
