using System.Text.Json.Serialization;
using Shared.Dtos.Produto;

namespace Shared.Dtos.Comanda;

public record ReadComandaDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("idUsuario")]
    public int IdUsuario { get; set; }
    [JsonPropertyName("nomeUsuario")]
    public string NomeUsuario { get; set; }
    [JsonPropertyName("telefoneUsuario")]
    public string TelefoneUsuario { get; set; }
    [JsonPropertyName("produtos")]
    public ReadProdutoDto[] Produtos { get; set; }
}
