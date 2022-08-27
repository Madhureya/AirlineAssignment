using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AirlineAssignment.Models;

namespace AirlineAssignment.Data
{
    public class ApplicationDbContext : IdentityDbContext
    { public DbSet <Approval> Approvals { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    

    }
}