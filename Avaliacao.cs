using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace escola
{
    internal class Avaliacao
    {
        public string Descricao { get; set; }
        public int Peso { get; set; }

        public Avaliacao(string descricao, int peso)
        {
            Descricao = descricao;
            Peso = peso;
        }
    }
}
