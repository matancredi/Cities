using Microsoft.EntityFrameworkCore;
using ReactApp1.Server.Domain.Models;

namespace ReactApp1.Server.Infra.Seed
{
    public static class CitySeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    ID = 1,
                    CreationDate = DateTime.Now,
                    Name = "Brasil"
                });
            modelBuilder.Entity<State>().HasData(
                new State
                {
                    ID = 1,
                    CreationDate = DateTime.Now,
                    Name = "São Paulo",
                    CountryID = 1
                });
            modelBuilder.Entity<City>().HasData(
                new City
                {
                    ID = 1,
                    CreationDate = DateTime.Now,
                    Name = "Guararema",
                    StateID = 1
                });
            modelBuilder.Entity<EconomicGroup>().HasData(
                new EconomicGroup
                {
                    ID = 1,
                    CreationDate = DateTime.Now,
                    Name = "Mercosul",
                });
            modelBuilder.Entity<CountryGroup>().HasData(
                new CountryGroup
                {
                    ID = 1,
                    CountryID = 1,
                    GroupID = 1
                });
            modelBuilder.Entity<ProjectLog>().HasData(
                new ProjectLog
                {
                    Date = DateTime.Now,
                    Exception = "test",
                    Hostname = "test",
                    Level = "Test",
                    Logger = "Test",
                    Message = "Test",
                    Thread = "Test",
                    ID = 1
                });
        }
    }
}
