using System.Text.Json.Serialization;

namespace Shared.Dtos.Comanda;

public record ReadComandasDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("idUsuario")]
    public int IdUsuario { get; set; }
    [JsonPropertyName("nomeUsuario")]
    public string NomeUsuario { get; set; }
    [JsonPropertyName("telefoneUsuario")]
    public string TelefoneUsuario { get; set; }
}
