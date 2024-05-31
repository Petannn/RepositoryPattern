using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Abstraction;
using RepositoryPattern.Models;
using System.ComponentModel.DataAnnotations;

namespace RepositoryPattern
{
    public class CustomDbContext : DbContext
    {

        //Add your table here
        public DbSet<DummyModel> VoxelTable { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var pathToFile = "....\\databaseFile.db";
            var connectionString = "Data Source = " + pathToFile;
            optionsBuilder.UseSqlite(connectionString);
        }
    }
}
