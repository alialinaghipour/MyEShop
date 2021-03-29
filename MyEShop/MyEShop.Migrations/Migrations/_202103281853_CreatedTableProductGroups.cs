using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyEShop.Migrations.Migrations
{
    [Migration(202103281853)]
    public class _202103281853_CreatedTableProductGroups : Migration
    {
        public override void Up()
        {
            Create.Table("ProductGroups")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Title").AsString(150).NotNullable()
                .WithColumn("ParentId").AsInt32().Nullable()
                    .ForeignKey("FK_ProductGroups_ProductGroups", "ProductGroups", "Id")
                    .OnDelete(System.Data.Rule.None);
        }

        public override void Down()
        {
            Delete.Table("ProductGroups");
        }

    }
}
