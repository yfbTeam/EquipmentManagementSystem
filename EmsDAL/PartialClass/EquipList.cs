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
    /// <summary>
    /// 实验设备表
    /// </summary>
    public partial class EquipList : DALHelper
    {
        /// <summary>
        /// 查询根据Id
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>Model的List集合</returns>
        public List<EmsModel.EquipList> GetData(Hashtable ht)
        {
            try
            {
                ht = Dispose(ht);

                DataSet ds = dbHelper.ExecuteQuery(CommandType.Text, ht["sql"].ToString(), (DbParameter[])(ht["DbParameter"]));
                return GetList(ds.Tables[0]);
            }
            catch (Exception)
            {
                //写入日志
                throw;
            }
        }
        /// <summary>
        /// 查询根据Id
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>Model的List集合</returns>
        public List<EmsModel.View_EquipListDetail> GetData2(Hashtable ht)
        {
            try
            {
                ht = Dispose2(ht);

                DataSet ds = dbHelper.ExecuteQuery(CommandType.Text, ht["sql"].ToString(), (DbParameter[])(ht["DbParameter"]));
                return GetList2(ds.Tables[0]);
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
        public List<EmsModel.View_EquipListDetail> GetList(Hashtable ht)
        {
            try
            {
                ht = Dispose2(ht);

                DataSet ds = base.GetListByPage("(" + ht["sql"].ToString() + ")", "", "", Convert.ToInt32(ht["StartIndex"].ToString()), Convert.ToInt32(ht["EndIndex"].ToString()), (DbParameter[])(ht["DbParameter"]));
                return GetList2(ds.Tables[0]);

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

                ht = Dispose2(ht);
                return base.GetRecordCount("(" + ht["sql"].ToString() + ") T", "", (DbParameter[])(ht["DbParameter"]));
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 获得实验设备详情状态列表
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>Model的List集合</returns>
        public DataTable GetExperimentEquipList(Hashtable ht)
        {
            try
            {
                StringBuilder sbSql4org;

                sbSql4org = new StringBuilder();
                sbSql4org.Append(" select a.*,ISNULL(b.OrderNo,'未生成订单') as OrderNo,ISNULL(b.[Status],'0') as [Status],c.Number,c.Name,c.Model,c.Unit,d.Name as WarehouseName from EquipList a ");
                sbSql4org.Append(" left join OrderInfo b on a.RelationID=b.ExperimentId ");
                sbSql4org.Append(" left join InstrumentEquip c on a.EquipKindId=c.Id ");
                sbSql4org.Append(" left join Warehouse d on c.WarehouseId = d.Id ");
                sbSql4org.Append(" where 1=1 ");
                List<DbParameter> List = new List<DbParameter>();
                if (ht.ContainsKey("Id"))
                {
                    sbSql4org.Append(" and a.Id=@Id ");
                    List.Add(dbHelper.CreateInDbParameter("@Id", DbType.Int32, Convert.ToInt32(ht["Id"].ToString())));
                }
                if (ht.ContainsKey("RelationID"))
                {
                    sbSql4org.Append(" and a.RelationID=@RelationID ");
                    List.Add(dbHelper.CreateInDbParameter("@RelationID", DbType.Int32, Convert.ToInt32(ht["RelationID"].ToString())));
                }
                if (ht.ContainsKey("sql"))
                {
                    ht.Remove("sql");
                }
                ht.Add("sql", sbSql4org.ToString());
                if (ht.ContainsKey("DbParameter"))
                {
                    ht.Remove("DbParameter");
                }
                ht.Add("DbParameter", List.ToArray());

                DataSet ds = dbHelper.ExecuteQuery(CommandType.Text, ht["sql"].ToString(), (DbParameter[])(ht["DbParameter"]));
                return ds.Tables[0];
            }
            catch (Exception)
            {
                //写入日志
                throw;
            }
        }
        #region 快速模板实验设备列表
        
        /// <summary>
        /// 快速模板实验设备列表
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>Model的List集合</returns>
        public DataTable GetPageTempSelect(Hashtable ht)
        {
            try
            {
                ht = DisposeTempSelect(ht);
                DataSet ds = base.GetListByPage("(" + ht["sql"].ToString() + ")", "", "", Convert.ToInt32(ht["StartIndex"].ToString()), Convert.ToInt32(ht["EndIndex"].ToString()), (DbParameter[])(ht["DbParameter"]));
                return ds.Tables[0];
            }
            catch (Exception)
            {
                //写入日志
                throw;
            }
        }
        /// <summary>
        /// 获得总条数
        /// </summary>
        /// <param name="ht">查询条件</param>
        /// <returns>总条数</returns>
        public int GetListByPageCountTempSelect(Hashtable ht)
        {
            try
            {

                ht = DisposeTempSelect(ht);
                return base.GetRecordCount("(" + ht["sql"].ToString() + ") T", "", (DbParameter[])(ht["DbParameter"]));
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 处理数据
        /// </summary>
        /// <param name="ht"></param>
        /// <returns>参数值</returns>
        private Hashtable DisposeTempSelect(Hashtable ht)
        {
            try
            {
                StringBuilder sbSql4org;

                sbSql4org = new StringBuilder();
                sbSql4org.Append(" select a.*,b.Number,b.Name,b.Model,b.Unit from EquipList a ");
                sbSql4org.Append(" left join InstrumentEquip b on a.EquipKindId=b.Id ");
                sbSql4org.Append(" where 1=1 ");
                List<DbParameter> List = new List<DbParameter>();
                if (ht.ContainsKey("Id"))
                {
                    sbSql4org.Append(" and a.Id=@Id ");
                    List.Add(dbHelper.CreateInDbParameter("@Id", DbType.Int32, Convert.ToInt32(ht["Id"].ToString())));
                }
                if (ht.ContainsKey("RelationID"))
                {
                    sbSql4org.Append(" and a.RelationID=@RelationID ");
                    List.Add(dbHelper.CreateInDbParameter("@RelationID", DbType.Int32, Convert.ToInt32(ht["RelationID"].ToString())));
                }
                if (ht.ContainsKey("sql"))
                {
                    ht.Remove("sql");
                }
                ht.Add("sql", sbSql4org.ToString());
                if (ht.ContainsKey("DbParameter"))
                {
                    ht.Remove("DbParameter");
                }
                ht.Add("DbParameter", List.ToArray());

            }
            catch (Exception)
            {
                //写入日志
                throw;
            }
            return ht;
        }

        #endregion
        /// <summary>
        /// 处理数据
        /// </summary>
        /// <param name="ht"></param>
        /// <returns>参数值</returns>
        private Hashtable Dispose(Hashtable ht)
        {
            try
            {
                StringBuilder sbSql4org;

                sbSql4org = new StringBuilder();
                sbSql4org.Append("SELECT * FROM EquipList ");
                sbSql4org.Append(" where 1=1 ");
                List<DbParameter> List =new List<DbParameter> ();
                if (ht.ContainsKey("Id"))
                {
                    sbSql4org.Append(" and Id=@Id ");
                    List.Add(dbHelper.CreateInDbParameter("@Id", DbType.Int32, Convert.ToInt32(ht["Id"].ToString())));
                }
                if (ht.ContainsKey("RelationID"))
                {
                    sbSql4org.Append(" and RelationID=@RelationID ");
                    List.Add(dbHelper.CreateInDbParameter("@RelationID", DbType.Int32, Convert.ToInt32(ht["RelationID"].ToString())));
                }
                if (ht.ContainsKey("sql"))
                {
                    ht.Remove("sql");
                }
                ht.Add("sql",sbSql4org.ToString());
                if (ht.ContainsKey("DbParameter"))
                {
                    ht.Remove("DbParameter");
                }
                ht.Add("DbParameter",List.ToArray());
                
            }
            catch (Exception)
            {
                //写入日志
                throw;
            }
            return ht;
        }
        /// <summary>
        /// 处理数据
        /// </summary>
        /// <param name="ht"></param>
        /// <returns>参数值</returns>
        private Hashtable Dispose2(Hashtable ht)
        {
            try
            {
                StringBuilder sbSql4org;

                sbSql4org = new StringBuilder();
                sbSql4org.Append("SELECT * FROM View_EquipListDetail ");
                sbSql4org.Append(" where 1=1 ");
                List<DbParameter> List = new List<DbParameter>();
                if (ht.ContainsKey("Id"))
                {
                    sbSql4org.Append(" and ELId=@Id ");
                    List.Add(dbHelper.CreateInDbParameter("@Id", DbType.String, Convert.ToInt32(ht["Id"].ToString())));
                }
                if (ht.ContainsKey("RelationID"))
                {
                    sbSql4org.Append(" and RelationID=@RelationID ");
                    List.Add(dbHelper.CreateInDbParameter("@RelationID", DbType.String, Convert.ToInt32(ht["RelationID"].ToString())));
                }

                if (ht.ContainsKey("sql"))
                {
                    ht.Remove("sql");
                }
                ht.Add("sql", sbSql4org.ToString());
                if (ht.ContainsKey("DbParameter"))
                {
                    ht.Remove("DbParameter");
                }
                ht.Add("DbParameter", List.ToArray());

            }
            catch (Exception)
            {
                //写入日志
                throw;
            }
            return ht;
        }
        /// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        internal List<EmsModel.View_EquipListDetail> GetList2(DataTable dt)
        {
            List<EmsModel.View_EquipListDetail> lst = new List<EmsModel.View_EquipListDetail>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.View_EquipListDetail mod = new EmsModel.View_EquipListDetail();
                DataRowToModel2(mod, dt.Rows[i]);
                lst.Add(mod);
            }

            return lst;
        }

        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        internal void DataRowToModel2(EmsModel.View_EquipListDetail EmsModel, DataRow dr)
        {
            EmsModel.ELId = dr["ELId"] as int?; EmsModel.RelationID = dr["RelationID"] as int?; EmsModel.Count = dr["Count"] as int?;
            EmsModel.Id = dr["Id"] as int?; EmsModel.Number = dr["Number"].ToString(); EmsModel.Name = dr["Name"].ToString(); EmsModel.Model = dr["Model"].ToString(); EmsModel.Unit = dr["Unit"].ToString();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="trans">事物</param>
        /// <param name="ht">条件</param>
        /// <returns>结果</returns>
        public int DeleteEquipList(SqlTransaction trans, Hashtable ht)
        {
            try
            {
                StringBuilder sbSql;
                DbParameter[] parms;

                sbSql = new StringBuilder();
                sbSql.Append("DELETE FROM EquipList");
                sbSql.Append(" WHERE RelationID in (@in_ID)");

                parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.Int32, Convert.ToInt32(ht["RelationID"]))};
                return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
            }
            catch (Exception)
            {
                //写入日志
                //throw;
                return 0;
            }
        }

        /// <summary>
        /// 获得事物对象
        /// </summary>
        /// <returns></returns>
        public SqlTransaction GetTran()
        {
            return dbHelper.BeginTransaction();
        }
    }
}
