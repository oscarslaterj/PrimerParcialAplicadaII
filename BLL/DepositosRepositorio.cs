using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DepositosRepositorio : RepositorioBase<Deposito>
    {
/*
        public override bool Eliminar(int id)
        {
            bool paso = false;

            try
            {
                Deposito depositos = Contexto.Deposito.Find(id);
                Contexto.Cuentas.Find(depositos.CuentaID).Balance -= depositos.Monto;
                Contexto.Deposito.Remove(depositos);
                Contexto.SaveChanges();
                paso = true;
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public override bool Guardar(Deposito entity)
        {
            bool paso = false;

            try
            {
                Contexto.Deposito.Add(entity);
                Contexto.Cuentas.Find(entity.CuentaID).Balance += entity.Monto;
               Contexto.SaveChanges();
                paso = true;

            }
            catch (Exception)
            {
                throw;
            }


            return paso;
        }

        public override bool Modificar(Deposito entity)
        {
            bool paso = false;

            try
            {
                Contexto.Entry(entity).State = EntityState.Modified;

                Deposito DepAnt = Contexto.Deposito.Find(entity.DepositoID);
                Cuenta cuenta = Contexto.Cuentas.Find(entity.CuentaID);
                var cuentaAnt = Contexto.Cuentas.Find(DepAnt.CuentaID);

                if (entity.CuentaID != DepAnt.CuentaID)
                {
                    cuenta.Balance += entity.Monto;
                    cuentaAnt.Balance -= DepAnt.Monto;
                }
                {
                    decimal diferencia = entity.Monto - DepAnt.Monto;
                    cuenta.Balance += diferencia;
                }

                Contexto.SaveChanges();
                paso = true;

            }
            catch (Exception)
            {
                throw;
            }


            return paso;
        }*/
    }
}
