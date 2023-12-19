using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_UFCD5089
{
    internal class Empresa
    {
        GestorFicheiros GF = new GestorFicheiros();
        List<Veiculo> listaVeiculos = new List<Veiculo>();


        public void AddVeiculo (Veiculo veiculo)
        {
            listaVeiculos.Add(veiculo);
            GF.EscreverCSV(listaVeiculos, @"veiculo.csv");
        { 
            listaVeiculos.Add(veiculo);   
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
    }
}
