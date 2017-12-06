using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace EmsDAL
{
    public partial class Role : DALHelper
    {
        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EmsModel.Role GetEmsModel(int? ID)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();
            sbSql4org.Append("SELECT * FROM Role");
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
        public List<EmsModel.Role> GetList(EmsModel.Role role)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;

            sbSql4org = new StringBuilder();
            sbSql4org.Append("SELECT * FROM Role where IsDelete=0 ");
            if (!string.IsNullOrEmpty(role.Name))
            {
                sbSql4org.Append(" and Name like '%'+@Name+'%'");
            }
            sbSql4org.Append(" order by CreateTime desc");
            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@Name", DbType.String,role.Name)};
           
            using (DbDataReader dr = dbHelper.ExecuteReader(CommandType.Text, sbSql4org.ToString(), parms4org))
            {
                List<EmsModel.Role> lst = GetList(dr);
                return lst;
            }

        }
        #endregion

        #region 判断角色名称是否已存在
        /// <summary>
        /// 判断角色名称是否已存在
        /// </summary>
        public bool IsNameExists(string name,Int32 Id)
        {
            try
            {
                StringBuilder sbSql;
                DbParameter[] parms;
                sbSql = new StringBuilder();
                sbSql.Append("SELECT COUNT(1) FROM Role");
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

        #region 获取全部角色，返回List
        /// <summary>
        /// 获取全部角色，返回List
        /// </summary>
        public List<EmsModel.Role> GetAllRoleList()
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;

            sbSql4org = new StringBuilder();
            sbSql4org.Append("SELECT * FROM Role where IsDelete=0 ");
            sbSql4org.Append(" order by Id desc");
            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("1", DbType.Int32, 1)};

            using (DbDataReader dr = dbHelper.ExecuteReader(CommandType.Text, sbSql4org.ToString(), parms4org))
            {
                List<EmsModel.Role> lst = GetList(dr);
                return lst;
            }
        }
        #endregion

        #region 根据唯一号获得所属角色
        /// <summary>
        /// 根据唯一号获得所属角色
        /// </summary>  
        public DataTable GetRoleByUniqueNo(string uniqueNo)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;

            sbSql4org = new StringBuilder();
            sbSql4org.Append(@"select distinct ru.RoleId,r.Name from RoleOfUser ru  
		                            left join Role r on r.Id=ru.RoleId
		                            where ru.LoginName=@UniqueNo ");
            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@UniqueNo", DbType.String, uniqueNo)};
            return dbHelper.ExecuteQuery(CommandType.Text, sbSql4org.ToString(), parms4org).Tables[0];
        }
        #endregion

        #region -------- 私有方法 --------

        #region 由一行数据得到一个实体
        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private EmsModel.Role GetEmsModel(DbDataReader dr)
        {
            EmsModel.Role EmsModel = new EmsModel.Role();
            DbDataReaderToModel(EmsModel, dr);

            return EmsModel;
        }
        #endregion

        #region 由DbDataReader得到泛型数据列表
        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<EmsModel.Role> GetList(DbDataReader dr)
        {
            List<EmsModel.Role> lst = new List<EmsModel.Role>();
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
