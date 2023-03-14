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

               string[] dop = new string[100];

               int qor = 0;
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

                    string op = Console.ReadLine();

                    #endregion

                    #region Opção para sair;

                    if (op == "s" || op == "S")
                    {
                         Console.ForegroundColor = ConsoleColor.Red;
                         Console.WriteLine("\nSaindo...");
                         Console.ForegroundColor = ConsoleColor.White;
                         break;
                    }

                    #endregion

                    #region Verifica se a opção desejada é válida;

                    if (op != "+" && op != "-" && op != "=" && op != "/" && op != "*" && op != "s" && op != "S" && op != "#")
                    {
                         Console.WriteLine("\nInsira um comando válido!");
                         Console.ReadLine();
                         continue;
                    }

                    #endregion

                    #region Opção de tabuada; 

                    if (op == "#")
                    {
                         Console.Write("\nDigite a tabuada que deseja:\n\n> ");
                         int tb = 0;
                         tb = Convert.ToInt32(Console.ReadLine());
                         Console.WriteLine($"\nTabuada do {tb}:");
                         for (int i = 1; i <= 10; i++)
                         {
                              int res = i % 2;
                              if (res == 0)

                                   Console.ForegroundColor = ConsoleColor.Blue;

                              else

                                   Console.ForegroundColor = ConsoleColor.White;

                              int rm = tb * i;

                              Console.WriteLine("\n" +tb + " X " +i+ " = " +rm);

                         }

                         Console.ReadLine();
                         Console.BackgroundColor = ConsoleColor.Black;
                         continue;

                    }

                    #endregion

                    #region Opção de histórico de operações;

                    if (op == "=")
                    {
                         Console.ForegroundColor = ConsoleColor.Cyan;
                         Console.WriteLine("\n=========<<Histórico>>=========\n");
                         Console.ForegroundColor = ConsoleColor.White;

                         for (int i = 0; i < dop.Length; i++)
                         {              
                              if (dop[i] != null)
                              Console.WriteLine($"\n{dop[i]}");
                         }

                         Console.ReadLine();
                         continue;
                    }

                    #endregion

                    #region Entrada dos valores;

                    Console.WriteLine();

                    Console.Write("\nDigite o primeiro número:\n> ");

                    double pn = Convert.ToDouble(Console.ReadLine());

                    Console.Write("\nDigite o segundo número:\n> ");

                    double sn = Convert.ToDouble(Console.ReadLine());

                    #endregion

                    #region Escolha de operações; 

                    double rt = 0;

                    switch (op)
                    {
                         case "+": rt = pn + sn; Console.ForegroundColor = ConsoleColor.Green; break;
                         case "-": rt = pn - sn; Console.ForegroundColor = ConsoleColor.Magenta; break;
                         case "*": rt = pn * sn; Console.ForegroundColor = ConsoleColor.DarkYellow; break;
                         case "/":
                              {
                                   while (sn == 0)
                                   {
                                        Console.WriteLine("\nO segundo número não pode ser 0, tente novamente.");
                                        Console.ReadLine();
                                        Console.Write("\nDigite o segundo número:\n> ");
                                        sn = Convert.ToDouble(Console.ReadLine());
                                   }

                                   Console.ForegroundColor = ConsoleColor.DarkGray;
                                   break;
                              }

                         default: break;
                    }

                    #endregion

                    #region Formatação e impressão de operadores;

                    double rtf = Math.Round(rt, 2);

                    string sop = "";

                    switch (op)
                    {
                         case "+": sop = "+"; break;
                         case "*": sop = "*"; break;
                         case "/": sop = "/"; break;
                         case "-": sop = "-"; break;
                         default: break;
                    }

                    #endregion

                    #region Alocação da operação na Array e impressão dos resultados;

                    dop[qor] = pn + " " + sop + " " + sn + " = " + rtf;

                    Console.WriteLine($"\nO resultado da operação é {rtf}");

                    Console.ReadLine();

                    qor++;

                    #endregion

               } while (true);
          }
     }
}