using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class Comanda
{
    public int Id { get; set; }
    //fazer por login?
    public int IdUsuario { get; set; }

    public string NomeUsuario { get; set; }

    public string TelefoneUsuario { get; set; }
    
    public bool Ativo { get; set; }
    public DateTime TimeCreated { get; set; }
    public virtual ICollection<Produto> Produtos { get; set; }
}
