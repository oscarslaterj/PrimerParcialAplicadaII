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
    public partial class rDepositos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cuenta CB = new Cuenta();

            if (!Page.IsPostBack)
            {
                RepositorioBase<Cuenta> repositorio = new RepositorioBase<Cuenta>();

                CuentaDropDownList.DataSource = repositorio.GetList(t => true);
                CuentaDropDownList.DataValueField = "CuentaID";
                CuentaDropDownList.DataTextField = "Nombre";
                CuentaDropDownList.DataBind();

                ViewState["Deposito"] = new Deposito();
            }
        }


        private void LlenarCombo()
        {
            RepositorioBase<Cuenta> repositorio = new RepositorioBase<Cuenta>();
            CuentaDropDownList.DataSource = repositorio.GetList(c => true);
            CuentaDropDownList.DataValueField = "CuentaID";
            CuentaDropDownList.DataTextField = "Nombre";
            CuentaDropDownList.DataBind();
            CuentaDropDownList.Items.Insert(0, new ListItem("", ""));
        }

        public Deposito LlenarClase()
        {
            Deposito deposito = new Deposito();

            deposito.DepositoID = Utils.ToInt(DepositoidTextBox.Text);
            deposito.Fecha = Utils.ToDateTime(FechaTextBox.Text).Date;
            deposito.CuentaID = Utils.ToInt(CuentaDropDownList.SelectedValue);
            deposito.Concepto = ConceptoTextBox.Text;
            deposito.Monto = Utils.ToInt(MontoTextBox.Text);

            return deposito;
        }


        protected void Limpiar()
        {
            DepositoidTextBox.Text = "0";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            CuentaDropDownList.SelectedIndex = 0;
            ConceptoTextBox.Text = "";
            MontoTextBox.Text = "0";
        }

        public void LlenarCampos(Deposito deposito)
        {
            Limpiar();
            DepositoidTextBox.Text = deposito.DepositoID.ToString();
            FechaTextBox.Text = deposito.Fecha.ToString("yyyy-MM-dd");
            CuentaDropDownList.SelectedIndex = deposito.CuentaID;
            ConceptoTextBox.Text = deposito.Concepto;
            MontoTextBox.Text = deposito.Monto.ToString();
        }



        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            DepositosRepositorio repositorio = new DepositosRepositorio();
            Deposito deposito = new Deposito();

            deposito = LlenarClase();

            if (deposito.DepositoID == 0)
            {
                paso = repositorio.Guardar(deposito);
                Utils.ShowToastr(this, "Guardado", "Exito", "success");
                Limpiar();
            }
            else
            {
                DepositosRepositorio repository = new DepositosRepositorio();
                int id = Utils.ToInt(DepositoidTextBox.Text);
                deposito = repository.Buscar(id);

                if (deposito != null)
                {
                    paso = repository.Modificar(LlenarClase());
                    Utils.ShowToastr(this, "Modificado", "Exito", "success");
                }
                else
                    Utils.ShowToastr(this, "Id no existe", "Error", "error");
            }

            if (paso)
            {
                Limpiar();
            }
            else
                Utils.ShowToastr(this, "No se pudo guardar", "Error", "error");

        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {

        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            DepositosRepositorio repositorio = new DepositosRepositorio();

            var deposito = repositorio.Buscar(Utilitarios.Utils.ToInt(DepositoidTextBox.Text));
            if (deposito != null)
            {
                LlenarCampos(deposito);
                Utils.ShowToastr(this, "Busqueda exitosa", "Exito", "success");
            }
            else
            {
                Limpiar();
               Utils.ShowToastr(this, "No Hay Resultado", "Error", "error");

            }
        }
    }
}
