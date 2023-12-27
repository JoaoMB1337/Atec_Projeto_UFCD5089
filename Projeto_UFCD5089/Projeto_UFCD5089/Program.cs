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

                rentCar.CarregarVeiculosDoArquivo("veiculo.csv");

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
                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    continue;
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
                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    continue;
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
            Console.WriteLine("|  1. Selecionar veículo     |");
            Console.WriteLine("|  2. Adicionar aluguer      |");
            Console.WriteLine("|  3. Voltar                 |");
            Console.WriteLine("|____________________________|");
            Console.Write("\nSelecione uma opção: ");

            int opcao;
            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
                return;
            }

            switch (opcao)
            {
                case 1:
                    AlugarVeiculo();
                    break;
                case 2:
                    ListarVeiculos();
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
            Console.WriteLine("|  3. Valor Pago por Aluguer |");
            Console.WriteLine("|  4. Voltar                 |");
            Console.WriteLine("|____________________________|");
            Console.Write("\nSelecione uma opção: ");


            int opcao;
            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
                return;
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
                    ValorPagoAluguer();
                    break;
                case 4:
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }

        #endregion

        private static void AlugarVeiculo()
        {
            rentCar.MostrarVeiculosDisponiveis();
            //Console.Write("Qual e o veiculo a alugar: ");
            int index = int.Parse(Console.ReadLine());
            rentCar.AlugarVeiculo(index);
        }

        private static void ListarVeiculos()
        {
            rentCar.MostrarVeiculosDisponiveis(); 
        }

        private static void AdicionarVeiculo()
        {
            int numeroPortas, cilindrada, numeroEixos, maxPassageiros, pesoMaximo, valorAluguerDiario;
            string tipoCaixa; 

            do
            {
                Console.Write("Informe o número de portas do veículo: ");
                string input = Console.ReadLine();
                if( int.TryParse(input, out numeroPortas) && numeroPortas >= 1 && numeroPortas <= 5)
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
                Console.Write("Informe o tipo de caixa do veículo: ");
                tipoCaixa = Console.ReadLine();

            } while(!(tipoCaixa.ToLower() == "manual" || tipoCaixa.ToLower() == "automatico"));

            do
            {
                Console.Write("Informe a cilindrada do veículo: ");
                string input = Console.ReadLine();

                if(int.TryParse(input,out cilindrada) && cilindrada >=100 && cilindrada <= 10000)
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
                Console.Write("Informe o número de eixos do veículo: ");
                string input = Console.ReadLine();

                if(int.TryParse(input, out numeroEixos) && numeroEixos >= 1 && numeroEixos <= 3 )
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Por favor, insira um número válido de 1 a 3.");
                }
                
            } while(true);

            do
            {
                Console.Write("Informe o número máximo de passageiros do veículo: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out maxPassageiros) && maxPassageiros >= 1 && maxPassageiros <= 10)
                { 
                    break;
                }
                else
                {
                    Console.WriteLine("Por favor, insira um número válido de 1 a 10.");
                }

            } while(true);

            do
            {
                Console.Write("Informe o peso máximo do veículo: ");
                string input = Console.ReadLine();
                if(int.TryParse(input, out pesoMaximo) &&  pesoMaximo >= 100 && pesoMaximo <= 10000)
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
                Console.Write("Informe o valor do aluguer diário do veículo: ");
                string input = Console.ReadLine();
                if(int.TryParse(input, out valorAluguerDiario) && valorAluguerDiario >= 1)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Por favor, insira um número maior que 1 .");
                }

            } while(true);

            //Quando se cria o veh. o status e manutenção ainda nao são contados
            Veiculo novoVeiculo = new Veiculo(numeroPortas, tipoCaixa, cilindrada, numeroEixos, maxPassageiros, pesoMaximo, valorAluguerDiario, false, false);
            rentCar.AddVeiculo(novoVeiculo);
        }
       
        private static void RemoverVeiculo()
        {
            rentCar.MostrarVeiculosDisponiveis();
            Console.Write("Veiculo a remover: ");
            int index = int.Parse(Console.ReadLine());
            rentCar.RemoverVeiculo(index);
            Console.WriteLine("Veiculo removido com sucesso!");
        }

        private static void FazerManutencao()
        {
            rentCar.MostrarVeiculosDisponiveisManuntencao();
            Console.Write("Veiculo a meter em manutenção: ");
            int index = int.Parse(Console.ReadLine());
            rentCar.ManutencaoVeiculo(index);
            Console.WriteLine("Veiculo enviado para a manutenção!");
        }

        private static void RemoverDaManutencao()
        {
            rentCar.MostrarVeiculosEmManutencao();
            Console.Write("Veiculo a remover da manutenção: ");
            int index = int.Parse(Console.ReadLine());
            rentCar.RemoverVeiculosManutencao(index);
            Console.WriteLine("Veiculo removido da manutenção!");
        }

        private static void VeiculosAlugados()
        {
            rentCar.ListarVeiculosAlugados();
        }

        private static void VeiculosDisponiveisAluguer()
        {
            rentCar.listarVeiculosDisponiveisParaAluguer();
        }

        private static void ValorPagoAluguer()
        {
            rentCar.MostrarVeiculosDisponiveis();
            Console.WriteLine("Veiculo a alugar.");
            int index = int.Parse(Console.ReadLine());
            Console.WriteLine("Dias aluguer veiculo");
            int dias = int.Parse(Console.ReadLine());
            rentCar.ValorAluguer(index, dias);
        }

    }
}