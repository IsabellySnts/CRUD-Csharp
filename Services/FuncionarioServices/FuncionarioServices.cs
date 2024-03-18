using ApiWeb.DataContext;
using ApiWeb.Models;
using Arch.EntityFrameworkCore;
using System.Collections.Generic;

namespace ApiWeb.Services.FuncionarioServices;

public class FuncionarioServices : IFuncionarioInterface
{
    private readonly AplicationDbContext _context;
    public FuncionarioServices(AplicationDbContext context)
    {
        _context = context;
    }
    public async Task<ServiceResponse<List<Funcionario>>> CreateFuncionario(Funcionario novoFuncionario)
    {
        ServiceResponse<List<Funcionario>> serviceResponse = new ServiceResponse<List<Funcionario>>();

        try
        {
            if (novoFuncionario is null)
            {
                serviceResponse.Details = null;
                serviceResponse.Mensagem = "Informe os dados do funcionário";
                serviceResponse.Sucesso = false;

                return serviceResponse;
            }
            _context.Add(novoFuncionario);
           await _context.SaveChangesAsync();

            serviceResponse.Details = _context.Funcionarios.ToList();
        }
        catch (Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<Funcionario>>> GetFuncionarios()
    {
        ServiceResponse<List<Funcionario>> serviceResponse = new ServiceResponse<List<Funcionario>>();

        try
        {
            serviceResponse.Details = _context.Funcionarios.ToList();

            if (serviceResponse.Details.Count == 0)
            {
                serviceResponse.Mensagem = "Nenhum dado de funcionários encontrado!";
            }
        }
        catch (Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }
    public async Task<ServiceResponse<Funcionario>> GetFuncionarioById(int id)
    {
        ServiceResponse<Funcionario> serviceResponse = new ServiceResponse<Funcionario>();

        try
        {
            Funcionario funcionario = _context.Funcionarios.FirstOrDefault(f => f.Id == id);

            if (funcionario is null)
            {
                serviceResponse.Details = null;
                serviceResponse.Mensagem = "Funcionário não encontrado";
                serviceResponse.Sucesso = false;
            }

            serviceResponse.Details = funcionario;
        }
        catch (Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }
    public async Task<ServiceResponse<List<Funcionario>>> InativaFuncionario(int id)
    {
        ServiceResponse<List<Funcionario>> serviceResponse = new ServiceResponse<List<Funcionario>>();

        try
        {
            Funcionario funcionario = _context.Funcionarios.FirstOrDefault(f => f.Id == id);

            if (funcionario is null)
            {
                serviceResponse.Details = null;
                serviceResponse.Mensagem = "Usuário não localizado.";
                serviceResponse.Sucesso = false;
            }

            funcionario.Ativo = false;
            funcionario.DataAlteracao = DateTime.Now.ToLocalTime();

            _context.Funcionarios.Update(funcionario);
            await _context.SaveChangesAsync();

            serviceResponse.Details = _context.Funcionarios.ToList();
        }
        catch (Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }


    public async Task<ServiceResponse<List<Funcionario>>> DeleteFuncionario(int id)
    {
        ServiceResponse<List<Funcionario>> serviceResponse = new ServiceResponse<List<Funcionario>>();

        try
        {
            Funcionario funcionario = _context.Funcionarios.FirstOrDefault(f => f.Id == id);
            if (funcionario is null)
            {
                serviceResponse.Details = null;
                serviceResponse.Mensagem = "Usuário não localizado.";
                serviceResponse.Sucesso = false;
            }
            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();

            serviceResponse.Details = _context.Funcionarios.ToList();
        }
        catch(Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;

        }

        return serviceResponse;
    }


    public async Task<ServiceResponse<List<Funcionario>>> UpdateFuncionario(Funcionario editadoFuncionario)
    {
        ServiceResponse<List<Funcionario>> serviceResponse = new ServiceResponse<List<Funcionario>>();

        try
        {
            if (_context.Funcionarios.Any(x => x.Id == editadoFuncionario.Id))
            {
                _context.Funcionarios.Update(editadoFuncionario);
                await _context.SaveChangesAsync();
                serviceResponse.Details = _context.Funcionarios.ToList();
            }
            else {

                serviceResponse.Details = null;
                serviceResponse.Mensagem = "Usuário não localizado!";
                serviceResponse.Sucesso = false;
            }
        }
        catch (Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }
}
