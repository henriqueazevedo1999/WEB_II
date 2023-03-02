using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IComandaService> _comandaService;
    private readonly Lazy<IProdutoService> _produtoService;

    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
    {
        _comandaService = new Lazy<IComandaService>(() => new ComandaService(repositoryManager, logger, mapper));
        _produtoService = new Lazy<IProdutoService>(() => new ProdutoService(repositoryManager, logger, mapper));
    }

    public IComandaService ComandaService => _comandaService.Value;
    public IProdutoService ProdutoService => _produtoService.Value;
}
