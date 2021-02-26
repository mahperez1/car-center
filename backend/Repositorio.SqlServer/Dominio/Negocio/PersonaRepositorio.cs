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
    public class PersonaRepositorio : Repositorio, IPersonaRepositorio
    {
        public PersonaRepositorio(SqlConnection contexto, SqlTransaction transacion)
        {
            this._contexto = contexto;
            this._transacion = transacion;
        }

        public async Task<bool> CrearAsync(Persona t)
        {
            Boolean respuesta;
            try
            {
                Dictionary<string, object> lstParametros = new Dictionary<string, object>();
                lstParametros.Add("@Primer_nombre", t.Primer_nombre);
                lstParametros.Add("@Segundo_nombre", t.Segundo_nombre);
                lstParametros.Add("@Primer_apellido", t.Primer_apellido);
                lstParametros.Add("@Segundo_apellido", t.Segundo_apellido);
                lstParametros.Add("@Id_tipo_documento", t.Id_tipo_documento);
                lstParametros.Add("@Numero_documento", t.Numero_documento);
                lstParametros.Add("@celular", t.celular);
                lstParametros.Add("@direccion", t.direccion);
                lstParametros.Add("@correo", t.celular);
                int resultado = 0;
                resultado =  int.Parse(await EjecutarComandoBDAsync("pa_persona_insertar", lstParametros, new SqlParameter() { ParameterName = "@Resultado", Value = resultado }));
                respuesta = (string.IsNullOrEmpty(resultado.ToString())) == true ? false : true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuesta;
        }

        public async Task<List<Persona>> ObtenerTodoAsync()
        {
            List<Persona> lstPersona = new List<Persona>();
            try
            {
                Dictionary<string, object> lstParametros = new Dictionary<string, object>();
                lstPersona = MapInstance.MapearInstanciaObjeto<Persona>(await EjecutarComandoBDDTAsync("pa_persona_consultar", lstParametros));
                return lstPersona;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public Task<Persona> ObtenerxIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
