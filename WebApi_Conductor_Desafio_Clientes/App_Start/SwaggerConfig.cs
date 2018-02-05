using System.Web.Http;
using WebActivatorEx;
using WebApi_Conductor_Desafio_Clientes;
using Swashbuckle.Application;

namespace WebApi_Conductor_Desafio_Clientes
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "WebApi_Conductor_Desafio_Clientes");
                        c.IncludeXmlComments(string.Format(@"{0}\bin\WebApi_Conductor_Desafio_Clientes.XML", System.AppDomain.CurrentDomain.BaseDirectory));

                    })
                .EnableSwaggerUi();
        }
    }
}
