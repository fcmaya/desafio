using System.Web;
using System.Web.Mvc;

namespace WebApi_Conductor_Desafio_Clientes
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
