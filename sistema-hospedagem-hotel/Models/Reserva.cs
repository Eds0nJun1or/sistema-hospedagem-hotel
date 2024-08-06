namespace sistema_hospedagem_hotel.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            if (diasReservados <= 0)
                throw new ArgumentException("O número de dias reservados deve ser um número positivo.");

            DiasReservados = diasReservados;
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite ?? throw new ArgumentException("A reserva deve estar associada a uma suíte.");
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (hospedes == null || hospedes.Count == 0)
                throw new ArgumentException("A reserva deve ter pelo menos um hóspede.");

            if (hospedes.Count > Suite.Capacidade)
                throw new ArgumentException("O número de hóspedes excede a capacidade da suíte.");

            Hospedes = hospedes;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = DiasReservados * Suite.ValorDiaria;
            if (DiasReservados >= 10)
            {
                valor *= 0.9m; // Aplicando desconto de 10%
            }
            return valor;
        }
    }
}
