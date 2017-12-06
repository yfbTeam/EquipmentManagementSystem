using EmsModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EmsDAL
{
    public partial class EquipborrowManage : DALHelper
    {
        public DataTable SelectEquipborrowManage(int BorrowYN, string EQtype, string name, int index)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();

            sbSql4org.Append(@"select top (@index) ");
            sbSql4org.Append(" * from  View_EquipDatail ");
            sbSql4org.Append(" where BorrowYN=@BorrowYN and (type=@EQtype or @EQtype='') and AssetName like '%'+@name+'%' ");
            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@index",DbType.Int32, index),
                dbHelper.CreateInDbParameter("@BorrowYN",DbType.Int32, BorrowYN),
                dbHelper.CreateInDbParameter("@EQtype",DbType.String,EQtype),
                dbHelper.CreateInDbParameter("@name",DbType.String, name)
               };
            return dbHelper.ExecuteQuery(CommandType.Text, sbSql4org.ToString(), parms4org).Tables[0];
        }


        public string setEquipDetail(string Ystr, string Dstr)
        {
            //事务
            using (SqlTransaction trans = dbHelper.BeginTransaction())
            {
                try
                {
                    StringBuilder sbSql;
                    DbParameter[] parms;
                    int index = 999;
                    //sbSql = new StringBuilder();
                    //sbSql.Append("update EquipDetail set BorrowYN=0 ");
                    //parms = new DbParameter[]{};
                    //dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
                    ///将移入不可借用表单的资产状态设置为0
                    if (Dstr != "")
                    {
                        sbSql = new StringBuilder();
                        sbSql.Append("EXEC('update EquipDetail set BorrowYN=0  where id in ('+@str+')')");
                        parms = new DbParameter[] 
                        {
                         dbHelper.CreateInDbParameter("@str",DbType.String, Dstr),
                        };
                        index = dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
                    }

                    ///将移入可借用表单的资产状态设置为1
                    if (Ystr != "")
                    {
                        sbSql = new StringBuilder();
                        sbSql.Append("EXEC('update EquipDetail set BorrowYN=1  where id in ('+@str+')')");
                        parms = new DbParameter[] 
                        {
                         dbHelper.CreateInDbParameter("@str",DbType.String, Ystr),
                        };
                         index = dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
                    }

                    if (index > 0 && index!=999)
                    {
                        trans.Commit();
                        return "ok";
                    }
                    else if (index == 999)
                    {
                        //回滚
                        trans.Rollback();
                        return "qx";
                    }
                    else
                    {
                        //回滚
                        trans.Rollback();
                        return "no";
                    }

                }

                catch (Exception)
                {
                    //回滚
                    trans.Rollback();
                    return "no";
                }
            }
        }




    }
}
