using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entidades.Parametrica;
using Servicios.Interface;
using UoW.Interface;

namespace Servicios.Service
{
    public class EstadoMantenimientoServicio : IEstadoMantenimientoServicio
    {
        private IUoW _unitOfWork;
        public EstadoMantenimientoServicio(IUoW unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<EstadoMantenimiento>> ConsultarTodo()
        {
            List<EstadoMantenimiento> LstEstadoMantenimiento = new List<EstadoMantenimiento>();
            try
            {
                using (var contexto = _unitOfWork.Crear())
                {
                    LstEstadoMantenimiento = await contexto.Repositorios.EstadoMantenimientoRepositorio.ObtenerTodoAsync();
                }
                return LstEstadoMantenimiento;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
