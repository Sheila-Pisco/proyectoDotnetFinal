using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enumerativos;

namespace CentroEventos.Aplicacion.Interfaces_Repositorios;

public interface IRepositorioUsuario
{
    public void AgregarUsuario(Usuario usuario);
    public List<Usuario> GetUsuarios();
    public void EliminarUsuario(int id);
    public void ModificarUsuario(Usuario usuario);
    public Usuario ObtenerUsuario(int id_Usuario);
    public bool BuscarPermiso(int Id_Usuario, Permiso permiso);
    
}
