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
    public partial class cDepositos : System.Web.UI.Page
    {
        Expression<Func<Deposito, bool>> filtro = d => true;

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
            DepositoGridView.DataSource = Metodos.FiltrarDepositos(index, CriterioTextBox.Text, desde, hasta);
            DepositoGridView.DataBind();

            CriterioTextBox.Text = FiltroDropDownList.Text.ToString();
        }
    }
}