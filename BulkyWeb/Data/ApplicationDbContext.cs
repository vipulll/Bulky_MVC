using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        //This is to add data to DB.  After this use Data migration and update.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category {Id =1, Name="Kingkong", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Kingkong1", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Kingkong1", DisplayOrder = 3 }
                );
        }
        //This will create table.
        public DbSet<Category> Categorys { get; set; }

    }
}
