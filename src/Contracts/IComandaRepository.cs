using Entities.Models;

namespace Contracts;

public interface IComandaRepository
{
    IEnumerable<Comanda> GetAllComandas(bool trackChanges);
    Comanda GetComanda(int id, bool trackChanges);
    void CreateComanda(Comanda comanda);
    void DeleteComanda(Comanda comanda);
}
