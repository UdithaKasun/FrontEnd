using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SPDC.Models;
using Microsoft.AspNetCore.Cors;

namespace SPDC.Controllers
{
    [EnableCors("AllowAllHeaders")]
    [Route("api/reservation")]
    public class ReservationController : Controller
    {
        private readonly DBContext _context;
        private const string API_SMS_BASE = "http://localhost:59731/api/sms";
        private const string API_SMS_RESOURCE = "";

        public ReservationController(DBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult saveReservation([FromBody]Reservation reservation)
        {
            this._context.Reservations.Add(reservation);

            var message = new Message { Reciever = reservation.ReservedUserId, SMSMessage = "Your Reservation Has Been Placed " };

            try
            {
                Utilities.PostCall_RestAPI(API_SMS_BASE, API_SMS_RESOURCE, message);
                Console.WriteLine("REST SUCCESS");
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }

            this._context.SaveChanges();

            return Ok();
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Reservation> GetReservations()
        {
            return this._context.Reservations.ToList();
        }
    }
}