using System;
using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Interfaces_Otros_Servicios;
namespace CentroEventos.Aplicacion.Servicio_Autorizacion;

public class ServicioLogin : IServicioLogin
{
    public void AlmacenarUsuario(string email, string contraseña)
    {
        throw new NotImplementedException();
        //chequear que mail sea valido con try catch y la contraseña hacerle un hash 
        //tener un Ejecutar que utilice el repositorio Usuario
    }
}