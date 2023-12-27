using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elfie.Serialization;
using Hotel.Domain.Entities;
using Hotel.Domain.Entities.Account;
using Hotel.Domain.Entities.Product;
using Hotel.Domain.Entities.Web;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hotel.Infrastructuer.DbContext
{
    public class HotelDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-K81JHQ4;Initial Catalog=HotelDbContextCore;Integrated Security=True;multipleActiveResultSets=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<AdvantageToRoom>().HasKey(ar => new { ar.RoomId, ar.AdvantageId });
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<FirstBaner> FirstBaners { get; set; }
        public DbSet<User> Users { get; set; }

        #region product

        public DbSet<AdvantageRoom> AdvantageRooms { get; set; }
        public DbSet<AdvantageToRoom> AdvantageToRooms { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<HotelRule> HotelRules { get; set; }
        public DbSet<HotelAddress> HotelAddresses { get; set; }
        public DbSet<HotelGallery> HotelGalleries { get; set; }
        public DbSet<Domain.Entities.Product.Hotel> Hotels { get; set; }
        public DbSet<ReserveRoom> ReserveRooms { get; set; }

    #endregion
  }

}
