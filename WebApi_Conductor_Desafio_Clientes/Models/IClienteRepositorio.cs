using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi_Conductor_Desafio_Clientes.Models
{
    interface IClienteRepositorio
    {
        IEnumerable<Cliente> GetAll();
        Cliente Get(int id);
        Cliente Add(Cliente cliente);
        void Remove(int id);
        bool Update(Cliente cliente);
    }
}
