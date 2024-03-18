using System.Text.Json.Serialization;

namespace ApiWeb.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Departamento
{
    RH,
    Financeiro,
    Fiscal,
    Compras,
    Marketing,
    TI,
    Judirico
}
