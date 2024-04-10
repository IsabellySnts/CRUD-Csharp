using ApiWeb.Models;
using ApiWeb.Services.FuncionarioServices;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
namespace ApiWeb.Controller;

[EnableCors("_PermitirOrigemEspecifica")]
[Route("api/[controller]")]
[ApiController]
public class FuncionarioController : ControllerBase
{
    private readonly IFuncionarioInterface _funcionarioInterface;
    public FuncionarioController(IFuncionarioInterface funcionarioInterface)
    {

        _funcionarioInterface = funcionarioInterface;
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<List<Funcionario>>>> CreateFuncionario(Funcionario novoFuncionario)
    {
        return Ok(await _funcionarioInterface.CreateFuncionario(novoFuncionario));
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Funcionario>>>> GetFuncionario()
    {
        return Ok(await _funcionarioInterface.GetFuncionarios());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<Funcionario>>> GetFuncionarioById(int id)
    {
        ServiceResponse<Funcionario> serviceResponse = await _funcionarioInterface.GetFuncionarioById(id);

        return Ok(serviceResponse);
    }

    [HttpPut("atualizar")]
    public async Task<ActionResult<ServiceResponse<List<Funcionario>>>> UpdateFuncionario(Funcionario editadoFuncionario)
    {
        ServiceResponse<List<Funcionario>> serviceResponse = await _funcionarioInterface.UpdateFuncionario(editadoFuncionario);

        return Ok(serviceResponse);
    }


    [HttpPut("inativaFuncionario")]
    public async Task<ActionResult<ServiceResponse<List<Funcionario>>>> InativaFuncionario(int id)
    {
        ServiceResponse<List<Funcionario>> serviceResponse = await _funcionarioInterface.InativaFuncionario(id);

        return Ok(serviceResponse);
    }

    [HttpDelete]
    public async Task<ActionResult<ServiceResponse<List<Funcionario>>>> DeletarFuncionario(int id)
    {
        ServiceResponse<List<Funcionario>> serviceResponse = await _funcionarioInterface.DeleteFuncionario(id);

        return Ok(serviceResponse);
    }
}
