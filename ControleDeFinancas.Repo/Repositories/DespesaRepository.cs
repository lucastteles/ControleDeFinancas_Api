using ControleDeFinancas.Domain.Entidade;
using ControleDeFinancas.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeFinancas.Repo.Repositories
{
    public class DespesaRepository : IDespesaRepository
    {
        private readonly DespesaContext _despesaContext;

        public DespesaRepository(DespesaContext despesaContext)
        {
            _despesaContext = despesaContext;
        }

        public async Task AdicionarDepesa(Despesa despesa)
        {
            await _despesaContext.Despesa.AddAsync(despesa);
            _despesaContext.SaveChanges();
        }

        public async Task AtualizarDespesa(Despesa despesa)
        {
            _despesaContext.Despesa.Update(despesa);
            _despesaContext.SaveChanges();
        }

        public async Task<Despesa> ObterDespesaPorId(Guid idDespesa)
        {
            return await _despesaContext.Despesa.FirstOrDefaultAsync(x => x.Id == idDespesa);
        }


        public async Task<List<Despesa>> ObterTodasDepesas()
        {
            return await _despesaContext.Despesa.ToListAsync();
        }

        public async Task Deletar(Guid idDepesa)
        {
            var despesa = await ObterDespesaPorId(idDepesa);
            _despesaContext.Despesa.Remove(despesa);
            _despesaContext.SaveChanges();
        }

        public async Task<List<Despesa>> ObterDespesaPorMes(DateTime data)
        {
            return await _despesaContext.Despesa
                                        .Where(x=> x.Vencimento.Date.Month ==  data.Date.Month)
                                        .ToListAsync();
        }
    }
}
