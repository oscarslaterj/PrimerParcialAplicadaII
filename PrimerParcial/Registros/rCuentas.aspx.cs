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
            }
            else
            {
                Response.Write("<script>alert('Usuario no encontrado');</script>");
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

            //todo: validaciones adicionales
            cuentasbancarias = LlenaClase();

            if (cuentasbancarias.CuentaID == 0)
            {
                paso = repositorio.Guardar(cuentasbancarias);
                Response.Write("<script>alert('Guardado');</script>");
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
                    Response.Write("<script>alert('Modificado');</script>");
                }
                else
                    Response.Write("<script>alert('Id no existe');</script>");
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
                    Response.Write("<script>alert('Eliminado');</script>");
                    LimpiarCampos();
                }
                else
                    Response.Write("<script>alert('No se pudo eliminar');</script>");
            }
            else
                Response.Write("<script>alert('No existe');</script>");
        }
    }
    }

