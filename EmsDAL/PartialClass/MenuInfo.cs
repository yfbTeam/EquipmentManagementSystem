using DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace EmsDAL
{
    public partial class MenuInfo : DALHelper
    {
        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EmsModel.MenuInfo GetEmsModel(int? ID)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();
            sbSql4org.Append("SELECT * FROM MenuInfo");
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

        #region 获得首页左侧导航处菜单信息
        /// <summary>
        /// 获得首页左侧导航处菜单信息
        /// </summary>  
        public DataTable GetLeftNavigationMenu(string loginUID,string adminUID)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;

            sbSql4org = new StringBuilder();
            if (loginUID == adminUID)
            {
                sbSql4org.Append(@"select distinct mi.* from MenuInfo mi
                                where mi.Id is not null and mi.isMeu=1 and mi.isShow=3 ");
            }
            else
            {
                sbSql4org.Append(@"select distinct mi.* from RoleOfUser ru
                                left join RoleOfMenu rm on ru.RoleId=rm.RoleId
                                left join MenuInfo mi on mi.Id=rm.MenuId 
                                where mi.Id is not null and mi.isMeu=1 and mi.isShow=3 and ru.LoginName=@loginUID ");
            }
            
            sbSql4org.Append(" order by mi.Id ");
            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@loginUID", DbType.String, loginUID)};
            return dbHelper.ExecuteQuery(CommandType.Text, sbSql4org.ToString(), parms4org).Tables[0];
        }
        #endregion

        #region 获得权限设置处菜单信息
        /// <summary>
        /// 获得权限设置处菜单信息
        /// </summary>  
        public DataTable GetPermissionMenu(string roleid)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;

            sbSql4org = new StringBuilder();            
            sbSql4org.Append(@"select mi.*,ISNULL(rm.MenuId,0) as ischeck from MenuInfo mi
                               left join RoleOfMenu rm on mi.Id=rm.MenuId and rm.RoleId=@RoleId ");
            sbSql4org.Append(" order by mi.Id ");
            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@RoleId", DbType.Int32, roleid)};
            return dbHelper.ExecuteQuery(CommandType.Text, sbSql4org.ToString(), parms4org).Tables[0];            
        }
        #endregion

        #region 根据登录名获得所属库房
        /// <summary>
        /// 根据登录名获得所属库房
        /// </summary>  
        public DataTable GetWarehouseByLoginName(string loginname)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;

            sbSql4org = new StringBuilder();
            sbSql4org.Append(@"select distinct w.Id,mi.Name from RoleOfUser ru
                                left join RoleOfMenu rm on ru.RoleId=rm.RoleId
                                left join MenuInfo mi on mi.Id=rm.MenuId 
                                left join Warehouse w on w.Name=mi.Name
                                where mi.Id is not null and mi.isMeu=0 and mi.isShow=0 and ru.LoginName=@LoginName ");
            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@LoginName", DbType.String, loginname)};
            return dbHelper.ExecuteQuery(CommandType.Text, sbSql4org.ToString(), parms4org).Tables[0];
        }
        #endregion

        #region 根据菜单名称获取对象实体
        /// <summary>
        /// 根据菜单名称获取对象实体
        /// </summary>
        public EmsModel.MenuInfo GetEmsModelByName(string name)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();
            sbSql4org.Append("SELECT * FROM MenuInfo");
            sbSql4org.Append(" WHERE Name=@Name");

            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@Name", DbType.String,name)};
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
        

        #region -------- 私有方法 --------

        #region 由一行数据得到一个实体
        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private EmsModel.MenuInfo GetEmsModel(DbDataReader dr)
        {
            EmsModel.MenuInfo EmsModel = new EmsModel.MenuInfo();
            DbDataReaderToModel(EmsModel, dr);

            return EmsModel;
        }
        #endregion

        #region 由DbDataReader得到泛型数据列表
        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<EmsModel.MenuInfo> GetList(DbDataReader dr)
        {
            List<EmsModel.MenuInfo> lst = new List<EmsModel.MenuInfo>();
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
