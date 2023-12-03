using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Domain.Entities.Web;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Infrastructuer.DbContext
{
    public class HotelDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) 
            : base(options)
        {

        }

        public DbSet<FirstBaner> FirstBaners { get; set; }
        public DbSet<Ali> Ali { get; set; }
    }
}
