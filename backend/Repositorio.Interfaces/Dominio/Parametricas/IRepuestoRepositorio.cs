using System;
using System.Collections.Generic;
using System.Text;
using Entidades.Parametrica;
using Repositorio.Interfaces.Acciones;

namespace Repositorio.Interfaces.Dominio.Parametricas
{
    public interface IRepuestoRepositorio: ICrearRepositorio<Repuesto, int>, IConsultarTodoRepositorio<Repuesto>, IConsultarxIdRepositorio<Repuesto,int>, IActualizarRepositorio<Repuesto>
    {
    }
}
