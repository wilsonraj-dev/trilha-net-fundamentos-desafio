using System.Collections.Generic;

namespace DesafioFundamentos
{
    public class Veiculo
    {
        public string NomeVeiculo { get; set; }

        public string PlacaVeiculo { get; set; }

        public List<Veiculo> veiculos = new List<Veiculo>();

        public Veiculo() { }

        public Veiculo(string nomeVeiculo, string placaVeiculo)
        {
            this.NomeVeiculo = nomeVeiculo;
            this.PlacaVeiculo = placaVeiculo;
        }
    }
}