using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPDC.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public string userId { get; set; }
        public string date { get; set; }
        public float TotalPrice { get; set; }
    }
}
