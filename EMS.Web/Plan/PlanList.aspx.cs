using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS.Web.Plan
{
    public partial class PlanList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hidUserIDCard.Value = UserInfo.UniqueNo;
                hidIsAdmin.Value = base.IsAdmin;
                hidPlanIDs.Value = Request.QueryString["planIds"];
            }
        }
    }
}