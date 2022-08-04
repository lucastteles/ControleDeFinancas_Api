using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeFinancas.Domain.Entidade
{
    public class Despesa : EntidadeBase
    {

        private Despesa() { }


        public Despesa(string nome, decimal valor, DateTime vencimento, bool statusPagamento)
        {
            Nome = nome;
            Valor = valor;
            Vencimento = vencimento;
            StatusPagamento = statusPagamento;

            ValidarNome();
            ValidarMaximo100Caracteres();
            ValidarValor();
            ValidarData();
        }


        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public DateTime Vencimento { get; set; }
        public bool StatusPagamento { get; set; }

        private void ValidarNome()
        {
            if (string.IsNullOrEmpty(Nome))
            {
                throw new Exception("O campo nome não pode ser vazio");
            }
        }

        private void ValidarMaximo100Caracteres()
        {
            if (Nome.Length > 100)
            {
                throw new Exception("O campo nome não pode ser maior que 100 caracteres");
            }
        }

        private void ValidarValor()
        {
            if (Valor <= 0)
            {
                throw new Exception("O campo Valor não pode ser menor ou igual a zero");
            }
        }
        private void ValidarData()
        {
            if (Vencimento.Date < DateTime.Now.Date)
            {
                throw new Exception("O campo Vencimento não pode ser menor do que a data atual ");
            }
        }
        public void AtualizarDadosDaDespesa(string nome, decimal valor, DateTime vencimento, bool statusPagamento)
        {
            Nome = nome;
            Valor = valor;
            Vencimento = vencimento;
            StatusPagamento = statusPagamento;

            ValidarNome();
            ValidarMaximo100Caracteres();
            ValidarValor();
            ValidarData();


        }

    }
}
