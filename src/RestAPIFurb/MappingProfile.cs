using AutoMapper;
using Entities.Models;
using Shared.Dtos.Comanda;
using Shared.Dtos.Produto;
using RestAPIFurb.Extensions;
using Shared.Dtos.User;

namespace RestAPIFurb;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        AllowNullCollections = true;

        //jeito mais fácil?
        CreateMap<int?, int>().ConvertUsing((src, dest) => src ?? dest);
        CreateMap<uint?, uint>().ConvertUsing((src, dest) => src ?? dest);

        CreateMap<long?, long>().ConvertUsing((src, dest) => src ?? dest);
        CreateMap<ulong?, ulong>().ConvertUsing((src, dest) => src ?? dest);

        CreateMap<short?, short>().ConvertUsing((src, dest) => src ?? dest);
        CreateMap<ushort?, ushort>().ConvertUsing((src, dest) => src ?? dest);

        CreateMap<float?, float>().ConvertUsing((src, dest) => src ?? dest);
        CreateMap<double?, double>().ConvertUsing((src, dest) => src ?? dest);
        CreateMap<decimal?, decimal>().ConvertUsing((src, dest) => src ?? dest);
        CreateMap<char?, char>().ConvertUsing((src, dest) => src ?? dest);
        CreateMap<byte?, byte>().ConvertUsing((src, dest) => src ?? dest);
        CreateMap<bool?, bool>().ConvertUsing((src, dest) => src ?? dest);
        CreateMap<DateTime?, DateTime>().ConvertUsing((src, dest) => src ?? dest);
        CreateMap<TimeOnly?, TimeOnly>().ConvertUsing((src, dest) => src ?? dest);

        CreateMap<Comanda, ReadComandaDto>();
        CreateMap<Comanda, ReadComandasDto>();
        CreateMap<CreateComandaDto, Comanda>();
        CreateMap<UpdateComandaDto, Comanda>().ForMember(x => x.Produtos, opt => opt.Ignore()).IgnoreNullsOnSource();

        CreateMap<Produto, ReadProdutoDto>();
        CreateMap<CreateProdutoDto, Produto>();
        CreateMap<UpdateProdutoDto, Produto>().IgnoreNullsOnSource();

        CreateMap<CreateUserDto, User>();
    }
}
