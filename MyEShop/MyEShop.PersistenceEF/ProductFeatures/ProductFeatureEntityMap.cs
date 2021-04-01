using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyEShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyEShop.PersistenceEF.ProductFeatures
{
    class ProductFeatureEntityMap : IEntityTypeConfiguration<ProductFeature>
    {
        public void Configure(EntityTypeBuilder<ProductFeature> _)
        {
            _.ToTable("ProductFeatures");

            _.HasKey(_ => _.Id);

            _.Property(_ => _.Id).IsRequired().ValueGeneratedOnAdd();

            _.Property(_ => _.Value).IsRequired();

            _.Property(_ => _.FeatureId).IsRequired();

            _.Property(_ => _.ProductId).IsRequired();

            _.HasOne(_ => _.Feature)
                .WithMany(_ => _.ProductFeatures)
                .HasForeignKey(_ => _.FeatureId)
                .OnDelete(DeleteBehavior.Restrict);

            _.HasOne(_ => _.Product)
                .WithMany(_ => _.ProductFeatures)
                .HasForeignKey(_ => _.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
