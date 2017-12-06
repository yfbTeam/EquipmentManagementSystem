using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EmsDAL
{

    public partial class OrderInfo : DALHelper
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EmsModel.OrderInfo GetEmsModel(int? ID)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();
            sbSql4org.Append("SELECT * FROM OrderInfo");
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
        /// 获取泛型数据列表
        /// </summary>
        public List<EmsModel.OrderInfo> GetList()
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;

            sbSql4org = new StringBuilder();
            sbSql4org.Append("SELECT * FROM OrderInfo");

            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("1", DbType.Int32, 1)};

            using (DbDataReader dr = dbHelper.ExecuteReader(CommandType.Text, sbSql4org.ToString(), parms4org))
            {
                List<EmsModel.OrderInfo> lst = GetList(dr);
                return lst;
            }

        }

        public List<EmsModel.View_orderCount> GetListVO(string OrderNo)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();
            sbSql4org.Append("SELECT * FROM View_orderCount ");

            sbSql4org.Append(" where RelationID in (select ExperimentId from OrderInfo where OrderNo =@in_OrderNo) ");
            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@in_OrderNo", DbType.String, OrderNo)};
            DataSet ds = dbHelper.ExecuteQuery(CommandType.Text, sbSql4org.ToString(), parms4org);
            List<EmsModel.View_orderCount> list = new EmsDAL.View_orderCount().GetList(ds.Tables[0]);
            return list;

        }

        public List<EmsModel.View_LoanANDEscheat> GetListEscheat(string OrderNo)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();
            sbSql4org.Append(" select ORDERID,InventoryKindId,InstrumentEquip,count(ORDERID)as countL,(select count(*) from OrderEquipDetail OO ");

            sbSql4org.Append(" where O.[InventoryKindId]=OO.[InventoryKindId] AND O.ORDERID=OO.ORDERID AND OO.[TYPE]=2 ) AS countE from [dbo].[OrderEquipDetail]  O  WHERE ORDERID =(SELECT ID FROM ORDERINFO WHERE EXPERIMENTID=59 ) Group By ORDERID,[InventoryKindId],[InstrumentEquip] ");
            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@in_OrderId", DbType.String, OrderNo)};
            DataSet ds = dbHelper.ExecuteQuery(CommandType.Text, sbSql4org.ToString(), parms4org);
            List<EmsModel.View_LoanANDEscheat> list = new EmsDAL.View_LoanANDEscheat().GetList(ds.Tables[0]);
            return list;

        }

        public List<EmsModel.View_LoanDate> GetLoanDate(string creator)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();
            sbSql4org.Append("SELECT * FROM View_LoanDate where 1=1 ");
            if(creator !=""){
            sbSql4org.Append(" AND  Creator = @in_Creator ");
            }
            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@in_Creator", DbType.String, creator)};
            DataSet ds = dbHelper.ExecuteQuery(CommandType.Text, sbSql4org.ToString(), parms4org);
            List<EmsModel.View_LoanDate> list = new EmsDAL.View_LoanDate().GetList(ds.Tables[0]);
            return list;

        }

        /// <summary>
        /// 更新数据
        /// </summary>
        public bool UpdateOrder(EmsModel.OrderInfo EmsModel, List<EmsModel.OrderEquipDetail> list)
        {
            using (SqlTransaction trans = dbHelper.BeginTransaction())
            {

                int count = Update(trans, EmsModel);//修改订单状态

                for (int i = 0; i < list.Count; i++)
                {
                    list[i].Type = Convert.ToByte(EmsModel.Status);
                    count += new EmsDAL.OrderEquipDetail().Update(trans, list[i]);
                }

                if (count < list.Count)
                {//如果没有全部修改
                    //回滚
                    trans.Rollback();
                    return false;
                }
                else
                {
                    //提交
                    trans.Commit();
                    return true;
                }

            }
        }

        public bool UpdateOrder(string orderNO, string orderDetailNO, int DetailType)
        {
            using (SqlTransaction trans = dbHelper.BeginTransaction())
            {
                int count = 0;
                try
                {
                    count = UpdateStatus(trans, DetailType, orderNO);//修改订单状态
                    count += new EmsDAL.OrderEquipDetail().UpdateType(trans, DetailType, orderDetailNO);
                }
                catch (Exception)
                {
                    //回滚
                    trans.Rollback();
                    count = 0;
                    //写入日志
                    //throw;
                }

                if (count < 1)
                {//如果没有修改
                    //回滚
                    trans.Rollback();
                    return false;
                }
                else
                {
                    //提交
                    trans.Commit();
                    return true;
                }

            }

        }

        /// <summary>
        /// 订单借出
        /// </summary>
        /// <param name="listModer"></param>
        /// <param name="orderNo"></param>
        /// <param name="orderType"></param>
        /// <param name="DetailType"></param>
        /// <returns></returns>
        public bool UpdateOrderLend(List<EmsModel.OrderEquipDetail> listModer, string orderNo, int orderType, int DetailType, EmsModel.OrderInfo mod)
        {

            using (SqlTransaction trans = dbHelper.BeginTransaction())
            {
                int count = 0;
                try
                {

                    int orderid = Add(trans, mod);
                    foreach (var item in listModer)
                    {
                        item.OrderId = orderid;
                        count += new EmsDAL.OrderEquipDetail().Add(trans, item);
                    }

                    
                }
                catch (Exception)
                {
                    //回滚
                    trans.Rollback();
                    count = 0;
                    //写入日志
                    //throw;
                }

                if (count < 0)
                {//如果没有修改
                    //回滚
                    trans.Rollback();
                    return false;
                }
                else
                {
                    //提交
                    trans.Commit();
                    return true;
                }

            }
        }


        public bool OtherLend(List<EmsModel.OrderEquipDetail> listModer,string LoanName, string Creator,string orderNo, int orderType, int DetailType)
        {

            using (SqlTransaction trans = dbHelper.BeginTransaction())
            {
                int count = 0;
                try
                {
                    EmsModel.OrderInfo order = new EmsModel.OrderInfo();
                    order.OrderNo = "WJ" + DateTime.Now.ToString("yyMMdd");

                    order.LoanName = LoanName;
                    order.ExperimentId = 0;
                    order.Type =Convert.ToByte(orderType);
                    order.Status = 0;
                    order.Creator = Creator;
                    order.CreateTime = DateTime.Now;
                    order.IsDelete = 0;
                    EmsDAL.OrderInfo orderDAL =new OrderInfo();
                    int num= orderDAL.Add(trans, order);
                    order.Id=num;
                    count += orderDAL.Update(trans, order);



                    foreach (var item in listModer)
                    {
                        count += new EmsDAL.OrderEquipDetail().Add(trans, item);
                    }
                            
                    //count = UpdateStatus(trans, orderType, orderNo);//修改订单状态
                }
                catch (Exception)
                {
                    //回滚
                    trans.Rollback();
                    count = 0;
                    //写入日志
                    //throw;
                }

                if (count < 1)
                {//如果没有修改
                    //回滚
                    trans.Rollback();
                    return false;
                }
                else
                {
                    //提交
                    trans.Commit();
                    return true;
                }

            }
        }

        /// <summary>
        /// 订单归还
        /// </summary>
        /// <param name="listModer"></param>
        /// <param name="orderNo"></param>
        /// <param name="orderType"></param>
        /// <param name="DetailType"></param>
        /// <returns></returns>
        public bool UpdateOrderEscheat(string strID,string orderID, int orderType, int DetailType)
        {
            using (SqlTransaction trans = dbHelper.BeginTransaction())
            {
                int count = 0;
                try
                {
                    //更新订单详情
                    count += new EmsDAL.OrderEquipDetail().UpdateType(trans, strID, orderID);

                    count += UpdateStatus(trans, orderType, orderID);//修改订单状态
                }
                catch (Exception)
                {
                    //回滚
                    trans.Rollback();
                    count = 0;
                    //写入日志
                    //throw;
                }

                if (count < 1)
                {//如果没有修改
                    //回滚
                    trans.Rollback();
                    return false;
                }
                else
                {
                    //提交
                    trans.Commit();
                    return true;
                }

            }
        }


        int GetStatusByDetailType(string orderNO, int DetailType)
        {
            if (DetailType == 1)
            {
                return 2;
            }
            else if (DetailType == 2)
            {
                return 3;
            }
            else
            {
                return 0;
            }
        }
        public int GetStatusCountL(string OrderNo)
        {
            try
            {
                StringBuilder sbSql;
                DbParameter[] parms;

                sbSql = new StringBuilder();
                sbSql.Append(" select (sum([count])-sum(countl)) as c from View_orderCount ");
                sbSql.Append("  where RelationID in (select ExperimentId from [dbo].[OrderInfo] where OrderNo =@in_orderNo )");


                parms = new DbParameter[]{
					dbHelper.CreateInDbParameter("@in_orderNo", DbType.String, OrderNo)
                };

                object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
                if (obj == null)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(obj);
                }
            }
            catch (Exception)
            {
                //写入日志
                //throw;
                return 0;
            }
        }

        public int GetStatusCountE(string OrderID)
        {
            try
            {
                StringBuilder sbSql;
                DbParameter[] parms;

                sbSql = new StringBuilder();
                sbSql.Append(" select (SELECT count(*) FROM [dbo].OrderEquipDetail  where type =1 and orderID=@in_OrderID )-(SELECT count(*) FROM [dbo].OrderEquipDetail  where type =2 and orderID=@in_OrderID )  ");
                parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@in_OrderID", DbType.String, OrderID)
                };

                object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql.ToString(), parms);
                if (obj == null)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(obj);
                }
            }
            catch (Exception)
            {
                //写入日志
                //throw;
                return 0;
            }
        }


        /// <summary>
        /// 更新 订单状态
        /// </summary>
        /// <param name="trans">事务</param>
        /// <param name="Status">状态</param>
        /// <param name="OrderNo">订单号</param>
        /// <returns></returns>
        public int UpdateStatus(SqlTransaction trans, int Status, string OrderID)
        {
            try
            {
                StringBuilder sbSql;
                DbParameter[] parms;

                sbSql = new StringBuilder();
                sbSql.Append("update OrderInfo set ");
                sbSql.Append("Status=@in_Status ");
                sbSql.Append("  where ID=@in_OrderID");

                parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_OrderID", DbType.String, OrderID),
                        dbHelper.CreateInDbParameter("@in_Status", DbType.Int32, Status)
                };

                return dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), parms);
            }
            catch (Exception EX)
            {
                //写入日志
                throw;
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

        #region -------- 私有方法 --------
        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private EmsModel.OrderInfo GetEmsModel(DbDataReader dr)
        {
            EmsModel.OrderInfo EmsModel = new EmsModel.OrderInfo();
            PrepareEmsModel(EmsModel, dr);

            return EmsModel;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<EmsModel.OrderInfo> GetList(DbDataReader dr)
        {
            List<EmsModel.OrderInfo> lst = new List<EmsModel.OrderInfo>();
            while (dr.Read())
            {
                lst.Add(GetEmsModel(dr));
            }
            return lst;
        }
        private List<EmsModel.View_orderCount> GetListVO(DbDataReader dr)
        {
            List<EmsModel.View_orderCount> lst = new List<EmsModel.View_orderCount>();
            while (dr.Read())
            {
                EmsModel.View_orderCount vo = new EmsModel.View_orderCount();
                new EmsDAL.View_orderCount().DbDataReaderToModel(vo, dr);
                lst.Add(vo);
            }
            return lst;
        }


        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private void PrepareEmsModel(EmsModel.OrderInfo EmsModel, DbDataReader dr)
        {
            EmsModel.Id = GetInt(dr["ID"]);
            EmsModel.OrderNo = GetString(dr["OrderNo"]);
            EmsModel.LoanName = GetString(dr["LoanName"]);
            EmsModel.ExperimentId = GetInt(dr["ExperimentId"]);
            EmsModel.Attachment = GetString(dr["Attachment"]);
            EmsModel.Type = GetByte(dr["Type"]);
            EmsModel.Status = GetInt(dr["Status"]);
            EmsModel.Remarks = GetString(dr["Remarks"]);
            EmsModel.LendTime = GetDateTime(dr["LendTime"]);
            EmsModel.ReturnTime = GetDateTime(dr["ReturnTime"]);
            EmsModel.Creator = GetString(dr["Creator"]);
            EmsModel.CreateTime = GetDateTime(dr["CreateTime"]);
            EmsModel.Editor = GetString(dr["Editor"]);
            EmsModel.UpdateTime = GetDateTime(dr["UpdateTime"]);
            EmsModel.IsDelete = GetByte(dr["IsDelete"]);
        }
        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private void GerEmsModelByDR(EmsModel.OrderInfo EmsModel, DbDataReader dr)
        {
            EmsModel.Id = dr["ID"] as int?;
            EmsModel.OrderNo = GetString(dr["OrderNo"]);
            EmsModel.LoanName = GetString(dr["LoanName"]);
            EmsModel.ExperimentId = GetInt(dr["ExperimentId"]);
            EmsModel.Attachment = GetString(dr["Attachment"]);
            EmsModel.Type = GetByte(dr["Type"]);
            EmsModel.Status = GetInt(dr["Status"]);
            EmsModel.Remarks = GetString(dr["Remarks"]);
            EmsModel.LendTime = GetDateTime(dr["LendTime"]);
            EmsModel.ReturnTime = GetDateTime(dr["ReturnTime"]);
            EmsModel.Creator = GetString(dr["Creator"]);
            EmsModel.CreateTime = GetDateTime(dr["CreateTime"]);
            EmsModel.Editor = GetString(dr["Editor"]);
            EmsModel.UpdateTime = GetDateTime(dr["UpdateTime"]);
            EmsModel.IsDelete = GetByte(dr["IsDelete"]);
        }
        #endregion
    }
}
