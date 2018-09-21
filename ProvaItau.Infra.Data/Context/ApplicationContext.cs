using System;
using Microsoft.Extensions.Configuration;

namespace Projeto.Infra.Data.Context
{
    public class ApplicationContext
    {
        //public static string ConnectionString;
		public IConfiguration _configuration;

        public ApplicationContext(IConfiguration configuration) {		
			_configuration = configuration;
        }

		public string GetConnectioString() {
			return _configuration.GetConnectionString("globalPhoneBD");
		}
    }
}
