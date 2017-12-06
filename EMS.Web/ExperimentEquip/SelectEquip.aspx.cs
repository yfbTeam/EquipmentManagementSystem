using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS.Web.ExperimentEquip
{
    public partial class SelectEquip : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //实验Id
                hidExperimentId.Value = Request.QueryString["ExperimentId"].ToString();
                //实验名称
                hidExpName.Value = Request.QueryString["ExpName"].ToString();
                //登录账号
                hidUserLgoinName.Value = UserInfo.LoginName;
            }
        }
    }
}