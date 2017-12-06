using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS.Web.OfficeFurniture
{
    public partial class OfficeFurnitureBorrow : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hidIsAdmin.Value = base.IsAdmin;
            hidUserIDCard.Value = UserInfo.UniqueNo;
        }
    }
}