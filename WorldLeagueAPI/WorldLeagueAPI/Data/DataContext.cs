using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;
using WorldLeagueAPI.Models;

namespace WorldLeagueAPI.Data
{
    public class DataContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupTeamMapping> GroupTeamMappings { get; set; }
        public DbSet<Draw> Draws { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ülkeleri ekleyin
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, CountryName = "Türkiye" },
                new Country { Id = 2, CountryName = "Almanya" },
                new Country { Id = 3, CountryName = "Fransa" },
                new Country { Id = 4, CountryName = "Hollanda" },
                new Country { Id = 5, CountryName = "Portekiz" },
                new Country { Id = 6, CountryName = "İtalya" },
                new Country { Id = 7, CountryName = "İspanya" },
                new Country { Id = 8, CountryName = "Belçika" }
            );

            // Gruplar ekleyin
            modelBuilder.Entity<Group>().HasData(
                new Group { Id = 1, GroupName = "A" },
                new Group { Id = 2, GroupName = "B" },
                new Group { Id = 3, GroupName = "C" },
                new Group { Id = 4, GroupName = "D" },
                new Group { Id = 5, GroupName = "E" },
                new Group { Id = 6, GroupName = "F" },
                new Group { Id = 7, GroupName = "G" },
                new Group { Id = 8, GroupName = "H" }
            );
            modelBuilder.Entity<Team>().HasData(
             // Türkiye
               new Team { Id = 1, GroupId = 1, CountryId = 1, TeamName = "Adesso İstanbul" },
               new Team { Id = 2, GroupId = 2, CountryId = 1, TeamName = "Adesso Ankara" },
               new Team { Id = 3, GroupId = 3, CountryId = 1, TeamName = "Adesso İzmir" },
               new Team { Id = 4, GroupId = 4, CountryId = 1, TeamName = "Adesso Antalya" },

             // Almanya
               new Team { Id = 5, GroupId = 1, CountryId = 2, TeamName = "Adesso Berlin" },
               new Team { Id = 6, GroupId = 2, CountryId = 2, TeamName = "Adesso Frankfurt" },
               new Team { Id = 7, GroupId = 3, CountryId = 2, TeamName = "Adesso Münih" },
               new Team { Id = 8, GroupId = 4, CountryId = 2, TeamName = "Adesso Dortmund" },

            // Fransa
               new Team { Id = 9, GroupId = 1, CountryId = 3, TeamName = "Adesso Paris" },
               new Team { Id = 10, GroupId = 2, CountryId = 3, TeamName = "Adesso Marsilya" },
               new Team { Id = 11, GroupId = 3, CountryId = 3, TeamName = "Adesso Nice" },
               new Team { Id = 12, GroupId = 4, CountryId = 3, TeamName = "Adesso Lyon" },

           // Hollanda
               new Team { Id = 13, GroupId = 1, CountryId = 4, TeamName = "Adesso Amsterdam" },
               new Team { Id = 14, GroupId = 2, CountryId = 4, TeamName = "Adesso Rotterdam" },
               new Team { Id = 15, GroupId = 3, CountryId = 4, TeamName = "Adesso Lahey" },
               new Team { Id = 16, GroupId = 4, CountryId = 4, TeamName = "Adesso Eindhoven" },

           // Portekiz
               new Team { Id = 17, GroupId = 1, CountryId = 5, TeamName = "Adesso Lisbon" },
               new Team { Id = 18, GroupId = 2, CountryId = 5, TeamName = "Adesso Porto" },
               new Team { Id = 19, GroupId = 3, CountryId = 5, TeamName = "Adesso Braga" },
               new Team { Id = 20, GroupId = 4, CountryId = 5, TeamName = "Adesso Coimbra" },
  
           // İtalya
               new Team { Id = 21, GroupId = 1, CountryId = 6, TeamName = "Adesso Roma" },
               new Team { Id = 22, GroupId = 2, CountryId = 6, TeamName = "Adesso Milano" },
               new Team { Id = 23, GroupId = 3, CountryId = 6, TeamName = "Adesso Venedik" },
               new Team { Id = 24, GroupId = 4, CountryId = 6, TeamName = "Adesso Napoli" },

           // İspanya
               new Team { Id = 25, GroupId = 1, CountryId = 7, TeamName = "Adesso Sevilla" },
               new Team { Id = 26, GroupId = 2, CountryId = 7, TeamName = "Adesso Madrid" },
               new Team { Id = 27, GroupId = 3, CountryId = 7, TeamName = "Adesso Barselona" },
               new Team { Id = 28, GroupId = 4, CountryId = 7, TeamName = "Adesso Granada" },

           // Belçika
               new Team { Id = 29, GroupId = 1, CountryId = 8, TeamName = "Adesso Brüksel" },
               new Team { Id = 30, GroupId = 2, CountryId = 8, TeamName = "Adesso Brugge" },
               new Team { Id = 31, GroupId = 3, CountryId = 8, TeamName = "Adesso Gent" },
               new Team { Id = 32, GroupId = 4, CountryId = 8, TeamName = "Adesso Anvers" }
          );
        }
    }
}
