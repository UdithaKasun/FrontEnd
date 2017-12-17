using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SPDC.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Cors;

namespace SPDC.Controllers
{

    [EnableCors("AllowAllHeaders")]
    [Route("api/food")]
    public class FoodController : Controller
    {
        private const string API_PAYMENT_BASE = "http://localhost:59731/api/payment";
        private const string API_PAYMENT_RESOURCE = "";
        private const string API_SMS_BASE = "http://localhost:59731/api/sms";
        private const string API_SMS_RESOURCE = "";

        private readonly DBContext _context;

        public FoodController(DBContext context)
        {
            _context = context;
            foreach (var food in _context.Foods)
            {
                _context.Foods.Remove(food);
            }
            this._context.Foods.Add(new Food { foodName = "Ice Cream" , foodPrice = 45.50f ,  foodImageUrl = "../assets/images/28.4v.jpg", foodSelected = false});
            this._context.Foods.Add(new Food { foodName = "Vegetable Won Ton", foodPrice = 50.50f , foodImageUrl = "../assets/images/web_15_1.jpg", foodSelected = false });
            this._context.Foods.Add(new Food { foodName = "Ice Cream", foodPrice = 45.50f, foodImageUrl = "../assets/images/28.4v.jpg", foodSelected = false });
            this._context.Foods.Add(new Food { foodName = "Vegetable Won Ton", foodPrice = 50.50f, foodImageUrl = "../assets/images/web_15_1.jpg", foodSelected = false });
            this._context.SaveChanges();
        }

        [HttpGet]
        public IEnumerable<Food> GetFoodItems()
        {
            return this._context.Foods.ToList();
        }

        [HttpPost]
        public IActionResult createFoodOrder([FromBody]FoodOrder foodOrder)
        {
            float totalPrice = 0;
            foreach (Food item in foodOrder.Foods)
            {
                totalPrice += item.foodPrice;
            }

            if(foodOrder.PaymentType == "CREDIT_CARD")
            {
                var payment = new Payment { Amount = totalPrice, CardNumber = foodOrder.CardNumber, CardHolderName = foodOrder.CardHolderName, CVCNumber = foodOrder.CVCNumber };

                try
                {
                    Utilities.PostCall_RestAPI(API_PAYMENT_BASE, API_PAYMENT_RESOURCE, payment);
                    Console.WriteLine("REST SUCCESS");
                }
                catch (Exception)
                {
                    return StatusCode(500);
                }

                var message = new Message { Reciever = foodOrder.UserId, SMSMessage = "Your Order Has Been Placed " };

                try
                {
                    Utilities.PostCall_RestAPI(API_SMS_BASE, API_SMS_RESOURCE, message);
                    Console.WriteLine("REST SUCCESS");
                }
                catch (Exception)
                {
                    return StatusCode(500);
                }
                var order = new OrderDetails { date = foodOrder.Date, TotalPrice = totalPrice, userId = foodOrder.UserId };
                this._context.Orders.Add(order);
                this._context.SaveChanges();
                return Ok();
            }
            else
            {
                var order = new OrderDetails { date = foodOrder.Date, TotalPrice = totalPrice, userId = foodOrder.UserId };
                this._context.Orders.Add(order);
                this._context.SaveChanges();
                return Ok();
            }

            
           
        }


    }
}