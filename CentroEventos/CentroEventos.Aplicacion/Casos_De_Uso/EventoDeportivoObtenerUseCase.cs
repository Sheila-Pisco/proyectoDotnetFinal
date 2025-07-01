using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces_Repositorios;
namespace CentroEventos.Aplicacion.Casos_De_Uso;

public class EventoDeportivoObtenerUseCase(IRepositorioEventoDeportivo repoE)
{
    public EventoDeportivo Ejecutar(int? id_evento)
    {
        return repoE.ObtenerEvento(id_evento); 
    }
}
