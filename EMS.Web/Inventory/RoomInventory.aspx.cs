using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS.Web.Inventory
{
    public partial class RoomInventory : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hid_UserIDCard.Value = UserInfo.UniqueNo;
            if (!IsPostBack)
            {
                string itemid = HttpContext.Current.Request.QueryString["itemid"];
                hid_Invenid.Value = HttpContext.Current.Request.QueryString["invenid"];
                hid_PPid.Value = HttpContext.Current.Request.QueryString["ppid"];
                string status = HttpContext.Current.Request.QueryString["status"];
                Btn_Sure.Visible = status == "0" ? true : false;
                if (!string.IsNullOrEmpty(itemid))
                {
                    hid_Id.Value = itemid;
                    span_name.InnerHtml = HttpContext.Current.Request.QueryString["roomname"]; 
                }
            }
        }
    }
}