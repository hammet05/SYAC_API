using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.Domain.Entities;

namespace Pedidos.Infrastructure.Configuration
{
    public class DetallePedidoConfig : IEntityTypeConfiguration<DetallePedido>
    {
        public void Configure(EntityTypeBuilder<DetallePedido> builder)
        {
            builder.ToTable("DetallePedidos");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.OrdenPedidoId).IsRequired();

            builder.Property(u => u.ProductoId).IsRequired();

            builder.Property(u => u.Cantidad).IsRequired();
            builder.Property(u => u.ValorUnitario).IsRequired();
            builder.Property(u => u.ValorParcial).IsRequired();
                
            builder.HasOne(d => d.OrdenPedido)
                   .WithMany(o => o.Detalles)
                   .HasForeignKey(d => d.OrdenPedidoId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Relación: un detalle pertenece a una orden
            builder.HasOne(d => d.OrdenPedido)
                   .WithMany(o => o.Detalles)
                   .HasForeignKey(d => d.OrdenPedidoId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Relación: un detalle tiene un producto
            builder.HasOne(d => d.Producto)
                   .WithMany(p => p.Detalles)
                   .HasForeignKey(d => d.ProductoId)
                   .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
