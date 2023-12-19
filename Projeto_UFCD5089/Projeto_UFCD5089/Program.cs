

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
            Console.WriteLine("Indian Guy");
        }

        private static void AdicionarVeiculo()
        {
            Console.Write("Informe o número de portas do veículo: ");
            int numeroPortas = int.Parse(Console.ReadLine());

            Console.Write("Informe o tipo de caixa do veículo: ");
            string tipoCaixa = Console.ReadLine();

            Console.Write("Informe a cilindrada do veículo: ");
            int cilindrada = int.Parse(Console.ReadLine());

            Console.Write("Informe o número de eixos do veículo: ");
            int numeroEixos = int.Parse(Console.ReadLine());

            Console.Write("Informe o número máximo de passageiros do veículo: ");
            int maxPassageiros = int.Parse(Console.ReadLine());

            Console.Write("Informe o peso máximo do veículo: ");
            int pesoMaximo = int.Parse(Console.ReadLine());

            Console.Write("Informe o valor do aluguer diário do veículo: ");
            double valorAluguerDiario = double.Parse(Console.ReadLine());

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
