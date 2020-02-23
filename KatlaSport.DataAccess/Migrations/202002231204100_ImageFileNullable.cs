namespace KatlaSport.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class ImageFileNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.product_store_hive_admins", "ImageFileId", c => c.Int());
        }

        public override void Down()
        {
            AlterColumn("dbo.product_store_hive_admins", "ImageFileId", c => c.Int(nullable: false));
        }
    }
}