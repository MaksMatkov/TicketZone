using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.DAL.ModelsConfigurations;
using TiketsTerminal.Domain.Models;
using TiketsTerminal.Domain.Models.ValueModels;

namespace TiketsTerminal.DAL.Infrastructure
{
    public class DBContext : DbContext
    {
        public DBContext(ConnectionStringsConfiguration ConnectionStringsConfiguration) : base()
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

            //set def values
            builder.Entity<User>().HasData(new Domain.Models.User(
                new RegData(
                new Email("admin@admin.admin"), 
                new Password("admin"), 
                new Role(2), 1, "ADMIN")));
        }

        public DbSet<Film> Film { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<TicketOrder> TicketOrder { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<FilmViewingTime> FilmViewingTime { get; set; }
    }
}
