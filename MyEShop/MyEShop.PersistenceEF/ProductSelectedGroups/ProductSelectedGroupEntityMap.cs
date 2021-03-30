using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyEShop.Entities;

namespace MyEShop.PersistenceEF.ProductSelectedGroups
{
    class ProductSelectedGroupEntityMap : IEntityTypeConfiguration<ProductSelectedGroup>
    {
        public void Configure(EntityTypeBuilder<ProductSelectedGroup> _)
        {
            _.ToTable("ProductSelectedGroups");

            _.HasKey(_ => _.Id);

            _.Property(_ => _.Id).IsRequired().ValueGeneratedOnAdd();

            _.Property(_ => _.ProductId).IsRequired();

            _.Property(_ => _.ProductGroupId).IsRequired();

            _.HasOne(_ => _.Product)
                .WithMany(_ => _.ProductSelectedGroups)
                .HasForeignKey(_ => _.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            _.HasOne(_ => _.ProductGroup)
               .WithMany(_ => _.ProductSelectedGroups)
               .HasForeignKey(_ => _.ProductGroupId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
