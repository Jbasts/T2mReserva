using System;
using System.Collections.Generic;
using System.Linq;

namespace ReservaT2M.Domain.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int NumeroQuartos { get; set; }

        private List<Reserva> Reservas { get; set; } = new List<Reserva>();

        public bool ReservarQuarto(Usuario usuario, Reserva reserva)
        {
            if (DisponibilidadeQuarto(reserva.DataCheckIn, reserva.DataCheckOut))
            {
                reserva.Usuario = usuario;
                reserva.Hotel = this;
                Reservas.Add(reserva);
                usuario.Reservas.Add(reserva);
                return true;
            }
            return false;
        }

        public void LiberarQuarto(Reserva reserva)
        {
            Reservas.Remove(reserva);
        }

        public bool DisponibilidadeQuarto(DateTime dataCheckIn, DateTime dataCheckOut)
        {
            int quartosReservados = Reservas
                .Count(r => r.DataCheckIn < dataCheckOut && r.DataCheckOut > dataCheckIn);

            return quartosReservados < NumeroQuartos;
        }
    }
}