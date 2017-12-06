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
    public partial class PlanExperiment : DALHelper
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>Model的List集合</returns>
        public List<EmsModel.PlanExperiment> GetData(string Id)
        {
            try
            {
                StringBuilder sbSql4org;
                DbParameter[] parms4org;

                sbSql4org = new StringBuilder();
                sbSql4org.Append("SELECT * FROM PlanExperiment ");
                sbSql4org.Append(" where Id=@Id");

                parms4org = new DbParameter[]{
							dbHelper.CreateInDbParameter("@Id", DbType.Int32, Id)
							};

                DataSet ds = dbHelper.ExecuteQuery(CommandType.Text, sbSql4org.ToString(), parms4org);
                return GetList(ds.Tables[0]);
            }
            catch (Exception)
            {
                //写入日志
                //throw;
                return null;
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>View_Calendar的List集合</returns>
        public List<EmsModel.View_Calendar_Land> GetDataFroDateTime(string dateTime, string isStatus)
        {
            try
            {
                StringBuilder sbSql4org;
                DbParameter[] parms4org;

                sbSql4org = new StringBuilder();
                //sbSql4org.Append(" SELECT * FROM View_Calendar where 1=1  ");
                //sbSql4org.Append(" and datediff(month,[StartDate],@dateTime)=0 ");
                if (isStatus != null)
                {
                    sbSql4org.Append(" SELECT * FROM View_Calendar_Land ");
                    sbSql4org.Append(" where isstatus=@isStatus ");
                }
                else
                {
                    sbSql4org.Append(" SELECT * FROM View_Calendar    ");
                }
                parms4org = new DbParameter[]{
							dbHelper.CreateInDbParameter("@dateTime", DbType.String, dateTime),
                            dbHelper.CreateInDbParameter("@isStatus", DbType.String, isStatus)
							};

                DataSet ds = dbHelper.ExecuteQuery(CommandType.Text, sbSql4org.ToString(), parms4org);
                return new EmsDAL.View_Calendar_Land().GetList(ds.Tables[0]);
            }
            catch (Exception)
            {
                //写入日志
                //throw;
                return null;
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>Model的List集合</returns>
        public DataTable GetData3(string Id)
        {
            try
            {
                StringBuilder sbSql4org;
                DbParameter[] parms4org;

                sbSql4org = new StringBuilder();
                sbSql4org.Append(" select a.*,b.Name as TypeName ");
                sbSql4org.Append(" from PlanExperiment a ");
                sbSql4org.Append(" left join Dictionary b on a.Type=b.Id ");
                sbSql4org.Append(" where a.Id=@Id");

                parms4org = new DbParameter[]{
							dbHelper.CreateInDbParameter("@Id", DbType.Int32, Id)
							};

                DataSet ds = dbHelper.ExecuteQuery(CommandType.Text, sbSql4org.ToString(), parms4org);
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
        /// 获得下拉列表
        /// </summary>
        /// <param name="ht">查询条件</param>
        /// <returns>Model的List集合</returns>
        public DataTable GetSelectOption(Hashtable ht)
        {
            try
            {

                //StringBuilder sbSql4org = new StringBuilder();
                //sbSql4org.Append(" select Id,Name,PlanId,ISNULL(SUM([Count]),'0') as [Count] from ");
                //sbSql4org.Append(" (SELECT a.Id,a.Name,a.PlanId,b.[Count] FROM PlanExperiment a");
                //sbSql4org.Append(" left join EquipList b on a.Id=b.RelationID ");
                //sbSql4org.Append(" where a.IsDelete<>1 ");
                //List<DbParameter> List = new List<DbParameter>();
                //if (ht.ContainsKey("Creator"))
                //{
                //    sbSql4org.Append(" and a.Creator=@Creator ");
                //    List.Add(dbHelper.CreateInDbParameter("@Creator", DbType.String, ht["Creator"].ToString()));
                //}

                //sbSql4org.Append(" ) c where [Count]<>0 group by Id,Name,PlanId  ");
                //if (ht.ContainsKey("sql"))
                //{
                //    ht.Remove("sql");
                //}
                //ht.Add("sql", sbSql4org.ToString());
                //if (ht.ContainsKey("DbParameter"))
                //{
                //    ht.Remove("DbParameter");
                //}
                //ht.Add("DbParameter", List.ToArray());
                //DataSet ds = dbHelper.ExecuteQuery(CommandType.Text, ht["sql"].ToString(), (DbParameter[])(ht["DbParameter"]));
                //return ds.Tables[0];

                StringBuilder sbSql4org = new StringBuilder();
                sbSql4org.Append(" SELECT Id,Name,PlanId FROM PlanExperiment ");
                sbSql4org.Append(" where 1=1 and IsDelete <> 1");

                List<DbParameter> List = new List<DbParameter>();
                if (ht.ContainsKey("Creator") && !string.IsNullOrWhiteSpace(ht["Creator"].ToString()))
                {
                    sbSql4org.Append(" and Creator=@Creator ");
                    List.Add(dbHelper.CreateInDbParameter("@Creator", DbType.String, ht["Creator"].ToString()));
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
        /// 查询根据条件
        /// </summary>
        /// <param name="ht">查询条件</param>
        /// <returns>Model的List集合</returns>
        public DataTable GetList(Hashtable ht)
        {
            try
            {
                StringBuilder sbSql4org = new StringBuilder();
                List<DbParameter> List = new List<DbParameter>();
                sbSql4org.Append("SELECT a.* FROM PlanExperiment a ");
                sbSql4org.Append(" where 1=1 ");
                if (ht.ContainsKey("Name") && !string.IsNullOrWhiteSpace(ht["Name"].ToString()))
                {
                    sbSql4org.Append(" and a.Name like N'%'+@Name+'%' ");
                    List.Add(dbHelper.CreateInDbParameter("@Name", DbType.String, ht["Name"].ToString()));
                }
                if (ht.ContainsKey("IsDelete"))
                {
                    if (ht["IsDelete"].ToString() == "全部")
                    {
                        sbSql4org.Append(" and a.IsDelete <> 1 ");
                    }
                    else
                    {
                        sbSql4org.Append(" and a.IsDelete = @IsDelete  ");
                        List.Add(dbHelper.CreateInDbParameter("@IsDelete", DbType.Int32, Convert.ToInt32(ht["IsDelete"].ToString())));
                    }
                }

                #region 拆解Id
                if (ht.ContainsKey("PlanId") && !string.IsNullOrWhiteSpace(ht["PlanId"].ToString()))
                {
                    //拆解Id，每个值都用Parameter
                    string[] PlanId = ht["PlanId"].ToString().Split(',');
                    string PlanIds = "";
                    foreach (string item in PlanId)
                    {
                        PlanIds += "@" + item + ",";
                        List.Add(dbHelper.CreateInDbParameter("@" + item, DbType.Int32, Convert.ToInt32(item)));
                    }
                    PlanIds = PlanIds.Substring(0, PlanIds.Length - 1);
                    sbSql4org.Append(" and a.PlanId in (" + PlanIds + ") ");
                }
                #endregion

                int StartIndex = Convert.ToInt32(ht["StartIndex"].ToString());
                int EndIndex = Convert.ToInt32(ht["EndIndex"].ToString());
                DataSet ds = base.GetListByPage("(" + sbSql4org.ToString() + ")", "", "", StartIndex, EndIndex, List.ToArray());

                int RowCount = base.GetRecordCount("(" + sbSql4org.ToString() + ") T", "", List.ToArray());
                ht.Add("RowCount", RowCount);
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
        /// 由DataTable得到泛型数据列表
        /// </summary>
        internal List<EmsModel.PlanExperiment> GetList_GetPage(DataTable dt)
        {
            List<EmsModel.PlanExperiment> lst = new List<EmsModel.PlanExperiment>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.PlanExperiment mod = new EmsModel.PlanExperiment();
                DataRowToModel_GetPage(mod, dt.Rows[i]);
                lst.Add(mod);
            }

            return lst;
        }

        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        internal void DataRowToModel_GetPage(EmsModel.PlanExperiment EmsModel, DataRow dr)
        {
            DataRowToModel(EmsModel, dr);
            //EmsModel.Id = dr["Id"] as int?; EmsModel.Name = dr["Name"] as string; EmsModel.Type = dr["Type"] as Byte?; EmsModel.IsOpen = dr["IsOpen"] as Byte?; EmsModel.StartDate = dr["StartDate"] as DateTime?; EmsModel.Week = dr["Week"] as int?; EmsModel.Weekday = dr["Weekday"] as int?; EmsModel.ClassHour = dr["ClassHour"] as int?; EmsModel.Part = dr["Part"] as string; EmsModel.Place = dr["Place"] as int?; EmsModel.GroupMemberNumber = dr["GroupMemberNumber"] as int?; EmsModel.GroupNumber = dr["GroupNumber"] as int?; EmsModel.NeedEquip = dr["NeedEquip"] as string; EmsModel.Contents = dr["Contents"] as string; EmsModel.PlanId = dr["PlanId"] as int?; EmsModel.Status = dr["Status"] as Byte?; EmsModel.Creator = dr["Creator"] as string; EmsModel.CreateTime = dr["CreateTime"] as DateTime?; EmsModel.Editor = dr["Editor"] as string; EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?; EmsModel.IsDelete = dr["IsDelete"] as Byte?;
            EmsModel.CreatorName = dr["CreatorName"] as string;
        }


        #region 班级
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>Model的List集合</returns>
        public List<EmsModel.ClassInfo> GetData2(Hashtable ht)
        {
            try
            {
                StringBuilder sbSql4org = new StringBuilder();

                sbSql4org.Append("SELECT * FROM ClassInfo ");
                sbSql4org.Append(" where 1=1 ");
                List<DbParameter> List = new List<DbParameter>();
                if (ht.ContainsKey("Id"))
                {
                    sbSql4org.Append(" and Id=@Id ");
                    List.Add(dbHelper.CreateInDbParameter("@Id", DbType.Int32, Convert.ToInt32(ht["Id"].ToString())));
                }
                if (ht.ContainsKey("Name"))
                {
                    sbSql4org.Append(" and Name like N'%'+@Name+'%' ");
                    List.Add(dbHelper.CreateInDbParameter("@Name", DbType.String, ht["Name"].ToString()));
                }
                if (ht.ContainsKey("IsDelete"))
                {
                    if (string.IsNullOrWhiteSpace(ht["IsDelete"].ToString()))
                    {
                        sbSql4org.Append(" and IsDelete <> 1 ");

                    }
                    else
                    {
                        sbSql4org.Append(" and IsDelete = @IsDelete  ");
                        List.Add(dbHelper.CreateInDbParameter("@IsDelete", DbType.Int32, Convert.ToInt32(ht["IsDelete"].ToString())));
                    }

                }
                if (ht.ContainsKey("Creator"))
                {
                    sbSql4org.Append(" and Creator=@Creator ");
                    List.Add(dbHelper.CreateInDbParameter("@Creator", DbType.String, ht["Creator"].ToString()));
                }
                if (ht.ContainsKey("UseStatus"))
                {
                    sbSql4org.Append(" and UseStatus=@UseStatus ");
                    List.Add(dbHelper.CreateInDbParameter("@UseStatus", DbType.Int32, Convert.ToInt32(ht["UseStatus"].ToString())));
                }

                DataSet ds = dbHelper.ExecuteQuery(CommandType.Text, sbSql4org.ToString(), List.ToArray());
                return new EmsDAL.ClassInfo().GetList(ds.Tables[0]);
            }
            catch (Exception)
            {
                //写入日志
                //throw;
                return null;
            }
        }
        #endregion
        /// <summary>
        /// 获得事物对象
        /// </summary>
        /// <returns></returns>
        public SqlTransaction GetTran()
        {
            return dbHelper.BeginTransaction();
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EmsModel.PlanExperiment GetEmsModel(int? ID)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();
            sbSql4org.Append("SELECT a.*,b.OrderNo FROM PlanExperiment a left join OrderInfo b on a.id=b.ExperimentId");
            sbSql4org.Append(" WHERE a.ID=@in_ID");

            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@in_ID", DbType.Int32,ID)};
            using (DbDataReader dr = dbHelper.ExecuteReader(CommandType.Text, sbSql4org.ToString(), parms4org))
            {
                if (dr.Read())
                {
                    EmsModel.PlanExperiment mod = new EmsModel.PlanExperiment();
                    DbDataReaderToModel(mod, dr);
                    return mod;
                }
                return null;
            }
        }



        /// <summary>
        /// 根据主讲教师，学期和课程名称查询是否重复
        /// </summary>
        public int getTeachingPlan(string MainTeacher, string name, string LearnYear)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();
            sbSql4org.Append("Select count(*) from TeachingPlan where MainTeacher=@MainTeacher and name=@name and LearnYear=@LearnYear");


            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@MainTeacher", DbType.String,MainTeacher),
                dbHelper.CreateInDbParameter("@name", DbType.String,name),
                dbHelper.CreateInDbParameter("@LearnYear", DbType.String,LearnYear)};
            object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql4org.ToString(), parms4org);
            return Convert.ToInt32(obj);

        }


        /// <summary>
        /// 查询相同计划内是否有重复实验
        /// </summary>
        public int getPlanExperiment(string name, string PlanId)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();
            sbSql4org.Append("SELECT count(*) FROM PlanExperiment where name=@name and PlanId=@PlanId");


            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@PlanId", DbType.String,PlanId),
                dbHelper.CreateInDbParameter("@name", DbType.String,name)};
            object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql4org.ToString(), parms4org);
            return Convert.ToInt32(obj);

        }

    }
}
