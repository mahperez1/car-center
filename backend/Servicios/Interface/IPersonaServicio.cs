using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entidades.Negocio;

namespace Servicios.Interface
{
    public interface IPersonaServicio
    {
        Task<List<Persona>> consultarTodo();
        Task<bool> crear(Persona model);
    }
}
