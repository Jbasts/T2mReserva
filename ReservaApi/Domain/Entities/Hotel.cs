namespace ReservaT2M.Domain.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int NumeroQuartos { get; set; }

        public bool ReservarQuarto(Usuario usuario, Reserva reserva)
        {
            // Implementação da lógica de reserva
            return true;
        }

        public void LiberarQuarto(Reserva reserva)
        {
            // Implementação da lógica de liberação de quarto
        }

        public bool DisponibilidadeQuarto()
        {
            // Implementação da lógica de verificação de disponibilidade
            return true;
        }
    }
}
