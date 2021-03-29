using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyEShop.Migrations.Migrations
{
    [Migration(202103291202)]
    public class _202103291202_CreatedTableproduct : Migration
    {

        public override void Up()
        {
            Create.Table("Products")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Title").AsString(350).NotNullable()
                .WithColumn("ShortDescription").AsString(500).NotNullable()
                .WithColumn("Text").AsCustom("NVARCHAR(MAX)").NotNullable()
                .WithColumn("ImageName").AsString(50).NotNullable()
                .WithColumn("Price").AsInt32().NotNullable()
                .WithColumn("CreateData").AsDateTime().NotNullable().WithDefaultValue(DateTime.Now);
        }
        public override void Down()
        {
            Delete.Table("Products");
        }
    }
}
