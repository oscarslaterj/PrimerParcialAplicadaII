using BLL;
using Entities;
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
                CuentaDropDownList.DataValueField = "CuentaBancariaId";
                CuentaDropDownList.DataTextField = "Nombre";
                CuentaDropDownList.DataBind();

                ViewState["Deposito"] = new Deposito();
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
           
        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {

        }
    }
    }
