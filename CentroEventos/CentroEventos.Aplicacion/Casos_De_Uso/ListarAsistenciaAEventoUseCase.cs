using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces_Repositorios;

namespace CentroEventos.Aplicacion.Casos_De_Uso;

public class ListarAsistenciaAEventoUseCase(IRepositorioReserva repoR)
{
    public List<Persona> Ejecutar(int idEvento){
        return repoR.ListarAsistencia(idEvento);
    }
}
