namespace _31CodeFirst.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_31CodeFirst.Data.models.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "_31CodeFirst.Data.models.SchoolContext";
        }

        protected override void Seed(_31CodeFirst.Data.models.SchoolContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //Az adatok mentéséhez mindenféleképpen kell:
            //context.SaveChanges();
        }

    }
}
