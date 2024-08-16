namespace ReservaT2M.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public List<Reserva> Reservas { get; set; }

        public bool FazerReserva(Hotel hotel, Reserva reserva)
        {
            // Implementação da lógica de fazer uma reserva
            return true;
        }

        public void CancelarReserva(Reserva reserva)
        {
            // Implementação da lógica de cancelamento de reserva
        }
    }
}
