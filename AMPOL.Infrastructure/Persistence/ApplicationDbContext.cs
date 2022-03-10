using AMPOL.Application.Common.Interfaces;
using AMPOL.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AMPOL.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Product> Products { get; set; }        
        public DbSet<PointsPromotion> PointsPromotions { get; set; }
        public DbSet<DiscountPromotion> DiscountPromotions { get; set; }

        public ApplicationDbContext(DbContextOptions options)
         : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Seed();
            base.OnModelCreating(builder);
        }
    }
}
