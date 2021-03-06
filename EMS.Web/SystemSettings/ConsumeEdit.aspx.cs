﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS.Web.SystemSettings
{
    public partial class ConsumeEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hid_UserIDCard.Value = UserInfo.UniqueNo;
            if (!IsPostBack)
            {
                string itemid = HttpContext.Current.Request.QueryString["itemid"];
                if (!string.IsNullOrEmpty(itemid))
                {
                    td_countword.Visible = false;
                    td_count.Visible = false;
                    hid_Id.Value = itemid;
                }
            }
        }
    }
}