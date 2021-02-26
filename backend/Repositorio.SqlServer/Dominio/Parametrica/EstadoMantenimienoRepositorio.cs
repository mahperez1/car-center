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
    public class EstadoMantenimienoRepositorio : Repositorio, IEstadoMantenimientoRepositorio
    {
        public EstadoMantenimienoRepositorio(SqlConnection contexto, SqlTransaction transacion)
        {
            this._contexto = contexto;
            this._transacion = transacion;
        }

        public async Task<List<EstadoMantenimiento>> ObtenerTodoAsync()
        {
            List<EstadoMantenimiento> lstestado = new List<EstadoMantenimiento>();
            try
            {
                Dictionary<string, object> lstParametros = new Dictionary<string, object>();
                lstestado = MapInstance.MapearInstanciaObjeto<EstadoMantenimiento>(await EjecutarComandoBDDTAsync("pa_estado_mantenimiento_consultar", lstParametros));
                return lstestado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
