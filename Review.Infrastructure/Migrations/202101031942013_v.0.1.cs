namespace Review.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        OrganizationName = c.String(),
                        Address = c.String(),
                        LikeMessage = c.String(),
                        DislikeMessage = c.String(),
                        Comment = c.String(),
                        Rate = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Reviews");
        }
    }
}
