using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS.Web.OfficeFurniture
{
    public partial class OfficeFurnitureList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hid_UserIDCard.Value = UserInfo.UniqueNo;
            hidIsAdmin.Value = base.IsAdmin;
        }
    }
}