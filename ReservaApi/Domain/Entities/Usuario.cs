namespace ReservaT2M.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public List<Reserva> Reservas { get; set; } = new List<Reserva>();

        public bool FazerReserva(Hotel hotel, Reserva reserva)
        {
            return hotel.ReservarQuarto(this, reserva);
        }

        public void CancelarReserva(Reserva reserva)
        {
            reserva.Hotel.LiberarQuarto(reserva);
            Reservas.Remove(reserva);
        }
    }
}
