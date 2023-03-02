using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.InitialData;

internal class ComandasInitialData : IEntityTypeConfiguration<Comanda>
{
    public void Configure(EntityTypeBuilder<Comanda> builder)
    {
        uint id = 1;

        builder.HasData
        (
            new Comanda
            {
                Id = id++,
                IdUsuario = 1,
                NomeUsuario = "joao",
                TelefoneUsuario = "478888888"
            },
            new Comanda
            {
                Id = id++,
                IdUsuario = 2,
                NomeUsuario = "Pedro",
                TelefoneUsuario = "47999999"
            }
        );
    }
}
