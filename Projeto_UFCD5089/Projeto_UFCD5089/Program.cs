using System.Drawing;
namespace Projeto_UFCD5089
{
    internal class Program
    {
        private static Empresa rentCar = new Empresa();

        static void Main(string[] args)
        {
            
            bool sair = false;

            while (!sair)
            {
                Console.Clear();

                rentCar.CarregarVeiculosDoArquivo(@"veiculo.csv");

                Console.WriteLine(" _________________________");
                Console.WriteLine("|                         |");
                Console.WriteLine("| Automobile renta-a-car  | ");
                Console.WriteLine("|_________________________|");
                Console.WriteLine("|                         |");
                Console.WriteLine("|  1. Gestor de veiculos  |");
                Console.WriteLine("|                         |");
                Console.WriteLine("|  2. Alugar veículo      |");
                Console.WriteLine("|                         |");
                Console.WriteLine("|  3. Relatorios veículos |");
                Console.WriteLine("|                         |");
                Console.WriteLine("|  4. Sair                |");
                Console.WriteLine("|_________________________|");

                Console.Write("\nSelecione uma opção: ");
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

        private static void MenuGestorVeiculos()
        {
            bool voltar = false;

            while (!voltar)
            {
                Console.Clear();

                Console.WriteLine(" __________________________");
                Console.WriteLine("|                          |");
                Console.WriteLine("|   Gestor de Veículos     |");
                Console.WriteLine("|__________________________|");
                Console.WriteLine("|                          |");
                Console.WriteLine("|  1. Adicionar Veículo    |");
                Console.WriteLine("|  2. Remover Veículo      |");
                Console.WriteLine("|  3. Adicionar Manutenção |");
                Console.WriteLine("|  4. Remover Manutenção   |");
                Console.WriteLine("|  5. Voltar               |");
                Console.WriteLine("|__________________________|");
                Console.Write("\nSelecione uma opção: ");


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
        
        private static void MenuAluguer()
        {
            Console.Clear();

            Console.WriteLine(" ____________________________");
            Console.WriteLine("|                            |");
            Console.WriteLine("|          Aluguer           |");
            Console.WriteLine("|____________________________|");
            Console.WriteLine("|                            |");
            Console.WriteLine("|  1. Adicionar Aluguer      |");
            Console.WriteLine("|  2. Retirar Aluguer        |");
            Console.WriteLine("|  3. Voltar                 |");
            Console.WriteLine("|____________________________|");
            Console.Write("\nSelecione uma opção: ");

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

        private static void MenuRelatorios()
        {
            Console.Clear();

            Console.WriteLine(" ____________________________");
            Console.WriteLine("|                            |");
            Console.WriteLine("|        Relatórios          |");
            Console.WriteLine("|____________________________|");
            Console.WriteLine("|                            |");
            Console.WriteLine("|  1. Veículos Alugados      |");
            Console.WriteLine("|  2. Veículos Disponíveis   |");
            Console.WriteLine("|  3. Voltar                 |");
            Console.WriteLine("|____________________________|");
            Console.Write("\nSelecione uma opção: ");


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

        private static void AdicionarVeiculo()
        {
            int numeroPortas, cilindrada, numeroEixos, maxPassageiros, pesoMaximo;
            double valorAluguerDiario;
            string tipoCaixa; 

            do
            {
                Console.Write("Informe o número de portas do veículo: ");
                numeroPortas = int.Parse(Console.ReadLine());

            } while (numeroPortas < 1 || numeroPortas > 5); 
            
            do
            {
                Console.Write("Informe o tipo de caixa do veículo: ");
                tipoCaixa = Console.ReadLine();

            } while(!(tipoCaixa.ToLower() == "manual" || tipoCaixa.ToLower() == "automatico"));

            do
            {
                Console.Write("Informe a cilindrada do veículo: ");
                cilindrada = int.Parse(Console.ReadLine());

            } while (cilindrada < 100 || cilindrada > 10000);

            do
            {
                Console.Write("Informe o número de eixos do veículo: ");
                numeroEixos = int.Parse(Console.ReadLine());

            } while(numeroEixos < 1 || numeroEixos > 3);

            do
            {
                Console.Write("Informe o número máximo de passageiros do veículo: ");
                maxPassageiros = int.Parse(Console.ReadLine());

            } while(maxPassageiros < 1 || maxPassageiros > 10);

            do
            {
                Console.Write("Informe o peso máximo do veículo: ");
                pesoMaximo = int.Parse(Console.ReadLine());

            } while (pesoMaximo < 100 || pesoMaximo > 10000);

            do
            {
                Console.Write("Informe o valor do aluguer diário do veículo: ");
                valorAluguerDiario = double.Parse(Console.ReadLine());

            } while(valorAluguerDiario < 1);

            //Quando se cria o veh. o status e manutenção ainda nao são contados
            Veiculo novoVeiculo = new Veiculo(numeroPortas, tipoCaixa, cilindrada, numeroEixos, maxPassageiros, pesoMaximo, valorAluguerDiario, false, false);

            if (rentCar.AdicionarVeiculo(novoVeiculo)){
                Console.WriteLine("Veiculo adicionado com sucesso!");
            }
            else{
                Console.WriteLine("Erro ao adicionar o veiculo!");
            }
        }
       
        private static void RemoverVeiculo()
        {
            if(rentCar.ListarVeiculosDisponiveis())
            {
                Console.Write("Veiculo a remover: ");
                int index = int.Parse(Console.ReadLine());
                if (rentCar.RemoverVeiculo(index))
                {
                    Console.WriteLine("Veiculo removido com sucesso!");
                }
                else
                {
                    Console.WriteLine("Veiculo Invalido!");
                }
            }
            
        }


        private static void FazerManutencao()
        {
            if (rentCar.ListarVeiculosDisponiveis())
            {
                Console.Write("Veiculo a meter em manutenção: ");
                int index = int.Parse(Console.ReadLine());
                if (rentCar.AdicionarManutencaoVeiculo(index))
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
            
        }

        private static void RemoverDaManutencao()
        {
            if (rentCar.MostrarVeiculosEmManutencao())
            {
                Console.Write("Veiculo a remover da manutenção: ");
                int index = int.Parse(Console.ReadLine());
                if (rentCar.RemoverManutencaoVeiculo(index))
                {
                    Console.WriteLine("Veiculo retirado com sucesso da manutenção");
                }
                else
                {
                    Console.WriteLine("Veiculo nao retirado com sucesso da manutenção");
                }
            }
            
        }

        private static void AdicionarAluguer()
        {
            if (rentCar.ListarVeiculosDisponiveis()){
                Console.Write("Escolha o veículo a alugar (insira o índice): ");
                int index = int.Parse(Console.ReadLine());
                if (index >= 0 && index < rentCar.listaVeiculos.Count)
                {
                    Console.Write("Insira a quantidade de dias de aluguel: ");
                    int dias = int.Parse(Console.ReadLine());
                    if (dias > 0)
                    {
                        double valorAPagar = rentCar.CalcularValorAluguer(index, dias);
                        Console.WriteLine($"O valor a pagar pelo aluguel é: {valorAPagar}");
                        Console.Write("Insira o valor a pagar: ");
                        double valorPago = double.Parse(Console.ReadLine());
                        if (valorPago >= valorAPagar)
                        {
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
        }

        private static void RetirarAlguer()
        {
           if(rentCar.ListarVeiculosAlugados())
           {
                Console.Write("Veiculo a retirar do aluguer: ");
                int index = int.Parse(Console.ReadLine());
                if (rentCar.RetirarAluguerVeiculo(index))
                {
                    Console.WriteLine($"Veículo {index + 1} devolvido com sucesso!");
                }
                else
                {
                    Console.WriteLine("Não foi possivel remover o veiculo do alguer!");
                }
           }
        }


        #region ListagensRelatorios
        private static void VeiculosAlugados()
        {
            rentCar.ListarVeiculosAlugados();
        }

        private static void VeiculosDisponiveisAluguer()
        {
            rentCar.ListarVeiculosDisponiveis();
        }

        #endregion

    }
}