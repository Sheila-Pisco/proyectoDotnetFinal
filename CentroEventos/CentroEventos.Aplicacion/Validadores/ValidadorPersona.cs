using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces_Repositorios;
using CentroEventos.Aplicacion.Excepciones_Personalizadas;
namespace CentroEventos.Aplicacion.Validadores;

public class ValidadorPersona (IRepositorioPersona repo_p)
{
    public bool Validador(Persona persona, out string mensajeError){

        mensajeError ="";
        if (string.IsNullOrWhiteSpace(persona.Nombre))
        {
            throw new ValidacionException(mensajeError); // mensajeError = "debe proporcionar un nombre valido";
        }
        if (string.IsNullOrWhiteSpace(persona.Apellido))
        {
            throw new ValidacionException(mensajeError);
        }
        if (string.IsNullOrWhiteSpace(persona.Email))
        {
            throw new ValidacionException(mensajeError);
        }
        else
        {
            if (repo_p.ExisteEmail(persona.Email))
            {
                throw new DuplicadoException(mensajeError);

            }
        }
        if (string.IsNullOrWhiteSpace(persona.Dni))
        {
            throw new ValidacionException(mensajeError);
        }
        else
        {
            if (repo_p.ExisteDniPersona(persona.Dni))
            {
                throw new DuplicadoException(mensajeError) ;
            }
        }
        return (mensajeError == "");
        
    }
}
