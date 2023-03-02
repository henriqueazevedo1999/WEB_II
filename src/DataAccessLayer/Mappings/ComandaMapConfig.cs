using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Mappings;

internal class ComandaMapConfig : IEntityTypeConfiguration<Comanda>
{
    public void Configure(EntityTypeBuilder<Comanda> builder)
    {
        builder.ToTable("comandas");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.IdUsuario).IsRequired();
        builder.Property(x => x.NomeUsuario).IsRequired().HasMaxLength(250);
        builder.Property(x => x.TelefoneUsuario).IsRequired().HasMaxLength(15);
        builder.Property(x => x.Ativo).HasDefaultValue(true);
        builder.Property(x => x.TimeCreated).HasDefaultValueSql("getdate()");

        builder.HasIndex(x => x.IdUsuario);
        builder.HasMany(c => c.Produtos).WithOne().IsRequired();
        builder.Navigation(c => c.Produtos).UsePropertyAccessMode(PropertyAccessMode.Property);
    }
}
