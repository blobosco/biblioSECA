using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace CapaPresentacion.Controles
{
    public partial class UCFechaActual : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void CargarFecha(DateTime fechaActual)
        {
            this.lblFecha.Text = fechaActual.ToShortDateString();
        }
    }
}