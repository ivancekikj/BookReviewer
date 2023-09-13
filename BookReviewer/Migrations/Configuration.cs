namespace BookReviewer.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<BookReviewer.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookReviewer.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Roles.AddOrUpdate(
                r => r.Name,
                new IdentityRole
                {
                    Name = "Administrator"
                },
                new IdentityRole
                {
                    Name = "NormalUser"
                }
            );
            context.SaveChanges();
        }
    }
}
