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
        if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.UsuarioBaja))
        {
            throw new FalloAutorizacionException();
        }
        if (repoR.ExisteReservaAsociadaPersona(idPersona) || repoE.EsResponsableDeEvento(idPersona))
        {
            throw new Exception("No se puede eliminar una persona porque tiene una reserva asociada");
        }
        repoP.EliminarPersona(idPersona);
    }
}
