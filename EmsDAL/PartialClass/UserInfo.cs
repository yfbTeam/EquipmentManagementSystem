using EmsModel;
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
    public partial class UserInfo : DALHelper
    {
        #region 获取泛型数据列表 分页
        ///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.UserInfo> GetListByPageAndRoleid(EmsModel.UserInfo EmsMod, int startIndex, int endIndex, string roleid, string joinStr)
        {
            //表名
            string TableName = "UserInfo";
            //条件
            string strWhere = "";
            //排序
            string orderby = "UseStatus,T.ID desc ";
            //参数            
            List<DbParameter> parmsList = new List<DbParameter>();
            strWhere += " and LoginName!='admin' ";
            if (!string.IsNullOrEmpty(roleid))
            {
                strWhere += " and LoginName " + joinStr + " (select LoginName from RoleOfUser where RoleId=@RoleId) ";
                parmsList.Add(dbHelper.CreateInDbParameter("@RoleId", DbType.String, roleid));
            }
            if (EmsMod.LoginName != null) { strWhere += " and LoginName=@in_LoginName "; parmsList.Add(dbHelper.CreateInDbParameter("@in_LoginName", DbType.String, EmsMod.LoginName)); } if (EmsMod.Name != null) { strWhere += " and Name like '%'+@in_Name+'%' "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); } if (EmsMod.PassWord != null) { strWhere += " and PassWord=@in_PassWord "; parmsList.Add(dbHelper.CreateInDbParameter("@in_PassWord", DbType.String, EmsMod.PassWord)); } if (EmsMod.Creator != null) { strWhere += " and Creator=@in_Creator "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); } if (EmsMod.CreateTime != null) { strWhere += " and CreateTime=@in_CreateTime "; parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); } if (EmsMod.Editor != null) { strWhere += " and Editor=@in_Editor "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); } if (EmsMod.UpdateTime != null) { strWhere += " and UpdateTime=@in_UpdateTime "; parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); } if (EmsMod.IsDelete != null) { strWhere += " and IsDelete=@in_IsDelete "; parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }


            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds = GetListByPage(TableName, strWhere, orderby, startIndex, endIndex, parms);
            List<EmsModel.UserInfo> list = GetList(ds.Tables[0]);
            return list;
        }
        #endregion
        
        #region 获取列表总数量
        public int GetListByPageCountAndRoleid(EmsModel.UserInfo EmsMod, string roleid, string joinStr)
        {
            string TableName = "UserInfo";
            string strWhere = "";

            List<DbParameter> parmsList = new List<DbParameter>();
            if (!string.IsNullOrEmpty(roleid))
            {
                strWhere += " and LoginName " + joinStr + " (select LoginName from RoleOfUser where RoleId=@RoleId) ";
                parmsList.Add(dbHelper.CreateInDbParameter("@RoleId", DbType.String, roleid));
            }
            if (EmsMod.LoginName != null) { strWhere += " and LoginName=@in_LoginName "; parmsList.Add(dbHelper.CreateInDbParameter("@in_LoginName", DbType.String, EmsMod.LoginName)); } if (EmsMod.Name != null) { strWhere += " and Name like '%'+@in_Name+'%' "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); } if (EmsMod.PassWord != null) { strWhere += " and PassWord=@in_PassWord "; parmsList.Add(dbHelper.CreateInDbParameter("@in_PassWord", DbType.String, EmsMod.PassWord)); } if (EmsMod.Creator != null) { strWhere += " and Creator=@in_Creator "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); } if (EmsMod.CreateTime != null) { strWhere += " and CreateTime=@in_CreateTime "; parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); } if (EmsMod.Editor != null) { strWhere += " and Editor=@in_Editor "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); } if (EmsMod.UpdateTime != null) { strWhere += " and UpdateTime=@in_UpdateTime "; parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); } if (EmsMod.IsDelete != null) { strWhere += " and IsDelete=@in_IsDelete "; parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); }

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(TableName, strWhere, parms);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EmsModel.UserInfo GetEmsModel(int? ID)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();
            sbSql4org.Append("SELECT * FROM UserInfo");
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
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EmsModel.UserInfo GetEmsModelByKaNo(string KaNo)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();
            sbSql4org.Append("SELECT * FROM UserInfo");
            sbSql4org.Append(" WHERE KaNo=@in_KaNo");

            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@in_KaNo", DbType.String,KaNo)};
            using (DbDataReader dr = dbHelper.ExecuteReader(CommandType.Text, sbSql4org.ToString(), parms4org))
            {
                if (dr.Read())
                {
                    return GetEmsModel(dr);
                }
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EmsModel.UserInfo GetEmsModel(Hashtable ht)
        {
            List<DbParameter> list = new List<DbParameter>();
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("SELECT * FROM UserInfo");
            sbSql.Append(" where 1=1 ");
            if (ht.Contains("IDCard"))
            {
                sbSql.Append(" and IDCard=@IDCard ");
                list.Add(dbHelper.CreateInDbParameter("@IDCard", DbType.String, ht["IDCard"].ToString()));
            }
            DbParameter[] parms = list.ToArray();
            using (DbDataReader dr = dbHelper.ExecuteReader(CommandType.Text, sbSql.ToString(), parms))
            {
                List<EmsModel.UserInfo> item = GetList(dr);
                dr.Close();
                if (item != null && item.Count > 0)
                {
                    return item[0];
                }
                return null;
            }
        }
        #endregion

        #region 获取泛型数据列表
        /// <summary>
        /// 获取泛型数据列表
        /// </summary>
        public List<EmsModel.UserInfo> GetList(EmsModel.UserInfo user)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;

            sbSql4org = new StringBuilder();
            sbSql4org.Append("SELECT * FROM UserInfo where IsDelete=0 ");
            if (!string.IsNullOrEmpty(user.Name))
            {
                sbSql4org.Append(" and Name like '%'+@Name+'%'");
            }
            sbSql4org.Append(" order by CreateTime desc");
            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@Name", DbType.String,user.Name)};

            using (DbDataReader dr = dbHelper.ExecuteReader(CommandType.Text, sbSql4org.ToString(), parms4org))
            {
                List<EmsModel.UserInfo> lst = GetList(dr);
                return lst;
            }

        }
        #endregion       

        #region 判断登录名是否已存在
        /// <summary>
        /// 判断登录名是否已存在
        /// </summary>
        public bool IsNameExists(string name, Int32 Id)
        {
            try
            {
                StringBuilder sbSql;
                DbParameter[] parms;
                sbSql = new StringBuilder();
                sbSql.Append("SELECT COUNT(1) FROM UserInfo");
                sbSql.Append(" where IsDelete=0 and LoginName=@LoginName ");
                if (Id != 0)
                {
                    sbSql.Append(" and Id!=@Id ");
                }
                parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@LoginName", DbType.String,name),
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

        #region 判断登录
        /// <summary>
        /// 判断登录
        /// </summary>
        public EmsModel.UserInfo IsLogin(string LoginName, string PassWord)
        {
            EmsModel.UserInfo user = null;
            try
            {               
                StringBuilder sbSql;
                DbParameter[] parms;
                sbSql = new StringBuilder();
                sbSql.Append("SELECT Id FROM UserInfo");
                sbSql.Append(" where IsDelete=0 and LoginName=@LoginName and PassWord=@PassWord ");
                
                parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@LoginName", DbType.String,LoginName),
                            dbHelper.CreateInDbParameter("@PassWord",DbType.String,PassWord)
							};
                int obj = int.Parse(dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms).ToString());
                if (obj> 0)
                {
                    user = GetEmsModel(obj);
                }
                return user;
            }
            catch (Exception ex)
            {
                //写入日志
                //throw;
                return user;
            }
        }
        #endregion
        
        #region -------- 私有方法 --------

        #region 由一行数据得到一个实体
        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private EmsModel.UserInfo GetEmsModel(DbDataReader dr)
        {
            EmsModel.UserInfo EmsModel = new EmsModel.UserInfo();
            DbDataReaderToModel(EmsModel, dr);

            return EmsModel;
        }
        #endregion

        #region 由DbDataReader得到泛型数据列表
        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<EmsModel.UserInfo> GetList(DbDataReader dr)
        {
            List<EmsModel.UserInfo> lst = new List<EmsModel.UserInfo>();
            while (dr.Read())
            {
                lst.Add(GetEmsModel(dr));
            }
            return lst;
        }
        #endregion

        #endregion

        #region 判断是否已存在
        /// <summary>
        /// 判断是否已存在
        /// </summary>
        public bool IsExists(Hashtable ht)
        {
            try
            {
                List<DbParameter> list = new List<DbParameter>();
                StringBuilder sbSql = new StringBuilder();
                sbSql.Append("SELECT COUNT(1) FROM UserInfo");
                sbSql.Append(" where 1=1 ");
                if (ht.Contains("IDCard"))
                {
                    sbSql.Append(" and IDCard=@IDCard ");
                    list.Add(dbHelper.CreateInDbParameter("@IDCard", DbType.String, ht["IDCard"].ToString()));
                }
                object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), list.ToArray());
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
    }
}
