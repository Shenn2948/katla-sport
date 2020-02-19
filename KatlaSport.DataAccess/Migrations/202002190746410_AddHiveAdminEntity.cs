namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddHiveAdminEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.product_store_hive_admins",
                c => new
                {
                    product_store_hive_admin_id = c.Int(nullable: false, identity: true),
                    product_store_hive_admin_name = c.String(nullable: false, maxLength: 60),
                })
                .PrimaryKey(t => t.product_store_hive_admin_id);

            AddColumn("dbo.product_hives", "product_hive_hiveAdmin_id", c => c.Int());
            CreateIndex("dbo.product_hives", "product_hive_hiveAdmin_id");
            AddForeignKey("dbo.product_hives", "product_hive_hiveAdmin_id", "dbo.product_store_hive_admins", "product_store_hive_admin_id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.product_hives", "product_hive_hiveAdmin_id", "dbo.product_store_hive_admins");
            DropIndex("dbo.product_hives", new[] { "product_hive_hiveAdmin_id" });
            DropColumn("dbo.product_hives", "product_hive_hiveAdmin_id");
            DropTable("dbo.product_store_hive_admins");
        }
    }
}
