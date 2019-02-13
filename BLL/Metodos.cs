using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Metodos
    {
        public static int ToInt(string valor)
        {
            int retorno = 0;
            int.TryParse(valor, out retorno);

            return retorno;
        }

        public static List<Cuenta> FiltrarCuentas(int index, string criterio, DateTime desde, DateTime hasta)
        {
            Expression<Func<Cuenta, bool>> filtro = p => true;
            RepositorioBase<Cuenta> repositorio = new RepositorioBase<Cuenta>();
            List<Cuenta> list = new List<Cuenta>();

            int id = ToInt(criterio);
            switch (index)
            {
                case 0://Todo
                    break;

                case 1://Todo por fecha
                    filtro = p => p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 2://CuentaId
                    filtro = p => p.CuentaID == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 3://Nombre
                    filtro = p => p.Nombre.Contains(criterio) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
            }

            list = repositorio.GetList(filtro);

            return list;
        }

        public static List<Deposito> FiltrarDepositos(int index, string criterio, DateTime desde, DateTime hasta)
        {
            Expression<Func<Deposito, bool>> filtro = p => true;
            RepositorioBase<Deposito> repositorio = new RepositorioBase<Deposito>();
            List<Deposito> list = new List<Deposito>();

            int id = ToInt(criterio);
            switch (index)
            {
                case 0://Todo
                    break;

                case 1://Todo por fecha
                    filtro = p => p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 2://DepositoId
                    filtro = p => p.DepositoID == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 3://CuentaId
                    filtro = p => p.CuentaID == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 4://Nombre
                    filtro = p => p.Concepto.Contains(criterio) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
            }

            list = repositorio.GetList(filtro);

            return list;
        }
    }
}

