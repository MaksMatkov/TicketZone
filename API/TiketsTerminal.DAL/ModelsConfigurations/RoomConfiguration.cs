using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.Domain.Models;

namespace TiketsTerminal.DAL.ModelsConfigurations
{
    class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("T_Room", schema: "fbd");

            builder.HasKey(el => el.ID);

            builder.HasMany<FilmViewingTime>(el => el.FilmViewingTimes).WithOne(el => el.Room).HasForeignKey(el => el.FK_Room);

            builder.Property(p => p.ID)
                .HasColumnName("PK_Film")
                .ValueGeneratedOnAdd();
            builder.Property(p => p.Number)
                .HasColumnName("Number");
            builder.Property(p => p.SeatsCount)
                .HasColumnName("Seats_Count");
        }
    }
}
