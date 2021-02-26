using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entidades.Negocio;
using Servicios.Interface;
using UoW.Interface;

namespace Servicios.Service
{
    public class FacturaServicio : IFacturaServicio
    {

        private IUoW _unitOfWork;
        public FacturaServicio(IUoW unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Factura>> consultarTodo()
        {
            List<Factura> LstFactura = new List<Factura>();
            try
            {
                using (var contexto = _unitOfWork.Crear())
                {
                    LstFactura = await contexto.Repositorios.FacturaRepositorio.ObtenerTodoAsync();
                }
                return LstFactura;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> crear(Factura model)
        {
            try
            {
                bool respuesta = false;
                using (var contexto = _unitOfWork.Crear()) {
                int resultado = await contexto.Repositorios.FacturaRepositorio.CrearAsync(model);
                    if (resultado > 0) {
                        respuesta = true;
                        contexto.SaveChange();
                    }
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
