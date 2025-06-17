using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces_Repositorios;
using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Excepciones_Personalizadas;
namespace CentroEventos.Repositorios;

public class RepositorioReserva : IRepositorioReserva
{
    protected readonly CentroEventoContext context = new CentroEventoContext(); //Conecta el programa con la base de datos para, por ejemplo, pedir los datos
    public void AgregarReserva(Reserva reserva)
    {
        context.Reservas.Add(reserva); //agrega en "modo espera" la nueva reserva
        context.SaveChanges(); //agrega totalmente la reserva a la base de datos
        Console.WriteLine("Reserva agregada!");
    }
    public void EliminarReserva(int id_reserva)
    {
        var rEliminar = context.Reservas.Where(r => r.Id == id_reserva).FirstOrDefault();
        if (rEliminar == null)
            throw new EntidadNotFoundException();
        context.Remove(rEliminar); //elimina "momentaneamente"
        context.SaveChanges(); //elimina definitivamente
        Console.WriteLine("Eliminado B)");
    }

    public int ContarReservasSegunEvento(int id_evento)
    {
        var reservas = ListarReserva();
        int cantReservas = reservas.Where(r => r.EventoDeportivo_id == id_evento).Count(); //cuenta la cantidad de reservas que tienen el id del evento
        return cantReservas;
    }


    public bool ExisteCupo(int idEvento)
    {
        int reservasDelEvento = ContarReservasSegunEvento(idEvento);
        var evento = context.EventosDeportivos.Where(e => e.Id == idEvento).FirstOrDefault(); //devuelve el unico valor y devuelve null si no encuentra
        if (evento == null)
            return false;
        return evento.CupoMaximo > reservasDelEvento;
    }

    public bool ExisteReserva(int id_persona, int id_evento)  
    {
        var reserva = ListarReserva();
        var existe = reserva.Any(r => r.EventoDeportivo_id == id_evento && r.Persona_id == id_persona);
        return existe;
    }

    public bool ExisteReservaAsociadaEvento(int id_evento)
    {
        var reserva = ListarReserva();
        var existe = reserva.Any(r => r.EventoDeportivo_id == id_evento);
        return existe;
    }

    public bool ExisteReservaAsociadaPersona(int id_persona) //utilizado tanto para personas como para responsables
    {
        var reserva = ListarReserva();
        var existe = reserva.Any(r => r.Persona_id == id_persona);
        return existe;
    }

    public List<Persona> ListarAsistencia(int idEvento)
    {
        var Personas = context.Personas.ToList(); //preguntar
        var reservas = ListarReserva().Where(e => e.EventoDeportivo_id == idEvento && e.EstadoAsistencia == Estado.Presente).ToList(); //filtro la lista completa para sacar solamente las asociadas al evento y con asistencia presente
        var Lista_Asistencia = Personas.Where(p => reservas.Any(r => r.Persona_id == p.Id)).ToList(); // genero la lista de las personas que concuerdan con la reserva de estado presente.
        return Lista_Asistencia;
    }

    public List<EventoDeportivo> ListarEventosConCupo()
    {
        var LR = ListarReserva();
        var eventos = context.EventosDeportivos.ToList(); //preguntar si utilizo lo de repoEventoDeportivo
        var LEventosCupo = eventos.Where(e => {
            int reservasDelEvento = LR.Count(r => r.EventoDeportivo_id == e.Id);
            return reservasDelEvento < e.CupoMaximo;
            }//junta las reservas asociadas a los eventos y luego compara si la cantidad de reservas es menor al cupo maximo
        ).ToList(); //realiza las comparaciones y lista todo
        return LEventosCupo;
    }

    public List<Reserva> ListarReserva()
    {
        var LReservas = context.Reservas.ToList();
        return LReservas;
    }

    public void ModificarReserva(Reserva nuevareserva)
    {
        var r = context.Reservas.Find(nuevareserva.Id);
        if (r == null)
            throw new EntidadNotFoundException("El evento no existe.");
        else
        {
            context.Entry(r).CurrentValues.SetValues(nuevareserva); //Trae los valores del objeto y copia encima de estos, los nuevos
            context.SaveChanges(); //guarda los cambios en la base de datos
        }
        
    }
}
