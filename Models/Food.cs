using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPDC.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string foodName { get; set; }
        public float foodPrice { get; set; }
        public string foodImageUrl { get; set; }
        public bool foodSelected { get; set; }
    }
}
