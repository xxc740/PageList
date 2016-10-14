namespace PagingAndSorting.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PagingAndSorting.DBHelper.StudentDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //不允许数据丢失
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(PagingAndSorting.DBHelper.StudentDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
