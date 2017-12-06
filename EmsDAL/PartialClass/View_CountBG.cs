using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace EmsDAL
{
    public partial class View_CountBG : DALHelper
    {
        public DataTable SelectView_CountBG() 
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();

            sbSql4org.Append(@"select * from  View_CountBG ");
            parms4org = new DbParameter[]{
               };
            return dbHelper.ExecuteQuery(CommandType.Text, sbSql4org.ToString(), parms4org).Tables[0];
        }
    }
}
