using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DesafioFundamentos
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        List<Veiculo> veiculos = new List<Veiculo>();

        public Estacionamento() { }

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.Write("Digite qual o veículo a ser estacionado: ");
            string nomeVeiculo = Console.ReadLine();
            Console.Write("Digite a placa do veículo: ");
            string placaVeiculo = Console.ReadLine();

            if (ValidarPlaca(placaVeiculo))
            {
                veiculos.Add(new Veiculo
                {
                    NomeVeiculo = nomeVeiculo,
                    PlacaVeiculo = placaVeiculo
                });
            }
            else
                throw new Exception("A placa inserida não é válida.");

        }

        public void RemoverVeiculo()
        {
            List<Veiculo> veiculoRemove = new List<Veiculo>();
            Console.Write("Digite a placa do veículo para remover: ");
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.PlacaVeiculo.ToUpper() == placa.ToUpper()))
            {
                Console.Write("Digite a quantidade de horas que o veículo permaneceu estacionado: ");
                decimal horasEstacionadas = Convert.ToDecimal(Console.ReadLine());
                decimal valorTotal = precoInicial + (precoPorHora * horasEstacionadas);

                veiculos.Remove(veiculos.Where(c => c.PlacaVeiculo == placa).FirstOrDefault());
                Console.WriteLine($"O veículo de {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (Veiculo carros in veiculos)
                {
                    Console.WriteLine($"Veículo - { carros.NomeVeiculo } de placa {carros.PlacaVeiculo}");
                }
            }
            else
                Console.WriteLine("Não há veículos estacionados.");
        }

        private static bool ValidarPlaca(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa))
                return false;

            if (placa.Length > 8)
                return false;

            placa = placa.Replace("-", "").Trim();

            /*
             *  Verifica se o caractere da posição 4 é uma letra, se sim, aplica a validação para o formato de placa do Mercosul,
             *  senão, aplica a validação do formato de placa padrão.
             */
            if (char.IsLetter(placa, 4))
            {
                /*
                 *  Verifica se a placa está no formato: três letras, um número, uma letra e dois números.
                 */
                var padraoMercosul = new Regex("[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}");
                return padraoMercosul.IsMatch(placa);
            }
            else
            {
                // Verifica se os 3 primeiros caracteres são letras e se os 4 últimos são números.
                var padraoNormal = new Regex("[a-zA-Z]{3}[0-9]{4}");
                return padraoNormal.IsMatch(placa);
            }
        }
    }
}