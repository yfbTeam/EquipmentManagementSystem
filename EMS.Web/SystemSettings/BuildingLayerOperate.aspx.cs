using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS.Web.SystemSettings
{
    public partial class BuildingLayerOperate : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hid_UserIDCard.Value = UserInfo.UniqueNo;
            if (!IsPostBack)
            {         
                hid_Pid.Value = HttpContext.Current.Request.QueryString["pid"];            
            }
        }
    }
}