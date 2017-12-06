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
    public partial class InventoryListDetail : DALHelper
    {
        #region 生成盘点单详情
        /// <summary>
        /// 生成盘点单详情
        /// </summary>
        public int AddInventoryListDetail(SqlTransaction trans, int planid, string type)
        {
            try
            {
                DbParameter[] parms;
//                string sql = @"insert into InventoryListDetail(InventoryListId,EquipId,AssetNumber,AssetName,RoomId,Status,IsLoss) 
//                                select @PlanId as listid,ed.Id,ed.AssetNumber,ed.AssetName,ed.StorageLocation,ed.EquipStatus,0 as IsLoss  from EquipDetail ed
//                                inner join Building bu on ed.StorageLocation=convert(varchar(50) ,bu.Id) and bu.IsDelete=0
//                                where bu.type=@Type and bu.RoomNo is not null and ed.IsDelete=0";
                string sql = @"insert into InventoryListDetail(InventoryListId,EquipId,AssetNumber,AssetName,RoomId,Status,IsLoss) 
                                select @PlanId as listid,ed.Id,ed.AssetNumber,ed.AssetName,ed.StorageLocation,ed.EquipStatus,0 as IsLoss  from EquipDetail ed
                                where ed.type=@Type and ed.IsDelete=0 and ed.UseStatus=0 ";   
                parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@PlanId", DbType.Int32,planid),
                        dbHelper.CreateInDbParameter("@Type", DbType.String,type)};
                return dbHelper.ExecuteNonQuery(trans, CommandType.Text, sql, parms);
            }
            catch (Exception)
            {
                //写入日志
                //throw;
                return 0;
            }
        }
        #endregion

        #region 根据盘点单获得楼房信息
        /// <summary>
        /// 根据盘点单获得楼房信息
        /// </summary>  
        public DataTable GetBuildingByInventory(string invenid,string type)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;                      
         
            sbSql4org = new StringBuilder();
            sbSql4org.Append(@"select distinct build.* from Building build
                                left join Building layer on layer.PID=build.Id
                                left join Building room on room.PID=layer.Id
                                where room.Id in(select distinct RoomId  from InventoryList where PlanId=@PlanId) ");
            sbSql4org.Append(" order by Id desc");
            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@PlanId", DbType.String, invenid),
                dbHelper.CreateInDbParameter("@Type", DbType.String, type)};
            return dbHelper.ExecuteQuery(CommandType.Text, sbSql4org.ToString(), parms4org).Tables[0];
        }
        #endregion

        #region 根据盘点单id及楼房id获得盘点时的楼层及房间信息
        /// <summary>
        /// 根据盘点单id及楼房id获得盘点时的楼层及房间信息
        /// </summary>  
        public DataTable GetLayersAndRoomsByInvenId(string invenid,string buildid,string type)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;

            sbSql4org = new StringBuilder();
            sbSql4org.Append("select * from( ");
            sbSql4org.Append(@"select distinct bu.*,list.Status,0 as numname from InventoryList list
                         left join Building bu on list.RoomId=bu.Id and PlanId=@PlanId
                        where bu.PID in (select Id from Building where PID=@BuildId)                    
                        union
                        select distinct *,0,cast(Name as int) as numname from Building where PID=@BuildId and Id in
                        (select bu.PID from InventoryList list
                        left join Building bu on list.RoomId=bu.Id and PlanId=@PlanId) ");
            sbSql4org.Append(")T order by numname desc,Id desc ");
            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@PlanId", DbType.String, invenid),
                dbHelper.CreateInDbParameter("@BuildId", DbType.String, buildid),
                dbHelper.CreateInDbParameter("@Type", DbType.String, type)};
            return dbHelper.ExecuteQuery(CommandType.Text, sbSql4org.ToString(), parms4org).Tables[0];
        }
        #endregion

        #region 获取房间的仪器设备信息
        public List<EmsModel.View_InvenRoomEquip> GetRoomEquipList(string invenid, string roomid)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();
            sbSql4org.Append("SELECT ind.*,equ.Barcode,equ.ImageName FROM InventoryListDetail ind ");
            sbSql4org.Append("left join EquipDetail equ on ind.EquipId=equ.Id ");
            sbSql4org.Append(" where ind.Status!=1 and ind.InventoryListId=@InventoryListId and ind.RoomId=@RoomId ");
            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@InventoryListId", DbType.String, invenid),
                dbHelper.CreateInDbParameter("@RoomId", DbType.String, roomid)};
            DataSet ds = dbHelper.ExecuteQuery(CommandType.Text, sbSql4org.ToString(), parms4org);
            List<EmsModel.View_InvenRoomEquip> list = new EmsDAL.View_InvenRoomEquip().GetList(ds.Tables[0]);
            return list;

        }
        #endregion

        #region 根据条形码得到盘点单中的一个对象实体
        /// <summary>
        /// 根据条形码得到盘点单中的一个对象实体
        /// </summary>
        public EmsModel.View_InvenRoomEquip GetInvenModelByBarcode(string invenid,string barcode)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();
            sbSql4org.Append("SELECT ind.*,equ.Barcode,equ.ImageName FROM InventoryListDetail ind ");
            sbSql4org.Append("left join EquipDetail equ on ind.EquipId=equ.Id ");
            sbSql4org.Append(" WHERE ind.InventoryListId=@InventoryListId and equ.Barcode=@in_Barcode");

            EmsModel.View_InvenRoomEquip model = new EmsModel.View_InvenRoomEquip();
            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@InventoryListId", DbType.String, invenid),
                dbHelper.CreateInDbParameter("@in_Barcode", DbType.String,barcode)};
            using (DbDataReader dr = dbHelper.ExecuteReader(CommandType.Text, sbSql4org.ToString(), parms4org))
            {
                if (dr.Read())
                {
                    new EmsDAL.View_InvenRoomEquip().DbDataReaderToModel(model, dr);
                    return model;
                }
                return null;
            }
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EmsModel.InventoryListDetail GetEmsModel(int? ID)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();
            sbSql4org.Append("SELECT * FROM InventoryListDetail");
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

        #region 获取房间仪器缺失数量
        /// <summary>
        /// 获取房间仪器缺失数量
        /// </summary>
        public int GetRoomLossCount(SqlTransaction trans, string invenid, string roomid)
        {
            try
            {
                StringBuilder sbSql;
                DbParameter[] parms;
                sbSql = new StringBuilder();
                sbSql.Append("SELECT COUNT(1) FROM InventoryListDetail");
                sbSql.Append(" where InventoryListId=@InventoryListId and RoomId=@RoomId and IsLoss=0 ");
                parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@InventoryListId", DbType.String,invenid),
                            dbHelper.CreateInDbParameter("@RoomId",DbType.String,roomid)
							};
                object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
                return int.Parse(obj.ToString());
            }
            catch (Exception)
            {
                //写入日志
                //throw;
                return 0;
            }
        }
        #endregion        

        #region 获取未盘点的盘点单数量
        /// <summary>
        /// 获取未盘点的盘点单数量
        /// </summary>
        public int GetNotInventoryCount(SqlTransaction trans,string invenid)
        {
            try
            {
                StringBuilder sbSql;
                DbParameter[] parms;
                sbSql = new StringBuilder();
                sbSql.Append("SELECT COUNT(1) FROM InventoryList");
                sbSql.Append(" where Status=0 and PlanId=@PlanId ");
                parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@PlanId", DbType.String,invenid)};
                object obj = dbHelper.ExecuteScalar(trans,CommandType.Text, sbSql.ToString(), parms);
                return int.Parse(obj.ToString());
            }
            catch (Exception)
            {
                //写入日志
                //throw;
                return -1;
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
        private EmsModel.InventoryListDetail GetEmsModel(DbDataReader dr)
        {
            EmsModel.InventoryListDetail EmsModel = new EmsModel.InventoryListDetail();
            DbDataReaderToModel(EmsModel, dr);

            return EmsModel;
        }
        #endregion

        #region 由DbDataReader得到泛型数据列表
        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<EmsModel.InventoryListDetail> GetList(DbDataReader dr)
        {
            List<EmsModel.InventoryListDetail> lst = new List<EmsModel.InventoryListDetail>();
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
