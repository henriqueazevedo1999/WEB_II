using System.Text.Json.Serialization;

namespace Shared.Dtos;

public record ProdutoDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("nome")]
    public string Nome { get; set; }
    [JsonPropertyName("preco")]
    public int Preco { get; set; }
}