using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Linq.Expressions;

namespace PrimerParcial.Tests
{
    [TestClass]
    public class UnitTest
    {

        [TestMethod]
        public void Guardar()
        {
            RepositorioBase<Cuenta> repositorio = new RepositorioBase<Cuenta>();
            Cuenta cuenta = new Cuenta();
            bool paso = false;

            cuenta.CuentaID = 4;
            cuenta.Fecha = DateTime.Now;
            cuenta.Nombre = "Juan";
            cuenta.Balance = 0;

            paso = repositorio.Guardar(cuenta);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void Modificar()
        {
            var cuenta = BuscarM();
            RepositorioBase<Cuenta> repositorio = new RepositorioBase<Cuenta>();

            bool paso = false;
            cuenta.Nombre = "Alfredo";
            paso = repositorio.Modificar(cuenta);
            Assert.AreEqual(true, paso);
        }

        public Cuenta BuscarM()
        {
            int id = 3;
            RepositorioBase<Cuenta> repositorio = new RepositorioBase<Cuenta>();
            Cuenta cuenta = new Cuenta();
            cuenta = repositorio.Buscar(id);
            return cuenta;
        }

        [TestMethod]
        public void Eliminar()
        {
            RepositorioBase<Cuenta> repositorio = new RepositorioBase<Cuenta>();
            int id = 4;
            bool paso = false;
            paso = repositorio.Eliminar(id);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void Buscar()
        {
            int id = 3;
            RepositorioBase<Cuenta> repositorio = new RepositorioBase<Cuenta>();
            Cuenta cuenta = new Cuenta();
            cuenta = repositorio.Buscar(id);
            Assert.IsNotNull(cuenta);
        }

        [TestMethod()]
        public void GetListTest()
        {
            RepositorioBase<Cuenta> repositorio = new RepositorioBase<Cuenta>();
            List<Cuenta> lista = new List<Cuenta>();
            Expression<Func<Cuenta, bool>> resultados = p => true;
            lista = repositorio.GetList(resultados);
            Assert.IsNotNull(lista);
        }

    }
}