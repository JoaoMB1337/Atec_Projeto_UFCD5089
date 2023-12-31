﻿using System.Drawing;
namespace Projeto_UFCD5089
{
    internal class Program
    {
        //Instanciar classe Empresa
        private static Empresa rentCar = new Empresa();

        //Metodo Main
        static void Main(string[] args)
        {
            
            bool sair = false;

            //Loop do menu principal
            while (!sair)
            {
                Console.Clear();

                rentCar.CarregarVeiculosDoArquivo(@"veiculo.csv");

                Console.WriteLine("  ┌─────────────────────────┐");
                Console.WriteLine("  │                         │");
                Console.WriteLine("  │  Automobile Renta-Car   │");
                Console.WriteLine("  │                         │");
                Console.WriteLine("  │─────────────────────────│");
                Console.WriteLine("  │                         │");
                Console.WriteLine("  │  1. Gestor de Veículos  │");
                Console.WriteLine("  │                         │");
                Console.WriteLine("  │  2. Alugar Veículo      │");
                Console.WriteLine("  │                         │");
                Console.WriteLine("  │  3. Relatórios Veículos │");
                Console.WriteLine("  │                         │");
                Console.WriteLine("  │  4.  Sair               │");
                Console.WriteLine("  │                         │");
                Console.WriteLine("  └─────────────────────────┘");

                Console.Write("\n   Selecione uma opção: ");
                int opcao;
                while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 1 || opcao > 4)
                {
                    Console.Write("Opção inválida. Tente novamente: ");
                }
                switch (opcao)
                {
                    case 1:
                        Console.Clear();
                        MenuGestorVeiculos();
                        break;
                    case 2:
                        Console.Clear();
                        MenuAluguer();
                        break;
                    case 3:
                        Console.Clear();
                        MenuRelatorios();
                        break;
                    case 4:
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        #region Menus

        //Submenu gestor veiculos
        private static void MenuGestorVeiculos()
        {
            bool voltar = false;

            while (!voltar)
            {
                Console.Clear();

                Console.WriteLine("   __________________________");
                Console.WriteLine("  |                          |");
                Console.WriteLine("  |   Gestor de Veículos     |");
                Console.WriteLine("  |__________________________|");
                Console.WriteLine("  |                          |");
                Console.WriteLine("  |  1. Adicionar Veículo    |");
                Console.WriteLine("  |                          |");
                Console.WriteLine("  |  2. Remover Veículo      |");
                Console.WriteLine("  |                          |");
                Console.WriteLine("  |  3. Adicionar Manutenção |");
                Console.WriteLine("  |                          |");
                Console.WriteLine("  |  4. Remover Manutenção   |");
                Console.WriteLine("  |                          |");
                Console.WriteLine("  |  5. Voltar               |");
                Console.WriteLine("  |__________________________|");
                Console.Write("\n   Selecione uma opção: ");


                int opcao;
                while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 1 || opcao > 5)
                {
                    Console.Write("Opção inválida. Tente novamente: ");
                }

                switch (opcao)
                {
                    case 1:
                        AdicionarVeiculo();
                        break;
                    case 2:
                        RemoverVeiculo();
                        break;
                    case 3:
                        FazerManutencao();
                        break;
                    case 4:
                        RemoverDaManutencao();
                        break;
                    case 5:
                        voltar = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }
        
        //Submenu de aluguel de veiculos
        private static void MenuAluguer()
        {
            Console.Clear();

            Console.WriteLine("   ____________________________");
            Console.WriteLine("  |                            |");
            Console.WriteLine("  |          Aluguer           |");
            Console.WriteLine("  |____________________________|");
            Console.WriteLine("  |                            |");
            Console.WriteLine("  |  1. Adicionar Aluguer      |");
            Console.WriteLine("  |                            |");
            Console.WriteLine("  |  2. Retirar Aluguer        |");
            Console.WriteLine("  |                            |");
            Console.WriteLine("  |  3. Voltar                 |");
            Console.WriteLine("  |____________________________|");
            Console.Write("\n   Selecione uma opção: ");

            int opcao;
            while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 1 || opcao > 4)
            {
                Console.Write("Opção inválida. Tente novamente: ");
            }

            switch (opcao)
            {
                case 1:
                    AdicionarAluguer();
                    break;
                case 2:
                    RetirarAlguer();
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

        }

        //Submenu relatórios
        private static void MenuRelatorios()
        {
            Console.Clear();

            Console.WriteLine("   ____________________________");
            Console.WriteLine("  |                            |");
            Console.WriteLine("  |        Relatórios          |");
            Console.WriteLine("  |____________________________|");
            Console.WriteLine("  |                            |");
            Console.WriteLine("  |  1. Veículos Alugados      |");
            Console.WriteLine("  |                            |");
            Console.WriteLine("  |  2. Veículos Disponíveis   |");
            Console.WriteLine("  |                            |");
            Console.WriteLine("  |  3. Voltar                 |");
            Console.WriteLine("  |____________________________|");
            Console.Write("\n    Selecione uma opção: ");


            int opcao;
            while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 1 || opcao > 4)
            {
                Console.Write("Opção inválida. Tente novamente: ");
            }

            switch (opcao)
            {
                case 1:
                    VeiculosAlugados();
                    break;
                case 2:
                    VeiculosDisponiveisAluguer();
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }

        #endregion

        //Adicionar veiculos a frota
        private static void AdicionarVeiculo()
        {
            int numeroPortas, cilindrada, numeroEixos, maxPassageiros, pesoMaximo, valorAluguerDiario;
            string tipoCaixa;

            do
            {
                Console.Write("\nInforme o número de portas do veículo: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out numeroPortas) && numeroPortas >= 1 && numeroPortas <= 5)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Por favor, insira um número válido de 1 a 5.");
                }

            } while (true);

            do
            {
                Console.Write("\nInforme o tipo de caixa do veículo(manual ou automatico): ");
                tipoCaixa = Console.ReadLine();

            } while (!(tipoCaixa.ToLower() == "manual" || tipoCaixa.ToLower() == "automatico"));

            do
            {
                Console.Write("\nInforme a cilindrada do veículo: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out cilindrada) && cilindrada >= 100 && cilindrada <= 10000)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Por favor, insira um número válido de 100 a 10000.");
                }

            } while (true);

            do
            {
                Console.Write("\nInforme o número de eixos do veículo: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out numeroEixos) && numeroEixos > 1 && numeroEixos <= 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Por favor, insira um número válido de 2 ou 3.");
                }

            } while (true);

            do
            {
                Console.Write("\nInforme o número máximo de passageiros do veículo: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out maxPassageiros) && maxPassageiros >= 1 && maxPassageiros <= 10)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Por favor, insira um número válido de 1 a 10.");
                }

            } while (true);

            do
            {
                Console.Write("\nInforme o peso máximo do veículo: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out pesoMaximo) && pesoMaximo >= 100 && pesoMaximo <= 10000)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Por favor, insira um número válido de 100 a 10000. ");
                }

            } while (true);

            do
            {
                Console.Write("\nInforme o valor(€) do aluguer diário do veículo: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out valorAluguerDiario) && valorAluguerDiario >= 1)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Por favor, insira um número maior que 1 .");
                }

            } while (true);

            //Quando se cria o veiculo o status e manutenção ainda nao são contados
            Veiculo novoVeiculo = new Veiculo(numeroPortas, tipoCaixa, cilindrada, numeroEixos, maxPassageiros, pesoMaximo, valorAluguerDiario, false, false);

            if (rentCar.AdicionarVeiculo(novoVeiculo)){
                Console.WriteLine("Veiculo adicionado com sucesso!");
            }
            else{
                Console.WriteLine("Erro ao adicionar o veiculo!");
            }
        }
       
        //Remover veiculos da frota
        private static void RemoverVeiculo()
        {
            if(rentCar.ListarVeiculosDisponiveis())
            {
                Console.Write("Veiculo a remover: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int index) && rentCar.RemoverVeiculo(index))
                {
                    Console.WriteLine("Veiculo removido com sucesso!");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Veiculo Invalido!");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.ReadKey();
            }
            
        }

        //Colocar veiculos em manutenção
        private static void FazerManutencao()
        {
            if (rentCar.ListarVeiculosDisponiveis())
            {
                Console.Write("Veiculo a meter em manutenção: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int index) && rentCar.AdicionarManutencaoVeiculo(index))
                {
                    Console.WriteLine("Veiculo adicionado à manutenção");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Veiculo não adicionado à manutenção");
                    Console.ReadKey();

                }
            }
            else
            {
                Console.ReadKey();
            }
            
        }

        //Remover manutenção
        private static void RemoverDaManutencao()
        {
            if (rentCar.MostrarVeiculosEmManutencao())
            {
                Console.Write("Veiculo a remover da manutenção: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int index) && rentCar.RemoverManutencaoVeiculo(index))
                {
                    Console.WriteLine("Veiculo retirado com sucesso da manutenção");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Veiculo nao retirado com sucesso da manutenção");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.ReadKey();
            }
            
        }

        //Alugar um veiculo da frota
        private static void AdicionarAluguer()
        {
            if (rentCar.ListarVeiculosDisponiveis()){
                Console.Write("Escolha o veículo a alugar (insira o índice): ");
                string inputCarro = Console.ReadLine();
                if (int.TryParse(inputCarro, out int index) && index >= 0 && index < rentCar.listaVeiculos.Count)
                {
                    Console.Write("Insira a quantidade de dias de aluguel: ");
                    string inputDias = Console.ReadLine();
                    if (int.TryParse(inputDias, out int dias) && dias > 0)
                    {
                        double valorAPagar = rentCar.CalcularValorAluguer(index, dias);
                        Console.WriteLine($"O valor a pagar pelo aluguel é: {valorAPagar}");
                        Console.Write("Insira o valor a pagar: ");
                        string inputValor = Console.ReadLine();
                        double.TryParse(inputValor, out double valorPago);
                        if (valorPago >= valorAPagar)
                        {
                            double troco = rentCar.CalcularTroco(valorPago, valorAPagar);
                            Console.WriteLine($"Troco: { troco}");
                            if (rentCar.AdicionarAluguerVeiculo(index))
                            {
                                Console.WriteLine("Aluguer adicionado com sucesso!");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Ocorreu um erro ao adicionar o aluguer.");
                                Console.ReadKey();

                            }
                        }
                        else
                        {
                            Console.WriteLine("Valor inserido é inferior ao valor a pagar. Operação cancelada.");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Número de dias inválido. Operação cancelada.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Índice de veículo inválido. Operação cancelada.");
                    Console.ReadKey();
                }
            }
            else { 
                    Console.ReadKey(); 
            }
        }

        //Retirar um veiculo de aluguel
        private static void RetirarAlguer()
        {
           if(rentCar.ListarVeiculosAlugados())
           {
                Console.Write("Veiculo a retirar do aluguer: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int index) && rentCar.RetirarAluguerVeiculo(index))
                {
                    Console.WriteLine($"Veículo {index + 1} devolvido com sucesso!");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Não foi possivel remover o veiculo do alguer!");
                    Console.ReadKey();
                }
           }
           else
           {
                Console.ReadKey();
           }
        }

        #region ListagensRelatorios

        //Listar veiculos alugados
        private static void VeiculosAlugados()
        {
            rentCar.ListarVeiculosAlugados();
            Console.ReadKey();
        }

        //Listar veiculos disponiveis para aluguel
        private static void VeiculosDisponiveisAluguer()
        {
            rentCar.ListarVeiculosDisponiveis();
            Console.ReadKey();
        }

        #endregion

    }
}