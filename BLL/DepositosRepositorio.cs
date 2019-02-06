using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DepositosRepositorio : RepositorioBase<Deposito>
    {/*
        public override bool Eliminar(int id)
        {
            bool paso = false;

            try
            {
                Deposito depositos = Contexto.Deposito.Find(id);
                Contexto.Cuenta.Find(depositos.CuentaId).Balance -= depositos.Monto;
                Contexto.Depositos.Remove(depositos);
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
                Contexto Deposito.Add(entity);
                Contexto.Cuenta.Find(entity.CuentaId).Balance += entity.Monto;
                Contexto.SaveChanges();
                paso = true;

            }
            catch (Exception)
            {
                throw;
            }


            return paso;
        }

        public override bool Modificar(Depositos entity)
        {
            bool paso = false;

            try
            {
                Contexto.Entry(entity).State = EntityState.Modified;

                Deposito DepAnt = Contexto.Deposito.Find(entity.DepositoId);
                var cuenta = Contexto.Cuenta.Find(entity.CuentaId);
                var cuentaAnt = Contexto.Cuenta.Find(DepAnt.CuentaId);

                if (entity.CuentaId != DepAnt.CuentaId)
                {
                    cuenta.Balance += entity.Monto;
                    cuentaAnt.Balance -= DepAnt.Monto;
                }
                {
                    decimal diferencia = entity.Monto - DepAnt.Monto;
                    cuenta.Balance += diferencia;
                }

                contexto.SaveChanges();
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
