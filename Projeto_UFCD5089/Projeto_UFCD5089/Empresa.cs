using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_UFCD5089
{
    internal class Empresa
    {
        List <Veiculo> listaVeiculos = new List <Veiculo> ();

        public void AddVeiculo (Veiculo veiculo)
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
                    Console.WriteLine($"Veículo {index + 1} alugado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Veículo não disponível para aluguel.");
                }
            }
            else
            {
                Console.WriteLine("Índice de veículo inválido.");
            }

        } 

        public void MostrarVeiculosDisponiveis()
        {
            Console.WriteLine("Veículos Disponíveis para Aluguel:");
            int count = 0;

            foreach (Veiculo veiculo in listaVeiculos)
            {
                if (!veiculo.StatusAluguer)
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
