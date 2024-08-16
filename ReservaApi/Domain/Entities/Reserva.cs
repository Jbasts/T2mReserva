using ReservaT2M.Domain.Entities;

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
        double valorPorDia = 100.0; // Valor fixo por dia (exemplo)
        int dias = (DataCheckOut - DataCheckIn).Days;

        return dias * valorPorDia;
    }

    public bool VerificarDisponibilidade()
    {
        return Hotel.DisponibilidadeQuarto(DataCheckIn, DataCheckOut);
    }
}
