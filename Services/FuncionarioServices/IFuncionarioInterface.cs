using ApiWeb.Models;

namespace ApiWeb.Services.FuncionarioServices;

public interface IFuncionarioInterface
{
    Task<ServiceResponse<List<Funcionario>>> GetFuncionarios();
    Task<ServiceResponse<List<Funcionario>>> CreateFuncionario (Funcionario novoFuncionario);
    Task<ServiceResponse<Funcionario>> GetFuncionarioById (int id);
    Task<ServiceResponse<List<Funcionario>>> UpdateFuncionario(Funcionario funcionarioEditado);
    Task<ServiceResponse<List<Funcionario>>> DeleteFuncionario(int id);
    Task<ServiceResponse<List<Funcionario>>> InativaFuncionario(int id);
}
