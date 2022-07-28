using ControleDeFinancas.Application.Dto;
using ControleDeFinancas.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeFinancas.Application.Interface
{
    public interface IDespesaApplication
    {
        Task AdicionarDespesa(DespesaViewModel despesaVM);
        Task<List<DespesaDto>> ObterTodasDespesa();
        Task AtualizarDespesa(DespesaViewModel despesaVM);
        Task<DespesaDto> ObterDespesaPorId(Guid idDespesa);
        Task DeletarDespesa(Guid idDespesa);
    }
}
