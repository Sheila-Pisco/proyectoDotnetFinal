using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces_Repositorios;

namespace CentroEventos.Aplicacion.Casos_De_Uso;

public class UsuarioObtenerUseCase(IRepositorioUsuario repoUs)
{
    public Usuario Ejecutar(int id_Usuario)
    {
        return repoUs.ObtenerUsuario(id_Usuario);
    }
}
