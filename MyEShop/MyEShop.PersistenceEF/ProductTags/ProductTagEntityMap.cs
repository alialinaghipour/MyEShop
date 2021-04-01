using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyEShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyEShop.PersistenceEF.ProductTags
{
    class ProductTagEntityMap : IEntityTypeConfiguration<ProductTag>
    {
        public void Configure(EntityTypeBuilder<ProductTag> _)
        {
            _.ToTable("ProductTags");

            _.HasKey(_ => _.Id);

            _.Property(_ => _.Id).IsRequired().ValueGeneratedOnAdd();

            _.Property(_ => _.ProductId).IsRequired();

            _.Property(_ => _.Title).IsRequired().HasMaxLength(50);

            _.HasOne(_ => _.Product)
                .WithMany(_ => _.ProductTags)
                .HasForeignKey(_ => _.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
