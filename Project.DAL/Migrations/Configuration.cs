namespace Project.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Project.DAL.Concrete.Context>
    {
        public Configuration()
        {
            //auto mig. true for while develop
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Project.DAL.Concrete.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
