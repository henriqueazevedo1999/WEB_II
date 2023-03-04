using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.InitialData;

internal static class RolesInitialDataHelper
{
    public static string GERENTE_ROLE_ID = "8A990D37-D53C-458A-B9EB-B2FA67DC6F35";
    public static string GERENTE_INICIAL_ID = "8e445865-a24d-4543-a6c6-9443d048cdb9";
}

internal class RolesInitialData : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Id = RolesInitialDataHelper.GERENTE_ROLE_ID,
                Name = "Gerente",
                NormalizedName = "GERENTE"
            },
            new IdentityRole
            {
                Name = "Administrador",
                NormalizedName = "ADMINISTRADOR"
            },
            new IdentityRole
            {
                Name = "Caixa",
                NormalizedName = "CAIXA"
            }
        );
    }
}

internal class UsersInitialData : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        var hasher = new PasswordHasher<IdentityUser>();

        builder.HasData
        (
            new User
            {
                Id = RolesInitialDataHelper.GERENTE_INICIAL_ID,
                UserName = "GerenteInicial",
                NormalizedUserName = "GERENTEINICIAL",
                PasswordHash = hasher.HashPassword(null, "123456"),
                FirstName = "Gerente",
                LastName = "Inicial",
            }
        );
    }
}

internal class UserRoleInitialData : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData(new IdentityUserRole<string>
        {
            RoleId = RolesInitialDataHelper.GERENTE_ROLE_ID,
            UserId = RolesInitialDataHelper.GERENTE_INICIAL_ID
        });
    }
}
