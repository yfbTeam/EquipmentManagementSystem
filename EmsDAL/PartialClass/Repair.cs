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
    public partial class Repair : DALHelper
    {

        public int AddRepairDetails(Hashtable ht)
        {
            using (SqlTransaction trans = dbHelper.BeginTransaction())
            {
                try
                {
                    List<DbParameter> list = new List<DbParameter>();
                    StringBuilder sbSql4org = new StringBuilder();
                    list.Add(dbHelper.CreateInDbParameter("@Record", DbType.String, ht["Record"].ToString()));
                    list.Add(dbHelper.CreateInDbParameter("@Date", DbType.DateTime, ht["Date"].ToString()));
                    list.Add(dbHelper.CreateInDbParameter("@RepairID", DbType.Int32, ht["ID"].ToString()));
                    list.Add(dbHelper.CreateInDbParameter("@RID", DbType.Int32, ht["RID"].ToString()));
                    List<EmsModel.FileModel> files = ht["fileJson"] as List<EmsModel.FileModel>;
                    string Operator = ht["Operator"].ToString();
                    string operat = string.Empty;
                    if (Operator == "edit")
                    {
                        sbSql4org.Append("update RepairDetails set Record=@Record where id=@RID ;");
                        sbSql4org.Append("delete RepairAttachment  where RepairDetailsID=@RID ;");
                        for (int i = 0; i < files.Count; i++)
                        {
                            sbSql4org.Append("insert into RepairAttachment Values (@RID,'" + files[i].name + "','" + files[i].path + "');");
                        }
                    }
                    else
                    {
                        sbSql4org.Append("declare @CID int;insert into RepairDetails values(@RepairID,@Record,@Date);set @CID=@@IDENTITY;");
                        operat = "@CID";
                        for (int i = 0; i < files.Count; i++)
                        {
                            sbSql4org.Append("insert into RepairAttachment Values (" + operat + ",'" + files[i].name + "','" + files[i].path + "');");
                        }
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


        public DataTable GetRepairDetails(int id)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();

            sbSql4org.Append(@" select * from RepairDetails ");
            sbSql4org.Append(" where RepairID=@id ");
            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@id",DbType.Int32, id),
               };
            return dbHelper.ExecuteQuery(CommandType.Text, sbSql4org.ToString(), parms4org).Tables[0];
        }

        public DataTable GetRepairDetailsNo(int id)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();

            sbSql4org.Append(@" select * from RepairDetails ");
            sbSql4org.Append(" where id=@id ");
            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@id",DbType.Int32, id),
               };
            return dbHelper.ExecuteQuery(CommandType.Text, sbSql4org.ToString(), parms4org).Tables[0];
        }


        public DataTable GetRepairAttachment(int id)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();

            sbSql4org.Append(@" select * from RepairAttachment ");
            sbSql4org.Append(" where RepairDetailsID=@id ");
            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@id",DbType.Int32, id),
               };
            return dbHelper.ExecuteQuery(CommandType.Text, sbSql4org.ToString(), parms4org).Tables[0];
        }




        public int RepairInfo(Hashtable ht)
        {
            using (SqlTransaction trans = dbHelper.BeginTransaction())
            {
                try
                {
                    List<DbParameter> list = new List<DbParameter>();
                    StringBuilder sbSql4org = new StringBuilder();
                    list.Add(dbHelper.CreateInDbParameter("@RepairLocation", DbType.String, ht["RepairLocation"].ToString()));
                    list.Add(dbHelper.CreateInDbParameter("@CostOfRepairs", DbType.String, ht["CostOfRepairs"].ToString()));
                    list.Add(dbHelper.CreateInDbParameter("@CompleteTime", DbType.String, ht["CompleteTime"].ToString()));
                    list.Add(dbHelper.CreateInDbParameter("@ID", DbType.Int32, ht["ID"].ToString()));
                    ///添加数据并修改保修状态
                    sbSql4org.Append("update Repair set RepairLocation=@RepairLocation , CostOfRepairs=@CostOfRepairs ,CompleteTime=@CompleteTime,RepairStatus=1 where id=@ID ");
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


        public int UpdateStatus(Hashtable ht)
        {
            using (SqlTransaction trans = dbHelper.BeginTransaction())
            {
                try
                {
                    List<DbParameter> list = new List<DbParameter>();
                    StringBuilder sbSql4org = new StringBuilder();
                    list.Add(dbHelper.CreateInDbParameter("@EquipID", DbType.Int32, ht["EquipID"].ToString()));
                    list.Add(dbHelper.CreateInDbParameter("@ID", DbType.Int32, ht["ID"].ToString()));
                    ///取回修改状态
                    sbSql4org.Append("update Repair set  RepairStatus=2 where id=@ID ; ");
                    if (ht["type"].ToString() == "no")
                    {
                        sbSql4org.Append("update EquipDetail set EquipStatus=4 where id=@EquipID ; ");
                    }
                    else
                    {
                        sbSql4org.Append("update EquipDetail set EquipStatus=0 where id=@EquipID ; ");
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



        public int DeteleRepair(Hashtable ht)
        {
            using (SqlTransaction trans = dbHelper.BeginTransaction())
            {
                try
                {
                    List<DbParameter> list = new List<DbParameter>();
                    StringBuilder sbSql4org = new StringBuilder();
                    list.Add(dbHelper.CreateInDbParameter("@ID", DbType.Int32, ht["ID"].ToString()));
                    ///取回修改状态
                    sbSql4org.Append("update Repair set  IsDelete=1 where id=@ID ; ");


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


        public int deleteRepairDetails(Hashtable ht)
        {
            using (SqlTransaction trans = dbHelper.BeginTransaction())
            {
                try
                {
                    List<DbParameter> list = new List<DbParameter>();
                    StringBuilder sbSql4org = new StringBuilder();
                    list.Add(dbHelper.CreateInDbParameter("@ID", DbType.Int32, ht["ID"].ToString()));
                    ///取回修改状态
                    sbSql4org.Append("delete RepairDetails  where id=@ID ; ");

                    sbSql4org.Append("delete RepairAttachment  where RepairDetailsID=@ID ; ");
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
    }
}
