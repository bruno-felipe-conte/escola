using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace escola
{
    internal class Disciplina
    {
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public int CargaHoraria { get; set; }
        public List<Avaliacao> Avaliacoes { get; set; }

        public Disciplina(string nome, string codigo, int cargaHoraria)
        {
            Nome = nome;
            Codigo = codigo;
            CargaHoraria = cargaHoraria;
            Avaliacoes = new List<Avaliacao>();
        }

        public void AdicionarAvaliacao(string descricao, int peso)
        {
            Avaliacoes.Add(new Avaliacao(descricao, peso));
        }
    }
}
