using AMPOL.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMPOL.Infrastructure.Persistence.Configurations
{
    public class PointsPromotionConfiguration: IEntityTypeConfiguration<PointsPromotion>
    {
        public void Configure(EntityTypeBuilder<PointsPromotion> builder)
        {
            builder.Property(t => t.PointsPromotionId)
                   .HasMaxLength(10)
                   .HasColumnType("char");

            builder.Property(t => t.PointsPerDollar)
                .IsRequired()
                .HasDefaultValue(0.0)
                .HasColumnType("Decimal(18,2)");
        }
    }
}
