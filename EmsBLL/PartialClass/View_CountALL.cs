using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EmsBLL
{
    public partial class View_CountALL
    {
        public DataTable SelectView_CountALL() 
        {
            return new EmsDAL.View_CountALL().SelectView_CountALL();
        }
    }
}
