using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces_Repositorios;

namespace CentroEventos.Aplicacion.Casos_De_Uso;

public class UsuarioListarUseCase(IRepositorioUsuario repoU) {
    public List<Usuario> Ejecutar()
    {
        return repoU.GetUsuarios();
    }
}

