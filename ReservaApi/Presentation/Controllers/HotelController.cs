using Microsoft.AspNetCore.Mvc;
using ReservaT2M.Application.DTOs;
using ReservaT2M.Domain.Entities;

[ApiController]
[Route("api/[controller]")]
public class HotelController : ControllerBase
{
    private readonly HotelService _hotelService;

    public HotelController(HotelService hotelService)
    {
        _hotelService = hotelService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<HotelDto>>> GetHoteis()
    {
        var hoteis = await _hotelService.ObterHoteisAsync();
        return Ok(hoteis.Select(h => new HotelDto
        {
            Id = h.Id,
            Nome = h.Nome,
            Endereco = h.Endereco,
            NumeroQuartos = h.NumeroQuartos
        }));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<HotelDto>> GetHotel(int id)
    {
        var hotel = await _hotelService.ObterHotelPorIdAsync(id);
        if (hotel == null)
            return NotFound();

        return Ok(new HotelDto
        {
            Id = hotel.Id,
            Nome = hotel.Nome,
            Endereco = hotel.Endereco,
            NumeroQuartos = hotel.NumeroQuartos
        });
    }

    [HttpPost]
    public async Task<ActionResult> CreateHotel(HotelDto hotelDto)
    {
        var hotel = new Hotel
        {
            Nome = hotelDto.Nome,
            Endereco = hotelDto.Endereco,
            NumeroQuartos = hotelDto.NumeroQuartos
        };

        await _hotelService.CriarHotelAsync(hotel);
        return CreatedAtAction(nameof(GetHotel), new { id = hotel.Id }, hotelDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateHotel(int id, HotelDto hotelDto)
    {
        var hotel = new Hotel
        {
            Id = id,
            Nome = hotelDto.Nome,
            Endereco = hotelDto.Endereco,
            NumeroQuartos = hotelDto.NumeroQuartos
        };

        await _hotelService.AtualizarHotelAsync(id, hotel);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteHotel(int id)
    {
        await _hotelService.DeletarHotelAsync(id);
        return NoContent();
    }
}
