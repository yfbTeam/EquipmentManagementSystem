using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EmsDAL
{
    public partial class Warehouse : DALHelper
    {
        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EmsModel.Warehouse GetEmsModel(int? ID)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();
            sbSql4org.Append("SELECT * FROM Warehouse");
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

        #region 获取泛型数据列表
        /// <summary>
        /// 获取泛型数据列表
        /// </summary>
        public List<EmsModel.Warehouse> GetList(EmsModel.Warehouse ware)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
           
            sbSql4org = new StringBuilder();
            sbSql4org.Append("SELECT * FROM Warehouse where IsDelete=0 ");
            if (!string.IsNullOrEmpty(ware.Name))
            {
                sbSql4org.Append(" and Name like '%'+@Name+'%'");
            }
            sbSql4org.Append(" order by CreateTime desc");
            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@Name", DbType.String,ware.Name)};

            using (DbDataReader dr = dbHelper.ExecuteReader(CommandType.Text, sbSql4org.ToString(), parms4org))
            {
                List<EmsModel.Warehouse> lst = GetList(dr);
                return lst;
            }

        }
        #endregion

        #region 获取泛型数据列表 分页
        ///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.Warehouse> GetListByPageAndSear(EmsModel.Warehouse EmsMod, int startIndex, int endIndex)
        {
            //表名
            string TableName = "Warehouse";
            //条件
            string strWhere = "";
            //排序
            string orderby = "UseStatus,T.ID desc ";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();

            if (EmsMod.Name != null) { strWhere +=" and Name like '%'+@in_Name+'%' "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); } if (EmsMod.Remarks != null) { strWhere += " and Remarks=@in_Remarks "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); } if (EmsMod.PlaneGraph != null) { strWhere += " and PlaneGraph=@in_PlaneGraph "; parmsList.Add(dbHelper.CreateInDbParameter("@in_PlaneGraph", DbType.String, EmsMod.PlaneGraph)); } if (EmsMod.Creator != null) { strWhere += " and Creator=@in_Creator "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); } if (EmsMod.CreateTime != null) { strWhere += " and CreateTime=@in_CreateTime "; parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); } if (EmsMod.Editor != null) { strWhere += " and Editor=@in_Editor "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); } if (EmsMod.UpdateTime != null) { strWhere += " and UpdateTime=@in_UpdateTime "; parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); } if (EmsMod.IsDelete != null) { strWhere += " and IsDelete=@in_IsDelete "; parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }


            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds = GetListByPage(TableName, strWhere, orderby, startIndex, endIndex, parms);
            List<EmsModel.Warehouse> list = GetList(ds.Tables[0]);
            return list;
        }
        #endregion

        #region 获取列表总数量
        public int GetListByPageCountAndSear(EmsModel.Warehouse EmsMod)
        {
            string TableName = "Warehouse";
            string strWhere = "";

            List<DbParameter> parmsList = new List<DbParameter>();
            if (EmsMod.Name != null) { strWhere += " and Name like '%'+@in_Name+'%' "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); } if (EmsMod.Remarks != null) { strWhere += " and Remarks=@in_Remarks "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); } if (EmsMod.PlaneGraph != null) { strWhere += " and PlaneGraph=@in_PlaneGraph "; parmsList.Add(dbHelper.CreateInDbParameter("@in_PlaneGraph", DbType.String, EmsMod.PlaneGraph)); } if (EmsMod.Creator != null) { strWhere += " and Creator=@in_Creator "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); } if (EmsMod.CreateTime != null) { strWhere += " and CreateTime=@in_CreateTime "; parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); } if (EmsMod.Editor != null) { strWhere += " and Editor=@in_Editor "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); } if (EmsMod.UpdateTime != null) { strWhere += " and UpdateTime=@in_UpdateTime "; parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); } if (EmsMod.IsDelete != null) { strWhere += " and IsDelete=@in_IsDelete "; parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);        
        }
        #endregion

        #region 判断库房名称是否已存在
        /// <summary>
        /// 判断库房名称是否已存在
        /// </summary>
        public bool IsNameExists(string name, Int32 Id)
        {
            try
            {
                StringBuilder sbSql;
                DbParameter[] parms;
                sbSql = new StringBuilder();
                sbSql.Append("SELECT COUNT(1) FROM Warehouse");
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

        #region 获得事物对象
        /// <summary>
        /// 获得事物对象
        /// </summary>
        /// <returns></returns>
        public SqlTransaction GetTran()
        {
            return dbHelper.BeginTransaction();
        }
        #endregion

        #region -------- 私有方法 --------

        #region 由一行数据得到一个实体
        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private EmsModel.Warehouse GetEmsModel(DbDataReader dr)
        {
            EmsModel.Warehouse EmsModel = new EmsModel.Warehouse();
            DbDataReaderToModel(EmsModel, dr);

            return EmsModel;
        }
        #endregion

        #region 由DbDataReader得到泛型数据列表
        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<EmsModel.Warehouse> GetList(DbDataReader dr)
        {
            List<EmsModel.Warehouse> lst = new List<EmsModel.Warehouse>();
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
