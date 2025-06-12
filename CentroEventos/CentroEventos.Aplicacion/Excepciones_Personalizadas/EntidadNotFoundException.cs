using System;

namespace CentroEventos.Aplicacion.Excepciones_Personalizadas;

public class EntidadNotFoundException: Exception
{
    public EntidadNotFoundException()
        : base("el id ingresado no existe") { } 
    public EntidadNotFoundException(string mensaje)
        : base(mensaje) { }
}
