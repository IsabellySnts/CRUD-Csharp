using ApiWeb.Models;
using Microsoft.EntityFrameworkCore;


namespace ApiWeb.DataContext;

public class AplicationDbContext : DbContext
{
    public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Funcionario> Funcionarios { get; set; }
}
