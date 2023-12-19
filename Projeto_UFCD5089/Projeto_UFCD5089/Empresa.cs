using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_UFCD5089
{
    internal class Empresa
    {
        GestorFicheiros GF = new GestorFicheiros();
        List<Veiculo> listaVeiculos = new List<Veiculo>();

        public void AddVeiculo(Veiculo veiculo)
        {
            listaVeiculos.Add(veiculo);
            GF.EscreverCSV(listaVeiculos, @"veiculo.csv");
            {
                listaVeiculos.Add(veiculo);
            }

        }

        public void AlugarVeiculo(int index)
        {
            if (index >= 0 && index < listaVeiculos.Count)
            {
                if (!listaVeiculos[index].StatusAluguer && !listaVeiculos[index].StatusManutencao)
                {
                    listaVeiculos[index].StatusAluguer = true;
                    GF.AtualizarEstadoAluguelVeiculo(listaVeiculos, @"veiculo.csv");
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
                    GF.AtulizarEstadoManutençãoVeiculo(listaVeiculos, @"veiculo.csv");
                    Console.WriteLine($"Veículo {index + 1} colocado em manutenção com sucesso!");
                }
                else
                {
                    Console.WriteLine("Veículo não disponível para manutenção.");
<<<<<<< Updated upstream
                }
            }
            else
            {
                Console.WriteLine("Índice de veículo inválido.");
=======
                }
            }
            else
            {
                Console.WriteLine("Índice de veículo inválido.");
            }
        }

        public void MostrarVeiculosManutencao()
        {
            Console.WriteLine("Veículos Disponíveis para Aluguel:");
            int count = 0;

            foreach (Veiculo veiculo in listaVeiculos)
            {
                if (!veiculo.StatusManutencao)
                {
                    count++;
                    Console.WriteLine($"Veículo {count}:");
                    Console.WriteLine($"Número de Portas: {veiculo.NumeroPortas}");
                    Console.WriteLine($"Tipo de Caixa: {veiculo.NumeroPortas}");
                    Console.WriteLine($"Cilindrada: {veiculo.NumeroPortas}");
                    Console.WriteLine($"Número de Eixos: {veiculo.NumeroPortas}");
                    Console.WriteLine($"Máximo de Passageiros: {veiculo.NumeroPortas}");
                    Console.WriteLine($"Peso Máximo: {veiculo.NumeroPortas}");
                    Console.WriteLine($"Valor de Aluguer Diário: {veiculo.NumeroPortas}");
                    Console.WriteLine("\n");
                }
            }

            if (count == 0)
            {
                Console.WriteLine("Não há veículos disponíveis para aluguel no momento.");
            }
        }

        public void MostrarVeiculosDisponiveis()
        {
            Console.WriteLine("Veículos Disponíveis para Aluguel:");
            int count = 0;

            foreach (Veiculo veiculo in listaVeiculos)
            {
                if (!veiculo.StatusAluguer && !veiculo.StatusManutencao)
                {
                    count++;
                    Console.WriteLine($"Veículo {count}:");
                    Console.WriteLine($"Número de Portas: {veiculo.NumeroPortas}");
                    Console.WriteLine($"Tipo de Caixa: {veiculo.NumeroPortas}");
                    Console.WriteLine($"Cilindrada: {veiculo.NumeroPortas}");
                    Console.WriteLine($"Número de Eixos: {veiculo.NumeroPortas}");
                    Console.WriteLine($"Máximo de Passageiros: {veiculo.NumeroPortas}");
                    Console.WriteLine($"Peso Máximo: {veiculo.NumeroPortas}");
                    Console.WriteLine($"Valor de Aluguer Diário: {veiculo.NumeroPortas}");
                    Console.WriteLine("\n");
                }
            }

            if (count == 0)
            {
                Console.WriteLine("Não há veículos disponíveis para aluguel no momento.");
            }
        }

        public void RemoverVeiculosManutencao(int index)
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

        public void ValorPagoAluguer(int index, int diasAluguer)
        {
            if (index >= 0 && index < listaVeiculos.Count && diasAluguer > 0)
            {
                Veiculo veiculo = listaVeiculos[index];

                if (veiculo.StatusManutencao != false)
                {
                    double valorTotalAluguer = veiculo.ValorAluguerDiario * diasAluguer;
                    Console.WriteLine($"Valor total do aluguer: R${valorTotalAluguer}");
                }
                else
                {
                    Console.WriteLine("Veiculo em manutenção.");
                }
            }
            else
            {
                Console.WriteLine("Indice inválido");
>>>>>>> Stashed changes
            }
        }

        public void MostrarVeiculosManutencao()
        {
            Console.WriteLine("Veículos em Manuntenção:");
            int count = 0;

            foreach (Veiculo veiculo in listaVeiculos)
            {
                if (!veiculo.StatusManutencao)
                {
                    count++;
                    Console.WriteLine($"Veículo {count}:");
                    Console.WriteLine($"Número de Portas: {veiculo.NumeroPortas}");
                    Console.WriteLine($"Tipo de Caixa: {veiculo.NumeroPortas}");
                    Console.WriteLine($"Cilindrada: {veiculo.NumeroPortas}");
                    Console.WriteLine($"Número de Eixos: {veiculo.NumeroPortas}");
                    Console.WriteLine($"Máximo de Passageiros: {veiculo.NumeroPortas}");
                    Console.WriteLine($"Peso Máximo: {veiculo.NumeroPortas}");
                    Console.WriteLine($"Valor de Aluguer Diário: {veiculo.NumeroPortas}");
                    Console.WriteLine("\n");
                }
            }

            if (count == 0)
            {
                Console.WriteLine("Não há veículos disponíveis para aluguer no momento.");
            }
        }

        public void MostrarVeiculosDisponiveis()
        {
            Console.WriteLine("Veículos Disponíveis para Aluguer:");
            int count = 0;

            foreach (Veiculo veiculo in listaVeiculos)
            {
                if (!veiculo.StatusAluguer && !veiculo.StatusManutencao)
                {
                    count++;
                    Console.WriteLine($"Veículo {count}:");
                    Console.WriteLine($"Número de Portas: {veiculo.NumeroPortas}");
                    Console.WriteLine($"Tipo de Caixa: {veiculo.TipoCaixa}");
                    Console.WriteLine($"Cilindrada: {veiculo.Cilindrada}");
                    Console.WriteLine($"Número de Eixos: {veiculo.NumeroEixos}");
                    Console.WriteLine($"Máximo de Passageiros: {veiculo.MaxPassageiros}");
                    Console.WriteLine($"Peso Máximo: {veiculo.PesoMaximo}");
                    Console.WriteLine($"Valor de Aluguer Diário: {veiculo.ValorAluguerDiario}");
                    Console.WriteLine("\n");
                }
            }

            if (count == 0)
            {
                Console.WriteLine("Não há veículos disponíveis para aluguer no momento.");
            }
        }

        public void RemoverVeiculo(int index)
        {
            if (index >= 0 && index < listaVeiculos.Count)
            {
                listaVeiculos.RemoveAt(index);
                GF.EscreverCSV(listaVeiculos, @"veiculo.csv");
                Console.WriteLine($"Veículo {index + 1} removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Índice de veículo inválido.");
            }
        }

        public void RemoverVeiculosManutencao(int index)
        {
            if (!listaVeiculos[index].StatusAluguer && listaVeiculos[index].StatusManutencao)
            {
                if (index >= 0 && index < listaVeiculos.Count)
                {
                    listaVeiculos[index].StatusManutencao = false;
                    Console.WriteLine($"Veículo {index + 1} removido da manutenção");
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

        public void ValorAluguer(int index, int diasAluguer)
        {
            if (index >= 0 && index < listaVeiculos.Count && diasAluguer > 0)
            {
                Veiculo veiculo = listaVeiculos[index];

                if (veiculo.StatusManutencao != true)
                {
                    double valorTotalAluguer = veiculo.ValorAluguerDiario * diasAluguer;
                    Console.WriteLine($"Valor total do aluguer: R${valorTotalAluguer}");
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

        public void ListarVeiculosAlugados()
        {
            Console.WriteLine("Veículos Alugados:");
            int count = 0;

            foreach (Veiculo veiculo in listaVeiculos)
            {
                if (veiculo.StatusAluguer)
                {
                    count++;
                    Console.WriteLine($"Veículo {count}:");
                    Console.WriteLine($"Número de Portas: {veiculo.NumeroPortas}");
                    Console.WriteLine($"Tipo de Caixa: {veiculo.TipoCaixa}");
                    Console.WriteLine($"Cilindrada: {veiculo.Cilindrada}");
                    Console.WriteLine($"Número de Eixos: {veiculo.NumeroEixos}");
                    Console.WriteLine($"Máximo de Passageiros: {veiculo.MaxPassageiros}");
                    Console.WriteLine($"Peso Máximo: {veiculo.PesoMaximo}");
                    Console.WriteLine($"Valor de Aluguer Diário: {veiculo.ValorAluguerDiario}");
                    Console.WriteLine("\n");
                }
            }

            if (count == 0)
            {
                Console.WriteLine("Não foram alugados veiculos");
            }
        }

        public void listarVeiculosDisponiveisParaAluguer()
        {
            Console.WriteLine("Veículos Disponíveis para Aluguer:");
            int count = 0;

            foreach (Veiculo veiculo in listaVeiculos)
            {
                if (!veiculo.StatusAluguer && !veiculo.StatusManutencao)
                {
                    count++;
                    Console.WriteLine($"Veículo {count}:");
                    Console.WriteLine($"Número de Portas: {veiculo.NumeroPortas}");
                    Console.WriteLine($"Tipo de Caixa: {veiculo.TipoCaixa}");
                    Console.WriteLine($"Cilindrada: {veiculo.Cilindrada}");
                    Console.WriteLine($"Número de Eixos: {veiculo.NumeroEixos}");
                    Console.WriteLine($"Máximo de Passageiros: {veiculo.MaxPassageiros}");
                    Console.WriteLine($"Peso Máximo: {veiculo.PesoMaximo}");
                    Console.WriteLine($"Valor de Aluguer Diário: {veiculo.ValorAluguerDiario}");
                    Console.WriteLine("\n");
                }
            }

            if (count == 0)
            {
                Console.WriteLine("Não há veículos disponíveis para aluguer no momento.");
            }
        }


    }
<<<<<<< Updated upstream
}
=======
}

>>>>>>> Stashed changes
