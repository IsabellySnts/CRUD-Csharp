using ApiWeb.Enums;
using System.ComponentModel.DataAnnotations;

namespace ApiWeb.Models;

public class Funcionario
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public Departamento Departamento { get; set; }
    public bool Ativo { get; set; }
    public Turrno Turno { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.Now.ToLocalTime();
    public DateTime DataAlteracao { get; set; } = DateTime.Now.ToLocalTime();
}
