using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_Conductor_Desafio_Clientes.Models
{
    public class Cliente
    {
        /// <summary>
        /// Identificador do cliente
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do cliente
        /// </summary>
        public string Nome { get; set; }

        public Cliente(string nome)
        {
            this.Nome = nome;
        }
    }
}