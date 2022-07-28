using ControleDeFinancas.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeFinancas.Domain.Repositories
{
    public interface IDespesaRepository
    {
        Task AdicionarDepesa(Despesa despesa);
        Task AtualizarDespesa(Despesa despesa);
        Task<Despesa> ObterDespesaPorId(Guid idDespesa);
        Task<List<Despesa>> ObterTodasDepesas();
        public Task Deletar(Guid idDepesa);
    }
}
