using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entidades.Parametrica;
using Servicios.Interface;
using UoW.Interface;


namespace Servicios.Service
{
    public class TipoDocumentoServicio : ITipoDocumentoServicio
    {

        private IUoW _unitOfWork;
        public TipoDocumentoServicio(IUoW unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<TipoDocumento>> consultartodo()
        {
            List<TipoDocumento> LstTipoDocumento = new List<TipoDocumento>();
            try
            {
                using (var contexto = _unitOfWork.Crear())
                {
                    LstTipoDocumento = await contexto.Repositorios.TipoDocumentoRepositorio.ObtenerTodoAsync();
                }
                return LstTipoDocumento;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
