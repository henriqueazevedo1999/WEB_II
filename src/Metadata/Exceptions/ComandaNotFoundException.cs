namespace Entities.Exceptions;

public sealed class ComandaNotFoundException : NotFoundException
{
    public ComandaNotFoundException(int id) : base($"A comanda com id \"{id}\" não existe na base de dados") { }
}
