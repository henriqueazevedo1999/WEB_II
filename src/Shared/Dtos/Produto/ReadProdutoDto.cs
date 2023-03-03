using System.Text.Json.Serialization;

namespace Shared.Dtos.Produto;

public record ReadProdutoDto
{
    [JsonPropertyName("id")]
    public int IdLista { get; set; }
    [JsonPropertyName("nome")]
    public string Nome { get; set; }
    [JsonPropertyName("preco")]
    public int Preco { get; set; }
}