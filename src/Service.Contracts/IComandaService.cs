using Shared.Dtos.Comanda;

namespace Service.Contracts;

public interface IComandaService
{
    IEnumerable<ReadComandasDto> GetAllComandas(bool trackChanges);
    ReadComandaDto GetComanda(int id, bool trackChanges);
    ReadComandaDto CreateComanda(CreateComandaDto createComandaDto);
    ReadComandaDto UpdateComanda(int id, UpdateComandaDto updateComandaDto);
    void DeleteComanda(int id, bool trackChanges);
}
