using System;
using CentroEventos.Aplicacion.Entidades;
namespace CentroEventos.Aplicacion.Interfaces_Repositorios;

public interface IRepositorioReserva
{
    public void AgregarReserva(Reserva reserva);
    public void EliminarReserva(int id_reserva);
    public void ModificarReserva(Reserva reserva);
    public bool ExisteReserva(int id_persona, int id_evento);
    public bool ExisteReservaAsociadaPersona(int id_persona);
    public bool ExisteReservaAsociadaEvento(int id_evento);
    public bool ExisteResposable(int IdResponsable);
    public bool ExisteCupo(int idEvento);
    public List<EventoDeportivo> ListarEventosConCupo();
    public List<Persona> ListarAsistencia(int idEvento);
    public List<Reserva> ListarReserva();
    public int ContarReservasSegunEvento(int id_evento);
}
