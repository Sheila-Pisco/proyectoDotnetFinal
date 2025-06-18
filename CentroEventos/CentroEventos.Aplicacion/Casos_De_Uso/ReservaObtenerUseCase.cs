using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces_Repositorios;

namespace CentroEventos.Aplicacion.Casos_De_Uso;

public class ReservaObtenerUseCase(IRepositorioReserva repoR)
{
    public Reserva Ejecutar(int idReserva)
    {
        return repoR.ObtenerReserva(idReserva);
    }
}