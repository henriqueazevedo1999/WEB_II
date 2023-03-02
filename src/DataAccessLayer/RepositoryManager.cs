using Contracts;

namespace Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IComandaRepository> _comandaRepository;
    private readonly Lazy<IProdutoRepository> _produtoRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _comandaRepository = new Lazy<IComandaRepository>(() => new ComandaRepository(_repositoryContext));
        _produtoRepository = new Lazy<IProdutoRepository>(() => new ProdutoRepository(_repositoryContext));
    }

    public IComandaRepository Comanda => _comandaRepository.Value;
    public IProdutoRepository Produto => _produtoRepository.Value;
    public void Save() => _repositoryContext.SaveChanges();
}
