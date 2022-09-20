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
    class FilmConfiguration : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.ToTable("T_Film", schema: "fbd");

            builder.HasKey(p => p.ID);

            builder.HasMany<FilmViewingTime>(el => el.FilmViewingTimes)
                .WithOne(el => el.Film)
                .HasForeignKey(el => el.FK_Film);

            builder.Property(p => p.ID)
               .HasColumnName("PK_Film")
               .ValueGeneratedOnAdd();
            builder.Property(p => p.Name)
               .HasColumnName("Name")
               .IsRequired();
            builder.Property(p => p.Description)
               .HasColumnName("Description")
               .ValueGeneratedOnAdd();
            builder.Property(p => p.TrailerUrl)
               .HasColumnName("Trailer_Url")
               .IsRequired();
            builder.Property(p => p.PosterUrl)
               .HasColumnName("Poster_Url")
               .IsRequired();
        }
    }
}
