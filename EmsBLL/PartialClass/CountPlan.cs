using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EmsBLL
{
    public partial class CountPlan
    {

        public DataTable View_CountPlan_Status()
        {
            return new EmsDAL.CountPlan().View_CountPlan_Status();
        }

        public DataTable View_CountPlan_Type()
        {
            return new EmsDAL.CountPlan().View_CountPlan_Type();
        }
    }
}
