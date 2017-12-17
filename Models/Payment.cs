using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPDC.Models
{
    public class Payment
    {
        public float Amount { get; set; }
        public string CardNumber { get; set; }
        public string CVCNumber { get; set; }
        public string CardHolderName { get; set; }
    }
}
