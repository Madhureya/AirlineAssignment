using Airline.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Airline.API
{
   

        public class AirlineDbContext : DbContext
        {
            public DbSet<ManageAirline> ManageAirlines { get; set; }

            public AirlineDbContext() { }
            public AirlineDbContext(DbContextOptions options)
            : base(options)
            {

            }


            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Data Source=HP-NOTEBOOK;Initial Catalog=AirlineManagement;Integrated Security=True");
            }

        }
    }

