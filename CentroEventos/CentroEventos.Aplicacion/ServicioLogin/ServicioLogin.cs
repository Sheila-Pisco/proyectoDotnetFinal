using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Interfaces_Otros_Servicios;
namespace CentroEventos.Aplicacion.Servicio_Autorizacion;

public class ServicioLogin : IServicioLogin
{
    public void AlmacenarUsuario(Usuario usuario)
    {
        /* para iniciar sesion recibo emaily contrania y lo busco en la base de datos
        si el repo retorna null es decir que no lo encontro y la persona tiene que ser registrada
        opcion 1 : volver a intentarlo 
        opcion 2 : opcion de registrarse*/
    }
    
}