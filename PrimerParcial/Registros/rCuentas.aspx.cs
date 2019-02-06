using BLL;
using Entities;
using PrimerParcial.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimerParcial.Registros
{
    public partial class rCuentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            BalanceTextBox.Text = "0";
        }

        private void LimpiarCampos()
        {
            CuentaIdTextBox.Text = "0";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            NombreTextBox.Text = "";
            BalanceTextBox.Text = "0";
        }

        private Cuenta LlenaClase()
        {
            Cuenta cb = new Cuenta();

            cb.CuentaID = Utils.ToInt(CuentaIdTextBox.Text);
            cb.Fecha = Convert.ToDateTime(FechaTextBox.Text).Date;
            cb.Nombre = NombreTextBox.Text;
            cb.Balance = Utils.ToInt(BalanceTextBox.Text);

            return cb;

        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Cuenta> repositoriobase = new RepositorioBase<Cuenta>();
            Cuenta cuentasbancarias = repositoriobase.Buscar(Utils.ToInt(CuentaIdTextBox.Text));
            if (cuentasbancarias != null)
            {
                FechaTextBox.Text = cuentasbancarias.Fecha.ToString();
                NombreTextBox.Text = cuentasbancarias.Nombre;
                BalanceTextBox.Text = cuentasbancarias.Balance.ToString();
                Utils.ShowToastr(this, "Busqueda exitosa", "Exito", "success");
            }
            else
            {
                Utils.ShowToastr(this, "No Hay Resultado", "Error", "error");
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Cuenta> repositorio = new RepositorioBase<Cuenta>();
            Cuenta cuentasbancarias = new Cuenta();
            bool paso = false;

           
            cuentasbancarias = LlenaClase();

            if (cuentasbancarias.CuentaID == 0)
            {
                paso = repositorio.Guardar(cuentasbancarias);
                Utils.ShowToastr(this, "Guardado", "Exito", "success");
                LimpiarCampos();
            }
            else
            {
                Cuenta user = new Cuenta();
                int id = Utils.ToInt(CuentaIdTextBox.Text);
                RepositorioBase<Cuenta> repository = new RepositorioBase<Cuenta>();
                cuentasbancarias = repository.Buscar(id);

                if (user != null)
                {
                    paso = repositorio.Modificar(LlenaClase());
                    Utils.ShowToastr(this, "Modificado", "Exito", "success");
                }
                else
                    Utils.ShowToastr(this, "Id no existe", "Error", "error");
            }

            if (paso)
            {
                LimpiarCampos();
            }
            else
                Response.Write("<script>alert('No se pudo guardar');</script>");

        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Cuenta> repositorio = new RepositorioBase<Cuenta>();
            int id = Utils.ToInt(CuentaIdTextBox.Text);

            var CuentasBancarias = repositorio.Buscar(id);

            if (CuentasBancarias != null)
            {
                if (repositorio.Eliminar(id))
                {
                    Utils.ShowToastr(this, "Eliminado", "Exito", "success");
                    LimpiarCampos();
                }
                else
                    Utils.ShowToastr(this, "No se pudo eliminar", "Error", "error");
            }
            else
                Utils.ShowToastr(this, "No existe", "Error", "error");
        }
    }
    }

