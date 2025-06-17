using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces_Repositorios;

namespace CentroEventos.Aplicacion.Casos_De_Uso;

public class ListarEventosConCupoDisponibleUseCase(IRepositorioReserva repoR)
{
    public List<EventoDeportivo> Ejecutar()
    {
        return repoR.ListarEventosConCupo();
    }
}
