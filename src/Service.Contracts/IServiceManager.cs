namespace Service.Contracts;

public interface IServiceManager
{
    IComandaService ComandaService { get; }
    IProdutoService ProdutoService { get; }
    IAuthenticationService AuthenticationService { get; }
}
