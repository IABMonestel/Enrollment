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
    public partial class Default : System.Web.UI.Page
    {
        private void GetReferenceValues()
        {
            ReferenceValuesLogic logic = new ReferenceValuesLogic(Config.getConnectionString);
            ReferenceValues referenceAsig;

            try
            {
                referenceAsig = logic.GetReferenceValues();
                if (referenceAsig != null)
                {
                    Session["_reference"] = referenceAsig;
                }
            }
            catch (Exception) {

                throw;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                GetReferenceValues();
            }
            catch (Exception ex)
            {
                Session["_mensaje"] = $"Error al obtener los valores de referencia {ex.Message}";
            }
        }
    }
}