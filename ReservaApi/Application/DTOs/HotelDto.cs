using Microsoft.AspNetCore.Mvc;
using Npgsql;
using ReservaT2M.Application.DTOs;
using ReservaT2M.Application.Services;
using ReservaT2M.Domain.Entities;
using ReservaT2M.Domain.Repositories;
using ReservaT2M.Infrastructure.Messaging;
using ReservaT2M.Infrastructure.Repositories;
using System.Data;

namespace ReservaT2M.Application.DTOs
{
    public class HotelDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int NumeroQuartos { get; set; }
    }
}

