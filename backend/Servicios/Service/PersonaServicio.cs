using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entidades.Negocio;
using Servicios.Interface;
using UoW.Interface;

namespace Servicios.Service
{
    public class PersonaServicio : IPersonaServicio
    {
        private IUoW _unitOfWork;
        public PersonaServicio(IUoW unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Persona>> consultarTodo()
        {
            List<Persona> LstPersona = new List<Persona>();
            try
            {
                using (var contexto = _unitOfWork.Crear())
                {
                    LstPersona = await contexto.Repositorios.PersonaRepositorio.ObtenerTodoAsync();
                }
                return LstPersona;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> crear(Persona model)
        {
            try
            {
                bool respuesta;
                using (var contexto = _unitOfWork.Crear()) {
                    respuesta = await contexto.Repositorios.PersonaRepositorio.CrearAsync(model);
                    contexto.SaveChange();
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
