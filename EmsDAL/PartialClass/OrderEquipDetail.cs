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
    public partial class OrderEquipDetail : DALHelper
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EmsModel.OrderEquipDetail GetEmsModel(int? ID)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();
            sbSql4org.Append("SELECT * FROM OrderEquipDetail");
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

        public List<EmsModel.OrderEquipDetail> GetEmsModelExperimentId(string ID)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();
            sbSql4org.Append(" SELECT * FROM OrderEquipDetail ");
            sbSql4org.Append(" WHERE orderid= (select id from OrderInfo where experimentId=@in_ID) ");

            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@in_ID", DbType.String,ID)};
            using (DbDataReader dr = dbHelper.ExecuteReader(CommandType.Text, sbSql4org.ToString(), parms4org))
            {
                List<EmsModel.OrderEquipDetail> lst = GetList(dr);
                return lst;
            }
        }

        /// <summary>
        /// 更新数据 事务中
        /// </summary>
        public int UpdateType(SqlTransaction trans, string strID, string OrderID)
        {
            try
            {
                StringBuilder sbSql;
                DbParameter[] parms;

                sbSql = new StringBuilder();
                sbSql.Append(" exec('update OrderEquipDetail set type=2 where equipid in(' + @in_Id + ') AND ORDERID ='+@in_OrderID) ");

                parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_Id", DbType.String, strID),
                        dbHelper.CreateInDbParameter("@in_OrderID", DbType.String, OrderID)
					};

                return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql.ToString(), parms);
            }
            catch (Exception EX)
            {
                //写入日志
                //throw;
                return 0;
            }
        }

        /// <summary>
        /// 获取泛型数据列表
        /// </summary>
        public List<EmsModel.OrderEquipDetail> GetList()
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;

            sbSql4org = new StringBuilder();
            sbSql4org.Append("SELECT * FROM OrderEquipDetail");

            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("1", DbType.Int32, 1)};

            using (DbDataReader dr = dbHelper.ExecuteReader(CommandType.Text, sbSql4org.ToString(), parms4org))
            {
                List<EmsModel.OrderEquipDetail> lst = GetList(dr);
                return lst;
            }

        }


       /// <summary>
       /// 更新状态 
       /// </summary>
       /// <param name="trans"></param>
       /// <param name="EmsModel"></param>
       /// <returns></returns>
        public int UpdateType(SqlTransaction trans, int Type, string orderDetailNO)
        {
            try
            {
                StringBuilder sbSql;
                DbParameter[] parms;

                sbSql = new StringBuilder();
                sbSql.Append(" exec ( 'update OrderEquipDetail set Type=@in_Type where EquipId in ('+@in_InventoryKindId+') ");

                parms = new DbParameter[]{
                        dbHelper.CreateInDbParameter("@in_Type", DbType.Byte,Type),
						dbHelper.CreateInDbParameter("@in_EquipId", DbType.String,orderDetailNO)
                };

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
        /// 更新状态 
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="EmsModel"></param>
        /// <returns></returns>
        public int UpdateType(int Type, string orderDetailNO)
        {
            try
            {
                StringBuilder sbSql;
                DbParameter[] parms;

                sbSql = new StringBuilder();
                sbSql.Append(" exec ( 'update OrderEquipDetail set Type=@in_Type where EquipId in ('+@in_InventoryKindId+') ");

                parms = new DbParameter[]{
                        dbHelper.CreateInDbParameter("@in_Type", DbType.Byte,Type),
						dbHelper.CreateInDbParameter("@in_EquipId", DbType.String,orderDetailNO)
                };

                return dbHelper.ExecuteNonQuery( CommandType.Text, sbSql.ToString(), parms);
            }
            catch (Exception)
            {
                //写入日志
                //throw;
                return 0;
            }
        }

        #region -------- 私有方法 --------
        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private EmsModel.OrderEquipDetail GetEmsModel(DbDataReader dr)
        {
            EmsModel.OrderEquipDetail EmsModel = new EmsModel.OrderEquipDetail();
            DbDataReaderToModel(EmsModel, dr);

            return EmsModel
;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<EmsModel.OrderEquipDetail> GetList(DbDataReader dr)
        {
            List<EmsModel.OrderEquipDetail> lst = new List<EmsModel.OrderEquipDetail>();
            while (dr.Read())
            {
                lst.Add(GetEmsModel(dr));
            }
            return lst;
        }

        
       
        #endregion

        /// <summary>
        /// 根据条件查询数据
        /// </summary>
        /// <param name="ht">查询条件</param>
        /// <returns>Model的List集合</returns>
        public DataTable GetData(Hashtable ht)
        {
            try
            {
                StringBuilder sbSql4org = new StringBuilder();
                sbSql4org.Append(" select a.*,b.OrderNo,c.AssetName,c.BrandStandardModel,a.[Count],c.Unit,c.StorageLocation,a.[Type],a.LendTime,a.ReturnTime from OrderEquipDetail a ");
                sbSql4org.Append(" left join OrderInfo b on a.OrderId=b.Id ");
                sbSql4org.Append(" left join EquipDetail c on a.EquipId=c.Id ");
                sbSql4org.Append(" where 1=1 ");

                List<DbParameter> List = new List<DbParameter>();
                if (ht.ContainsKey("Id") && !string.IsNullOrWhiteSpace(ht["Id"].ToString()))
                {
                    sbSql4org.Append(" and a.Id=@Id ");
                    List.Add(dbHelper.CreateInDbParameter("@Id", DbType.Int32, Convert.ToInt32(ht["Id"].ToString())));
                }
                //if (ht.ContainsKey("Name") && !string.IsNullOrWhiteSpace(ht["Name"].ToString()))
                //{
                //    sbSql4org.Append(" and Name like N'%'+@Name+'%' ");
                //    List.Add(dbHelper.CreateInDbParameter("@Name", DbType.String, ht["Name"].ToString()));
                //}
                if (ht.ContainsKey("ExperimentId"))
                {
                    sbSql4org.Append(" and b.ExperimentId=@ExperimentId ");
                    List.Add(dbHelper.CreateInDbParameter("@ExperimentId", DbType.Int32, Convert.ToInt32(ht["ExperimentId"].ToString())));
                }
                if (ht.ContainsKey("IsDelete"))
                {
                    if (string.IsNullOrWhiteSpace(ht["IsDelete"].ToString()))
                    {
                        sbSql4org.Append(" and a.IsDelete <> 1 ");
                    }
                    else
                    {
                        sbSql4org.Append(" and a.IsDelete = @IsDelete  ");
                        List.Add(dbHelper.CreateInDbParameter("@IsDelete", DbType.Int32, Convert.ToInt32(ht["IsDelete"].ToString())));
                    }
                }

                DataSet ds = dbHelper.ExecuteQuery(CommandType.Text, sbSql4org.ToString(), List.ToArray());
                return ds.Tables[0];
            }
            catch (Exception)
            {
                //写入日志
                //throw;
                return null;
            }
        }
    }
}
