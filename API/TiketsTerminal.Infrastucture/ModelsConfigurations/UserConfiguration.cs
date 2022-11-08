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
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("T_User", schema: "fbd");

            builder.HasKey(p => p.ID);

            builder.HasMany<TicketOrder>(el => el.TicketOrders).WithOne(el => el.User).HasForeignKey(el => el.FK_User);

            builder.Property(p => p.ID)
                .HasColumnName("PK_User")
                .UseIdentityColumn(1, 1)
                .ValueGeneratedOnAdd();
            builder
                .Property(p => p.Name)
                .HasColumnName("Name")
                .IsRequired();
            builder
                .Property(p => p.Email)
                .HasColumnName("Email")
                .IsRequired();
            builder
               .Property(p => p.FK_Role)
               .HasColumnName("FK_Role")
               .IsRequired();
            builder
               .Property(p => p.Password)
               .HasColumnName("Password")
               .IsRequired();
            builder
               .Property(p => p.LastVisited)
               .HasColumnName("Last_Visited")
               .IsRequired();
        }
    }
}
