using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elfie.Serialization;
using Hotel.Domain.Entities;
using Hotel.Domain.Entities.Web;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hotel.Infrastructuer.DbContext
{
    public class HotelDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-K81JHQ4;Initial Catalog=HotelDbContext;Integrated Security=True;multipleActiveResultSets=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<FirstBaner> FirstBaners { get; set; }
        public DbSet<Ali> Ali { get; set; }
    }
}
