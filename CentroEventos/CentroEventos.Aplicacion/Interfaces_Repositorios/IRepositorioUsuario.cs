using System;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces_Repositorios;

public interface IRepositorioUsuario
{
    public void AgregarUsuario(Usuario usuario);
    public List<Usuario> GetUsuarios();
    public void EliminarUsuario(int id);
    public void ModificarUsuario(Usuario usuario);
    
}
