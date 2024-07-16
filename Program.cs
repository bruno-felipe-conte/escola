namespace escola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Lista de disciplinas e alunos
            List<Disciplina> disciplinas = new List<Disciplina>
            {
                new Disciplina("Matemática", "MAT101", 60),
                new Disciplina("História", "HIS201", 40),
                new Disciplina("Física", "FIS301", 50)
            };

            List<Aluno> alunos = new List<Aluno>
            {
                new Aluno("João Silva", "2021001", "Engenharia"),
                new Aluno("Maria Souza", "2021002", "História"),
                new Aluno("Pedro Oliveira", "2021003", "Física")
            };

            // Configurar avaliações
            disciplinas[0].AdicionarAvaliacao("Prova 1", 1);
            disciplinas[0].AdicionarAvaliacao("Prova 2", 2);
            disciplinas[1].AdicionarAvaliacao("Trabalho 1", 1);
            disciplinas[1].AdicionarAvaliacao("Trabalho 2", 3);
            disciplinas[2].AdicionarAvaliacao("Prova 1", 1);
            disciplinas[2].AdicionarAvaliacao("Prova 2", 2);

            while (true)
            {
                Console.WriteLine("\nEscolha uma opção:");
                Console.WriteLine("1. Configurar nova matéria");
                Console.WriteLine("2. Avaliar alunos de uma matéria específica");
                Console.WriteLine("3. Sair");

                string escolha = Console.ReadLine();

                if (escolha == "1")
                {
                    // Configurar nova matéria
                    try
                    {
                        Console.WriteLine("Nome da matéria:");
                        string nome = Console.ReadLine();
                        Console.WriteLine("Código da matéria:");
                        string codigo = Console.ReadLine();
                        Console.WriteLine("Carga horária:");
                        int cargaHoraria = int.Parse(Console.ReadLine());

                        Disciplina novaDisciplina = new Disciplina(nome, codigo, cargaHoraria);
                        for (int i = 0; i < 6; i++)
                        {
                            Console.WriteLine("Adicionar avaliação? (s/n)");
                            if (Console.ReadLine().ToLower() == "s")
                            {
                                Console.WriteLine("Descrição da avaliação:");
                                string descricao = Console.ReadLine();
                                Console.WriteLine("Peso da avaliação (1, 2, 3 ou 4):");
                                int peso = int.Parse(Console.ReadLine());

                                if (peso < 1 || peso > 4)
                                {
                                    Console.WriteLine("Peso inválido. Deve ser 1, 2, 3 ou 4.");
                                    i--;
                                    continue;
                                }

                                novaDisciplina.AdicionarAvaliacao(descricao, peso);
                            }
                            else
                            {
                                break;
                            }
                        }
                        disciplinas.Add(novaDisciplina);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Erro: A carga horária e o peso devem ser números inteiros.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro inesperado: {ex.Message} // Evite inserir caracteres não condizentes com o requisitado");
                    }
                }
                else if (escolha == "2")
                {
                    try
                    {
                        // Avaliar alunos de uma matéria específica
                        Console.WriteLine("Selecione a matéria:");
                        for (int i = 0; i < disciplinas.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {disciplinas[i].Nome}");
                        }

                        int indiceDisciplina = int.Parse(Console.ReadLine()) - 1;
                        if (indiceDisciplina < 0 || indiceDisciplina >= disciplinas.Count)
                        {
                            Console.WriteLine("Índice inválido. Selecione uma matéria válida.");
                            continue;
                        }
                        Disciplina disciplinaSelecionada = disciplinas[indiceDisciplina];

                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Nome do aluno:");
                                string nomeAluno = Console.ReadLine();
                                Console.WriteLine("Matrícula do aluno:");
                                string matriculaAluno = Console.ReadLine();
                                Console.WriteLine("Curso do aluno:");
                                string cursoAluno = Console.ReadLine();

                                Aluno novoAluno = new Aluno(nomeAluno, matriculaAluno, cursoAluno);

                                foreach (var avaliacao in disciplinaSelecionada.Avaliacoes)
                                {
                                    try
                                    {
                                        Console.WriteLine($"Nota para {avaliacao.Descricao}:");
                                        double nota = double.Parse(Console.ReadLine());
                                        if (nota < 0 || nota > 10)
                                        {
                                            Console.WriteLine("Nota inválida. Deve ser um valor entre 0 e 10.");
                                            continue;
                                        }
                                        novoAluno.AdicionarNota(avaliacao, nota);
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Erro: A nota deve ser um número decimal.");
                                    }
                                }

                                alunos.Add(novoAluno);

                                Console.WriteLine("Adicionar mais alunos? (s/n)");
                                if (Console.ReadLine().ToLower() == "n")
                                {
                                    break;
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Erro inesperado ao adicionar aluno: {ex.Message}  // Evite inserir caracteres não condizentes com o requisitado");
                            }
                        }

                        // Exibir lista de alunos, suas médias e status de aprovação
                        Console.WriteLine("\nLista de alunos e suas médias:");
                        foreach (var aluno in alunos)
                        {
                            double media = aluno.CalcularMedia();
                            string status = media >= 6 ? "Aprovado" : "Reprovado";
                            Console.WriteLine($"Aluno: {aluno.Nome}, Média: {media:F2}, Status: {status}");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Erro: O índice da matéria deve ser um número inteiro.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro inesperado ao avaliar alunos: {ex.Message} // Evite inserir caracteres não condizentes com o requisitado");
                    }
                }
                else if (escolha == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Opção inválida. Por favor, escolha 1, 2 ou 3.");
                }
            }
        }
    }
}