using Entities.Models;

namespace Contracts;

public interface IComandaRepository
{
    IEnumerable<Comanda> GetAllComandas(bool trackChanges);
}
