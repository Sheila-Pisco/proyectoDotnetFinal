using System;
using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Interfaces_Otros_Servicios;
using CentroEventos.Aplicacion.Interfaces_Repositorios;
namespace CentroEventos.Aplicacion.Servicio_Autorizacion;

public class ServicioAutorizacion(IRepositorioUsuario repoU):IServicioAutorizacion
{
    public bool PoseeElPermiso(int IdUsuario, Permiso permiso)
    {
        return repoU.BuscarPermiso(IdUsuario, permiso); 
    }
}
