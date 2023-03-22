namespace P01.CalculadoraConsole
{
     internal class Program
     { 
          static string[] descricaoOperacoes = new string[100];

          static int quantidadeOperacoes = 0;

          #region Critérios;
          //01 : Nossa calculadora deve ter a possibilidade de somar dois números
          //02 : Nossa calculadora deve ter a possibilidade fazer várias operações de soma
          //03 : Nossa calculadora deve ter a possibilidade fazer várias operações de soma e de subtração
          //04 : Nossa calculadora deve ter a possibilidade fazer as quatro operações básicas da matemática
          //05 : Nossa calculadora deve realizar as operações com "0"
          //06 : Nossa calculadora deve validar a opções do menu 
          //07 : Nossa calculadora deve realizar as operações com números com duas casas decimais
          //08 : Nossa calculadora deve permitir visualizar as operações já realizadas
          #endregion

          #region Funções Calculadora;
          static string MostrarMenu()
          {
               Console.Clear();
               Console.ForegroundColor = ConsoleColor.White;
               Console.WriteLine("==============================");
               Console.WriteLine("\nCalculadora App 2023");
               Console.WriteLine("\n==============================");
               Console.WriteLine("\nEscolha uma das opções abaixo: ");
               Console.WriteLine("\nDigite + para somar; ");
               Console.WriteLine("\nDigite - para subtrair; ");
               Console.WriteLine("\nDigite * para multiplicar; ");
               Console.WriteLine("\nDigite / para dividir; ");
               Console.WriteLine("\nDigite # para tabuada; ");
               Console.WriteLine("\nDigite = para ver o histórico; ");
               Console.Write("\nDigite S para sair.\n\n> ");

               string opcao = Console.ReadLine();
               return opcao;
          }

          static void SairPrograma()
          {
               Console.ForegroundColor = ConsoleColor.Red;
               Console.WriteLine("\nSaindo...");
               Console.ForegroundColor = ConsoleColor.White;
          }

          static bool OpcaoInvalida(string opcao)
          {
               return 
                    opcao != "+" && 
                    opcao != "-" && 
                    opcao != "=" && 
                    opcao != "/" && 
                    opcao != "*" && 
                    opcao != "s" && 
                    opcao != "S" && 
                    opcao != "#";
          }

          static void ApresentarMensagem(string mensagem, string tipo)
          {
               if (tipo == "ERRO")
               {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(mensagem);
                    Console.ReadLine();
                    Console.ResetColor();
               }
               else
               {
                    Console.WriteLine(mensagem);
                    Console.ReadLine();
               }
          }

          static void GerarTabuada()
          {
               Console.Write("\nDigite a tabuada que deseja:\n\n> ");
               int tabuada = 0;
               tabuada = Convert.ToInt32(Console.ReadLine());
               Console.WriteLine($"\nTabuada do {tabuada}:");
               for (int i = 1; i <= 10; i++)
               {
                    int resto = i % 2;
                    if (resto == 0)

                         Console.ForegroundColor = ConsoleColor.Blue;

                    else

                         Console.ForegroundColor = ConsoleColor.White;

                    int resultadoMultiplicacao = tabuada * i;

                    Console.WriteLine("\n" + tabuada + " X " + i + " = " + resultadoMultiplicacao);

               }

               Console.ReadLine();
               Console.BackgroundColor = ConsoleColor.Black;
          }

          static void HistoricoOperacoes()
          {

               Console.ForegroundColor = ConsoleColor.Cyan;
               Console.WriteLine("\n=========<<Histórico>>=========\n");
               Console.ForegroundColor = ConsoleColor.White;

               for (int i = 0; i < descricaoOperacoes.Length; i++)
               {
                    if (descricaoOperacoes[i] != null)
                         Console.WriteLine($"\n{descricaoOperacoes[i]}");
               }

               Console.ReadLine();
          }

          static double ObterNumero(string mensagem)
          {
               Console.WriteLine();
               Console.Write(mensagem);
               double numero = Convert.ToDouble(Console.ReadLine());
               return numero;
          }

          static void RealizarOperacoes(string opcao)
          {
               double primeiroNumero = ObterNumero("\nDigite o primeiro número:\n> ");

               double segundoNumero = ObterNumero("\nDigite o segundo número:\n> ");

               double resultado = ObterResultado(opcao, primeiroNumero, ref segundoNumero);

               ApresentarMensagem($"\nO resultado da operação é {resultado}", "SUCESSO");

               string sinalOperacao = ObterSinalOperacao(opcao);

               RegistrarCalculos(primeiroNumero, segundoNumero, resultado, sinalOperacao);

          }

          static void RegistrarCalculos(double primeiroNumero, double segundoNumero, double resultado, string sinalOperacao)
          {
               descricaoOperacoes[quantidadeOperacoes] = primeiroNumero + " " + sinalOperacao + " " + segundoNumero + " = " + resultado;
               quantidadeOperacoes++;
          }

          static string ObterSinalOperacao(string opcao)
          {
               string sinalOperacao = "";

               switch (opcao)
               {
                    case "+": sinalOperacao = "+"; break;
                    case "*": sinalOperacao = "*"; break;
                    case "/": sinalOperacao = "/"; break;
                    case "-": sinalOperacao = "-"; break;
                    default: break;
               }

               return sinalOperacao;
          }

          static double ObterResultado(string opcao, double primeiroNumero, ref double segundoNumero)
          {
               double resultado = 0;

               switch (opcao)
               {
                    case "+": resultado = primeiroNumero + segundoNumero; Console.ForegroundColor = ConsoleColor.Green; break;
                    case "-": resultado = primeiroNumero - segundoNumero; Console.ForegroundColor = ConsoleColor.Magenta; break;
                    case "*": resultado = primeiroNumero * segundoNumero; Console.ForegroundColor = ConsoleColor.DarkYellow; break;
                    case "/":
                         {
                              while (segundoNumero == 0)
                              {
                                   ApresentarMensagem("\nO segundo número não pode ser 0, tente novamente.", "ERRO");                                  
                                   Console.Clear();
                                   Console.Write("\nDigite o segundo número:\n> ");
                                   segundoNumero = Convert.ToDouble(Console.ReadLine());
                              }

                              Console.ForegroundColor = ConsoleColor.DarkGray;
                              break;
                         }

                    default: break;
               }

               return Math.Round(resultado, 2);
          }

          #endregion

          static void Main(string[] args)
          {
               do
               {
                    string opcao = MostrarMenu();

                    if (opcao == "s" || opcao == "S")
                    {
                         SairPrograma();
                         break;
                    }

                    if (OpcaoInvalida(opcao))
                    {
                         ApresentarMensagem("\nInsira uma opção válida!", "ERRO");
                         continue;
                    }

                    if (opcao == "#")
                    {
                         GerarTabuada();
                         continue;
                    }

                    if (opcao == "=")
                    {
                         HistoricoOperacoes();
                         continue;
                    }

                    RealizarOperacoes(opcao);

               } while (true);
          }


     }
}