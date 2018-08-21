namespace _31CodeFirst.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSubjecttable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            Sql("insert Subjects(Name) values('matematika')");
            Sql("insert Subjects(Name) values('informatika')");

        }
        
        public override void Down()
        {
            DropTable("dbo.Subjects");
        }
    }
}
