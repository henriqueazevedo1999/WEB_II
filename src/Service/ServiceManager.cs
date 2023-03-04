using AutoMapper;
using Contracts;
using Entities.ConfigurationModels;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Service.Contracts;

namespace Service;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IComandaService> _comandaService;
    private readonly Lazy<IProdutoService> _produtoService;
    private readonly Lazy<IAuthenticationService> _authenticationService;

    public ServiceManager(IRepositoryManager repositoryManager
                        , ILoggerManager logger
                        , IMapper mapper
                        , UserManager<User> userManager
                        , IOptions<JwtConfiguration> configuration)
    {
        _comandaService = new Lazy<IComandaService>(() => new ComandaService(repositoryManager, logger, mapper));
        _produtoService = new Lazy<IProdutoService>(() => new ProdutoService(repositoryManager, logger, mapper));
        _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, mapper, userManager, configuration));
    }

    public IComandaService ComandaService => _comandaService.Value;
    public IProdutoService ProdutoService => _produtoService.Value;
    public IAuthenticationService AuthenticationService => _authenticationService.Value;
}
