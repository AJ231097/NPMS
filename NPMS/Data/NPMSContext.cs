using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NPMS.Models;

namespace NPMS.Models
{
    //public class NPMSContext : DbContext
    //{

    //    public NPMSContext(DbContextOptions<NPMSContext> options)
    //        : base(options)
    //    {
    //    }

    //    public DbSet<Passes> Passes { get; set; }
    //}

    public class NPMSContext : IdentityDbContext
    {
        //public NPMSContext(DbContextOptions<NPMSContext> options)
        //: base(options)
        //{ }

        public NPMSContext(DbContextOptions<NPMSContext> options)
                : base(options)
        {
        }
        public DbSet<Passes> Passes { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<Parks> Parks { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }      

        public DbSet<Careers> Careers { get; set; }

        public DbSet<Reservations> Reservations { get; set; }



    }
}
