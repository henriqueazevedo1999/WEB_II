using Shared.Dtos;

namespace Service.Contracts;

public interface IComandaService
{
    IEnumerable<ReadComandasDto> GetAllComandas(bool trackChanges);
}
