using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Entidades.Negocio;
using Repositorio.Interfaces.Dominio.Negocio;

namespace Repositorio.SqlServer.Dominio.Negocio
{
    public class RepuestoMantenimientoRepositorio : Repositorio, IRespuestoMantenimientoRepositorio
    {
        public RepuestoMantenimientoRepositorio(SqlConnection contexto, SqlTransaction transacion)
        {
            this._contexto = contexto;
            this._transacion = transacion;
        }


        public async Task<int> CrearAsync(RepuestoMantenimiento t)
        {
            int respuesta;
            try
            {
                Dictionary<string, object> lstParametros = new Dictionary<string, object>();
                lstParametros.Add("@Id_mantenimiento", t.Id_mantenimiento);
                lstParametros.Add("@Id_Mecanico", t.Id_Mecanico);
                lstParametros.Add("@Id_Respuesto", t.Id_Respuesto);
                lstParametros.Add("@N_unidades", t.N_unidades);
                lstParametros.Add("@Valor_descuento", t.Valor_descuento);
                lstParametros.Add("@Aplica_servicio_mano_obra", t.Aplica_servicio_mano_obra);
                lstParametros.Add("@Id_Servicio_Mano", t.Id_Servicio_Mano);
                lstParametros.Add("@Vlr_mano_obra", t.Vlr_mano_obra);
                int resultado = 0;
                resultado = int.Parse(await EjecutarComandoBDAsync("pa_repuesto_mantenimiento_insertar", lstParametros, new SqlParameter() { ParameterName = "@Resultado", Value = resultado }));
                respuesta = resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuesta;
        }

        public Task<List<RepuestoMantenimiento>> ObtenerTodoAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RepuestoMantenimiento> ObtenerxIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
