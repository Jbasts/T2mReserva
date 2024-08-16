namespace ReservaT2M.Domain.Entities
{
    public class Reserva
    {
        public int Id { get; set; }
        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }
        public int NumeroQuarto { get; set; }
        public Hotel Hotel { get; set; }
        public Usuario Usuario { get; set; }

        public double CalcularValor()
        {
            // Implementação da lógica de cálculo do valor
            return 0.0;
        }

        public bool VerificarDisponibilidade()
        {
            // Implementação da lógica de verificação de disponibilidade
            return true;
        }
    }
}
