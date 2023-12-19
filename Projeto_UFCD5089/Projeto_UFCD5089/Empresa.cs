﻿using System;
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
        GestorFicheiros GF = new GestorFicheiros();
        List<Veiculo> listaVeiculos = new List<Veiculo>();

        public void AddVeiculo(Veiculo veiculo)
        {
            if (!listaVeiculos.Contains(veiculo))
            {
                listaVeiculos.Add(veiculo);
                GF.EscreverCSV(listaVeiculos, @"veiculo.csv");
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

        public void CarregarVeiculosDoArquivo(string caminhoArquivo)
        {
            int ultimoId = GF.ObterUltimoId(caminhoArquivo);
            Veiculo.DefinirUltimoId(ultimoId);
            listaVeiculos = GF.CarregarListaViaArquivo(caminhoArquivo);
            Console.WriteLine("Veiculos carregados com sucesso!");
        }
        
        public void MostrarTodosVeiculos()
        {
            Console.WriteLine("Lista de Veículos:");

            if (listaVeiculos.Count > 0)
            {
                for (int i = 0; i < listaVeiculos.Count; i++)
                {
                    Veiculo veiculo = listaVeiculos[i];
                    Console.WriteLine($"Veículo {i + 1}:");
                    Console.WriteLine($"ID: {veiculo.Id}");
                    Console.WriteLine($"Número de Portas: {veiculo.NumeroPortas}");
                    Console.WriteLine($"Tipo de Caixa: {veiculo.TipoCaixa}");
                    Console.WriteLine($"Cilindrada: {veiculo.Cilindrada}");
                    Console.WriteLine($"Número de Eixos: {veiculo.NumeroEixos}");
                    Console.WriteLine($"Máximo de Passageiros: {veiculo.MaxPassageiros}");
                    Console.WriteLine($"Peso Máximo: {veiculo.PesoMaximo}");
                    Console.WriteLine($"Valor de Aluguer Diário: {veiculo.ValorAluguerDiario}");
                    Console.WriteLine($"Status de Aluguel: {(veiculo.StatusAluguer ? "Alugado" : "Disponível")}");
                    Console.WriteLine($"Status de Manutenção: {(veiculo.StatusManutencao ? "Em manutenção" : "Disponível")}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Não há veículos cadastrados.");
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
}