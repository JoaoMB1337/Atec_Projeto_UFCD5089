using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection.Metadata.Ecma335;

namespace Projeto_UFCD5089
{
    internal class Empresa
    {
        public List<Veiculo> listaVeiculos = new List<Veiculo>();

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

        public void CarregarVeiculosDoArquivo(string caminhoArquivo){

            int ultimoId = GestorFicheiros.ObterUltimoId(caminhoArquivo);
            Veiculo.DefinirUltimoId(ultimoId);
            listaVeiculos = GestorFicheiros.CarregarListaViaArquivo(caminhoArquivo);
        }


        #region Metodos de Edição de Veiculos

        public bool AdicionarVeiculo(Veiculo veiculo)
        {
            try
            {
                if (!listaVeiculos.Contains(veiculo)){
                    listaVeiculos.Add(veiculo);
                    GestorFicheiros.EscreverCSV(listaVeiculos, @"veiculo.csv");
                    return true; 
                }
                else{
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                return false;
            }
        }

        public bool RemoverVeiculo(int index)
        {
            try
            {
                if (index >= 0 && index < listaVeiculos.Count)
                {
                    listaVeiculos.RemoveAt(index);
                    GestorFicheiros.EscreverCSV(listaVeiculos, @"veiculo.csv");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            }
            return false;
        }


        public bool AdicionarManutencaoVeiculo(int index)
        {
            try
            {
                if(index >= 0 && index < listaVeiculos.Count && !listaVeiculos[index].StatusAluguer && !listaVeiculos[index].StatusManutencao)
                {
                    listaVeiculos[index].StatusManutencao = true;
                    GestorFicheiros.AtulizarEstadoManutençãoVeiculo(listaVeiculos, @"veiculo.csv");
                    return true;
                }
                else
                {
                    Console.WriteLine("Veículo não disponível para manutenção.");
                    return false;
                }
            }
            catch(Exception ex) {
                Console.WriteLine($"Error: {ex}");
                return false;
            }
            
        }

        public bool RemoverManutencaoVeiculo(int index)
        {
            try
            {
                if (!listaVeiculos[index].StatusAluguer && listaVeiculos[index].StatusManutencao)
                {
                    if (index >= 0 && index < listaVeiculos.Count)
                    {
                        listaVeiculos[index].StatusManutencao = false;
                        GestorFicheiros.AtualizarEstadoAluguelVeiculo(listaVeiculos, @"veiculo.csv");

                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Veículo não disponível para manutenção.");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Índice de veículo inválido.");
                    return false;
                }
            }
            catch(Exception ex) {
                Console.WriteLine($"Error: {ex}");
                return false;
            }
        }

        public bool AdicionarAluguerVeiculo(int index)
        {
            try
            {
                if (index >= 0 && index < listaVeiculos.Count && !listaVeiculos[index].StatusAluguer && !listaVeiculos[index].StatusManutencao)
                {
                    listaVeiculos[index].StatusAluguer = true;
                    GestorFicheiros.AtualizarEstadoAluguelVeiculo(listaVeiculos, @"veiculo.csv");

                    return true;
                }
                else
                {
                    Console.WriteLine("Veículo não disponível para aluguel.");
                    return false;

                }
            }
            catch (Exception ex){
                Console.WriteLine($"Error: {ex}");
                return false;
            }
            
            
        }

        public bool RetirarAluguerVeiculo(int index)
        {
            try
            {
                if (index >= 0 && index < listaVeiculos.Count)
                {
                    if (listaVeiculos[index].StatusAluguer && !listaVeiculos[index].StatusManutencao)
                    {
                        listaVeiculos[index].StatusAluguer = false;
                        GestorFicheiros.AtualizarEstadoAluguelVeiculo(listaVeiculos, @"veiculo.csv");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Veículo não disponível para devolução.");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Índice de veículo inválido.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                return false;
            }
            
        }

        public double CalcularValorAluguer(int index, int diasAluguer)
        {
            if (index >= 0 && index < listaVeiculos.Count && diasAluguer > 0 && !listaVeiculos[index].StatusManutencao && !listaVeiculos[index].StatusAluguer)
            {
                Veiculo veiculo = listaVeiculos[index];
                return veiculo.ValorAluguerDiario * diasAluguer;
            }
            Console.WriteLine("Veículo em manutenção ou já em aluguer!");
            return 0;
        }

        #endregion

        #region Listagens

        public bool MostrarVeiculosEmManutencao()
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
                    Console.WriteLine($"Veiculo: {count}");
                    ExibirDetalhesVeiculo(veiculo);
                    count ++;
                }
            }

            if (count == 0)
            {
                Console.WriteLine("Não há veículos em manutenção no momento.");
                Console.ReadKey();
                return false;
            }
            return true;
            
        }

        public bool ListarVeiculosAlugados()
        {
            Console.WriteLine(" _____________________");
            Console.WriteLine("|                     |");
            Console.WriteLine("|  Veículos Alugados  |");
            Console.WriteLine("|_____________________|\n");

            int count = 0;

            foreach (Veiculo veiculo in listaVeiculos)
            {
                if (veiculo.StatusAluguer)
                {
                    Console.WriteLine($"Veiculo: {count}");
                    ExibirDetalhesVeiculo(veiculo);
                    count++;
                }
            }

            if (count == 0)
            {
                Console.WriteLine("Não foram alugados veiculos");
                Console.ReadKey();
                return false;
            }
            return true;
        }

        public bool ListarVeiculosDisponiveis()
        {
            Console.WriteLine(" ________________________________________");
            Console.WriteLine("|                                        |");
            Console.WriteLine("|          Veículos Disponíveis          |");
            Console.WriteLine("|________________________________________|\n");
            int count = 0;

            foreach (Veiculo veiculo in listaVeiculos)
            {
                if (!veiculo.StatusAluguer && !veiculo.StatusManutencao)
                {    
                    Console.WriteLine($"VEICULO: {count} ");
                    ExibirDetalhesVeiculo(veiculo);
                    Console.WriteLine("-----------------------------------------");
                    count++;

                }
            }

            if (count == 0)
            {
                Console.WriteLine("Não há veículos disponíveis de momento.");
                Console.ReadKey();
                return false;
            }
            return true;
        }

        #endregion

    }
}