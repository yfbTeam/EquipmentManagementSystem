using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace EmsDAL
{
    /// <summary>
    /// 课程
    /// </summary>
    public partial class TeachingPlan : DALHelper
    {
        /// <summary>
        /// 查询根据Id
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>Model的List集合</returns>
        public List<EmsModel.TeachingPlan> GetData(string Id)
        {
            try
            {
                StringBuilder sbSql4org;
                DbParameter[] parms4org;

                sbSql4org = new StringBuilder();
                sbSql4org.Append("SELECT * FROM TeachingPlan ");
                sbSql4org.Append(" where Id=@Id ");

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
        /// 根据条件查询数据
        /// </summary>
        /// <param name="ht">查询条件</param>
        /// <returns>Model的List集合</returns>
        public List<EmsModel.TeachingPlan> GetModelList(Hashtable ht)
        {
            try
            {
                StringBuilder sbSql4org = new StringBuilder();
                sbSql4org.Append("SELECT * FROM TeachingPlan ");
                sbSql4org.Append(" where 1=1 ");

                List<DbParameter> List = new List<DbParameter>();
                if (ht.ContainsKey("Id") && !string.IsNullOrWhiteSpace(ht["Id"].ToString()))
                {
                    sbSql4org.Append(" and Id=@Id ");
                    List.Add(dbHelper.CreateInDbParameter("@Id", DbType.Int32, Convert.ToInt32(ht["Id"].ToString())));
                }
                if (ht.ContainsKey("Name") && !string.IsNullOrWhiteSpace(ht["Name"].ToString()))
                {
                    sbSql4org.Append(" and Name like N'%'+@Name+'%' ");
                    List.Add(dbHelper.CreateInDbParameter("@Name", DbType.String, ht["Name"].ToString()));
                }
                if (ht.ContainsKey("LearnYear") && !string.IsNullOrWhiteSpace(ht["LearnYear"].ToString()))
                {
                    sbSql4org.Append(" and LearnYear=@LearnYear ");
                    List.Add(dbHelper.CreateInDbParameter("@LearnYear", DbType.Int32, Convert.ToInt32(ht["LearnYear"].ToString())));
                }
                //if (!string.IsNullOrWhiteSpace(ht["StartDate"].ToString()))
                //{
                //    sbSql4org.Append(" and a.CreateTime >= @StartDate ");
                //    List.Add(dbHelper.CreateInDbParameter("@StartDate", DbType.DateTime2, Convert.ToDateTime(ht["StartDate"].ToString())));
                //}
                //if (!string.IsNullOrWhiteSpace(ht["EndDate"].ToString()))
                //{
                //    sbSql4org.Append(" and a.CreateTime < @EndDate  ");
                //    List.Add(dbHelper.CreateInDbParameter("@EndDate", DbType.DateTime2, Convert.ToDateTime(ht["EndDate"].ToString())));
                //}
                if (ht.ContainsKey("Creator") && !string.IsNullOrWhiteSpace(ht["Creator"].ToString()))
                {
                    sbSql4org.Append(" and Creator=@Creator ");
                    List.Add(dbHelper.CreateInDbParameter("@Creator", DbType.String, ht["Creator"].ToString()));
                }
                if (ht.ContainsKey("IsDelete") )
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

                DataSet ds = dbHelper.ExecuteQuery(CommandType.Text, sbSql4org.ToString(), List.ToArray());
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
        /// 获得下拉列表
        /// </summary>
        /// <param name="ht">查询条件</param>
        /// <returns>Model的List集合</returns>
        public DataTable GetSelectOption(Hashtable ht)
        {
            try
            {

                StringBuilder sbSql4org = new StringBuilder();
                sbSql4org.Append(" SELECT Id,Name,LearnYear FROM TeachingPlan ");
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
        /// 分页查询根据条件
        /// </summary>
        /// <param name="ht">查询条件</param>
        /// <returns>Model的List集合</returns>
        public DataTable GetPage(Hashtable ht)
        {
            try
            {
                StringBuilder sbSql4org = new StringBuilder();
                sbSql4org.Append("SELECT a.* FROM TeachingPlan a ");
                sbSql4org.Append(" where 1=1 and a.Creator <> '' ");

                List<DbParameter> List = new List<DbParameter>();
                if (ht.ContainsKey("PIds") && !string.IsNullOrWhiteSpace(Convert.ToString(ht["PIds"])))
                {
                    sbSql4org.Append(" and a.Id in (" + ht["PIds"].ToString() + ") ");
                }
                if (ht.ContainsKey("Name") && !string.IsNullOrWhiteSpace(ht["Name"].ToString()))
                {
                    sbSql4org.Append(" and a.Name like N'%'+@Name+'%' ");
                    List.Add(dbHelper.CreateInDbParameter("@Name", DbType.String, ht["Name"].ToString()));
                }
                if (ht.ContainsKey("EName") && !string.IsNullOrWhiteSpace(ht["EName"].ToString()))
                {
                    sbSql4org.Append(" and a.id in (select Planid from PlanExperiment where name like N'%'+@EName+'%'  and IsDelete <> 1 ) ");
                    List.Add(dbHelper.CreateInDbParameter("@EName", DbType.String, ht["EName"].ToString()));
                }
                if (ht.ContainsKey("Date") && !string.IsNullOrWhiteSpace(Convert.ToString(ht["Date"])))
                {
                    sbSql4org.Append(" and CONVERT(varchar(100),a.CreateTime, 23)=@CreateTime ");
                    List.Add(dbHelper.CreateInDbParameter("@CreateTime", DbType.DateTime, Convert.ToString(ht["Date"])));
                }
                if (ht.ContainsKey("LearnYear") && !string.IsNullOrWhiteSpace(ht["LearnYear"].ToString()) && string.IsNullOrWhiteSpace(ht["PIds"].ToString()))
                {
                    sbSql4org.Append(" and a.LearnYear=@LearnYear ");
                    List.Add(dbHelper.CreateInDbParameter("@LearnYear", DbType.Int32, Convert.ToInt32(ht["LearnYear"].ToString())));
                }
                if (ht.ContainsKey("Creator"))
                {
                    sbSql4org.Append(" and a.Creator=@Creator ");
                    List.Add(dbHelper.CreateInDbParameter("@Creator", DbType.String, ht["Creator"].ToString()));
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
    }
}
