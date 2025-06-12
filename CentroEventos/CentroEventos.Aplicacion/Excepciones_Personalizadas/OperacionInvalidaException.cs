using System;

namespace CentroEventos.Aplicacion.Excepciones_Personalizadas;

public class OperacionInvalidaException: Exception
{
    public OperacionInvalidaException()
        : base("Operacion invalida") { } 
    public OperacionInvalidaException(string mensaje)
        : base(mensaje) { }
    public OperacionInvalidaException(string mensaje, Exception innerException) { }
}
