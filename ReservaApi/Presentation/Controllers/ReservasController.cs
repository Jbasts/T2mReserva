using Microsoft.AspNetCore.Mvc;
using ReservaT2M.Application.DTOs;
using ReservaT2M.Application.Services;
using ReservaT2M.Domain.Entities;

[ApiController]
[Route("api/[controller]")]
public class ReservaController : ControllerBase
{
    private readonly ReservaService _reservaService;

    public ReservaController(ReservaService reservaService)
    {
        _reservaService = reservaService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReservaDto>>> GetReservas()
    {
        var reservas = await _reservaService.ObterReservasAsync();
        return Ok(reservas.Select(r => new ReservaDto
        {
            Id = r.Id,
            DataCheckIn = r.DataCheckIn,
            DataCheckOut = r.DataCheckOut,
            NumeroQuarto = r.NumeroQuarto,
            HotelId = r.HotelId,
            UsuarioId = r.UsuarioId
        }));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReservaDto>> GetReserva(int id)
    {
        var reserva = await _reservaService.ObterReservaPorIdAsync(id);
        if (reserva == null)
            return NotFound();

        return Ok(new ReservaDto
        {
            Id = id,
            DataCheckIn = reserva.DataCheckIn,
            DataCheckOut = reserva.DataCheckOut,
            NumeroQuarto = reserva.NumeroQuarto,
            HotelId = reserva.HotelId,
            UsuarioId = reserva.UsuarioId
        });
    }

    [HttpPost]
    public async Task<ActionResult> CreateReserva(ReservaDto reservaDto)
    {
       

        await _reservaService.CriarReservaAsync(reservaDto);
        return CreatedAtAction(nameof(GetReserva), new { id = reservaDto.Id }, reservaDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateReserva(int id, ReservaDto reservaDto)
    {
        var reserva = new Reserva
        {
            Id = id,
            DataCheckIn = reservaDto.DataCheckIn,
            DataCheckOut = reservaDto.DataCheckOut,
            NumeroQuarto = reservaDto.NumeroQuarto,
            HotelId = reservaDto.HotelId,
            UsuarioId = reservaDto.UsuarioId
        };

        await _reservaService.AtualizarReservaAsync(id, reserva);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteReserva(int id)
    {
        await _reservaService.DeletarReservaAsync(id);
        return NoContent();
    }
}
