namespace _31CodeFirst.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudenttableandconnectiontoteacher : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        teacher_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.teacher_Id)
                .Index(t => t.teacher_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "teacher_Id", "dbo.Teachers");
            DropIndex("dbo.Students", new[] { "teacher_Id" });
            DropTable("dbo.Students");
        }
    }
}
