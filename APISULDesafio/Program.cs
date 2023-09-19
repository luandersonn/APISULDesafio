namespace APISULDesafio
{
    // .NET 6
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string filePath;
                do
                {
                    Console.WriteLine("Digite o PATH do arquivo json");
                    filePath = Console.ReadLine();
                } while (!File.Exists(filePath));

                IElevadorService elevadorService = new ElevadorService(filePath);

                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Digite a opção (Arquivo: {0})", filePath);
                    Console.WriteLine("[1]. Andares menos utilizado pelos usuários");
                    Console.WriteLine("[2]. Elevador mais frequentado");
                    Console.WriteLine("[3]. Elevador menos frequentado");
                    Console.WriteLine("[4]. Período de maior fluxo dos elevadores mais frequentados");
                    Console.WriteLine("[5]. Período de menor fluxo dos elevadores menos frequentados");
                    Console.WriteLine("[6]. Período de maior utilização de todos os elevadores");
                    Console.WriteLine("[7]. Percental de utilização de cada elevador");
                    Console.WriteLine("[8]. Sair");

                    switch (Console.ReadKey().KeyChar)
                    {
                        case '1':
                            Console.Clear();
                            Console.WriteLine("-------------------------------");
                            Console.WriteLine("[1]. Andares menos utilizado pelos usuários");
                            Console.WriteLine(string.Join(", ", elevadorService.andarMenosUtilizado()));
                            Console.WriteLine("-------------------------------");
                            break;

                        case '2':
                            Console.Clear();
                            Console.WriteLine("-------------------------------");
                            Console.WriteLine("[2]. Elevadores mais frequentados");
                            Console.WriteLine(string.Join(", ", elevadorService.elevadorMaisFrequentado()));
                            Console.WriteLine("-------------------------------");
                            break;

                        case '3':
                            Console.Clear();
                            Console.WriteLine("-------------------------------");
                            Console.WriteLine("[3]. Elevadores menos frequentados");
                            Console.WriteLine(string.Join(", ", elevadorService.elevadorMenosFrequentado()));
                            Console.WriteLine("-------------------------------");
                            break;

                        case '4':
                            Console.Clear();
                            Console.WriteLine("-------------------------------");
                            Console.WriteLine("[4]. Período de maior fluxo dos elevadores mais frequentados (M: Matutino; V: Vespertino; N: Noturno)");
                            Console.WriteLine("Elevadores mais frequentados: {0}", string.Join(", ", elevadorService.elevadorMaisFrequentado()));
                            Console.WriteLine("Turnos mais frequentados: {0}", string.Join(", ", elevadorService.periodoMaiorFluxoElevadorMaisFrequentado()));
                            Console.WriteLine("-------------------------------");
                            break;

                        case '5':
                            Console.Clear();
                            Console.WriteLine("-------------------------------");
                            Console.WriteLine("[5]. Período de menor fluxo dos elevadores menos frequentados (M: Matutino; V: Vespertino; N: Noturno)");
                            Console.WriteLine("Elevadores menos frequentados: {0}", string.Join(", ", elevadorService.elevadorMenosFrequentado()));
                            Console.WriteLine("Turnos menos frequentados: {0}", string.Join(", ", elevadorService.periodoMenorFluxoElevadorMenosFrequentado()));
                            Console.WriteLine("-------------------------------");
                            break;

                        case '6':
                            Console.Clear();
                            Console.WriteLine("-------------------------------");
                            Console.WriteLine("[6]. Período de maior utilização de todos os elevadores (M: Matutino; V: Vespertino; N: Noturno)");
                            Console.WriteLine(string.Join(", ", elevadorService.periodoMaiorUtilizacaoConjuntoElevadores()));
                            Console.WriteLine("-------------------------------");
                            break;

                        case '7':
                            Console.Clear();
                            Console.WriteLine("-------------------------------");
                            Console.WriteLine("[7]. Percental de utilização de cada elevador");
                            Console.WriteLine("Elevador A: {0}%", Math.Round(elevadorService.percentualDeUsoElevadorA() * 100, 2));
                            Console.WriteLine("Elevador B: {0}%", Math.Round(elevadorService.percentualDeUsoElevadorB() * 100, 2));
                            Console.WriteLine("Elevador C: {0}%", Math.Round(elevadorService.percentualDeUsoElevadorC() * 100, 2));
                            Console.WriteLine("Elevador D: {0}%", Math.Round(elevadorService.percentualDeUsoElevadorD() * 100, 2));
                            Console.WriteLine("Elevador E: {0}%", Math.Round(elevadorService.percentualDeUsoElevadorE() * 100, 2));
                            Console.WriteLine("-------------------------------");
                            break;

                        case '8':
                            Console.Clear();
                            return;

                        default:
                            Console.Clear();
                            Console.WriteLine("-------------------------------");
                            Console.WriteLine("Opção inválida");
                            Console.WriteLine("-------------------------------");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR {0}", ex);
            }
        }
    }
}