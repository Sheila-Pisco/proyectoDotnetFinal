using System;
using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Interfaces_Otros_Servicios;
using CentroEventos.Aplicacion.Interfaces_Repositorios;
using CentroEventos.Aplicacion.Excepciones_Personalizadas;

namespace CentroEventos.Aplicacion.Casos_De_Uso;

public class ReservaBajaUseCase(IRepositorioReserva repoR, IServicioAutorizacion autorizacion)
{
    public void Ejecutar (int idReserva, int idUsuario){

        if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.ReservaBaja))
        {
            throw new FalloAutorizacionException();
        }
        repoR.EliminarReserva(idReserva);
    }
}
