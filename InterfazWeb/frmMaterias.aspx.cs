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
    public partial class frmMaterias : System.Web.UI.Page
    {
        //*********************métodos
        //Limpia los campos
        private void Limpiar()
        {
            txtCode.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtCredits.Text = string.Empty;
            txtCode.Focus();
        }

        //Generar materia
        private Matter GenerarEntidad()
        {
            Matter matter = new Matter();
            if (Session["Matter_Code"] != null)
            {
                matter.Code = Session["Matter_Code"].ToString();
                matter.Exists = true;
            }
            else
            {
                matter.Code = txtCode.Text.Trim();
                matter.Exists = false;
            }

            matter.Name = txtNombre.Text;
            matter.Credits = Convert.ToByte(txtCredits.Text);
            
            return matter;
        }


        //********************************************************//
        protected void Page_Load(object sender, EventArgs e)
        {
            Matter matter;
            MatterLogic logica = new MatterLogic(Config.getConnectionString);
            string code;
            try
            {
                // que solo se ejecuta la primera vez que carga la página
                if (!IsPostBack)
                {
                    Session["_mensaje"] = null;
                    if (Session["Matter_Code"] != null)
                    {
                        code = Session["Matter_Code"].ToString();
                        matter = logica.GetMatter(code);
                        if (matter != null)
                        {
                            txtCode.Text = matter.Code.ToString();
                            txtNombre.Text = matter.Name;
                            txtCredits.Text = matter.Credits.ToString();
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
                Response.Redirect("frmListadoMaterias.aspx");
            }
        }
        //Cancela la operación
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Session["Matter_Code"] = null;
            Response.Redirect("frmListadoMaterias.aspx");
        }
        //Guarda la materia
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Matter matter;
            MatterLogic logicaCliente = new MatterLogic(Config.getConnectionString);
            
            try
            {
                matter = GenerarEntidad();


                if (logicaCliente.UpdateMatter(matter) != -1)
                {
                    Session["_mensaje"] = "Operación realizada satisfactoriamente";
                    Response.Redirect("frmListadoMaterias.aspx", false);
                }
                else {
                    Session["_mensaje"] = "Error al guardar materia";
                    Response.Redirect("frmListadoMaterias.aspx", false);
                }
            }
            catch (Exception ex)
            {

                Session["_mensaje"] = $"Error guardar los datos {ex.Message}";
                Response.Redirect("frmListadoMaterias.aspx");
            }
        }
    }
}