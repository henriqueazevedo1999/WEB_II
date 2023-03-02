namespace Entities.Models;

public class Comanda
{
    public uint Id { get; set; }
    //fazer por login?
    public uint IdUsuario { get; set; }
    public string NomeUsuario { get; set; }
    public string TelefoneUsuario { get; set; }
    public bool Ativo { get; set; }
    public DateTime TimeCreated { get; set; }
    public ICollection<Produto> Produtos { get; set; }
}
