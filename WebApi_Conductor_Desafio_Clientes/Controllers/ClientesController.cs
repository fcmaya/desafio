using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_Conductor_Desafio_Clientes.Models;

namespace WebApi_Conductor_Desafio_Clientes.Controllers
{
    /* 
       =======================================================================================================
        UTILIZE A URL [localHost:porta]/swagger PARA TESTAR OS MÉTODOS DA API. NELA TERÁ A DOCUMENTAÇÃO DOS MESMOS.
       =======================================================================================================
    */
    public class ClientesController : ApiController
    {
        static readonly IClienteRepositorio repositorio = new ClienteRepositorio();


        /// <summary>
        /// Listar todos clientes com paginação
        /// </summary>
        /// <param name="pagina"></param>
        /// <param name="tamanhoPagina"></param>
        /// <remarks>Retorna todos os clientes de uma lista pré-configurada</remarks>
        public IHttpActionResult GetAllClientes(int pagina = 1, int tamanhoPagina = 5)
        {
            var clientes = repositorio.GetAll()
               .Skip(tamanhoPagina * (pagina - 1))
               .Take(tamanhoPagina);
            return Ok(clientes);
        }

        /// <summary>
        /// Consultar um cliente
        /// </summary>
        /// <param cliente="ciente">ID</param>
        /// <remarks>Consulta um cliente específico</remarks>
        public Cliente GetCliente(int id)
        {
            Cliente cliente = repositorio.Get(id);
            if (cliente == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return cliente;
        }

        /// <summary>
        /// Cadastrar um cliente
        /// </summary>
        /// <param cliente="ciente">Nome</param>
        /// <remarks>Inclui um cliente na lista de clientes</remarks>
        public HttpResponseMessage PostCliente(string nome)
        {
            Cliente cliente = new Cliente(nome);
            
            cliente = repositorio.Add(cliente);
            var response = Request.CreateResponse<Cliente>(HttpStatusCode.Created, cliente);

            string uri = Url.Link("DefaultApi", new { id = cliente.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        /// <summary>
        /// Editar um cliente
        /// </summary>
        /// <param cliente="ciente">ID, Nome</param>
        /// <remarks>Atualiza um cliente específico da lista de clientes</remarks>
        public void PutCliente(int id, string nome)
        {
            Cliente cliente = new Cliente(nome);
            cliente.Id = id;
            if (!repositorio.Update(cliente))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        /// Excuir um cliente
        /// </summary>
        /// <param cliente="ciente">ID</param>
        /// <remarks>Remove um cliente da lista de clientes</remarks>
        public void DeleteCliente(int id)
        {
            Cliente cliente = repositorio.Get(id);

            if (cliente == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            repositorio.Remove(id);
        }


    }
}
