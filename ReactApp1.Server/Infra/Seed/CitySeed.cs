﻿using Microsoft.EntityFrameworkCore;
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
        }
    }
}
