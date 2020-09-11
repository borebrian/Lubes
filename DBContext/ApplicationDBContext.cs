//using Covid19Tracing.Models;
using Lubes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lubes.DBContext
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Item_category> Items_category { get; set; }


        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
           : base(options)
        {

        }


        public DbSet<Lubes.Models.Add_item> Add_item { get; set; }


        public DbSet<Lubes.Models.Submited_stock> Submited_stock { get; set; }


        public DbSet<Lubes.Models.Stock_summary> Stock_summary { get; set; }
        public DbSet<Lubes.Models.c_Users> c_Users { get; set; }
        public DbSet<Lubes.Models.Roles> Roles { get; set; }










    }
}
