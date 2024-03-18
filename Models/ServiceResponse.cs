namespace ApiWeb.Models;

public class ServiceResponse<T>
{
    public T? Details { get; set; }
    public string Mensagem { get; set; } = string.Empty;
    public bool Sucesso { get; set; } = true;
}
