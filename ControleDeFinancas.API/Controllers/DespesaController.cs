using ControleDeFinancas.Application.Interface;
using ControleDeFinancas.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ControleDeFinancas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DespesaController : ControllerBase
    {
        private readonly IDespesaApplication _despesaApplication;

        public DespesaController(IDespesaApplication despesaApplication)
        {
            _despesaApplication = despesaApplication;
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(DespesaViewModel despesaVm)
        {
            try
            {
                await _despesaApplication.AdicionarDespesa(despesaVm);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet]
        public async Task<IActionResult> Obter()
        {
            var despesas = await _despesaApplication.ObterTodasDespesa();

            return Ok(despesas);
        }

        [HttpGet("idDespesa")]
        public async Task<IActionResult> ObterPorId(Guid idDespesa)
        {
            var despesas = await _despesaApplication.ObterDespesaPorId(idDespesa);

            return Ok(despesas);
        }

        [HttpGet("ObterPorMes/{data}")]
        public async Task<IActionResult> ObterPorMes(DateTime data)
        {
            var despesas = await _despesaApplication.DespesaPorData(data);

            return Ok(despesas);
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(DespesaViewModel despesaVm)
        {
            await _despesaApplication.AtualizarDespesa(despesaVm);

            return Ok();
        }

        [HttpDelete("idDespesa")]
        public async Task<IActionResult> Delete(Guid idDespesa)
        {
            await _despesaApplication.DeletarDespesa(idDespesa);

            return Ok();
        }



    }
    
}
