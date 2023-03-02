using System.Text.Json.Serialization;

namespace Shared.Dtos;

public record ReadComandasDto
{
    [JsonPropertyName("idUsuario")]
    public uint IdUsuario { get; set; }
    [JsonPropertyName("nomeUsuario")]
    public string NomeUsuario { get; set; }
    [JsonPropertyName("telefoneUsuario")]
    public string TelefoneUsuario { get; set; }
}
