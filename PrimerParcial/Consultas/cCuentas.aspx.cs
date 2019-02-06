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

        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Cuenta> repositorio = new RepositorioBase<Cuenta>();
            int id = 0;
            switch (FiltroDropDownList.SelectedIndex)
            {
                case 0://Todo
                    filtro = c => true;
                    break;

                case 1://CuentaId
                    id = Utils.ToInt(CriterioTextBox.Text);
                    filtro = (c => c.CuentaID == id);
                    break;

                case 2://Fecha
                    filtro = (c => c.Fecha.Equals(CriterioTextBox.Text));
                    break;

                case 3://Nombre
                    filtro = (c => c.Nombre.Contains(CriterioTextBox.Text));
                    break;

                case 4://Balance
                    decimal balance = Utils.ToDecimal(CriterioTextBox.Text);
                    filtro = (c => c.Balance == balance);
                    break;

            }
        }
}
}
