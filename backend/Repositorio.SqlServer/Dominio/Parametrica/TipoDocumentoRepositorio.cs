using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Entidades.Parametrica;
using Repositorio.Interfaces.Dominio.Parametricas;
using Utilitarios;

namespace Repositorio.SqlServer.Dominio.Parametrica
{
    public class TipoDocumentoRepositorio : Repositorio, ITipoDocumentoRepositorio
    {
        public TipoDocumentoRepositorio(SqlConnection contexto, SqlTransaction transacion)
        {
            this._contexto = contexto;
            this._transacion = transacion;
        }

        public async Task<List<TipoDocumento>> ObtenerTodoAsync()
        {
            List<TipoDocumento> lsttipodocumento = new List<TipoDocumento>();
            try
            {
                Dictionary<string, object> lstParametros = new Dictionary<string, object>();
                lsttipodocumento = MapInstance.MapearInstanciaObjeto<TipoDocumento>(await EjecutarComandoBDDTAsync("pa_tipo_documento_consultar", lstParametros));
                return lsttipodocumento;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
