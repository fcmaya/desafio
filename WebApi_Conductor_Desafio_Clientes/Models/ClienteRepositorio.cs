using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_Conductor_Desafio_Clientes.Models
{
    public class ClienteRepositorio: IClienteRepositorio
    {
        private List<Cliente> clientes = new List<Cliente>();
        private int _nextId = 1;

        public ClienteRepositorio()
        {
            Add(new Cliente ("Fernando"));
            Add(new Cliente ("Brunna"));
            Add(new Cliente ("Pedro"));
            Add(new Cliente("Rafael"));
            Add(new Cliente("Letícia"));
            Add(new Cliente("Gustavo"));
            Add(new Cliente("Felipe"));
            Add(new Cliente("Henrique"));
            Add(new Cliente("Laura"));
            Add(new Cliente("Beatriz"));
            Add(new Cliente("Gustavo"));
            Add(new Cliente("Manuela"));
            Add(new Cliente("Letícia"));
            Add(new Cliente("Amanda"));
        }

        public Cliente Add(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentNullException("Cliente não passado por parâmetro");
            }
            cliente.Id = _nextId++;
            clientes.Add(cliente);
            return cliente;
        }

        public Cliente Get(int id)
        {
            return clientes.Find(p => p.Id == id);
        }

        public IEnumerable<Cliente> GetAll()
        {
            return clientes;
        }

        public void Remove(int id)
        {
            clientes.RemoveAll(p => p.Id == id);
        }

        public bool Update(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentNullException("Cliente não passado por parâmetro");
            }

            int index = clientes.FindIndex(p => p.Id == cliente.Id);

            if (index == -1)
            {
                return false;
            }
            clientes.RemoveAt(index);
            clientes.Add(cliente);
            return true;
        }
    }
}