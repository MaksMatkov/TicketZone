using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.Domain.Models;
using TiketsTerminal.Infrastucture.ModelsConfigurations;

namespace TiketsTerminal.Infrastucture.Infrastructure
{
    public class dbContext : DbContext
    {
        public dbContext(ConnectionStringsConfiguration ConnectionStringsConfiguration) : base()
        {
            this.connectionString = ConnectionStringsConfiguration.Main;
        }

        private string connectionString { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(this.connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new FilmConfiguration());
            builder.ApplyConfiguration(new RoomConfiguration());
            builder.ApplyConfiguration(new TicketOrderConfiguration());
            builder.ApplyConfiguration(new FilmViewingTimeConfiguration());
        }

        public DbSet<Film> Film { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<TicketOrder> TicketOrder { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<FilmViewingTime> FilmViewingTime { get; set; }
    }
}
