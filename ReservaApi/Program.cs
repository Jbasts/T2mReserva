using ReservaT2M.Application.Services;
using ReservaT2M.Domain.Repositories;
using ReservaT2M.Domain.Services;
using ReservaT2M.Infrastructure.Messaging;
using ReservaT2M.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ReservaService>();
builder.Services.AddScoped<IHotelService ,HotelService>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<IReservaRepository, ReservaRepository>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// Add RabbitMQ Configuration
builder.Services.AddRabbitMQ(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
