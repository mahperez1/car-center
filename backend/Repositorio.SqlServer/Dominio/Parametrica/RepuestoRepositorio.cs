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
    public class RepuestoRepositorio : Repositorio, IRepuestoRepositorio
    {
        public RepuestoRepositorio(SqlConnection contexto, SqlTransaction transacion)
        {
            this._contexto = contexto;
            this._transacion = transacion;
        }
        public Task<bool> ActualizarAsync(Repuesto t)
        {
            throw new NotImplementedException();
        }

        public Task<int> CrearAsync(Repuesto t)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Repuesto>> ObtenerTodoAsync()
        {
            List<Repuesto> lstRepuesto = new List<Repuesto>();
            try
            {
                Dictionary<string, object> lstParametros = new Dictionary<string, object>();
                lstRepuesto = MapInstance.MapearInstanciaObjeto<Repuesto>(await EjecutarComandoBDDTAsync("pa_repuesto_consultar", lstParametros));
                return lstRepuesto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Repuesto> ObtenerxIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
