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

        public void AlugarVeiculo()
        {

        } 

        public void ShowVeiculos()
        {
            for(int i = 0;i<listaVeiculos.Count;i++){

                Console.WriteLine($"Veiculo {i + 1}:");
                Console.WriteLine($"Número de Portas: {listaVeiculos[i].NumeroPortas}");
                Console.WriteLine($"Tipo de Caixa: {listaVeiculos[i].TipoCaixa}");
                Console.WriteLine($"Cilindrada: {listaVeiculos[i].Cilindrada}");
                Console.WriteLine($"Número de Eixos: {listaVeiculos[i].NumeroEixos}");
                Console.WriteLine($"Máximo de Passageiros: {listaVeiculos[i].MaxPassageiros}");
                Console.WriteLine($"Peso Máximo: {listaVeiculos[i].PesoMaximo}");
                Console.WriteLine($"Valor de Aluguer Diário: {listaVeiculos[i].ValorAluguerDiario}");
                Console.WriteLine($"Status de Aluguer: {listaVeiculos[i].StatusAluguer}");
                Console.WriteLine($"Status de Manutenção: {listaVeiculos[i].StatusManutencao}");
                Console.WriteLine(); 

            }
        }
    }
}
