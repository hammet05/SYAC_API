using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.Domain.Entities;
using System.Reflection.Emit;

namespace Pedidos.Infrastructure.Configuration
{
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Identificacion).IsRequired().HasMaxLength(50);

            builder.Property(u => u.Nombre).IsRequired().HasMaxLength(100);

            builder.Property(u => u.Direccion).IsRequired();                      

        }
    }
}
