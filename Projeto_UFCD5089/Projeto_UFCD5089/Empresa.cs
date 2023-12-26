using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Projeto_UFCD5089
{
    internal class Empresa
    {
        List<Veiculo> listaVeiculos = new List<Veiculo>();

        private static void ExibirDetalhesVeiculo(Veiculo veiculo)
        {
            Console.WriteLine($"Número de Portas: {veiculo.NumeroPortas}");
            Console.WriteLine($"Tipo de Caixa: {veiculo.TipoCaixa}");
            Console.WriteLine($"Cilindrada: {veiculo.Cilindrada}");
            Console.WriteLine($"Número de Eixos: {veiculo.NumeroEixos}");
            Console.WriteLine($"Máximo de Passageiros: {veiculo.MaxPassageiros}");
            Console.WriteLine($"Peso Máximo: {veiculo.PesoMaximo}");
            Console.WriteLine($"Valor de Aluguer Diário: {veiculo.ValorAluguerDiario}");
            Console.WriteLine("\n");
        }

        public void CarregarVeiculosDoArquivo(string caminhoArquivo)
        {
            int ultimoId = GestorFicheiros.ObterUltimoId(caminhoArquivo);
            Veiculo.DefinirUltimoId(ultimoId);
            listaVeiculos = GestorFicheiros.CarregarListaViaArquivo(caminhoArquivo);
        }


        #region Metodos de Edição de Veiculos
        public void AdicionarVeiculo(Veiculo veiculo)
        {
            if (!listaVeiculos.Contains(veiculo))
            {
                listaVeiculos.Add(veiculo);
                GestorFicheiros.EscreverCSV(listaVeiculos, @"veiculo.csv");
                Console.WriteLine("Veículo adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("O veículo já existe na lista.");
            }
        }

        public void AlugarVeiculo(int index)
        {
            if (index >= 0 && index < listaVeiculos.Count)
            {
                if (!listaVeiculos[index].StatusAluguer && !listaVeiculos[index].StatusManutencao)
                {
                    listaVeiculos[index].StatusAluguer = true;
                    GestorFicheiros.AtualizarEstadoAluguelVeiculo(listaVeiculos, @"veiculo.csv");
                    Console.WriteLine($"Veiculo {index + 1} alugado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Veiculo nao disponivel para aluguel.");
                }
            }
            else
            {
                Console.WriteLine("Indice de veiculo invalido.");
            }

        }

        public void ManutencaoVeiculo(int index)
        {
            if (index >= 0 && index < listaVeiculos.Count)
            {
                if (!listaVeiculos[index].StatusAluguer && !listaVeiculos[index].StatusManutencao)
                {
                    listaVeiculos[index].StatusManutencao = true;
                    GestorFicheiros.AtulizarEstadoManutençãoVeiculo(listaVeiculos, @"veiculo.csv");
                    Console.WriteLine($"Veículo {index + 1} colocado em manutenção com sucesso!");
                }
                else
                {
                    Console.WriteLine("Veículo não disponível para manutenção.");
                }
            }
            else
            {
                Console.WriteLine("Índice de veículo inválido.");
            }
        }

        public void RemoverVeiculo(int index)
        {
            if (index >= 0 && index < listaVeiculos.Count)
            {
                listaVeiculos.RemoveAt(index);
                GestorFicheiros.EscreverCSV(listaVeiculos, @"veiculo.csv");
                Console.WriteLine($"Veículo {index + 1} removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Índice de veículo inválido.");
            }
        }

        public void RemoverVeiculoManutencao(int index)
        {
            if (!listaVeiculos[index].StatusAluguer && listaVeiculos[index].StatusManutencao)
            {
                if (index >= 0 && index < listaVeiculos.Count)
                {
                    listaVeiculos[index].StatusManutencao = false;
                }
                else
                {
                    Console.WriteLine("Veículo não disponível para manutenção.");
                }
            }
            else
            {
                Console.WriteLine("Índice de veículo inválido.");
            }
        }

        //public void RemoverVeiculoAluguer(int index)
        //{
        //    if (!listaVeiculos[index].StatusAluguer && listaVeiculos[index].StatusManutencao)
        //    {
        //        if (index >= 0 && index < listaVeiculos.Count)
        //        {
        //            listaVeiculos[index].StatusManutencao = false;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Veículo não disponível para manutenção.");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Índice de veículo inválido.");
        //    }
        //}

        #endregion


        #region Listagens

        public void MostrarVeiculosEmManutencao()
        {
            Console.WriteLine(" ___________________________");
            Console.WriteLine("|                           |");
            Console.WriteLine("|  Veículos em Manutenção   |");
            Console.WriteLine("|___________________________|");

            int count = 0;

            foreach (Veiculo veiculo in listaVeiculos)
            {
                if (veiculo.StatusManutencao)
                {
                    count++;
                    ExibirDetalhesVeiculo(veiculo);
                }
            }

            if (count == 0)
            {
                Console.WriteLine("Não há veículos em manutenção no momento.");
            }
            
        }

        public void MostrarVeiculosDisponiveis()
         {
            Console.WriteLine(" ____________________________________");
            Console.WriteLine("|                                    | ");
            Console.WriteLine("|        Veículos Disponíveis        |");
            Console.WriteLine("|____________________________________|");

            int count = 0;

            foreach (Veiculo veiculo in listaVeiculos)
            {
                if (!veiculo.StatusAluguer && !veiculo.StatusManutencao)
                {
                    count++;
                    ExibirDetalhesVeiculo(veiculo);
                }
            }

            if (count == 0)
            {
                Console.WriteLine("Não há veículos disponíveis para aluguel no momento.");
            }
         }

        public void MostrarVeiculosDisponiveisManuntencao()
        {
            Console.WriteLine(" ____________________________________________");
            Console.WriteLine("|                                            |");
            Console.WriteLine("|    Veículos Disponíveis para Manuntençao   |");
            Console.WriteLine("|____________________________________________|\n");
            int count = 0;

            foreach (Veiculo veiculo in listaVeiculos)
            {
                if (!veiculo.StatusAluguer && !veiculo.StatusManutencao)
                {
                    count++;
                    ExibirDetalhesVeiculo(veiculo);
                }
            }

            if (count == 0)
            {
                Console.WriteLine("Não há veículos disponíveis para aluguer no momento.");
            }

        }

        public void ListarVeiculosAlugados()
        {
            Console.WriteLine(" _________________");
            Console.WriteLine("|                 |");
            Console.WriteLine("|Veículos Alugados|");
            Console.WriteLine("|_________________|");

            int count = 0;

            foreach (Veiculo veiculo in listaVeiculos)
            {
                if (veiculo.StatusAluguer)
                {
                    count++;
                    ExibirDetalhesVeiculo(veiculo);
                }
            }

            if (count == 0)
            {
                Console.WriteLine("Não foram alugados veiculos");
            }
        }

        public void ListarVeiculosDisponiveisParaAluguer()
        {
            Console.WriteLine(" ________________________________________");
            Console.WriteLine("|                                        |");
            Console.WriteLine("|    Veículos Disponíveis para Aluguer   |");
            Console.WriteLine("|________________________________________|\n");
            int count = 0;

            foreach (Veiculo veiculo in listaVeiculos)
            {
                if (!veiculo.StatusAluguer && !veiculo.StatusManutencao)
                {
                    count++;
                    ExibirDetalhesVeiculo(veiculo);
                }
            }

            if (count == 0)
            {
                Console.WriteLine("Não há veículos disponíveis para aluguer no momento.");
            }
        }

        #endregion

        public void CalcularValorAluguer(int index, int diasAluguer)
        {
            if (index >= 0 && index < listaVeiculos.Count && diasAluguer > 0)
            {
                Veiculo veiculo = listaVeiculos[index];

                if (veiculo.StatusManutencao != true)
                {
                    double valorTotalAluguer = veiculo.ValorAluguerDiario * diasAluguer;
                    Console.WriteLine($"Valor total do aluguer: €{valorTotalAluguer}");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Veiculo em manutenção.");
                }
            }
            else
            {
                Console.WriteLine("Indice inválido");
            }
        }

    }
}