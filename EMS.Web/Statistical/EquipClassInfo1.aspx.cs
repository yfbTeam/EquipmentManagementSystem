using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS.Web.Statistical
{
    public partial class EquipClassInfo1 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hidUserLgoinName.Value =UserInfo.LoginName;
                //hidId.Value = Request.QueryString["Id"].ToString();
            }
        }
    }
}