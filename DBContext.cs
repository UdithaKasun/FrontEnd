using Microsoft.EntityFrameworkCore;
using SPDC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPDC
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<OrderDetails> Orders { get; set; }
        public DbSet<Customer> Users { get; set; }
    }
}
