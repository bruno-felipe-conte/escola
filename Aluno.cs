using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace escola
{
    internal class Aluno
    {
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public string Curso { get; set; }
        public List<Nota> Notas { get; set; }

        public Aluno(string nome, string matricula, string curso)
        {
            Nome = nome;
            Matricula = matricula;
            Curso = curso;
            Notas = new List<Nota>();
        }

        public void AdicionarNota(Avaliacao avaliacao, double valor)
        {
            Notas.Add(new Nota(avaliacao, valor));
        }

        public double CalcularMedia()
        {
            double somaNotas = 0;
            int somaPesos = 0;
            foreach (var nota in Notas)
            {
                somaNotas += nota.Valor * nota.Avaliacao.Peso;
                somaPesos += nota.Avaliacao.Peso;
            }
            return somaPesos > 0 ? somaNotas / somaPesos : 0;
        }
    }
}
