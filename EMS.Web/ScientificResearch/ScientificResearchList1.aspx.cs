using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS.Web.ScientificResearch
{
    public partial class ScientificResearchList1 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hidIsAdmin.Value = base.IsAdmin;
                hidUserIDCard.Value = UserInfo.UniqueNo;
            }
        }
    }
}