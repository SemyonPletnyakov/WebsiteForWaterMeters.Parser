using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser_09_2022
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Check> Checks { get; set; }

        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ParserDB1;Trusted_Connection=True;");
        }
    }
}
