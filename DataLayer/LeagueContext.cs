using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    class LeagueContext:DbContext
    {
        public DbSet<Speler> Spelers { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-CQ5M5QL\SQLEXPRESS;Initial Catalog=DbLeague;Integrated Security=True;Pooling=False");
        }
    }
}
