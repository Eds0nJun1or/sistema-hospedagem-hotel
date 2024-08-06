namespace sistema_hospedagem_hotel.Models
{
    public class Suite
    {
        public Suite() { }

        public Suite(string tipoSuite, int capacidade, decimal valorDiaria)
        {
            if (capacidade <= 0)
                throw new ArgumentException("A capacidade da suíte deve ser um número positivo.");

            if (valorDiaria <= 0)
                throw new ArgumentException("O valor da diária deve ser um valor positivo.");

            TipoSuite = tipoSuite;
            Capacidade = capacidade;
            ValorDiaria = valorDiaria;
        }

        public string TipoSuite { get; set; }
        public int Capacidade { get; set; }
        public decimal ValorDiaria { get; set; }
    }
}