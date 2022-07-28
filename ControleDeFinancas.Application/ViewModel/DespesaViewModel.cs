using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeFinancas.Application.ViewModel
{
    public class DespesaViewModel
    {
        public Guid DepesaId { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public bool StatusPagamento { get; set; }
        public DateTime Vencimento { get; set; }
    }
}
