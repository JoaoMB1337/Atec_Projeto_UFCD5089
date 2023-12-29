using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Projeto_UFCD5089
{
    internal class GestorFicheiros
    {
        //Função para carregar lista de veiculos via arquivo CSV
        public static List<Veiculo> CarregarListaViaArquivo(string caminhoArquivo)
        {
            List<Veiculo> listaVeiculos = new List<Veiculo>();

            try
            {
                if (!File.Exists(caminhoArquivo))
                {
                    File.Create(caminhoArquivo).Close();
                }

                using (StreamReader sr = new StreamReader(caminhoArquivo))
                {
                    string linha;
                    while ((linha = sr.ReadLine()) != null)
                    {
                        string[] dadosVeiculo = linha.Split(',');
                        int id = Convert.ToInt32(dadosVeiculo[0]);
                        int numeroPortas = Convert.ToInt32(dadosVeiculo[1]);
                        string tipoCaixa = dadosVeiculo[2];
                        int cilindrada = Convert.ToInt32(dadosVeiculo[3]);
                        int numeroEixos = Convert.ToInt32(dadosVeiculo[4]);
                        int maxPassageiros = Convert.ToInt32(dadosVeiculo[5]);
                        int pesoMaximo = Convert.ToInt32(dadosVeiculo[6]);
                        double valorAluguerDiario = Convert.ToDouble(dadosVeiculo[7]);
                        bool statusAluguer = Convert.ToBoolean(dadosVeiculo[8]);
                        bool statusManutencao = Convert.ToBoolean(dadosVeiculo[9]);
                        Veiculo novoVeiculo = new Veiculo(numeroPortas, tipoCaixa, cilindrada, numeroEixos, maxPassageiros, pesoMaximo, valorAluguerDiario, statusAluguer, statusManutencao);

                        listaVeiculos.Add(novoVeiculo);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("O arquivo não foi encontrado.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }

            return listaVeiculos;
        }

        //Obter ultimoID no arquivo
        public static int ObterUltimoId(string caminhoArquivo)
        {
            int ultimoId = 0;
            try
            {
                if (File.Exists(caminhoArquivo))
                {
                    string[] linhas = File.ReadAllLines(caminhoArquivo);

                    if (linhas.Length > 0)
                    {
                        var ids = linhas.Select(line => int.Parse(line.Split(',')[0]));
                        ultimoId = ids.Max();
                    }
                }
            }
            catch (FileNotFoundException){
                Console.WriteLine("O arquivo não foi encontrado.");
            }
            catch (IOException ex){
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }
            Veiculo.DefinirUltimoId(ultimoId); 
            return ultimoId;
        }

        //Escrever lista de veiculos no CSV
        public static void EscreverCSV(List<Veiculo> listaVeiculos, string nomeArquivo)
        {
            try
            {
                if (!File.Exists(nomeArquivo))
                {
                    File.Create(nomeArquivo).Close(); 
                }
                using (StreamWriter sw = new StreamWriter(nomeArquivo))
                {
                    foreach (Veiculo veiculo in listaVeiculos)
                    {
                        string linha = $"{veiculo.Id},{veiculo.NumeroPortas},{veiculo.TipoCaixa},{veiculo.Cilindrada},{veiculo.NumeroEixos},{veiculo.MaxPassageiros},{veiculo.PesoMaximo}," +
                            $"{veiculo.ValorAluguerDiario},{veiculo.StatusAluguer},{veiculo.StatusManutencao}";
                        sw.WriteLine(linha);
                    }
                }

                Console.WriteLine($"Os dados foram escritos no arquivo '{nomeArquivo}' com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }
        }

        //Atualizar estado de aluguel no CSV
        public static void AtualizarEstadoAluguelVeiculo(List<Veiculo> listaVeiculos, string nomeArquivo)
        {
            try
            {
                if (!File.Exists(nomeArquivo))
                {
                    File.Create(nomeArquivo).Close();
                }

                using (StreamWriter sw = new StreamWriter(nomeArquivo))
                {
                    foreach (Veiculo veiculo in listaVeiculos)
                    {
                        string estadoAluguel = veiculo.StatusAluguer ? "True" : "False";
                        string linha = $"{veiculo.Id},{veiculo.NumeroPortas},{veiculo.TipoCaixa},{veiculo.Cilindrada},{veiculo.NumeroEixos}," +
                                        $"{veiculo.MaxPassageiros},{veiculo.PesoMaximo},{veiculo.ValorAluguerDiario},{estadoAluguel},{veiculo.StatusManutencao}";
                        sw.WriteLine(linha);
                    }
                }

                Console.WriteLine($"O estado de aluguel foi atualizado no arquivo '{nomeArquivo}' com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }
        }

        //Atualizar estado de manutenção no CSV
        public static void AtulizarEstadoManutençãoVeiculo(List<Veiculo> listaVeiculos, string nomeArquivo)
        {
            try
            {
                if (!File.Exists(nomeArquivo))
                {
                   File.Create(nomeArquivo).Close(); 
                }

                using (StreamWriter sw = new StreamWriter(nomeArquivo))
                {
                    foreach (Veiculo veiculo in listaVeiculos)
                    {
                        string estadoManutencao = veiculo.StatusManutencao ? "True" : "False";
                        string linha = $"{veiculo.Id},{veiculo.NumeroPortas},{veiculo.TipoCaixa},{veiculo.Cilindrada},{veiculo.NumeroEixos}," +
                                        $"{veiculo.MaxPassageiros},{veiculo.PesoMaximo},{veiculo.ValorAluguerDiario},{veiculo.StatusAluguer},{estadoManutencao}";
                        sw.WriteLine(linha);
                    }
                }

                Console.WriteLine($"O estado de manutenção foi atualizado no arquivo '{nomeArquivo}' com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }
        }
    }
}
