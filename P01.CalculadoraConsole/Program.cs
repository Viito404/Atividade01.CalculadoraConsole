namespace P01.CalculadoraConsole
{
     internal class Program
     {
          static void Main(string[] args)
          {
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

               #region Declaração da Array que será utilizada no histórico;

               string[] historicoOperacoes = new string[100];

               int quantidadeOperacoes = 0;
               #endregion

               do
               {
                    #region Opções de menu;

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

                    #endregion

                    #region Opção para sair;

                    if (opcao == "s" || opcao == "S")
                    {
                         Console.ForegroundColor = ConsoleColor.Red;
                         Console.WriteLine("\nSaindo...");
                         Console.ForegroundColor = ConsoleColor.White;
                         break;
                    }

                    #endregion

                    #region Verifica se a opção desejada é válida;

                    if (opcao != "+" && opcao != "-" && opcao != "=" && opcao != "/" && opcao != "*" && opcao != "s" && opcao != "S" && opcao != "#")
                    {
                         Console.WriteLine("\nInsira um comando válido!");
                         Console.ReadLine();
                         continue;
                    }

                    #endregion

                    #region Opção de tabuada; 

                    if (opcao == "#")
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

                              Console.WriteLine("\n" +tabuada + " X " +i+ " = " +resultadoMultiplicacao);

                         }

                         Console.ReadLine();
                         Console.BackgroundColor = ConsoleColor.Black;
                         continue;

                    }

                    #endregion

                    #region Opção de histórico de operações;

                    if (opcao == "=")
                    {
                         Console.ForegroundColor = ConsoleColor.Cyan;
                         Console.WriteLine("\n=========<<Histórico>>=========\n");
                         Console.ForegroundColor = ConsoleColor.White;

                         for (int i = 0; i < historicoOperacoes.Length; i++)
                         {              
                              if (historicoOperacoes[i] != null)
                              Console.WriteLine($"\n{historicoOperacoes[i]}");
                         }

                         Console.ReadLine();
                         continue;
                    }

                    #endregion

                    #region Entrada dos valores;

                    Console.WriteLine();

                    Console.Write("\nDigite o primeiro número:\n> ");

                    double primeiroNumero = Convert.ToDouble(Console.ReadLine());

                    Console.Write("\nDigite o segundo número:\n> ");

                    double segundoNumero = Convert.ToDouble(Console.ReadLine());

                    #endregion

                    #region Escolha de operações; 

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
                                        Console.WriteLine("\nO segundo número não pode ser 0, tente novamente.");
                                        Console.ReadLine();
                                        Console.Write("\nDigite o segundo número:\n> ");
                                        segundoNumero = Convert.ToDouble(Console.ReadLine());
                                   }

                                   Console.ForegroundColor = ConsoleColor.DarkGray;
                                   break;
                              }

                         default: break;
                    }

                    #endregion

                    #region Formatação e impressão de operadores;

                    double resultaoFormatado = Math.Round(resultado, 2);

                    string sinalOperacao = "";

                    switch (opcao)
                    {
                         case "+": sinalOperacao = "+"; break;
                         case "*": sinalOperacao = "*"; break;
                         case "/": sinalOperacao = "/"; break;
                         case "-": sinalOperacao = "-"; break;
                         default: break;
                    }

                    #endregion

                    #region Alocação da operação na Array e impressão dos resultados;

                    historicoOperacoes[quantidadeOperacoes] = primeiroNumero + " " + sinalOperacao + " " + segundoNumero + " = " + resultaoFormatado;

                    Console.WriteLine($"\nO resultado da operação é {resultaoFormatado}");

                    Console.ReadLine();

                    quantidadeOperacoes++;

                    #endregion

               } while (true);
          }
     }
}