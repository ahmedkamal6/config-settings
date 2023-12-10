using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using config_server.Models;
using Microsoft.EntityFrameworkCore;

namespace config_server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options):base(options)
        {
            
        }
        public DbSet<Config> Config => Set<Config>();
    }
}