using System.Data.Entity.Migrations;

namespace Lab2Paper1.Migrations;

internal sealed class Configuration : DbMigrationsConfiguration<Session1Entities>
{
    public Configuration()
    {
        AutomaticMigrationsEnabled = false;
    }
}