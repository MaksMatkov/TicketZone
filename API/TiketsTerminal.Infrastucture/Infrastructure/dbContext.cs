using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.Domain.Enums;
using TiketsTerminal.Domain.Models;
using TiketsTerminal.Domain.Models.NotEntity;
using TiketsTerminal.Infrastucture.ModelsConfigurations;

namespace TiketsTerminal.Infrastucture.Infrastructure
{
    public class dbContext : DbContext
    {
        public dbContext(ConnectionStringsConfiguration ConnectionStringsConfiguration) : base()
        {
            this._ConnectionStringsConfiguration = ConnectionStringsConfiguration;
        }

        private ConnectionStringsConfiguration _ConnectionStringsConfiguration { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(_ConnectionStringsConfiguration.DbType == DbType.sqlLite)
                optionsBuilder.UseSqlite(_ConnectionStringsConfiguration.sqlLiteConnectionString);
            else
                optionsBuilder.UseSqlServer(_ConnectionStringsConfiguration.msSqlConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new FilmConfiguration());
            builder.ApplyConfiguration(new RoomConfiguration());
            builder.ApplyConfiguration(new TicketOrderConfiguration());
            builder.ApplyConfiguration(new FilmViewingTimeConfiguration());

            builder.Entity<OrderFullInfoModel>().ToTable(nameof(OrderFullInfoModel), t => t.ExcludeFromMigrations());
        }

        public DbSet<Film> Film { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<TicketOrder> TicketOrder { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<FilmViewingTime> FilmViewingTime { get; set; }
        public DbSet<OrderFullInfoModel> OrderFullInfoModel { get; set; }
    }
}
