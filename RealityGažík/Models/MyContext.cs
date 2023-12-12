using Microsoft.EntityFrameworkCore;
using RealityGažík.Models.Database;

namespace RealityGažík.Models
{
    public class MyContext : DbContext
    {

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Inquiry> Inquiries { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Value> Values { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=mysqlstudenti.litv.sssvt.cz;database=4b1_gazikmarcel_db2;user=gazikmarcel;password=123456;SslMode=none");
            optionsBuilder.UseLazyLoadingProxies(); //samo naloaduje foreign keys, věci co potom chceme použít musí ale být visual
        }

    }
}
