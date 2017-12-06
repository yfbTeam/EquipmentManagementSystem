using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace EmsDAL
{
    public partial class Student : DALHelper
    {
        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EmsModel.Student GetEmsModel(int? ID)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();
            sbSql4org.Append("SELECT * FROM Student");
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
        #region 获取列表的sql语句
        public string GetListSql()
        {
            StringBuilder sbSql4org = new StringBuilder();
            sbSql4org.Append("SELECT stu.*,cla.Name as ClassName  ");
            sbSql4org.Append(" FROM Student stu");
            sbSql4org.Append(" left join ClassInfo cla on stu.ClassId=cla.Id ");
            sbSql4org.Append(" where 1=1 ");
            return sbSql4org.ToString();
        }
        #endregion
        #region 获取泛型数据列表 分页
        ///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.Student> GetListByPageAndSear(EmsModel.Student EmsMod, int startIndex, int endIndex)
        {
            string sql = GetListSql();
            //条件
            string strWhere = "";
            //排序
            string orderby = "UseStatus,T.ID desc ";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();
            if (EmsMod.Name != null) { strWhere += " and stu.Name like '%'+@in_Name+'%' "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); } if (EmsMod.IDCard != null) { strWhere += " and stu.IDCard=@in_IDCard "; parmsList.Add(dbHelper.CreateInDbParameter("@in_IDCard", DbType.String, EmsMod.IDCard)); } if (EmsMod.ClassId != null) { strWhere += " and stu.ClassId=@in_ClassId "; parmsList.Add(dbHelper.CreateInDbParameter("@in_ClassId", DbType.String, EmsMod.ClassId)); } if (EmsMod.Sex != null) { strWhere += " and stu.Sex=@in_Sex "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Sex", DbType.String, EmsMod.Sex)); } if (EmsMod.Phone != null) { strWhere += " and stu.Phone=@in_Phone "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Phone", DbType.String, EmsMod.Phone)); } if (EmsMod.KaNo != null) { strWhere += " and stu.KaNo=@in_KaNo "; parmsList.Add(dbHelper.CreateInDbParameter("@in_KaNo", DbType.String, EmsMod.KaNo)); } if (EmsMod.Creator != null) { strWhere += " and stu.Creator=@in_Creator "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); } if (EmsMod.CreateTime != null) { strWhere += " and stu.CreateTime=@in_CreateTime "; parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); } if (EmsMod.Editor != null) { strWhere += " and stu.Editor=@in_Editor "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); } if (EmsMod.UpdateTime != null) { strWhere += " and stu.UpdateTime=@in_UpdateTime "; parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); } if (EmsMod.IsDelete != null) { strWhere += " and stu.IsDelete=@in_IsDelete "; parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); } if (EmsMod.UseStatus != null) { strWhere += " and stu.UseStatus=@in_UseStatus "; parmsList.Add(dbHelper.CreateInDbParameter("@in_UseStatus", DbType.String, EmsMod.UseStatus)); } if (EmsMod.Remarks != null) { strWhere += " and stu.Remarks=@in_Remarks "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); }
 
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds = GetListByPage(sql+strWhere, orderby, startIndex, endIndex, parms);          
            return GetListJoin(ds.Tables[0]);
        }
        #endregion

        #region 获取列表总数量
        public int GetListByPageCountAndSear(EmsModel.Student EmsMod)
        {
            string sql = GetListSql();
            string strWhere = "";

            List<DbParameter> parmsList = new List<DbParameter>();
            if (EmsMod.Name != null) { strWhere += " and stu.Name like '%'+@in_Name+'%' "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); } if (EmsMod.IDCard != null) { strWhere += " and stu.IDCard=@in_IDCard "; parmsList.Add(dbHelper.CreateInDbParameter("@in_IDCard", DbType.String, EmsMod.IDCard)); } if (EmsMod.ClassId != null) { strWhere += " and stu.ClassId=@in_ClassId "; parmsList.Add(dbHelper.CreateInDbParameter("@in_ClassId", DbType.String, EmsMod.ClassId)); } if (EmsMod.Sex != null) { strWhere += " and stu.Sex=@in_Sex "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Sex", DbType.String, EmsMod.Sex)); } if (EmsMod.Phone != null) { strWhere += " and stu.Phone=@in_Phone "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Phone", DbType.String, EmsMod.Phone)); } if (EmsMod.KaNo != null) { strWhere += " and stu.KaNo=@in_KaNo "; parmsList.Add(dbHelper.CreateInDbParameter("@in_KaNo", DbType.String, EmsMod.KaNo)); } if (EmsMod.Creator != null) { strWhere += " and stu.Creator=@in_Creator "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); } if (EmsMod.CreateTime != null) { strWhere += " and stu.CreateTime=@in_CreateTime "; parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); } if (EmsMod.Editor != null) { strWhere += " and stu.Editor=@in_Editor "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); } if (EmsMod.UpdateTime != null) { strWhere += " and stu.UpdateTime=@in_UpdateTime "; parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); } if (EmsMod.IsDelete != null) { strWhere += " and stu.IsDelete=@in_IsDelete "; parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); } if (EmsMod.UseStatus != null) { strWhere += " and stu.UseStatus=@in_UseStatus "; parmsList.Add(dbHelper.CreateInDbParameter("@in_UseStatus", DbType.String, EmsMod.UseStatus)); } if (EmsMod.Remarks != null) { strWhere += " and stu.Remarks=@in_Remarks "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); }

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(sql+strWhere, parms);
        }
        #endregion

        #region 判断学生名称是否已存在
        /// <summary>
        /// 判断学生名称是否已存在
        /// </summary>
        public bool IsNameExists(string name, Int32 Id)
        {
            try
            {
                StringBuilder sbSql;
                DbParameter[] parms;
                sbSql = new StringBuilder();
                sbSql.Append("SELECT COUNT(1) FROM Student");
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

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EmsModel.Student GetEmsModelByKaNo(string KaNo)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();
            sbSql4org.Append("SELECT * FROM Student");
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

        

        #region -------- 私有方法 --------
        #region 由DataTable得到泛型数据列表
        /// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        internal List<EmsModel.Student> GetListJoin(DataTable dt)
        {
            List<EmsModel.Student> lst = new List<EmsModel.Student>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.Student mod = new EmsModel.Student();
                DataRowToModelJoin(mod, dt.Rows[i]);
                lst.Add(mod);
            }

            return lst;
        }
        #endregion
        #region  由一行DataRow数据得到一个实体
        /// <summary>
        /// 由一行DataRow数据得到一个实体
        /// </summary>
        internal void DataRowToModelJoin(EmsModel.Student EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?; EmsModel.Name = dr["Name"] as string; EmsModel.IDCard = dr["IDCard"] as string; EmsModel.ClassId = dr["ClassId"] as int?; EmsModel.Sex = dr["Sex"] as string; EmsModel.Phone = dr["Phone"] as string; EmsModel.KaNo = dr["KaNo"] as string; EmsModel.Creator = dr["Creator"] as string; EmsModel.CreateTime = dr["CreateTime"] as DateTime?; EmsModel.Editor = dr["Editor"] as string; EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?; EmsModel.IsDelete = dr["IsDelete"] as Byte?; EmsModel.UseStatus = dr["UseStatus"] as Byte?; EmsModel.Remarks = dr["Remarks"] as string;
            EmsModel.ClassName = dr["ClassName"] as string; //额外添加的字段ClassName（班级名称）
            EmsModel.CreateName = dr["CreateName"] as string; //额外添加的字段CreateName（创建人姓名）            
        }
        #endregion

        #region 由一行数据得到一个实体
        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private EmsModel.Student GetEmsModel(DbDataReader dr)
        {
            EmsModel.Student EmsModel = new EmsModel.Student();
            DbDataReaderToModel(EmsModel, dr);

            return EmsModel;
        }
        #endregion

        #region 由DbDataReader得到泛型数据列表
        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<EmsModel.Student> GetList(DbDataReader dr)
        {
            List<EmsModel.Student> lst = new List<EmsModel.Student>();
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
