using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces_Repositorios;

namespace CentroEventos.Aplicacion.Casos_De_Uso;

public class ReservaListarUseCase (IRepositorioReserva repoR)
{
    public List<Reserva> Ejecutar()
    {
        return repoR.ListarReserva();
    }
}