using ReservaT2M.Domain.Entities;

public class Reserva
{
    public int Id { get; set; }
    public DateTime DataCheckIn { get; set; }
    public DateTime DataCheckOut { get; set; }
    public int NumeroQuarto { get; set; }
    public int HotelId { get; set; }
    public int UsuarioId { get; set; }

    public double CalcularValor()
    {
        double valorPorDia = 100.0;
        int dias = (DataCheckOut - DataCheckIn).Days;

        return dias * valorPorDia;
    }

    //public bool VerificarDisponibilidade()
    //{
    //    return Hotel.DisponibilidadeQuarto(DataCheckIn, DataCheckOut);
    //}
}
