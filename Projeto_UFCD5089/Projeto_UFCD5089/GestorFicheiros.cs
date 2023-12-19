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
        public void EscreverCSV(List<Veiculo> listaVeiculos, string nomeArquivo)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(nomeArquivo, true))
                {
                    foreach (Veiculo veiculo in listaVeiculos)
                    {
                        string linha = $"{veiculo.NumeroPortas},{veiculo.TipoCaixa},{veiculo.Cilindrada},{veiculo.NumeroEixos},{veiculo.MaxPassageiros},{veiculo.PesoMaximo}," +
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
                using (StreamWriter sw = new StreamWriter(nomeArquivo,true))
                {
                    foreach (Veiculo veiculo in listaVeiculos)
                    {
                        string estadoAluguel = veiculo.StatusAluguer ? "True" : "False";
                        string linha = $"{veiculo.NumeroPortas},{veiculo.TipoCaixa},{veiculo.Cilindrada},{veiculo.NumeroEixos}," +
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
                using (StreamWriter sw = new StreamWriter(nomeArquivo, true))
                {
                    foreach (Veiculo veiculo in listaVeiculos)
                    {
                        string estadoManutencao = veiculo.StatusManutencao ? "True" : "False";
                        string linha = $"{veiculo.NumeroPortas},{veiculo.TipoCaixa},{veiculo.Cilindrada},{veiculo.NumeroEixos}," +
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
