using AutoMapper;
using Entities.Models;
using Shared.Dtos;

namespace RestAPIFurb;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Comanda, ReadComandaDto>();
        CreateMap<Comanda, ReadComandasDto>();
    }
}
