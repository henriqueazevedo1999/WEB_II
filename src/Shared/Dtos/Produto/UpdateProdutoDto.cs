using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Shared.Dtos.Produto;

public record UpdateProdutoDto
{
    [JsonPropertyName("id")]
    [Range(1, int.MaxValue, ErrorMessage = "Id do produto deve ser informado e ser maior que zero")]
    public int IdLista { get; set; }

    [JsonPropertyName("nome")]
    [MaxLength(ErrorMessage = "Nome do produto deve ter no máximo 250 caracteres")]
    public string Nome { get; set; }

    [JsonPropertyName("preco")]
    [Range(0, int.MaxValue, ErrorMessage = "Preço do produto deve ser maior ou igual a zero")]
    public int? Preco { get; set; }
}
