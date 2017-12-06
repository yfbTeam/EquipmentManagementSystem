using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS.Web.Honor
{
    public partial class HonorEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hidUserIDCard.Value = UserInfo.UniqueNo;
                hidType.Value = Request.QueryString["type"];
                hidId.Value = Request.QueryString["Id"];
                hidIsAdmin.Value = base.IsAdmin;
            }
        }
    }
}