using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Casos_De_Uso;
using CentroEventos.Aplicacion.Interfaces_Repositorios;
using CentroEventos.Repositorios;
using CentroEventos.UI.Components;
using CentroEventos.Aplicacion.Interfaces_Otros_Servicios;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Servicio_Autorizacion;
using CentroEventos.Aplicacion.Servicio_Login;

//Inicializa la base de datos:
CentroEventosSqlite.Inicializar(); //solo tiene efecto si la base de datos no existe
using var context = new CentroEventoContext();

/*Agrego algunos datos

context.EventosDeportivos.Add(new EventoDeportivo("Aerobicos", "Movimiento", new DateTime(2025, 1, 1), 1.5, 15, 2));
context.EventosDeportivos.Add(new EventoDeportivo("Zumba", "Baile", new DateTime(2025, 7, 7), 1.5, 25, 3));
context.EventosDeportivos.Add(new EventoDeportivo("Funcional", "Desafío", new DateTime(2025, 8, 9), 1.5, 10, 4));
context.EventosDeportivos.Add(new EventoDeportivo("G.A.P", "Movimiento", new DateTime(2025, 9, 1), 1.5, 20, 5));
context.EventosDeportivos.Add(new EventoDeportivo("Judo", "Lucha", new DateTime(2025, 8, 9), 1.5, 10, 6));

context.Reservas.Add(new Reserva(3, 1, DateTime.Now, Estado.Pendiente));
context.Reservas.Add(new Reserva(2, 3, DateTime.Now, Estado.Pendiente));
context.Reservas.Add(new Reserva(2, 2, DateTime.Now, Estado.Pendiente));
context.Reservas.Add(new Reserva(4, 3, DateTime.Now, Estado.Pendiente));
context.Reservas.Add(new Reserva(3, 1, DateTime.Now, Estado.Pendiente));

context.Personas.Add(new Persona("123456", "Tomas", "Emma", "tiene@gmail.com", "221567890"));
context.Personas.Add(new Persona("15870", "Gado", "Leandro", "alperro@gmail.com", "111594420"));
context.Personas.Add(new Persona("233569", "Ceballo", "Julia", "rando@gmail.com", "157896290"));
context.Personas.Add(new Persona("785426","Quito", "Esteban", "roto@gmail", "221567890") );

context.SaveChanges();
*/

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

// Agregamos estos servicios al conteiner DI

builder.Services.AddTransient<UsuarioAltaUseCase>();
builder.Services.AddTransient<UsuarioBajaUseCase>();
builder.Services.AddTransient<UsuarioModificacionesUseCase>();
builder.Services.AddTransient<UsuarioListarUseCase>();
builder.Services.AddTransient<ValidadorUsuario>();
builder.Services.AddTransient<UsuarioObtenerUseCase>();
builder.Services.AddTransient<UsuarioRegistrarUseCase>();
builder.Services.AddTransient<IRepositorioUsuario, RepositorioUsuario>();

builder.Services.AddTransient<EventoDeportivoAltaUseCase>();
builder.Services.AddTransient<EventoDeportivoModificacionUseCase>();
builder.Services.AddTransient<EventoDeportivoBajaUseCase>();
builder.Services.AddTransient<EventoDeportivoListarUseCase>();
builder.Services.AddTransient<EventoDeportivoObtenerUseCase>();
builder.Services.AddTransient<IRepositorioEventoDeportivo, RepositorioEventoDeportivo>();
builder.Services.AddTransient<ValidadorEventoDeportivo>();
builder.Services.AddTransient<ListarEventosConCupoDisponibleUseCase>();
builder.Services.AddTransient<ListarAsistenciaAEventoUseCase>();

builder.Services.AddTransient<PersonaAltaUseCase>();
builder.Services.AddTransient<PersonaBajaUseCase>();
builder.Services.AddTransient<PersonaModificacionUseCase>();
builder.Services.AddTransient<PersonaListarUseCase>();
builder.Services.AddTransient<PersonaObtenerUseCase>();
builder.Services.AddTransient<ValidadorPersona>();
builder.Services.AddTransient<IRepositorioPersona, RepositorioPersona>();

builder.Services.AddTransient<ReservaAltaUseCase>();
builder.Services.AddTransient<ReservaBajaUseCase>();
builder.Services.AddTransient<ReservaModificacionUseCase>();
builder.Services.AddTransient<ReservaListarUseCase>();
builder.Services.AddTransient<ReservaObtenerUseCase>(); 
builder.Services.AddTransient<ValidadorReserva>();
builder.Services.AddTransient<IRepositorioReserva, RepositorioReserva>();

builder.Services.AddTransient<CentroEventoContext>();
builder.Services.AddTransient<IServicioAutorizacion, ServicioAutorizacion>();
builder.Services.AddScoped<ServicioLogin>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
app.Run();


 