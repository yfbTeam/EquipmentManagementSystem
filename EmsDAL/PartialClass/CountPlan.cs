using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace EmsDAL
{
    public partial class CountPlan : DALHelper
    {
        public DataTable View_CountPlan_Status()
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
             sbSql4org = new StringBuilder();

             sbSql4org.Append(@"select * from  View_CountPlan_Status ");
             parms4org = new DbParameter[]{
               };
             return dbHelper.ExecuteQuery(CommandType.Text, sbSql4org.ToString(), parms4org).Tables[0];
        }

        public DataTable View_CountPlan_Type()
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();

            sbSql4org.Append(@"select * from  View_CountPlan_Type ");
            parms4org = new DbParameter[]{
               };
            return dbHelper.ExecuteQuery(CommandType.Text, sbSql4org.ToString(), parms4org).Tables[0];
        }
    }
}
