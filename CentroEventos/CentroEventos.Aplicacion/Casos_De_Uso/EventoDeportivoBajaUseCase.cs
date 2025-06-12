using System;
using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Excepciones_Personalizadas;
using CentroEventos.Aplicacion.Interfaces_Otros_Servicios;
using CentroEventos.Aplicacion.Interfaces_Repositorios;

namespace CentroEventos.Aplicacion.Casos_De_Uso;

public class EventoDeportivoBajaUseCase(IRepositorioEventoDeportivo repoE, IServicioAutorizacion autorizacion,IRepositorioReserva repoR) //inyección de dependencias
{
    public void Ejecutar(int idEvento, int idUsuario)
    {
        if (!autorizacion.PoseeElPermiso(idUsuario,Permiso.EventoBaja))
        {
            throw new FalloAutorizacionException();
        }
        if (!repoR.ExisteReservaAsociadaEvento(idEvento))
        {
            throw new Exception("No se puede eliminar el evento porque existen reservas asociadas.");
        }
        repoE.EliminarEvento(idEvento);
    }
}
