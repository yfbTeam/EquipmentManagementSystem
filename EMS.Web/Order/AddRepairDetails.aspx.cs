using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS.Web.Order
{
    public partial class AddRepairDetails : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                hidOperator.Value = Request.QueryString["p"];
                hidId.Value = Request.QueryString["id"];
                hidUserName.Value = UserInfo.Name;
                hidDate.Value = System.DateTime.Now.ToString("yyyy-MM-dd");
                hidRId.Value = Request.QueryString["RId"];
            }
        }
    }
}