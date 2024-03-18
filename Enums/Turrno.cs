using System.Text.Json.Serialization;
namespace ApiWeb.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Turrno
{
    Manha,
    Tarde,
    Noite
}
