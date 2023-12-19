

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
                Console.WriteLine("Selecione uma opção:");
                Console.WriteLine("1. Adicionar veículo");
                Console.WriteLine("2. Alugar veículo");
                Console.WriteLine("3. Listar veículos");
                Console.WriteLine("4. Sair");

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
                        int index = int.Parse(Console.ReadLine());
                        rentCar.AlugarVeiculo(index);
                        break;
                    case 3:
                        ListarVeiculos();
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

        private static void AlugarVeiculo()
        {
            rentCar.MostrarVeiculosDisponiveis();
            Console.Write("Qual e o veiculo a alugar: ");
            int index = int.Parse(Console.ReadLine());
            rentCar.AlugarVeiculo(index);
        }

        private static void ListarVeiculos()
        {
            rentCar.MostrarVeiculosDisponiveis(); 

        }

        //Adiciona vehi. e valida os dados inseridos
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
            rentCar.AddVeiculo(novoVeiculo);
        }

        private static void ColocarEmManutencaoVeiculos()
        {
            rentCar.MostrarVeiculosDisponiveis();
            Console.WriteLine("Veiculo a meter em manutenção: ");
            int index = int.Parse(Console.ReadLine());
            rentCar.ManutencaoVeiculo(index);
        }
    }
}
