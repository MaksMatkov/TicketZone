using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.Domain.Models;

namespace TiketsTerminal.Infrastucture.ModelsConfigurations
{
    class FilmViewingTimeConfiguration : IEntityTypeConfiguration<FilmViewingTime>
    {
        public void Configure(EntityTypeBuilder<FilmViewingTime> builder)
        {
            builder.ToTable("T_Film_Viewing_Time", schema: "fbd");

            builder.HasKey(el => el.ID);

            builder.HasOne<Room>(el => el.Room).WithMany(u => u.FilmViewingTimes).HasForeignKey(el => el.FK_Room);
            builder.HasOne<Film>(el => el.Film).WithMany(u => u.FilmViewingTimes).HasForeignKey(el => el.FK_Film);
            
            builder.HasMany<TicketOrder>(el => el.TicketOrders).WithOne(el => el.FilmViewingTime).HasForeignKey(el => el.FK_Film_Viewing_Time);

            builder.Property(p => p.ID)
                .HasColumnName("PK_Film_Viewing_Time")
                .ValueGeneratedOnAdd();
            builder.Property(p => p.FK_Film)
                .HasColumnName("FK_Film");
            builder.Property(p => p.FK_Room)
                .HasColumnName("FK_Room");
            builder.Property(p => p.Date)
                .HasColumnName("Date");
        }
    }
}
