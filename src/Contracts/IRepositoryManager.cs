namespace Contracts;

public interface IRepositoryManager
{
    IComandaRepository Comanda { get; }
    IProdutoRepository Produto { get; }

    void Save();
}
