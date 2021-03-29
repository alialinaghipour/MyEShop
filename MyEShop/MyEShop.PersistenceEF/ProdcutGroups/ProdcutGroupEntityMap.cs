using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyEShop.Entities;

namespace MyEShop.PersistenceEF.ProdcutGroups
{
    class ProdcutGroupEntityMap : IEntityTypeConfiguration<ProductGroup>
    {
        public void Configure(EntityTypeBuilder<ProductGroup> _)
        {
            _.ToTable("ProductGroups");

            _.HasKey(_ => _.Id);

            _.Property(_ => _.Id).IsRequired().ValueGeneratedOnAdd();

            _.Property(_ => _.Title).IsRequired().HasMaxLength(150);

            _.Property(_ => _.ParentId).IsRequired(false);

            _.HasOne(_ => _.ProductGroup1)
                .WithMany(_ => _.ProductGroups)
                .HasForeignKey(_ => _.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
