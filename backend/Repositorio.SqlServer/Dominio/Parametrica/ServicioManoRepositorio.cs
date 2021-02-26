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
    public class ServicioManoRepositorio : Repositorio, IServicioManoRepositorio
    {
        public ServicioManoRepositorio(SqlConnection contexto, SqlTransaction transacion)
        {
            this._contexto = contexto;
            this._transacion = transacion;
        }

        public async Task<List<ServicioMano>> ObtenerTodoAsync()
        {
            
                List<ServicioMano> lstServicioMano = new List<ServicioMano>();
            try
            {
                Dictionary<string, object> lstParametros = new Dictionary<string, object>();
                lstServicioMano = MapInstance.MapearInstanciaObjeto<ServicioMano>(await EjecutarComandoBDDTAsync("pa_servicio_mano_consultar", lstParametros));
                return lstServicioMano;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
