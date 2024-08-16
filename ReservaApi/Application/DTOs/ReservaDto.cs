using Microsoft.AspNetCore.Mvc;
using Npgsql;
using ReservaT2M.Application.DTOs;
using ReservaT2M.Application.Services;
using ReservaT2M.Domain.Entities;
using ReservaT2M.Domain.Repositories;
using System.Data;

namespace ReservaT2M.Application.DTOs
{
    public class ReservaDto
    {
        public int Id { get; set; }
        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }
        public int NumeroQuarto { get; set; }
        public int Hotel_Id { get; set; }
        public int Usuario_Id { get; set; }
    }
}


