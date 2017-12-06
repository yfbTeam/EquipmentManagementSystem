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
    public partial class BorrowRecord : DALHelper
    {
        /// <summary>
        ///查询借用记录表
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public DataTable GetPage(Hashtable ht)
        {
            try
            {
                StringBuilder sbSql4org;

                sbSql4org = new StringBuilder();
                sbSql4org.Append(@"  select a.* from BorrowRecord a ");
                sbSql4org.Append(" where 1=1 ");

                List<DbParameter> List = new List<DbParameter>();
                if (ht.ContainsKey("BeginDate"))
                {
                    sbSql4org.Append(" and a.BeginDate>=@BeginDate ");
                    List.Add(dbHelper.CreateInDbParameter("@BeginDate", DbType.DateTime, Convert.ToDateTime(ht["BeginDate"].ToString())));
                }
                if (ht.ContainsKey("EndDate"))
                {
                    sbSql4org.Append(" and a.EndDate<=@EndDate ");
                    List.Add(dbHelper.CreateInDbParameter("@EndDate", DbType.DateTime, Convert.ToDateTime(ht["EndDate"].ToString())));
                }
                if (ht.ContainsKey("BorrowStatus"))
                {
                    sbSql4org.Append(" and a.BorrowStatus=@BorrowStatus ");
                    List.Add(dbHelper.CreateInDbParameter("@BorrowStatus", DbType.Int32, Convert.ToInt32(ht["BorrowStatus"].ToString())));
                }
                if (ht["UserIDCard"] != "" && !string.IsNullOrEmpty(Convert.ToString(ht["UserIDCard"])))
                {
                    sbSql4org.Append(" and a.IDCard=@IDCard ");
                    List.Add(dbHelper.CreateInDbParameter("@IDCard", DbType.String, ht["UserIDCard"].ToString()));
                }

                DataSet ds = base.GetListByPage("(" + sbSql4org.ToString() + ")", "", "", Convert.ToInt32(ht["StartIndex"].ToString()), Convert.ToInt32(ht["EndIndex"].ToString()), List.ToArray());
                int RowCount = base.GetRecordCount("(" + sbSql4org.ToString() + ") T", "", List.ToArray());
                ht.Add("RowCount", RowCount);
                return ds.Tables[0];

            }
            catch (Exception ex)
            {
                //写入日志
                //throw;
                return null;
            }
        }

        /// <summary>
        /// 对借用表进行编辑操作
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int SetBorrowRecord(Hashtable ht)
        {
            using (SqlTransaction trans = dbHelper.BeginTransaction())
            {
                try
                {
                    List<DbParameter> list = new List<DbParameter>();
                    StringBuilder sbSql4org = new StringBuilder();
                    list.Add(dbHelper.CreateInDbParameter("@Id", DbType.Int32, ht["Id"].ToString() == "" ? 0 : Convert.ToInt32(ht["Id"])));
                    list.Add(dbHelper.CreateInDbParameter("@UserIDCard", DbType.String, ht["UserIDCard"].ToString()));
                    list.Add(dbHelper.CreateInDbParameter("@BeginDate", DbType.DateTime, Convert.ToDateTime(ht["BeginDate"])));
                    list.Add(dbHelper.CreateInDbParameter("@EndDate", DbType.DateTime, Convert.ToDateTime(ht["EndDate"])));
                    list.Add(dbHelper.CreateInDbParameter("@BorrowReason", DbType.String, ht["BorrowReason"].ToString()));
                    list.Add(dbHelper.CreateInDbParameter("@Notes", DbType.String, ht["Notes"].ToString()));
                    List<string> equips = ht["equips"] as List<string>;
                    string operat = string.Empty;
                    if (Convert.ToString(ht["operator"]) == "edit")
                    {
                        sbSql4org.Append(" update BorrowRecord set BeginDate=@BeginDate,EndDate=@EndDate,BorrowReason=@BorrowReason,Notes=@Notes where Id=@Id;");
                        operat = "@Id";
                        sbSql4org.Append("delete  BorrowRecordDetails where BorrowRecord=" + operat + ";");
                    }
                    else
                    {
                        sbSql4org.Append("declare @CID int;insert into BorrowRecord values(@BeginDate,@EndDate,@BorrowReason,@Notes,0,@UserIDCard);set @CID=@@IDENTITY;");
                        operat = "@CID";
                    }

                    for (int j = 0; j < equips.Count; j++)
                    {
                        if (Convert.ToString(ht["operator"]) == "edit")
                        {
                            sbSql4org.Append(" update EquipDetail  set EquipStatus=0 where id=" + equips[j] + ";");
                        }

                        sbSql4org.Append("insert into BorrowRecordDetails values(" + operat + "," + equips[j] + ");");
                        sbSql4org.Append(" update EquipDetail  set EquipStatus=5 where id=" + equips[j] + ";");

                    }
                    int number = dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql4org.ToString(), list.ToArray());
                    if (number > 0)
                    {
                        trans.Commit();
                        return number;
                    }
                    else
                        return -1;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return -1;
                }
            }
        }

        public int DeleteBorrowRecord(Hashtable ht)
        {
            using (SqlTransaction trans = dbHelper.BeginTransaction())
            {
                try
                {
                    StringBuilder sbSql4org = new StringBuilder();
                    DbParameter[] parms = new DbParameter[]{
				    dbHelper.CreateInDbParameter("@Id", DbType.Int32, Convert.ToInt32(ht["Id"])),
                    };
                    sbSql4org.Append(" delete BorrowRecord  where Id=@Id;");
                    sbSql4org.Append(" delete BorrowRecordDetails where BorrowRecord=@Id;");
                    int number = dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql4org.ToString(), parms);
                    if (number > 0)
                    {
                        trans.Commit();
                        return number;
                    }
                    return -1;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return -1;
                }
            }
        }

        public int AuditingBorrow(Hashtable ht)
        {
            using (SqlTransaction trans = dbHelper.BeginTransaction())
            {
                try
                {
                    StringBuilder sbSql4org = new StringBuilder();
                    DbParameter[] parms = new DbParameter[]{
				    dbHelper.CreateInDbParameter("@Id", DbType.Int32, Convert.ToInt32(ht["Id"])),
                    dbHelper.CreateInDbParameter("@BorrowStatus", DbType.Int32, Convert.ToInt32(ht["BorrowStatus"])),
                    };
                    sbSql4org.Append(" update BorrowRecord set BorrowStatus=@BorrowStatus  where id=@id;");
                    if (Convert.ToInt32(ht["BorrowStatus"]) == 1)
                    {
                        sbSql4org.Append(" update EquipDetail set EquipStatus=1 where id in (select EquipDatailID from BorrowRecordDetails where BorrowRecord=@id);");
                    }
                    if (Convert.ToInt32(ht["BorrowStatus"]) == 3 || Convert.ToInt32(ht["BorrowStatus"]) == 4)
                    {
                        sbSql4org.Append(" update EquipDetail set EquipStatus=0 where id in (select EquipDatailID from BorrowRecordDetails where BorrowRecord=@id);");
                    }
                    int number = dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql4org.ToString(), parms);
                    if (number > 0)
                    {
                        trans.Commit();
                        return number;
                    }
                    return -1;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return -1;
                }
            }
        }


        public DataTable GetPage(int id)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();

            sbSql4org.Append(@" select a.* from BorrowRecord a ");
            sbSql4org.Append(" where a.id=@id ");
            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@id",DbType.Int32, id),
               };
            return dbHelper.ExecuteQuery(CommandType.Text, sbSql4org.ToString(), parms4org).Tables[0];
        }


        public DataTable GetPageList(int id)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();

            sbSql4org.Append(@" select a.id,a.EquipDatailID, b.AssetNumber as number,b.AssetName as name,b.type,b.unit from BorrowRecordDetails a left join EquipDetail b on a.EquipDatailID=b.id ");
            sbSql4org.Append(" where BorrowRecord=@id ");
            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@id",DbType.Int32, id),
               };
            return dbHelper.ExecuteQuery(CommandType.Text, sbSql4org.ToString(), parms4org).Tables[0];
        }
    }
}
