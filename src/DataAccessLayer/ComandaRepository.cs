using Contracts;
using Entities.Models;

namespace Repository;

public class ComandaRepository : RepositoryBase<Comanda>, IComandaRepository
{
    public ComandaRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

    public void CreateComanda(Comanda comanda)
    {
        Create(comanda);
    }

    public void DeleteComanda(Comanda comanda)
    {
        Delete(comanda);
    }

    public IEnumerable<Comanda> GetAllComandas(bool trackChanges)
    {
        return FindAll(trackChanges).OrderBy(x => x.Id).ToList();
    }

    public Comanda GetComanda(int id, bool trackChanges)
    {
        return FindByCondition(c => c.Id == id, trackChanges).SingleOrDefault();
    }
}
