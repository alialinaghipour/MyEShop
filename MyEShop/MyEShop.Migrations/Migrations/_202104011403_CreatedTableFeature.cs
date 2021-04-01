using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyEShop.Migrations.Migrations
{
    [Migration(202104011403)]
    public class _202104011403_CreatedTableFeature : Migration
    {
        public override void Up()
        {
            Create.Table("Features")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Title").AsString().NotNullable();

            Create.Table("ProductFeatures")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Value").AsString().NotNullable()
                .WithColumn("FeatureId").AsInt32().NotNullable()
                    .ForeignKey("FK_ProductFeatures_Features", "Features", "Id")
                        .OnDelete(System.Data.Rule.None)
                .WithColumn("ProductId").AsInt32().NotNullable()
                    .ForeignKey("FK_ProductFeatures_Products", "Products", "Id")
                        .OnDelete(System.Data.Rule.Cascade);
        }
        
        public override void Down()
        {
            Delete.Table("ProductFeatures");
            Delete.Table("Features");
        }

    }
}
