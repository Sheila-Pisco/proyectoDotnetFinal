using System;
using CentroEventos.Aplicacion.Enumerativos;
namespace CentroEventos.Aplicacion.Interfaces_Otros_Servicios;

public interface IServicioAutorizacion
{
    public bool PoseeElPermiso(int IdUsuario,Permiso permiso);
}
