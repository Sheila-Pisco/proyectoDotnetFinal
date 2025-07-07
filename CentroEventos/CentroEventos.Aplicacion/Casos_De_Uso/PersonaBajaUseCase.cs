using System;
using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Interfaces_Otros_Servicios;
using CentroEventos.Aplicacion.Interfaces_Repositorios;
using CentroEventos.Aplicacion.Excepciones_Personalizadas;

namespace CentroEventos.Aplicacion.Casos_De_Uso;

public class PersonaBajaUseCase(IRepositorioPersona repoP, IRepositorioReserva repoR, IRepositorioEventoDeportivo repoE, IServicioAutorizacion autorizacion)
{
    public void Ejecutar(int idPersona, int idUsuario)
    {
        if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.PersonaBaja))
        {
            throw new FalloAutorizacionException();
        }
        if (repoR.ExisteReservaAsociadaPersona(idPersona) || repoE.EsResponsableDeEvento(idPersona))
        {
            throw new Exception($"La operación no pudo concretarse. La persona que intenta eliminar tiene una reserva asociada");
        }
        repoP.EliminarPersona(idPersona);
    }
}
