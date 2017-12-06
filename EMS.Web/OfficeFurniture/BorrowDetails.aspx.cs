using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS.Web.OfficeFurniture
{
    public partial class BorrowDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                if (!IsPostBack)
                {
                    hidId.Value = Request.QueryString["Id"];
                    hidBorrowStatus.Value = Request.QueryString["BorrowStatus"];
                }
            }
        }
    }
}