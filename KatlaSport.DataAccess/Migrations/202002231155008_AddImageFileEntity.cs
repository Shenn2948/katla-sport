namespace KatlaSport.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddImageFileEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable("dbo.product_store_hive_admin_image_files",
                    c => new
                    {
                        product_store_hive_admin_image_file_id = c.Int(nullable: false, identity: true),
                        product_store_hive_admin_image_file_name = c.String(nullable: false, maxLength: 60),
                        product_store_hive_admin_image_file_content = c.Binary(),
                        HiveAdminId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.product_store_hive_admin_image_file_id)
                .ForeignKey("dbo.product_store_hive_admins", t => t.product_store_hive_admin_image_file_id)
                .Index(t => t.product_store_hive_admin_image_file_id);

            AddColumn("dbo.product_store_hive_admins", "ImageFileId", c => c.Int(nullable: false));
        }

        public override void Down()
        {
            DropForeignKey("dbo.product_store_hive_admin_image_files", "product_store_hive_admin_image_file_id", "dbo.product_store_hive_admins");
            DropIndex("dbo.product_store_hive_admin_image_files", new[] {"product_store_hive_admin_image_file_id"});
            DropColumn("dbo.product_store_hive_admins", "ImageFileId");
            DropTable("dbo.product_store_hive_admin_image_files");
        }
    }
}