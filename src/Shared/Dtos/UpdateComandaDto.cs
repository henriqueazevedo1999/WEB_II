using System.Text.Json.Serialization;

namespace Shared.Dtos;

public record UpdateComandaDto
{
    [JsonPropertyName("idUsuario")]
    public int IdUsuario { get; set; }
    [JsonPropertyName("nomeUsuario")]
    public string NomeUsuario { get; set; }
    [JsonPropertyName("telefoneUsuario")]
    public string TelefoneUsuario { get; set; }
    [JsonPropertyName("produtos")]
    public ProdutoDto[] Produtos { get; set; }
}
