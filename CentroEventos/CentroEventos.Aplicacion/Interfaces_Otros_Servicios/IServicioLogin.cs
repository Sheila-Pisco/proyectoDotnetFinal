using System;
using CentroEventos.Aplicacion.Enumerativos;
namespace CentroEventos.Aplicacion.Interfaces_Otros_Servicios;

public interface IServicioLogin
{
    public void AlmacenarUsuario(string email, string contraseña);
}
