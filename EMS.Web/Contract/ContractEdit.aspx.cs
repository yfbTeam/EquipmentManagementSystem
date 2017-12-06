using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS.Web.Contract
{
    public partial class ContractEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hidId.Value = Request.QueryString["id"];
                hidOperator.Value = Request.QueryString["p"];
                hidUserIDCard.Value = UserInfo.UniqueNo; 
                hidIsAdmin.Value = base.IsAdmin;
            }
        }
    }
}