using System;
using CentroEventos.Aplicacion.Interfaces_Otros_Servicios;
using CentroEventos.Aplicacion.Interfaces_Repositorios;
using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Excepciones_Personalizadas;

namespace CentroEventos.Aplicacion.Casos_De_Uso;

public class UsuarioBajaUseCase(IRepositorioUsuario repoUs , IServicioAutorizacion autorizacion)
{
    public void Ejecutar( int idUsuario)
    {
       /* if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.UsuarioBaja))
        {
            throw new FalloAutorizacionException();
        }*/

        repoUs.EliminarUsuario(idUsuario);
    }
}
