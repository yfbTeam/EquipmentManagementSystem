using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EmsBLL
{
    public partial class RepairDetails
    {
        public DataTable SelectRepairDetails(int ID)
        {
            return new EmsDAL.RepairDetails().SelectRepairDetails(ID);
        }

        public List<EmsModel.View_RepairList> GetList(DataTable dt)
        {
            return new EmsDAL.View_RepairList().GetList(dt);
        }
    }
}
