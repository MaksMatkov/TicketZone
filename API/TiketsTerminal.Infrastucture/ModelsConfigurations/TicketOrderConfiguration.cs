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
    class TicketOrderConfiguration : IEntityTypeConfiguration<TicketOrder>
    {
        public void Configure(EntityTypeBuilder<TicketOrder> builder)
        {
            builder.ToTable("T_Ticket_Order", schema: "fbd");

            builder.HasKey(el => el.ID);

            builder.HasOne<User>(el => el.User).WithMany(u => u.TicketOrders).HasForeignKey(el => el.FK_User);
            builder.HasOne<FilmViewingTime>(el => el.FilmViewingTime).WithMany(u => u.TicketOrders).HasForeignKey(el => el.FK_Film_Viewing_Time);

            builder.Property(p => p.ID)
                .HasColumnName("PK_Ticket_Order")
                .UseIdentityColumn(1, 1)
                .ValueGeneratedOnAdd();
            builder.Property(p => p.FK_Film_Viewing_Time)
                .HasColumnName("FK_Film_Viewing_Time");
            builder.Property(p => p.FK_User)
                .HasColumnName("FK_User");
            builder.Property(p => p.CreationDate)
                .HasColumnName("Creation_Date");


            
        }
    }
}
