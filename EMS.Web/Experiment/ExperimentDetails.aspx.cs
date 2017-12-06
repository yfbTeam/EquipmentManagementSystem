using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS.Web.Experiment
{
    public partial class ExperimentDetails : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hidId.Value = Request.QueryString["Id"];
                hidName.Value = Request.QueryString["Name"];
            }
        }
    }
}