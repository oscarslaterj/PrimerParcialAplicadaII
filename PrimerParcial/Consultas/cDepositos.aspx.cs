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

        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Deposito> repositorio = new RepositorioBase<Deposito>();
            int id = 0;
            switch (FiltroDropDownList.SelectedIndex)
            {
                case 0://Todo
                    filtro = d => true;
                    break;

                case 1://CuentaId
                    id = Utils.ToInt(CriterioTextBox.Text);
                    filtro = (d => d.DepositoID == id);
                    break;

                case 2://Fecha
                    filtro = (d => d.Fecha.Equals(CriterioTextBox.Text));
                    break;

                case 3://CuentaId
                    id = Utils.ToInt(CriterioTextBox.Text);
                    filtro = (d => d.CuentaID == id);
                    break;

                case 4://Concepto
                    filtro = (d => d.Concepto.Contains(CriterioTextBox.Text));
                    break;

                case 5://Monto
                    decimal monto = Utils.ToDecimal(CriterioTextBox.Text);
                    filtro = (d => d.Monto == monto);
                    break;

            }

            DepositoGridView.DataSource = repositorio.GetList(filtro);
            DepositoGridView.DataBind();
        }
    }
}