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
    /// 学年学期
    /// </summary>
    public partial class LearnYear : DALHelper
    {

        /// <summary>
        /// 根据条件查询数据
        /// </summary>
        /// <param name="ht">查询条件</param>
        /// <returns>Model的List集合</returns>
        public List<EmsModel.LearnYear> GetModelList(Hashtable ht)
        {
            try
            {
                StringBuilder sbSql4org = new StringBuilder();
                sbSql4org.Append("SELECT * FROM LearnYear ");
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
                if (ht.ContainsKey("Creator") && !string.IsNullOrWhiteSpace(ht["Creator"].ToString()))
                {
                    sbSql4org.Append(" and Creator=@Creator ");
                    List.Add(dbHelper.CreateInDbParameter("@Creator", DbType.String, ht["Creator"].ToString()));
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
        /// 分页查询
        /// </summary>
        /// <param name="ht">查询条件</param>
        /// <returns></returns>
        public DataTable GetPage(Hashtable ht)
        {
            try
            {
                StringBuilder sbSql4org = new StringBuilder();
                sbSql4org.Append("SELECT * FROM LearnYear a ");
                sbSql4org.Append(" where 1=1 ");

                List<DbParameter> List = new List<DbParameter>();
                if (ht.ContainsKey("Name") && !string.IsNullOrWhiteSpace(ht["Name"].ToString()))
                {
                    sbSql4org.Append(" and Name like N'%'+@Name+'%' ");
                    List.Add(dbHelper.CreateInDbParameter("@Name", DbType.String, ht["Name"].ToString()));
                }
                if (ht.ContainsKey("Creator"))
                {
                    sbSql4org.Append(" and Creator=@Creator ");
                    List.Add(dbHelper.CreateInDbParameter("@Creator", DbType.String, ht["Creator"].ToString()));
                }
                if (ht.ContainsKey("IsDelete"))
                {
                    if (ht["IsDelete"].ToString() == "全部")
                    {
                        sbSql4org.Append(" and IsDelete <> 1 ");
                    }
                    else
                    {
                        sbSql4org.Append(" and IsDelete = @IsDelete  ");
                        List.Add(dbHelper.CreateInDbParameter("@IsDelete", DbType.Int32, Convert.ToInt32(ht["IsDelete"].ToString())));
                    }
                }
                DbParameter[] para = List.ToArray();
                DataSet ds = base.GetListByPage("(" + sbSql4org.ToString() + ")", "", "UseStatus,T.ID desc ", Convert.ToInt32(ht["StartIndex"].ToString()), Convert.ToInt32(ht["EndIndex"].ToString()), para);
                //总条数
                int RowCount = base.GetRecordCount("(" + sbSql4org.ToString() + ") T", "", para);
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
        /// 获得总条数
        /// </summary>
        /// <param name="ht">查询条件</param>
        /// <returns>总条数</returns>
        public int GetListByPageCount(Hashtable ht)
        {
            try
            {
                StringBuilder sbSql4org = new StringBuilder();
                sbSql4org.Append("SELECT * FROM LearnYear a ");
                sbSql4org.Append(" where 1=1 ");

                List<DbParameter> List = new List<DbParameter>();
                if (ht.ContainsKey("Name") && !string.IsNullOrWhiteSpace(ht["Name"].ToString()))
                {
                    sbSql4org.Append(" and Name like N'%'+@Name+'%' ");
                    List.Add(dbHelper.CreateInDbParameter("@Name", DbType.String, ht["Name"].ToString()));
                }
                if (ht.ContainsKey("Creator"))
                {
                    sbSql4org.Append(" and Creator=@Creator ");
                    List.Add(dbHelper.CreateInDbParameter("@Creator", DbType.String, ht["Creator"].ToString()));
                }
                if (ht.ContainsKey("IsDelete"))
                {
                    if (ht["IsDelete"].ToString() == "全部")
                    {
                        sbSql4org.Append(" and IsDelete <> 1 ");
                    }
                    else
                    {
                        sbSql4org.Append(" and IsDelete = @IsDelete  ");
                        List.Add(dbHelper.CreateInDbParameter("@IsDelete", DbType.Int32, Convert.ToInt32(ht["IsDelete"].ToString())));
                    }
                }
                return base.GetRecordCount("(" + sbSql4org.ToString() + ") T", "", List.ToArray());
            }
            catch
            {
                return 0;
            }
        }

        #region 获取泛型数据列表 分页
        ///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.LearnYear> GetListByPageAndSear(EmsModel.LearnYear EmsMod, int startIndex, int endIndex)
        {
            //表名
            string TableName = "LearnYear";
            //条件
            string strWhere = "";
            //排序
            string orderby = "UseStatus,T.ID desc ";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();
            if (EmsMod.Name != null) { strWhere += " and Name like '%'+@in_Name+'%' "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); } if (EmsMod.StartDate != null) { strWhere += " and StartDate=@in_StartDate "; parmsList.Add(dbHelper.CreateInDbParameter("@in_StartDate", DbType.String, EmsMod.StartDate)); } if (EmsMod.EndDate != null) { strWhere += " and EndDate=@in_EndDate "; parmsList.Add(dbHelper.CreateInDbParameter("@in_EndDate", DbType.String, EmsMod.EndDate)); } if (EmsMod.DataCollectionTime != null) { strWhere += " and DataCollectionTime=@in_DataCollectionTime "; parmsList.Add(dbHelper.CreateInDbParameter("@in_DataCollectionTime", DbType.String, EmsMod.DataCollectionTime)); } if (EmsMod.Creator != null) { strWhere += " and Creator=@in_Creator "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); } if (EmsMod.CreateTime != null) { strWhere += " and CreateTime=@in_CreateTime "; parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); } if (EmsMod.Editor != null) { strWhere += " and Editor=@in_Editor "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); } if (EmsMod.UpdateTime != null) { strWhere += " and UpdateTime=@in_UpdateTime "; parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); } if (EmsMod.IsDelete != null) { strWhere += " and IsDelete=@in_IsDelete "; parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); } if (EmsMod.Remarks != null) { strWhere += " and Remarks=@in_Remarks "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); } if (EmsMod.UseStatus != null) { strWhere += " and UseStatus=@in_UseStatus "; parmsList.Add(dbHelper.CreateInDbParameter("@in_UseStatus", DbType.String, EmsMod.UseStatus)); }

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds = GetListByPage(TableName, strWhere, orderby, startIndex, endIndex, parms);
            List<EmsModel.LearnYear> list = GetList(ds.Tables[0]);
            return list;
        }
        #endregion

        #region 获取列表总数量
        public int GetListByPageCountAndSear(EmsModel.LearnYear EmsMod)
        {
            string TableName = "LearnYear";
            string strWhere = "";

            List<DbParameter> parmsList = new List<DbParameter>();
            if (EmsMod.Name != null) { strWhere += " and Name like '%'+@in_Name+'%' "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); } if (EmsMod.StartDate != null) { strWhere += " and StartDate=@in_StartDate "; parmsList.Add(dbHelper.CreateInDbParameter("@in_StartDate", DbType.String, EmsMod.StartDate)); } if (EmsMod.EndDate != null) { strWhere += " and EndDate=@in_EndDate "; parmsList.Add(dbHelper.CreateInDbParameter("@in_EndDate", DbType.String, EmsMod.EndDate)); } if (EmsMod.DataCollectionTime != null) { strWhere += " and DataCollectionTime=@in_DataCollectionTime "; parmsList.Add(dbHelper.CreateInDbParameter("@in_DataCollectionTime", DbType.String, EmsMod.DataCollectionTime)); } if (EmsMod.Creator != null) { strWhere += " and Creator=@in_Creator "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); } if (EmsMod.CreateTime != null) { strWhere += " and CreateTime=@in_CreateTime "; parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); } if (EmsMod.Editor != null) { strWhere += " and Editor=@in_Editor "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); } if (EmsMod.UpdateTime != null) { strWhere += " and UpdateTime=@in_UpdateTime "; parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); } if (EmsMod.IsDelete != null) { strWhere += " and IsDelete=@in_IsDelete "; parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); } if (EmsMod.Remarks != null) { strWhere += " and Remarks=@in_Remarks "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); } if (EmsMod.UseStatus != null) { strWhere += " and UseStatus=@in_UseStatus "; parmsList.Add(dbHelper.CreateInDbParameter("@in_UseStatus", DbType.String, EmsMod.UseStatus)); }

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EmsModel.LearnYear GetEmsModel(int? ID)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();
            sbSql4org.Append("SELECT * FROM LearnYear");
            sbSql4org.Append(" WHERE ID=@in_ID");

            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@in_ID", DbType.Int32,ID)};
            using (DbDataReader dr = dbHelper.ExecuteReader(CommandType.Text, sbSql4org.ToString(), parms4org))
            {
                if (dr.Read())
                {
                    return GetEmsModel(dr);
                }
                return null;
            }
        }
        #endregion

        #region 判断学期名称是否已存在
        /// <summary>
        /// 判断学期名称是否已存在
        /// </summary>
        public bool IsNameExists(string name, Int32 Id)
        {
            try
            {
                StringBuilder sbSql;
                DbParameter[] parms;
                sbSql = new StringBuilder();
                sbSql.Append("SELECT COUNT(1) FROM LearnYear");
                sbSql.Append(" where IsDelete=0 and Name=@Name ");
                if (Id != 0)
                {
                    sbSql.Append(" and Id!=@Id ");
                }
                parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@Name", DbType.String,name),
                            dbHelper.CreateInDbParameter("@Id",DbType.Int32,Id)
							};
                object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
                return int.Parse(obj.ToString()) > 0;
            }
            catch (Exception)
            {
                //写入日志
                //throw;
                return false;
            }
        }
        #endregion

        #region -------- 私有方法 --------

        #region 由一行数据得到一个实体
        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private EmsModel.LearnYear GetEmsModel(DbDataReader dr)
        {
            EmsModel.LearnYear EmsModel = new EmsModel.LearnYear();
            DbDataReaderToModel(EmsModel, dr);

            return EmsModel;
        }
        #endregion

        #region 由DbDataReader得到泛型数据列表
        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<EmsModel.LearnYear> GetList(DbDataReader dr)
        {
            List<EmsModel.LearnYear> lst = new List<EmsModel.LearnYear>();
            while (dr.Read())
            {
                lst.Add(GetEmsModel(dr));
            }
            return lst;
        }
        #endregion

        #endregion
    }
}
