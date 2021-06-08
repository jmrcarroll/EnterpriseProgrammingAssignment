using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EnterpriseProgrammingAssignment.Models;

namespace EnterpriseProgrammingAssignment.Data
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> Options) : base(Options) { }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Site> Sites { get; set; }

    }
}
