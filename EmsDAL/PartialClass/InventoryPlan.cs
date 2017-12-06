﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace EmsDAL
{
    public partial class InventoryPlan : DALHelper
    {
        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EmsModel.InventoryPlan GetEmsModel(int? ID)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();
            sbSql4org.Append("SELECT * FROM InventoryPlan");
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
        public List<EmsModel.InventoryPlan> GetListByPageAndSear(EmsModel.InventoryPlan EmsMod, int startIndex, int endIndex)
        {
            //表名
            string TableName = "InventoryPlan";
            //条件
            string strWhere = "";
            //排序
            string orderby = "";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();
            if (EmsMod.Name != null) { strWhere += " and Name like '%'+@in_Name+'%' "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); } if (EmsMod.InventoryNo != null) { strWhere += " and InventoryNo=@in_InventoryNo "; parmsList.Add(dbHelper.CreateInDbParameter("@in_InventoryNo", DbType.String, EmsMod.InventoryNo)); } if (EmsMod.InventoryTime != null) { strWhere += " and InventoryTime=@in_InventoryTime "; parmsList.Add(dbHelper.CreateInDbParameter("@in_InventoryTime", DbType.String, EmsMod.InventoryTime)); } if (EmsMod.Type != null) { strWhere += " and Type=@in_Type "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Type", DbType.String, EmsMod.Type)); } if (EmsMod.Status != null) { strWhere += " and Status=@in_Status "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Status", DbType.String, EmsMod.Status)); } if (EmsMod.Creator != null) { strWhere += " and Creator=@in_Creator "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); } if (EmsMod.CreateTime != null) { strWhere += " and CreateTime=@in_CreateTime "; parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); } if (EmsMod.Editor != null) { strWhere += " and Editor=@in_Editor "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); } if (EmsMod.UpdateTime != null) { strWhere += " and UpdateTime=@in_UpdateTime "; parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); } if (EmsMod.IsDelete != null) { strWhere += " and IsDelete=@in_IsDelete "; parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); } if (EmsMod.IsGenerate != null) { strWhere += " and IsGenerate=@in_IsGenerate "; parmsList.Add(dbHelper.CreateInDbParameter("@in_IsGenerate", DbType.String, EmsMod.IsGenerate)); }

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds = GetListByPage(TableName, strWhere, orderby, startIndex, endIndex, parms);
            List<EmsModel.InventoryPlan> list = GetList(ds.Tables[0]);
            return list;
        }
        #endregion

        #region 获取列表总数量
        public int GetListByPageCountAndSear(EmsModel.InventoryPlan EmsMod)
        {
            string TableName = "InventoryPlan";
            string strWhere = "";

            List<DbParameter> parmsList = new List<DbParameter>();
            if (EmsMod.Name != null) { strWhere += " and Name like '%'+@in_Name+'%' "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); } if (EmsMod.InventoryNo != null) { strWhere += " and InventoryNo=@in_InventoryNo "; parmsList.Add(dbHelper.CreateInDbParameter("@in_InventoryNo", DbType.String, EmsMod.InventoryNo)); } if (EmsMod.InventoryTime != null) { strWhere += " and InventoryTime=@in_InventoryTime "; parmsList.Add(dbHelper.CreateInDbParameter("@in_InventoryTime", DbType.String, EmsMod.InventoryTime)); } if (EmsMod.Type != null) { strWhere += " and Type=@in_Type "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Type", DbType.String, EmsMod.Type)); } if (EmsMod.Status != null) { strWhere += " and Status=@in_Status "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Status", DbType.String, EmsMod.Status)); } if (EmsMod.Creator != null) { strWhere += " and Creator=@in_Creator "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); } if (EmsMod.CreateTime != null) { strWhere += " and CreateTime=@in_CreateTime "; parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); } if (EmsMod.Editor != null) { strWhere += " and Editor=@in_Editor "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); } if (EmsMod.UpdateTime != null) { strWhere += " and UpdateTime=@in_UpdateTime "; parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); } if (EmsMod.IsDelete != null) { strWhere += " and IsDelete=@in_IsDelete "; parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); } if (EmsMod.IsGenerate != null) { strWhere += " and IsGenerate=@in_IsGenerate "; parmsList.Add(dbHelper.CreateInDbParameter("@in_IsGenerate", DbType.String, EmsMod.IsGenerate)); }

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
        #endregion

        #region 判断盘点计划名称是否已存在
        /// <summary>
        /// 判断盘点计划名称是否已存在
        /// </summary>
        public bool IsNameExists(string name, Int32 Id)
        {
            try
            {
                StringBuilder sbSql;
                DbParameter[] parms;
                sbSql = new StringBuilder();
                sbSql.Append("SELECT COUNT(1) FROM InventoryPlan");
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
        private EmsModel.InventoryPlan GetEmsModel(DbDataReader dr)
        {
            EmsModel.InventoryPlan EmsModel = new EmsModel.InventoryPlan();
            DbDataReaderToModel(EmsModel, dr);

            return EmsModel;
        }
        #endregion

        #region 由DbDataReader得到泛型数据列表
        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<EmsModel.InventoryPlan> GetList(DbDataReader dr)
        {
            List<EmsModel.InventoryPlan> lst = new List<EmsModel.InventoryPlan>();
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
