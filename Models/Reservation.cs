using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPDC.Models
{
    public class Reservation
    {
        public int ID { get; set; }
        public string ReservedTables { get; set; }
        public string ReservedDate { get; set; }
        public string ReservedUserId { get; set; }
        public string PaymentType { get; set; }
        public string CardNumber { get; set; }
        public string CVCNumber { get; set; }
        public string CardHolderName { get; set; }
    }
}
