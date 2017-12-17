using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPDC.Models
{
    public class FoodOrder
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Date { get; set; }
        public string Address { get; set; }
        public List<Food> Foods { get; set; }
        public string PaymentType { get; set; }
        public string CardNumber { get; set; }
        public string CVCNumber { get; set; }
        public string CardHolderName { get; set; }

    }
}
