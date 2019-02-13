using BLL;
using Entities;
using PrimerParcial.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimerParcial.Consultas
{
    public partial class cCuentas : System.Web.UI.Page
    {

        Expression<Func<Cuenta, bool>> filtro = c => true;

        protected void Page_Load(object sender, EventArgs e)
        {
            DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private int ToInt(object valor)
        {
            int retorno = 0;
            int.TryParse(valor.ToString(), out retorno);

            return retorno;
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            int id = Utils.ToInt(CriterioTextBox.Text);
            int index = ToInt(FiltroDropDownList.SelectedIndex);
            DateTime desde = Utils.ToDateTime(DesdeTextBox.Text);
            DateTime hasta = Utils.ToDateTime(HastaTextBox.Text);
            CuentaGridView.DataSource = Metodos.FiltrarCuentas(index, CriterioTextBox.Text, desde, hasta);
            CuentaGridView.DataBind();

            CriterioTextBox.Text = FiltroDropDownList.Text.ToString();

        }
        }
}

