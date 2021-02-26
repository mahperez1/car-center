using System;
using System.Collections.Generic;
using System.Text;
using UoW.Interface;
using Servicios.Interface;
using System.Threading.Tasks;
using Entidades.Parametrica;

namespace Servicios.Service
{
    public class RepuestoServicio : IRepuestoServicio
    {
        private IUoW _unitOfWork;
        public RepuestoServicio(IUoW unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Repuesto>> consultarTodo()
        {
            List<Repuesto> LstRepuesto = new List<Repuesto>();
            try
            {
                using (var contexto = _unitOfWork.Crear())
                {
                    LstRepuesto = await contexto.Repositorios.RepuestoRepositorio.ObtenerTodoAsync();
                }
                return LstRepuesto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
