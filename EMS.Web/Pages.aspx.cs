﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS.Web
{
    public partial class Pages : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hid_LoginUID.Value =UserInfo.UniqueNo;
                sp_LoginName.InnerHtml = UserInfo.Name;
            }
        }
    }
}