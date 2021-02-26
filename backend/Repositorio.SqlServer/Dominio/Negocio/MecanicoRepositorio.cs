using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Entidades.Negocio;
using Repositorio.Interfaces.Dominio.Negocio;
using Utilitarios;

namespace Repositorio.SqlServer.Dominio.Negocio
{
    public class MecanicoRepositorio : Repositorio, IMecanicoRepositorio
    {
        public MecanicoRepositorio(SqlConnection contexto, SqlTransaction transacion)
        {
            this._contexto = contexto;
            this._transacion = transacion;
        }


        public  async Task<string> CrearAsync(Mecanico t)
        {
            string respuesta;
            try
            {
                Dictionary<string, object> lstParametros = new Dictionary<string, object>();
                lstParametros.Add("@Id_Persona", t.Id_Persona);
                lstParametros.Add("@Activo", t.Activo);
                int resultado = 0;
                resultado = int.Parse(await EjecutarComandoBDAsync("pa_mecanico_insertar", lstParametros, new SqlParameter() { ParameterName = "@Resultado", Value = resultado }));
                respuesta = resultado.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuesta;
        }

        public async Task<List<Mecanico>> ObtenerTodoAsync()
        {
            
                List<Mecanico> lstMecanico = new List<Mecanico>();
            try
            {
                Dictionary<string, object> lstParametros = new Dictionary<string, object>();
                lstMecanico = MapInstance.MapearInstanciaObjeto<Mecanico>(await EjecutarComandoBDDTAsync("pa_mecanico_consultar", lstParametros));
                return lstMecanico;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Task<Mecanico> ObtenerxIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
