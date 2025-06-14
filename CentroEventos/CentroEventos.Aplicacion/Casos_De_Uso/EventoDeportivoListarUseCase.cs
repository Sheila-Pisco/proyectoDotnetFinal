using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces_Repositorios;

namespace CentroEventos.Aplicacion.Casos_De_Uso;

public class EventoDeportivoListarUseCase(IRepositorioEventoDeportivo repoE)
{
    public List<EventoDeportivo> Ejecutar()
    {
        return repoE.ListarEventos();
    }
}
