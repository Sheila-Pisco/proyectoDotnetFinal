using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces_Repositorios;
using CentroEventos.Aplicacion.Excepciones_Personalizadas;
namespace CentroEventos.Aplicacion.Validadores;

public class ValidadorPersona (IRepositorioPersona repo_p)
{
    public bool Validador(Persona persona, out string mensajeError,bool ok){

        mensajeError ="";
        if (string.IsNullOrWhiteSpace(persona.Nombre))
        {
            mensajeError = "Debe proporcionar un Nombre valido \n"; // mensajeError = "debe proporcionar un nombre valido";
        }
        if (string.IsNullOrWhiteSpace(persona.Apellido))
        {
              mensajeError += "El campo apellido no puede estar vacio \n";
        }
        if (string.IsNullOrWhiteSpace(persona.Email))
        {
              mensajeError += "El campo email no puede estar vacio \n";
        }
        else
        {
            if (repo_p.ExisteEmail(persona.Email)&& ok)
            {
                mensajeError += $"Existe una persona asociada a este email{persona.Email} \n";
            }
        }
        if (string.IsNullOrWhiteSpace(persona.Dni))
        {
             mensajeError += "El campo dni no puede estar vacio \n";
        }
        else
        {
            if (repo_p.ExisteDniPersona(persona.Dni)&& ok)
            {
                 mensajeError += "Existe una persona con este dni asociado \n"; 
            }
        }
        return mensajeError == "";
        
    }
}
