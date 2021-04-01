using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyEShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyEShop.PersistenceEF.Features
{
    class FeatureEntityMap : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> _)
        {
            _.ToTable("Features");

            _.HasKey(_ => _.Id);

            _.Property(_ => _.Id).IsRequired().ValueGeneratedOnAdd();

            _.Property(_ => _.Title).IsRequired();
        }
    }
}
