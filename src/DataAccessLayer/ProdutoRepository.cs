using Contracts;
using Entities.Models;

namespace Repository;

public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
{
    public ProdutoRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
}
