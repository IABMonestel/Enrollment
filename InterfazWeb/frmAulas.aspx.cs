using BusinessLogic;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterfazWeb
{
    public partial class frmAulas : System.Web.UI.Page
    {
        //Limpia los campos
        private void Limpiar()
        {
            txtCode.Text = string.Empty;
            txtNumero.Text = string.Empty;
            txtCapacidad.Text = string.Empty;
            txtCode.Enabled = false;
            txtCode.Focus();
        }

        //Generar aula
        private Aula GenerarEntidad()
        {
            Aula aula = new Aula();
            if (Session["Aula_Code"] != null)
            {
                aula.Codigo = byte.Parse(Session["Aula_Code"].ToString());
                aula.Existe = true;
            }
            else
            {
                aula.Codigo = -1;
                aula.Existe = false;
            }

            aula.Tipo = cboTipo.Text;
            aula.Numero = Convert.ToByte(txtNumero.Text);
            aula.Capacidad = Convert.ToByte(txtCapacidad.Text);

            return aula;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Aula aula;
            LogicaAula logica = new LogicaAula(Config.getConnectionString);
            byte code;
            try
            {
                // que solo se ejecuta la primera vez que carga la página
                if (!IsPostBack)
                {
                    Session["_mensaje"] = null;
                    if (Session["Aula_Code"] != null)
                    {
                        code = byte.Parse(Session["Aula_Code"].ToString());
                        aula = logica.ObtenerAula(code);
                        if (aula != null)
                        {
                            txtCode.Text = aula.Codigo.ToString();
                            cboTipo.Text = aula.Tipo;
                            txtNumero.Text = aula.Numero.ToString();
                            txtCapacidad.Text = aula.Capacidad.ToString();
                            txtCode.Enabled = false;
                            //lblCode.Visible = true;
                            //txtCode.Visible = true;
                        }
                        else
                        {
                            Session["_mensaje"] = "La materia no se encontró";
                        }
                    }
                    else
                    {
                        Limpiar();
                    }
                }
            }
            catch (Exception ex)
            {

                Session["_mensaje"] = $"Error al carga los datos {ex.Message}";
                Response.Redirect("frmListadoAulas.aspx");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Aula aula;
            LogicaAula logica = new LogicaAula(Config.getConnectionString);

            try
            {
                aula = GenerarEntidad();

                if (logica.Insertar(aula) != -1)
                {
                    Session["_mensaje"] = "Operación realizada satisfactoriamente";
                    Response.Redirect("frmListadoAulas.aspx", false);
                }
                else
                {
                    Session["_mensaje"] = "Error al guardar aula";
                    Response.Redirect("frmListadoAulas.aspx", false);
                }
            }
            catch (Exception ex)
            {

                Session["_mensaje"] = $"Error guardar los datos {ex.Message}";
                Response.Redirect("frmListadoAulas.aspx");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Session["Aula_Code"] = null;
            Response.Redirect("frmListadoAulas.aspx");
        }
    }
}