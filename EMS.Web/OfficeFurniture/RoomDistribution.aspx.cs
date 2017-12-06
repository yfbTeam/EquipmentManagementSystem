using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS.Web.OfficeFurniture
{
    public partial class RoomDistribution : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hid_UserIDCard.Value = UserInfo.UniqueNo;
            if (!IsPostBack)
            {
                string itemid = HttpContext.Current.Request.QueryString["itemid"];
                hid_Pid.Value = HttpContext.Current.Request.QueryString["pid"];
                hid_PPid.Value = HttpContext.Current.Request.QueryString["ppid"];
                if (!string.IsNullOrEmpty(itemid))
                {
                    hid_Id.Value = itemid;
                }
            }
        }
}
}