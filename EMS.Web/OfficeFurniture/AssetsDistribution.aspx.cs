using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS.Web.OfficeFurniture
{
    public partial class AssetsDistribution : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                hid_UserIDCard.Value = UserInfo.UniqueNo;
                string type= HttpContext.Current.Request.QueryString["type"];
                hid_Type.Value =type;
                h1_title.InnerHtml = type == "2" ? "办公家具分配" : "科研设备分配";
            }
        }
    }
}