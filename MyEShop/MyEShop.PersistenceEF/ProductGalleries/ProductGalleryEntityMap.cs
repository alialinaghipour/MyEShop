using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyEShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyEShop.PersistenceEF.ProductGalleries
{
    class ProductGalleryEntityMap : IEntityTypeConfiguration<ProductGallery>
    {
        public void Configure(EntityTypeBuilder<ProductGallery> _)
        {
            _.ToTable("ProductGalleries");

            _.HasKey(_ => _.Id);

            _.Property(_ => _.Id).IsRequired().ValueGeneratedOnAdd();

            _.Property(_ => _.ImageName).IsRequired();

            _.Property(_ => _.Title).IsRequired().HasMaxLength(100);

            _.Property(_ => _.ProductId).IsRequired();

            _.HasOne(_ => _.Product)
                .WithMany(_ => _.ProductGalleries)
                .HasForeignKey(_ => _.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
