using APIDAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace APIDAL.Data.Context
{
    public class DataBaseContext:DbContext 
    {
        public DataBaseContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Developer>  Developers => Set<Developer>();
    }
}
