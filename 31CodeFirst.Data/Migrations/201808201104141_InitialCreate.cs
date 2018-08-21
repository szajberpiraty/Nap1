namespace _31CodeFirst.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        ClassCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            Sql("insert Teachers(FirstName,Lastname,ClassCode) values('Zubornyák','Zénó','1/9/1')");
            Sql("insert Teachers(FirstName,Lastname,ClassCode) values('Zubor','Ubul','1/9/2')");
        }
        
        public override void Down()
        {
            DropTable("dbo.Teachers");
        }
    }
}
