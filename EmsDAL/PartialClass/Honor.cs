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
    /// 荣誉
    /// </summary>
    public partial class Honor : DALHelper
    {
        /// <summary>
        /// 查询根据Id
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>Model的List集合</returns>
        public List<EmsModel.Honor> GetData(string Id)
        {
            try
            {
                StringBuilder sbSql4org;
                DbParameter[] parms4org;

                sbSql4org = new StringBuilder();
                sbSql4org.Append("SELECT a.*,b.Name as LevelName,c.Name as ExperimentName FROM Honor a ");
                sbSql4org.Append(" left join Dictionary b on a.HonorLevel=b.Id ");
                sbSql4org.Append(" left join PlanExperiment c on a.ExperimentId=c.Id ");

                sbSql4org.Append(" where a.Id=@Id");

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

        public DataTable GetData(EmsModel.Honor honor)
        {
            try
            {
                StringBuilder sbSql4org;
                List<DbParameter> list = new List<DbParameter>();
                sbSql4org = new StringBuilder();
                sbSql4org.Append("SELECT * FROM Honor  where 1=1 ");
                if (!string.IsNullOrEmpty(honor.Name))
                {
                    sbSql4org.Append(" and [name]=@name ");
                    list.Add(dbHelper.CreateInDbParameter("@name", DbType.String, honor.Name));
                }

                DataSet ds = dbHelper.ExecuteQuery(CommandType.Text, sbSql4org.ToString(), list.ToArray());
                if (ds!=null && ds.Tables[0].Rows.Count>0)
                {
                    return ds.Tables[0];
                }
                return null;
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
                sbSql4org.Append("SELECT a.*,b.Name as LevelName,c.Name as ExperimentName FROM Honor a ");
                sbSql4org.Append(" left join Dictionary b on a.HonorLevel=b.Id ");
                sbSql4org.Append(" left join PlanExperiment c on a.ExperimentId=c.Id ");
                sbSql4org.Append(" where 1=1 ");
                List<DbParameter> List = new List<DbParameter>();
                if (ht.ContainsKey("Id"))
                {
                    sbSql4org.Append(" and a.Id=@Id ");
                    List.Add(dbHelper.CreateInDbParameter("@Id", DbType.String, Convert.ToInt32(ht["Id"].ToString())));
                }
                if (ht.ContainsKey("Name") && !string.IsNullOrWhiteSpace(ht["Name"].ToString()))
                {
                    sbSql4org.Append(" and a.Name like N'%'+@Name+'%' ");
                    List.Add(dbHelper.CreateInDbParameter("@Name", DbType.String, ht["Name"].ToString()));
                }
                if (ht.ContainsKey("Creator"))
                {
                    sbSql4org.Append(" and a.Creator=@Creator ");
                    List.Add(dbHelper.CreateInDbParameter("@Creator", DbType.String, ht["Creator"].ToString()));
                }
                if (ht.ContainsKey("ExperimentName") && !string.IsNullOrWhiteSpace(ht["ExperimentName"].ToString()))
                {
                    sbSql4org.Append(" and c.Name like N'%'+@ExperimentName+'%' ");
                    List.Add(dbHelper.CreateInDbParameter("@ExperimentName", DbType.Int32, Convert.ToInt32(ht["ExperimentName"].ToString())));
                }

                if (ht.ContainsKey("HonorLevel") && ht["HonorLevel"].ToString() != "全部")
                {
                    sbSql4org.Append(" and a.HonorLevel = @HonorLevel  ");
                    List.Add(dbHelper.CreateInDbParameter("@HonorLevel", DbType.Int32, Convert.ToInt32(ht["HonorLevel"].ToString())));
                }
                if (ht.ContainsKey("IsDelete") && ht["IsDelete"].ToString() == "全部")
                {
                    sbSql4org.Append(" and a.IsDelete <> 1 ");
                }
                else if (ht.ContainsKey("IsDelete"))
                {
                    sbSql4org.Append(" and a.IsDelete = @IsDelete  ");
                    List.Add(dbHelper.CreateInDbParameter("@IsDelete", DbType.Int32, Convert.ToInt32(ht["IsDelete"].ToString())));
                }
                DataSet ds = base.GetListByPage("(" + sbSql4org.ToString() + ")", "", "", Convert.ToInt32(ht["StartIndex"]??"1"), Convert.ToInt32(ht["EndIndex"]??"10"), List.ToArray());

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
        /// 调用赋值了LearnYearName（学年学期名称）的方法
        /// </summary>
        internal List<EmsModel.Honor> GetList2(DataTable dt)
        {
            List<EmsModel.Honor> lst = new List<EmsModel.Honor>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.Honor mod = new EmsModel.Honor();
                DataRowToModel2(mod, dt.Rows[i]);
                lst.Add(mod);
            }
            return lst;
        }

        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        internal void DataRowToModel2(EmsModel.Honor EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?; EmsModel.Name = dr["Name"] as string; EmsModel.HonorLevel = dr["HonorLevel"] as int?; EmsModel.ExperimentId = dr["ExperimentId"] as int?; EmsModel.Creator = dr["Creator"] as string; EmsModel.CreateTime = dr["CreateTime"] as DateTime?; EmsModel.Editor = dr["Editor"] as string; EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?; EmsModel.IsDelete = dr["IsDelete"] as Byte?;
            EmsModel.LevelName = dr["LevelName"] as string; 
            EmsModel.ExperimentName = dr["ExperimentName"] as string;
            EmsModel.CreatorName = dr["CreatorName"] as string;
        }
    }
}
