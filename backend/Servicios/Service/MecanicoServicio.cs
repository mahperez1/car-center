using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entidades.Negocio;
using Servicios.Interface;
using UoW.Interface;

namespace Servicios.Service
{
    public class MecanicoServicio : IMecanicoServicio
    {
        private IUoW _unitOfWork;
        public MecanicoServicio(IUoW unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Mecanico>> consultarTodo()
        {
            List<Mecanico> LstMecanico = new List<Mecanico>();
            try
            {
                using (var contexto = _unitOfWork.Crear())
                {
                    LstMecanico = await contexto.Repositorios.MecanicoRepositorio.ObtenerTodoAsync();
                }
                return LstMecanico;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> crear(Mecanico model)
        {
            try
            {
                bool respuesta= false;
                using (var contexto = _unitOfWork.Crear()) {
                    string id = await contexto.Repositorios.MecanicoRepositorio.CrearAsync(model);
                    if (!string.IsNullOrEmpty(id)) {
                        respuesta = true;
                        contexto.SaveChange();
                    }
                }
                return respuesta;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
