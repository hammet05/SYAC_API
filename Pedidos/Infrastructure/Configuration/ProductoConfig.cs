using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.Domain.Entities;

namespace Pedidos.Infrastructure.Configuration
{
    public class ProductoConfig : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Productos");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Codigo).IsRequired();

            builder.Property(u => u.Nombre).IsRequired().HasMaxLength(100);

            builder.Property(u => u.ValorUnitario).IsRequired();
           
        }
    }
}
