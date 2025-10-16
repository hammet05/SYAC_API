using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.Domain.Entities;

namespace Pedidos.Infrastructure.Configuration
{
    public class OrdenPedidoConfig : IEntityTypeConfiguration<OrdenPedido>
    {
        public void Configure(EntityTypeBuilder<OrdenPedido> builder)
        {
            builder.ToTable("OrdenPedidos");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.ClienteId).IsRequired();

            builder.Property(u => u.Estado).IsRequired().HasMaxLength(100);

            builder.Property(u => u.DireccionEntrega).IsRequired();

            builder.Property(u => u.Prioridad).IsRequired();

            builder.Property(u => u.ValorTotal).IsRequired();

            builder.HasOne(o => o.Cliente)
                   .WithMany(c => c.Ordenes)
                   .HasForeignKey(o => o.ClienteId)
                   .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
