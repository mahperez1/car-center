﻿using UoW.Interface;
using Microsoft.Extensions.Configuration;

namespace UoW.SqlServer
{
    public class UoWSqlServer : IUoW
    {
        private readonly IConfiguration _configuration;

        public UoWSqlServer(IConfiguration configuration = null)
        {
            _configuration = configuration;
        }

        public IUoWAdaptador Crear()
        {
            var connectionString = _configuration.GetValue<string>("SqlConnectionString");
            return new UoWSqlServerAdaptador(connectionString);
        }
    }
}