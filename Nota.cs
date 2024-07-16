using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace escola
{
    internal class Nota
    {
        public Avaliacao Avaliacao { get; set; }
        public double Valor { get; set; }

        public Nota(Avaliacao avaliacao, double valor)
        {
            Avaliacao = avaliacao;
            Valor = valor;
        }
    }
}
