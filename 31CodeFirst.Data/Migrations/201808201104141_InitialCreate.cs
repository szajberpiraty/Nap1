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

            //Ha garantálni akarom az Id-ket
            Sql("set identity_insert Teachers on");
            Sql("insert Teachers(Id,FirstName,Lastname,ClassCode) values(1,'Zubornyák','Zénó','1/9/1')");
            Sql("insert Teachers(Id,FirstName,Lastname,ClassCode) values(2,'Zubor','Ubul','1/9/2')");
            Sql("set identity_insert Teachers off");
        }
        
        public override void Down()
        {
            DropTable("dbo.Teachers");
        }
    }
}
