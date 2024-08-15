using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            // *IMPLEMENTADO*                     
            bool placaValida = false;

            while (!placaValida)
            {
                Console.WriteLine("Digite a placa do veículo para estacionar:"); 
                string placa = Console.ReadLine().ToUpper();

                if (placa.Length == 7 || !placa.Contains("-"))
                {   

                    bool validadorPlacaAntiga = Regex.IsMatch(placa, @"^[A-Z]{3}\d{4}$");
                    bool validadorPlacaMercosul = Regex.IsMatch(placa, @"^[A-Z]{3}\d{1}[A-Z]{1}\d{2}$");

                    if (validadorPlacaAntiga || validadorPlacaMercosul)
                        {   
                            veiculos.Add(placa);
                            placaValida = true;
                        }
                        else
                        {
                            Console.WriteLine("Favor digitar no seguinte padão ABC1234 ou ABC1D23");
                        }
                }
                else
                {
                    Console.WriteLine("Placa inválida, digite uma placa de 7 dígitos sem o hífen.");
                }
            }          
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // TODO: Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTADO*
            string placa = "";
            placa = Console.ReadLine().ToUpper();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                // *IMPLEMENTADO*
                int horas = int.Parse(Console.ReadLine());                    
                decimal valorTotal = precoInicial + precoPorHora * horas;

                // TODO: Remover a placa digitada da lista de veículos
                // *IMPLEMENTADO*
                veiculos.Remove(placa); 

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTADO*
                for (int contador = 0; contador < veiculos.Count; contador++)
                {
                    Console.WriteLine($"{contador+1} - {veiculos[contador]}");
                }                 
            
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
