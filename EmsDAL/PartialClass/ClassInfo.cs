using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace EmsDAL
{
    public partial class ClassInfo : DALHelper
    {

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EmsModel.ClassInfo GetEmsModel(int? ID)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();
            sbSql4org.Append("SELECT * FROM ClassInfo");
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

        #region 获取泛型数据列表 分页
        ///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.ClassInfo> GetListByPageAndSear(EmsModel.ClassInfo EmsMod, int startIndex, int endIndex)
        {
            //表名
            string TableName = "ClassInfo";
            //条件
            string strWhere = "";
            //排序
            string orderby = "UseStatus,T.ID desc ";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();
            if (EmsMod.Name != null) { strWhere += " and Name like '%'+@in_Name+'%' "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); } if (EmsMod.Creator != null) { strWhere += " and Creator=@in_Creator "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); } if (EmsMod.CreateTime != null) { strWhere += " and CreateTime=@in_CreateTime "; parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); } if (EmsMod.Editor != null) { strWhere += " and Editor=@in_Editor "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); } if (EmsMod.UpdateTime != null) { strWhere += " and UpdateTime=@in_UpdateTime "; parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); } if (EmsMod.Remarks != null) { strWhere += " and Remarks=@in_Remarks "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); }

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds = GetListByPage(TableName, strWhere, orderby, startIndex, endIndex, parms);
            List<EmsModel.ClassInfo> list = GetList(ds.Tables[0]);
            return list;
        }
        #endregion

        #region 获取列表总数量
        public int GetListByPageCountAndSear(EmsModel.ClassInfo EmsMod)
        {
            string TableName = "ClassInfo";
            string strWhere = "";

            List<DbParameter> parmsList = new List<DbParameter>();
            if (EmsMod.Name != null) { strWhere += " and Name like '%'+@in_Name+'%' "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); } if (EmsMod.Creator != null) { strWhere += " and Creator=@in_Creator "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); } if (EmsMod.CreateTime != null) { strWhere += " and CreateTime=@in_CreateTime "; parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); } if (EmsMod.Editor != null) { strWhere += " and Editor=@in_Editor "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); } if (EmsMod.UpdateTime != null) { strWhere += " and UpdateTime=@in_UpdateTime "; parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); } if (EmsMod.Remarks != null) { strWhere += " and Remarks=@in_Remarks "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); }

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
        #endregion

        #region 判断班级名称是否已存在
        /// <summary>
        /// 判断班级名称是否已存在
        /// </summary>
        public bool IsNameExists(string name, Int32 Id)
        {
            try
            {
                StringBuilder sbSql;
                DbParameter[] parms;
                sbSql = new StringBuilder();
                sbSql.Append("SELECT COUNT(1) FROM ClassInfo");
                sbSql.Append(" where Name=@Name ");
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
        private EmsModel.ClassInfo GetEmsModel(DbDataReader dr)
        {
            EmsModel.ClassInfo EmsModel = new EmsModel.ClassInfo();
            DbDataReaderToModel(EmsModel, dr);

            return EmsModel;
        }
        #endregion

        #region 由DbDataReader得到泛型数据列表
        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<EmsModel.ClassInfo> GetList(DbDataReader dr)
        {
            List<EmsModel.ClassInfo> lst = new List<EmsModel.ClassInfo>();
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
