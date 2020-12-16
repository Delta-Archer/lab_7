using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab_6.Models
{
    public class MobileContext : DbContext
    {
        public DbSet<Mobiles> Mobiles { get; set; }
        public DbSet<Purchases> Purchases { get; set; }
        public DbSet<Companies> Companies { get; set; }
    }
}