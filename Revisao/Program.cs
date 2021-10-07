using System;
using System.Globalization;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {

            Aluno[] alunos = new Aluno[5];

            int indiceAluno = 0;

            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":

                        Console.Write("Informe o nome do aluno: ");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.Write("Informe a nota do aluno: ");

                        if(decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException("O valor da nota deve ser decimal!");
                        }
                        
                        alunos[indiceAluno] = aluno;
                        indiceAluno++;

                        break;

                    case "2":
                        
                        foreach(var a in alunos)
                        {
                            if (!(a.Nome == null))
                            {
                                Console.WriteLine($"ALUNO(A): {a.Nome} \t- NOTA: {a.Nota.ToString("F1", CultureInfo.InvariantCulture)}");
                            }
                                
                        }

                        break;

                    case "3":
                        
                        decimal notaTotal = 0;
                        int numeroDeAlunos = 0;

                        for(int i=0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal += alunos[i].Nota;
                                numeroDeAlunos++;
                            }
                        }

                        decimal mediaGeral = notaTotal / numeroDeAlunos;

                        Conceito conceitoGeral;

                        if (mediaGeral <= 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if (mediaGeral <= 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if (mediaGeral <= 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if (mediaGeral <= 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        {
                            conceitoGeral = Conceito.A;
                        }

                        Console.WriteLine($"MÉDIA GERAL: {mediaGeral.ToString("F1", CultureInfo.InvariantCulture)} \t- CONCEITO GERAL: {conceitoGeral}");
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
                
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Inserir novo Aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
