using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Mappings;

internal class ProdutoMapConfig : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("produtos");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.IdLista).IsRequired();
        builder.Property(x => x.Nome).IsRequired().HasMaxLength(250);
        builder.Property(x => x.Preco).IsRequired();

        builder.HasIndex(x => x.IdLista);
    }
}
