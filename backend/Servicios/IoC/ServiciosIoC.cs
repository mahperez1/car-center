using Servicios.Interface;
using Servicios.Service;
using UoW.Interface;
using UoW.SqlServer;
using Microsoft.Extensions.DependencyInjection;

namespace Servicios.IoC
{
    public static class ServiciosIoC
    {
        public static void AplicacionServiciosIoC(this IServiceCollection services)
        {
            services.AddTransient<IUoW, UoWSqlServer>();

            #region "Parametricas"
            services.AddTransient<IEstadoMantenimientoServicio, EstadoMantenimientoServicio>();
            services.AddTransient<IRepuestoMantenimientoServicio, RepuestoMantenimientoServicio>();
            services.AddTransient<IServicioManoServicio, ServicioManoServicio>();
            services.AddTransient<ITipoDocumentoServicio, TipoDocumentoServicio>();
            #endregion

            #region "Negocio"
            services.AddTransient<IFacturaServicio, FacturaServicio>();
            services.AddTransient<IMantenimientoServicio, MantenimientoServicio>();
            services.AddTransient<IMecanicoServicio, MecanicoServicio>();
            services.AddTransient<IPersonaServicio, PersonaServicio>();
            services.AddTransient<IRepuestoMantenimientoServicio, RepuestoMantenimientoServicio>();
            #endregion

        }
    }
}
