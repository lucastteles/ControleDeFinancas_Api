using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeFinancas.Domain.Entidade
{
    public class EntidadeBase
    {
        public EntidadeBase()
        {
            Id= Guid.NewGuid();
            DataDespesa = DateTime.Now;
        }


        public Guid Id { get; set; }

        public DateTime DataDespesa { get; set; }
    }
}
