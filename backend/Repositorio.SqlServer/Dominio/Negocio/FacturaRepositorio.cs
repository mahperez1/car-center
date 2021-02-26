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
    public class FacturaRepositorio : Repositorio, IFacturaRepositorio
    {
        public FacturaRepositorio(SqlConnection contexto, SqlTransaction transacion)
        {
            this._contexto = contexto;
            this._transacion = transacion;
        }

        public Task<bool> ActualizarAsync(Factura t)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CrearAsync(Factura t)
        {
            int respuesta;
            try
            {
                Dictionary<string, object> lstParametros = new Dictionary<string, object>();
                lstParametros.Add("@Id_Persona", t.Id_Persona);
                lstParametros.Add("@Valor_factura", t.Valor_factura);
                lstParametros.Add("@Valor_iva", t.Valor_iva);
                lstParametros.Add("@Valor_total", t.Valor_total);
                lstParametros.Add("@Placa_vehiculo", t.Placa_vehiculo);
                lstParametros.Add("@AplicaLimitePresupuesto", t.AplicaLimitePresupuesto);
                lstParametros.Add("@Valor_limite_presupuesto", t.Valor_limite_presupuesto);
                int resultado = 0;
                resultado = int.Parse(await EjecutarComandoBDAsync("p_factura_insertar", lstParametros, new SqlParameter() { ParameterName = "@Resultado", Value = resultado }));
                respuesta = resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuesta;
        }

        public async Task<List<Factura>> ObtenerTodoAsync()
        {
            List<Factura> lstFactura = new List<Factura>();
            try
            {
                Dictionary<string, object> lstParametros = new Dictionary<string, object>();
                lstFactura = MapInstance.MapearInstanciaObjeto<Factura>(await EjecutarComandoBDDTAsync("pa_factura_consultar", lstParametros));
                return lstFactura;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Factura> ObtenerxIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
