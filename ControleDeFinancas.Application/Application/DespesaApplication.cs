using ControleDeFinancas.Application.Dto;
using ControleDeFinancas.Application.Interface;
using ControleDeFinancas.Application.ViewModel;
using ControleDeFinancas.Domain.Entidade;
using ControleDeFinancas.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeFinancas.Application.Application
{
    public class DespesaApplication : IDespesaApplication
    {
        private readonly IDespesaRepository _despesaRepository;

        public DespesaApplication(IDespesaRepository despesaRepository)
        {
            _despesaRepository = despesaRepository;
        }

        public async Task AdicionarDespesa(DespesaViewModel despesaVM)
        {
            var despesa = new Despesa(despesaVM.Nome, despesaVM.Valor, despesaVM.Vencimento, despesaVM.StatusPagamento);

            await _despesaRepository.AdicionarDepesa(despesa);
        }


        public async Task AtualizarDespesa(DespesaViewModel despesaVM)
        {
            var despesa = await _despesaRepository.ObterDespesaPorId(despesaVM.DepesaId);

            despesa.AtualizarDadosDaDespesa(despesaVM.Nome, despesaVM.Valor, despesaVM.Vencimento, despesaVM.StatusPagamento);

            await _despesaRepository.AtualizarDespesa(despesa);
        }

        public async Task<DespesaDto> ObterDespesaPorId(Guid idDespesa)
        {
            var despesa = await _despesaRepository.ObterDespesaPorId(idDespesa);

            var despesaDto = new DespesaDto()
            {
                Nome = despesa.Nome,
                Valor = despesa.Valor,
                StatusPagamento = despesa.StatusPagamento,
                Vencimento = despesa.Vencimento.ToString("dd/MM/yyyy"),
                DepesaId = despesa.Id
            };

            return despesaDto;
        }

        public async Task<List<DespesaDto>> ObterTodasDespesa()
        {
            var despesas = await _despesaRepository.ObterTodasDepesas();

            var listaDespesas = new List<DespesaDto>();

            foreach (var despesa in despesas)
            {
                var despesaDto = new DespesaDto()
                {
                    Nome = despesa.Nome,
                    Valor = despesa.Valor,
                    StatusPagamento = despesa.StatusPagamento,
                    Vencimento = despesa.Vencimento.ToString("dd/MM/yyyy"),
                    DepesaId = despesa.Id
                };

                listaDespesas.Add(despesaDto);
            }
            return listaDespesas;
        }

        public async Task DeletarDespesa(Guid idDespesa)
        {
            await _despesaRepository.Deletar(idDespesa);
        }

        public async Task<List<DespesaDto>> DespesaPorData(DateTime data)
        {

            var despesas = await _despesaRepository.ObterDespesaPorMes(data);

            var listaDespesas = new List<DespesaDto>();

            foreach (var despesa in despesas)
            {

                var despesaDto = new DespesaDto()
                {
                    Nome = despesa.Nome,
                    Valor = despesa.Valor,
                    StatusPagamento = despesa.StatusPagamento,
                    Vencimento = despesa.Vencimento.ToString("dd/MM/yyyy"),
                    DepesaId = despesa.Id,
                    DespesaVencida = DateTime.Now.Date > despesa.Vencimento.Date && !despesa.StatusPagamento ? true : false
                };

                listaDespesas.Add(despesaDto);
            }
            return listaDespesas;
        }


    }
}
