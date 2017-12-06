using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EmsDAL
{
    public partial class ExperimentClassInfo : DALHelper
    {

        /// <summary>
        /// 获得实验班级
        /// </summary>
        /// <param name="ht">查询条件</param>
        /// <returns>Model的List集合</returns>
        public DataTable GetData(Hashtable ht)
        {
            try
            {

                StringBuilder sbSql4org = new StringBuilder();
                sbSql4org.Append(" SELECT a.*,b.Name FROM ExperimentClassInfo a ");
                sbSql4org.Append(" left join ClassInfo b on a.ClassId=b.Id ");
                sbSql4org.Append(" where 1=1 ");

                List<DbParameter> List = new List<DbParameter>();
                if (ht.ContainsKey("ExperimentId"))
                {
                    sbSql4org.Append(" and ExperimentId=@ExperimentId ");
                    List.Add(dbHelper.CreateInDbParameter("@ExperimentId", DbType.Int32, Convert.ToInt32(ht["ExperimentId"].ToString())));
                }
                DataSet ds = dbHelper.ExecuteQuery(CommandType.Text, sbSql4org.ToString(), List.ToArray());
                return ds.Tables[0];

            }
            catch (Exception)
            {
                //写入日志
                //throw;
                return null;
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="trans">事物</param>
        /// <param name="ht">条件</param>
        /// <returns>结果</returns>
        public int DeleteEC(SqlTransaction trans, int ExperimentId)
        {
            try
            {
                StringBuilder sbSql;
                DbParameter[] parms;

                sbSql = new StringBuilder();
                sbSql.Append(" DELETE FROM ExperimentClassInfo ");
                sbSql.Append(" WHERE ExperimentId = @in_ID ");

                parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.Int32, ExperimentId)};
                return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
            }
            catch (Exception)
            {
                //写入日志
                //throw;
                return 0;
            }
        }


     


    }
}
