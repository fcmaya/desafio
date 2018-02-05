using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi_Conductor_Desafio_Clientes;
using WebApi_Conductor_Desafio_Clientes.Controllers;
using WebApi_Conductor_Desafio_Clientes.Models;

namespace WebApi_Conductor_Desafio_Clientes.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public void GetAllClientes()
        {
            // Arrange
            ClientesController controller = new ClientesController();

            // Act
            IHttpActionResult result = controller.GetAllClientes();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetCliente()
        {
            // Arrange
            ClientesController controller = new ClientesController();

            // Act
            Cliente result = controller.GetCliente(2);

            // Assert
            Assert.AreEqual("Brunna", result.Nome);
        }


        [TestMethod]
        public void PutCliente()
        {
            // Arrange
            ClientesController controller = new ClientesController();

            // Act
            controller.PutCliente(1, "Fernando Maia");
            Cliente result = controller.GetCliente(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Fernando Maia", result.Nome);
        }

        [TestMethod]
        public void DeleteCliente()
        {
            // Arrange
            ClientesController controller = new ClientesController();

            // Act
            controller.DeleteCliente(4);
            var result = controller.GetAllClientes();

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
