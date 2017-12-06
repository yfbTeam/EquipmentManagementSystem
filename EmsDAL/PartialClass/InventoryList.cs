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
    public partial class InventoryList : DALHelper
    {
        #region 生成盘点单
        /// <summary>
        /// 生成盘点单
        /// </summary>
        public int AddInventoryList(SqlTransaction trans, int planid, string type, string useridcard)
        {
            try
            {
                DbParameter[] parms;
                string sel;
                if (type == "0")
                {
                    sel = @"(select count(1) from EquipDetail where StorageLocation=ed.StorageLocation and EquipStatus!=1) as Quantity,
                            (select count(1) from EquipDetail where StorageLocation=ed.StorageLocation and EquipStatus=1) as BorrowQuantity,";
                }
                else
                {
                    sel = @"(select count(1) from EquipDetail where StorageLocation=ed.StorageLocation) as Quantity,0,";
                }
                string sql = @"insert into InventoryList(PlanId,RoomId,Quantity,BorrowQuantity,RealQuantity,LossQuantity,
                                 Status,Operator,Creator,CreateTime) 
                                select distinct @PlanId as PlanId,bu.Id," + sel + @"0,0,0,'',@Creator as Creator,getdate()
                                from  Building bu
                                left join EquipDetail ed on ed.StorageLocation=convert(varchar(50) ,bu.Id) and ed.IsDelete=0
                                where bu.type=@Type and bu.RoomNo is not null and bu.IsDelete=0 ";

                parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@PlanId", DbType.Int32,planid),
                        dbHelper.CreateInDbParameter("@Type", DbType.String,type),
                        dbHelper.CreateInDbParameter("@Creator", DbType.String,useridcard)};
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

        #region 根据盘点id和房间id得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EmsModel.InventoryList GetEmsModelByInvRoomId(string invenid, string roomid)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();
            sbSql4org.Append("SELECT * FROM InventoryList");
            sbSql4org.Append(" WHERE PlanId=@PlanId and RoomId=@RoomId ");

            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@PlanId", DbType.String,invenid),
                dbHelper.CreateInDbParameter("@RoomId", DbType.String,roomid)};
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

        #region 获取盘点单列表数据 分页
        /// <summary>
        /// 获取盘点单列表数据 分页
        /// </summary>
        /// <param name="ht">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable GetInvenListDataPage(Hashtable ht, bool ispage)
        {
            try
            {
                List<DbParameter> List = new List<DbParameter>();
                StringBuilder sbSql4org = new StringBuilder();
                string orderby = "";
                if (ht.ContainsKey("IsRoomGroup") && !string.IsNullOrWhiteSpace(ht["IsRoomGroup"].ToString()))
                {
                    sbSql4org.Append(@"select distinct list.Quantity,list.RealQuantity,list.BorrowQuantity
                   ,(select count(Id) from InventoryListDetail where IsLoss=0 and RoomId=list.RoomId and InventoryListId=@PlanId) as LossQuantity 
                   ,list.RoomId,list.Operator as OperatorUID,equip.EquipOwner as OwnerUID,0  as display ");
                   orderby = " RoomId desc ";
                }
                else
                {
                    sbSql4org.Append(@"select distinct det.*,case when det.IsLoss='False' then 0 else 1 end as loss,
                                    list.Operator as OperatorUID,equip.EquipOwner as OwnerUID,equip.EquipSource,equip.Unit,1  as display ");
                    orderby = " IsLoss ";
                }
                sbSql4org.Append(@" ,vplan.Type,build.Name+'-'+layer.Name+'层-'+room.RoomNo+'('+room.Name+')' as Storage
                                        from InventoryListDetail det
                                        left join EquipDetail equip on equip.Id=det.EquipId
                                        left join InventoryPlan vplan on det.InventoryListId=vplan.Id
                                        left join InventoryList list on list.PlanId=vplan.Id                                       
                                        left join Building room on room.Id=det.RoomId
                                        left join Building layer on room.PID=layer.Id
                                        left join Building build on layer.PID=build.Id 
                                        where vplan.Id=@PlanId ");
                if (ht.ContainsKey("PlanId") && !string.IsNullOrWhiteSpace(ht["PlanId"].ToString()))
                    {
                        List.Add(dbHelper.CreateInDbParameter("@PlanId", DbType.String, ht["PlanId"].ToString()));
                    }
                if (ht.ContainsKey("RoomId") && !string.IsNullOrWhiteSpace(ht["RoomId"].ToString()))
                {
                    sbSql4org.Append(" and det.RoomId=@RoomId ");
                    List.Add(dbHelper.CreateInDbParameter("@RoomId", DbType.String, ht["RoomId"].ToString()));
                }
                if (ht.ContainsKey("serisloss") && !string.IsNullOrWhiteSpace(ht["serisloss"].ToString()))
                {
                    sbSql4org.Append(" and det.IsLoss=@IsLoss ");
                    List.Add(dbHelper.CreateInDbParameter("@IsLoss", DbType.String, ht["serisloss"].ToString()=="0"?"False":"True"));
                }
                if (ht.ContainsKey("equipsource") && !string.IsNullOrWhiteSpace(ht["equipsource"].ToString()))
                {
                    sbSql4org.Append(" and equip.EquipSource=@EquipSource ");
                    List.Add(dbHelper.CreateInDbParameter("@EquipSource", DbType.String, ht["equipsource"].ToString()));
                }
                if (ht.ContainsKey("assetname") && !string.IsNullOrWhiteSpace(ht["assetname"].ToString()))
                {
                    sbSql4org.Append(" and equip.AssetName like N'%'+@AssetName+'%' ");
                    List.Add(dbHelper.CreateInDbParameter("@AssetName", DbType.String, ht["assetname"].ToString()));
                }
                DataSet ds = base.GetListByPage("(" + sbSql4org.ToString() + ")", "", orderby, Convert.ToInt32(ht["StartIndex"].ToString()), Convert.ToInt32(ht["EndIndex"].ToString()), List.ToArray(), ispage);

                int RowCount = base.GetRecordCount("(" + sbSql4org.ToString() + ") T", "", List.ToArray());
                ht.Add("RowCount", RowCount);

                return ds.Tables[0];                      
            }
            catch (Exception)
            {
                //写入日志
                //throw;
                return null;
            }
        }
        #endregion

        #region 获取盘点单总数信息
        /// <summary>
        /// 获取盘点单总数信息
        /// </summary>
        public DataTable GetInvenListCount(string planid)
        {
            try
            {
                DbParameter[] parms4org;
                StringBuilder sbSql4org = new StringBuilder();
                sbSql4org.Append(@"select vplan.Id,vplan.Name,vplan.InventoryNo,vplan.Type,
                                    sum(list.Quantity) as Quantity,
                                    (select count(Id) from InventoryListDetail where IsLoss=1 and InventoryListId=@PlanId) as RealQuantity,
                                    sum(list.BorrowQuantity) as BorrowQuantity,(select count(Id) from InventoryListDetail where IsLoss=0 and InventoryListId=@PlanId) as LossQuantity
                                        from InventoryPlan vplan
                                    left join InventoryList list on list.PlanId=vplan.Id
                                    where vplan.IsDelete=0 and vplan.Id=@PlanId
                                    group by vplan.Id,vplan.Name,vplan.InventoryNo,vplan.Type ");
                parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@PlanId", DbType.String, planid)};
                return dbHelper.ExecuteQuery(CommandType.Text, sbSql4org.ToString(), parms4org).Tables[0];
            }
            catch (Exception)
            {
                //写入日志
                //throw;
                return null;
            }
        }
        #endregion

        #region -------- 私有方法 --------

        #region 由一行数据得到一个实体
        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private EmsModel.InventoryList GetEmsModel(DbDataReader dr)
        {
            EmsModel.InventoryList EmsModel = new EmsModel.InventoryList();
            DbDataReaderToModel(EmsModel, dr);

            return EmsModel;
        }
        #endregion

        #region 由DbDataReader得到泛型数据列表
        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<EmsModel.InventoryList> GetList(DbDataReader dr)
        {
            List<EmsModel.InventoryList> lst = new List<EmsModel.InventoryList>();
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
