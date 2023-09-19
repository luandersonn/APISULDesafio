using System.Text.Json;

namespace APISULDesafio
{
    public class ElevadorService : IElevadorService
    {
        private readonly MoradorResposta[] listaDeRespostas;

        public ElevadorService(string jsonFilePath)
        {
            string json = File.ReadAllText(jsonFilePath);
            listaDeRespostas = JsonSerializer.Deserialize<MoradorResposta[]>(json);
        }

        public List<int> andarMenosUtilizado()
        {
            if (listaDeRespostas.Length == 0)
                return new List<int>();

            var respostas = listaDeRespostas.GroupBy(r => r.Andar) // Agrupa por andar
                                            .Select(g => new
                                            {
                                                Andar = g.Key,
                                                QtdUtilizacao = g.Count()  // Conta a utilização por andar
                                            });

            var menor = respostas.MinBy(a => a.QtdUtilizacao); // Obtem o menor baseado na quantidade de utilização

            // retorna todos os itens com quantidade de uso igual ao menor da coleção
            return respostas.Where(x => x.QtdUtilizacao == menor.QtdUtilizacao)
                            .Select(x => x.Andar) // Somente o número andar
                            .ToList();
        }

        public List<char> elevadorMaisFrequentado()
        {
            if (listaDeRespostas.Length == 0)
                return new List<char>();

            var respostas = listaDeRespostas.GroupBy(r => r.Elevador) // Agrupa por elevador
                                            .Select(g => new
                                            {
                                                Elevador = g.Key,
                                                QtdUtilizacao = g.Count()  // Conta a utilização por elevador
                                            });

            var maior = respostas.MaxBy(a => a.QtdUtilizacao); // Obtem o maior baseado na quantidade de utilização

            // retorna todos os itens com quantidade de uso igual ao maior da coleção
            return respostas.Where(x => x.QtdUtilizacao == maior.QtdUtilizacao)
                            .Select(x => x.Elevador[0]) // Somente o nome do elevador
                            .ToList();
        }

        public List<char> elevadorMenosFrequentado()
        {
            if (listaDeRespostas.Length == 0)
                return new List<char>();

            var respostas = listaDeRespostas.GroupBy(r => r.Elevador) // Agrupa por elevador
                                            .Select(g => new
                                            {
                                                Elevador = g.Key,
                                                QtdUtilizacao = g.Count()  // Conta a utilização por elevador
                                            });

            var menor = respostas.MinBy(a => a.QtdUtilizacao); // Obtem o menor baseado na quantidade de utilização

            // retorna todos os itens com quantidade de uso igual ao menor da coleção
            return respostas.Where(x => x.QtdUtilizacao == menor.QtdUtilizacao)
                            .Select(x => x.Elevador[0]) // Somente o nome do elevador
                            .ToList();
        }

        public float percentualDeUsoElevadorA()
        {
            if (listaDeRespostas.Length == 0) // Não divida por zero
                return 0;
            return listaDeRespostas.Count(x => x.Elevador == "A") / (float)listaDeRespostas.Length;
        }

        public float percentualDeUsoElevadorB()
        {
            if (listaDeRespostas.Length == 0)
                return 0;
            return listaDeRespostas.Count(x => x.Elevador == "B") / (float)listaDeRespostas.Length;
        }

        public float percentualDeUsoElevadorC()
        {
            if (listaDeRespostas.Length == 0)
                return 0;
            return listaDeRespostas.Count(x => x.Elevador == "C") / (float)listaDeRespostas.Length;
        }

        public float percentualDeUsoElevadorD()
        {
            if (listaDeRespostas.Length == 0)
                return 0;
            return listaDeRespostas.Count(x => x.Elevador == "D") / (float)listaDeRespostas.Length;
        }

        public float percentualDeUsoElevadorE()
        {
            if (listaDeRespostas.Length == 0)
                return 0;
            return listaDeRespostas.Count(x => x.Elevador == "E") / (float)listaDeRespostas.Length;
        }

        public List<char> periodoMaiorFluxoElevadorMaisFrequentado()
        {
            List<char> periodosDeMaiorFluxo = new List<char>();

            // Obtem a lista de elevadores mais frequentados
            foreach (char elevador in elevadorMaisFrequentado())
            {
                // Obtem o período de mais fluxo dos elevadores mais frequentados
                periodosDeMaiorFluxo.AddRange(ObterPeriodoDeMaiorFluxoPorElevador(elevador.ToString()));
            }
            return periodosDeMaiorFluxo;
        }


        public List<char> periodoMenorFluxoElevadorMenosFrequentado()
        {
            List<char> periodosDeMenorFluxo = new List<char>();

            // Obtem a lista de elevadores menos frequentados
            foreach (char elevador in elevadorMenosFrequentado())
            {
                // Obtem o período de menor fluxo dos elevadores menos frequentados
                periodosDeMenorFluxo.AddRange(ObterPeriodoDeMenorFluxoPorElevador(elevador.ToString()));
            }
            return periodosDeMenorFluxo;
        }

        public List<char> periodoMaiorUtilizacaoConjuntoElevadores()
        {
            var respostas = listaDeRespostas.GroupBy(r => r.Turno) // Agrupa por turno
                                            .Select(g => new
                                            {
                                                Turno = g.Key,
                                                QtdUtilizacao = g.Count()  // Conta a utilização por turno
                                            });

            var maior = respostas.MaxBy(a => a.QtdUtilizacao); // Obtem o maior baseado na quantidade de utilização

            // retorna todos os itens com quantidade de uso igual ao maior da coleção
            return respostas.Where(x => x.QtdUtilizacao == maior.QtdUtilizacao)
                            .Select(x => x.Turno[0])
                            .ToList();
        }


        /// <summary>
        /// Retorna a lista de turno mais utilizado de um elevador especifíco
        /// </summary>
        /// <param name="elevador">Letra do elevador</param>
        /// <returns></returns>
        private List<char> ObterPeriodoDeMaiorFluxoPorElevador(string elevador)
        {
            var respostas = listaDeRespostas.Where(r => r.Elevador == elevador)
                                            .GroupBy(r => r.Turno) // Agrupa por turno
                                            .Select(g => new
                                            {
                                                Turno = g.Key,
                                                QtdUtilizacao = g.Count()  // Conta a utilização por turno
                                            });

            var maior = respostas.MaxBy(a => a.QtdUtilizacao); // Obtem o maior baseado na quantidade de utilização

            // retorna todos os itens com quantidade de uso igual ao maior da coleção
            return respostas.Where(x => x.QtdUtilizacao == maior.QtdUtilizacao)
                            .Select(x => x.Turno[0])
                            .ToList();
        }

        /// <summary>
        /// Retorna a lista de turno menos utilizado de um elevador especifíco
        /// </summary>
        /// <param name="elevador">Letra do elevador</param>
        /// <returns></returns>
        private List<char> ObterPeriodoDeMenorFluxoPorElevador(string elevador)
        {
            var respostas = listaDeRespostas.Where(r => r.Elevador == elevador)
                                            .GroupBy(r => r.Turno) // Agrupa por turno
                                            .Select(g => new
                                            {
                                                Turno = g.Key,
                                                QtdUtilizacao = g.Count()  // Conta a utilização por turno
                                            });

            var menor = respostas.MinBy(a => a.QtdUtilizacao); // Obtem o menor baseado na quantidade de utilização

            // retorna todos os itens com quantidade de uso igual ao menor da coleção
            return respostas.Where(x => x.QtdUtilizacao == menor.QtdUtilizacao)
                            .Select(x => x.Turno[0])
                            .ToList();
        }
    }

}