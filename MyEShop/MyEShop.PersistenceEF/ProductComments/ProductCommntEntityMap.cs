using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyEShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyEShop.PersistenceEF.ProductComments
{
    public class ProductCommntEntityMap : IEntityTypeConfiguration<ProductComment>
    {
        public void Configure(EntityTypeBuilder<ProductComment> _)
        {
            _.ToTable("ProductComments");

            _.HasKey(_ => _.Id);

            _.Property(_ => _.Id).IsRequired().ValueGeneratedOnAdd();

            _.Property(_ => _.Name).IsRequired().HasMaxLength(50);

            _.Property(_ => _.Email).IsRequired().HasMaxLength(250);

            _.Property(_ => _.Comment).IsRequired().HasMaxLength(800);

            _.Property(_ => _.CreateDate).IsRequired().HasDefaultValue(DateTime.Now);

            _.Property(_ => _.ParentId).IsRequired(false);

            _.Property(_ => _.ProductId).IsRequired();

            _.HasOne(_ => _.ProductComment1)
                .WithMany(_ => _.ProductComments)
                .HasForeignKey(_ => _.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            _.HasOne(_ => _.Product)
                .WithMany(_ => _.ProductComments)
                .HasForeignKey(_ => _.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
