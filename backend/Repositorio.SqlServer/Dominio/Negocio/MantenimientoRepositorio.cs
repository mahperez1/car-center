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
    public class MantenimientoRepositorio : Repositorio, IMantenimientoRepositorio
    {
        public MantenimientoRepositorio(SqlConnection contexto, SqlTransaction transacion)
        {
            this._contexto = contexto;
            this._transacion = transacion;
        }

        public Task<bool> ActualizarAsync(Mantenimiento t)
        {
            throw new NotImplementedException();
        }

        public async Task<string> CrearAsync(Mantenimiento t)
        {
            string respuesta;
            try
            {
                Dictionary<string, object> lstParametros = new Dictionary<string, object>();
                lstParametros.Add("@Nombre_mantenimiento", t.Nombre_mantenimiento);
                lstParametros.Add("@Descripcion", t.Descripcion);
                lstParametros.Add("@Id_Estado_mantenimiento", t.Id_Estado_mantenimiento);
                lstParametros.Add("@Id_Factura", t.Id_Factura);
                int resultado = 0;
                resultado = int.Parse(await EjecutarComandoBDAsync("pa_mantenimiento_insertar", lstParametros, new SqlParameter() { ParameterName = "@Resultado", Value = resultado }));
                respuesta = resultado.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuesta;
        }

        public async Task<List<Mantenimiento>> ObtenerTodoAsync()
        {
            List<Mantenimiento> lstMantenimiento = new List<Mantenimiento>();
            try
            {
                Dictionary<string, object> lstParametros = new Dictionary<string, object>();
                lstMantenimiento = MapInstance.MapearInstanciaObjeto<Mantenimiento>(await EjecutarComandoBDDTAsync("pa_mantenimiento_consultar", lstParametros));
                return lstMantenimiento;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Mantenimiento> ObtenerxIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
