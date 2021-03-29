using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyEShop.Entities;

namespace MyEShop.PersistenceEF.Products
{
    public class ProductEntityMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> _)
        {
            _.ToTable("Products");

            _.HasKey(_ => _.Id);

            _.Property(_ => _.Id).IsRequired().ValueGeneratedOnAdd();

            _.Property(_ => _.Title).IsRequired().HasMaxLength(350);

            _.Property(_ => _.ShortDescription).IsRequired().HasMaxLength(500);

            _.Property(_ => _.Text).IsRequired();

            _.Property(_ => _.ImageName).IsRequired();

            _.Property(_ => _.Price).IsRequired();

            _.Property(_ => _.CreateData).IsRequired().HasDefaultValue(DateTime.Now);

        }
    }
}
