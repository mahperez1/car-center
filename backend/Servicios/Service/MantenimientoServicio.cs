using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entidades.Negocio;
using Servicios.Interface;
using UoW.Interface;

namespace Servicios.Service
{
    public class MantenimientoServicio : IMantenimientoServicio
    {
        private IUoW _unitOfWork;
        public MantenimientoServicio(IUoW unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Mantenimiento>> consultarTodo()
        {
            List<Mantenimiento> LstMantenimiento = new List<Mantenimiento>();
            try
            {
                using (var contexto = _unitOfWork.Crear())
                {
                    LstMantenimiento = await contexto.Repositorios.MantenimientoRepositorio.ObtenerTodoAsync();
                }
                return LstMantenimiento;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
