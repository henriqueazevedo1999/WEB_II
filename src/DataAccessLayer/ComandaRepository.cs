using Contracts;
using Entities.Models;

namespace Repository;

public class ComandaRepository : RepositoryBase<Comanda>, IComandaRepository
{
    public ComandaRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

    public IEnumerable<Comanda> GetAllComandas(bool trackChanges)
    {
        return FindAll(trackChanges).OrderBy(x => x.Id).ToList();
    }
}
