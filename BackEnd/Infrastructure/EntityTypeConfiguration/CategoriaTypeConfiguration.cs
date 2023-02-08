using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.EntityTypeConfiguration
{
    public class CategoriaTypeConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("t_Categoria");
            builder.HasKey(u => u.Id);

            builder.Property(e => e.Id).HasColumnName("Id_Categoria");
            builder.Property(e => e.Descripcion).HasColumnName("Descripcion").IsRequired();
        }
    }
}
