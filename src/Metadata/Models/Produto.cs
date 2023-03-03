using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class Produto
{
    public int Id { get; set; }
    public int IdLista { get; set; }
    public string Nome { get; set; }
    public int Preco { get; set; }
}
