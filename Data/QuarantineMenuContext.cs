using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuarantineMenu.Models;

namespace QuarantineMenu.Data
{
    public class QuarantineMenuContext : DbContext
    {
        public QuarantineMenuContext (DbContextOptions<QuarantineMenuContext> options)
            : base(options)
        {
        }
        public DbSet<QuarantineMenu.Models.Food> Food { get; set; }
        public DbSet<QuarantineMenu.Models.FoodKind> FoodKind { get; set; }
        public DbSet<QuarantineMenu.Models.MealKind> MealKind { get; set; }
        public DbSet<QuarantineMenu.Models.Menu> Menu { get; set; }
        public DbSet<QuarantineMenu.Models.Pantry> Pantry { get; set; }

    }
}
