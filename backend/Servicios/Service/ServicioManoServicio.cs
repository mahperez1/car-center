using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entidades.Parametrica;
using Servicios.Interface;
using UoW.Interface;
using UoW.Interface;

namespace Servicios.Service
{
    public class ServicioManoServicio : IServicioManoServicio
    {
        private IUoW _unitOfWork;
        public ServicioManoServicio(IUoW unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ServicioMano>> consultarTodo()
        {

            List<ServicioMano> LstServicioMano = new List<ServicioMano>();
            try
            {
                using (var contexto = _unitOfWork.Crear())
                {
                    LstServicioMano = await contexto.Repositorios.ServicioManoRepositorio.ObtenerTodoAsync();
                }
                return LstServicioMano;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
