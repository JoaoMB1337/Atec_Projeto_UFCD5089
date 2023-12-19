using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Projeto_UFCD5089
{
    internal class GestorFicheiros
    {
        public List<Veiculo> CarregarListaViaArquivo(string caminhoArquivo)
        {
            List<Veiculo> listaVeiculos = new List<Veiculo>();

            try
            {
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
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro ao ler o arquivo: " + e.Message);
            }

            return listaVeiculos;
        }

        public int ObterUltimoId(string caminhoArquivo)
        {
            int ultimoId = 0;

            if (File.Exists(caminhoArquivo))
            {
                string[] linhas = File.ReadAllLines(caminhoArquivo);

                if (linhas.Length > 0)
                {
                    var ids = linhas.Select(line => int.Parse(line.Split(',')[0]));
                    ultimoId = ids.Max();
                }
            }

            Veiculo.DefinirUltimoId(ultimoId); // Define o último ID na classe Veiculo
            return ultimoId;
        }

        public void EscreverCSV(List<Veiculo> listaVeiculos, string nomeArquivo)
        {
            try
            {
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
                Console.WriteLine($"Ocorreu um erro ao escrever no arquivo: {ex.Message}");
            }
        }

        public void AtualizarEstadoAluguelVeiculo(List<Veiculo> listaVeiculos, string nomeArquivo)
        {
            try
            {
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
                Console.WriteLine($"Ocorreu um erro ao atualizar o arquivo: {ex.Message}");
            }

        }

        public void AtulizarEstadoManutençãoVeiculo(List<Veiculo> listaVeiculos, string nomeArquivo)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(nomeArquivo))
                {
                    foreach (Veiculo veiculo in listaVeiculos)
                    {
                        string estadoManutencao = veiculo.StatusManutencao ? "True" : "False";
                        string linha = $"{veiculo.Id},{veiculo.NumeroPortas},{veiculo.TipoCaixa},{veiculo.Cilindrada},{veiculo.NumeroEixos}," +
                                        $"{veiculo.MaxPassageiros},{veiculo.PesoMaximo},{veiculo.ValorAluguerDiario},{estadoManutencao},{veiculo.StatusManutencao}";
                        sw.WriteLine(linha);
                    }
                }

                Console.WriteLine($"O estado de aluguel foi atualizado no arquivo '{nomeArquivo}' com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao atualizar o arquivo: {ex.Message}");
            }

        }
    }
}
