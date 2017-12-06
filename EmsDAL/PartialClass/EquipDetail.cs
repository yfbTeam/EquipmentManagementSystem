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
    /// 设备详情
    /// </summary>
    public partial class EquipDetail : DALHelper
    {
        /// <summary>
        /// 分页查询根据条件
        /// </summary>
        /// <param name="ht">查询条件</param>
        /// <returns>Model的List集合</returns>
        public DataTable GetPage(Hashtable ht)
        {
            try
            {
                StringBuilder sbSql4org;

                sbSql4org = new StringBuilder();
                sbSql4org.Append(@" SELECT a.*,room.Name as WarehouseName,a.EquipOwner as OwnerUID,                                                                                
                                        case when a.StorageLocation='0' then '未分配' else build.Name+'-'+layer.Name+'层-'+room.RoomNo+'('+room.Name+')' end as Storage  ");
                string display = ",0 as display ";
                bool isStorageLocation = ht.ContainsKey("StorageLocation") && !string.IsNullOrEmpty(ht["StorageLocation"].ToString());
                bool isSLSymbol = ht.ContainsKey("SLSymbol") && !string.IsNullOrWhiteSpace(ht["SLSymbol"].ToString());
                if (isStorageLocation && isSLSymbol && (ht["SLSymbol"].ToString() == "="))
                {
                    display = ",1 as display ";
                }
                sbSql4org.Append(display);
                sbSql4org.Append(@" FROM EquipDetail a
                                    left join Building room on a.StorageLocation=convert(varchar(50) ,room.id) 
                                    left join Building layer on room.PID=layer.Id
                                    left join Building build on layer.PID=build.Id ");
                sbSql4org.Append(" where 1=1 ");

                List<DbParameter> List = new List<DbParameter>();
                if (ht.ContainsKey("Id"))
                {
                    sbSql4org.Append(" and a.Id=@Id ");
                    List.Add(dbHelper.CreateInDbParameter("@Id", DbType.Int32, Convert.ToInt32(ht["Id"].ToString())));
                }
                if (ht.ContainsKey("EquipKindId"))
                {
                    sbSql4org.Append(" and a.EquipKindId=@EquipKindId ");
                    List.Add(dbHelper.CreateInDbParameter("@EquipKindId", DbType.Int32, Convert.ToInt32(ht["EquipKindId"].ToString())));
                }
                if (ht.ContainsKey("AssetName") && !string.IsNullOrWhiteSpace(ht["AssetName"].ToString()))
                {
                    sbSql4org.Append(" and a.AssetName like N'%'+@AssetName+'%' ");
                    List.Add(dbHelper.CreateInDbParameter("@AssetName", DbType.String, ht["AssetName"].ToString()));
                }
                if (ht.ContainsKey("Creator"))
                {
                    sbSql4org.Append(" and a.Creator=@Creator ");
                    List.Add(dbHelper.CreateInDbParameter("@Creator", DbType.String, ht["Creator"].ToString()));
                }
                if (ht.ContainsKey("Type") && !string.IsNullOrWhiteSpace(ht["Type"].ToString()))
                {
                    sbSql4org.Append(" and a.Type=@Type ");
                    List.Add(dbHelper.CreateInDbParameter("@Type", DbType.String, ht["Type"].ToString()));
                }
                if (ht.ContainsKey("IsConsume"))
                {
                    sbSql4org.Append(" and a.IsConsume=@IsConsume ");
                    List.Add(dbHelper.CreateInDbParameter("@IsConsume", DbType.String, ht["IsConsume"].ToString()));
                }
                if (ht.ContainsKey("IsDelete"))
                {
                    if (string.IsNullOrWhiteSpace(ht["IsDelete"].ToString()))
                    {
                        sbSql4org.Append(" and a.IsDelete <> 1 ");
                    }
                    else
                    {
                        sbSql4org.Append(" and a.IsDelete = @IsDelete ");
                        List.Add(dbHelper.CreateInDbParameter("@IsDelete", DbType.Int32, Convert.ToInt32(ht["IsDelete"])));
                    }
                }
                if (ht.ContainsKey("AssetsClassName") && !string.IsNullOrWhiteSpace(ht["AssetsClassName"].ToString()))
                {
                    sbSql4org.Append(" and a.AssetsClassName like N'%'+@AssetsClassName+'%'");
                    List.Add(dbHelper.CreateInDbParameter("@AssetsClassName", DbType.String, ht["AssetsClassName"].ToString()));
                }
                if (ht.ContainsKey("SerRoomid") && !string.IsNullOrWhiteSpace(ht["SerRoomid"].ToString()))
                {
                    sbSql4org.Append(" and a.StorageLocation=@SerRoomid ");
                    List.Add(dbHelper.CreateInDbParameter("@SerRoomid", DbType.String, ht["SerRoomid"].ToString()));
                }
                if (ht.ContainsKey("SerEquipOwner") && !string.IsNullOrWhiteSpace(ht["SerEquipOwner"].ToString()))
                {
                    sbSql4org.Append(ht["SerEquipOwner"].ToString() == "-1" ? " and a.EquipOwner is null " : " and a.EquipOwner=@SerEquipOwner ");
                    List.Add(dbHelper.CreateInDbParameter("@SerEquipOwner", DbType.String, ht["SerEquipOwner"].ToString()));
                }               
                if (ht.ContainsKey("StorageLocation") && !string.IsNullOrWhiteSpace(ht["StorageLocation"].ToString()))
                {
                    sbSql4org.Append(" and a.StorageLocation");
                    if (ht.ContainsKey("SLSymbol") && !string.IsNullOrWhiteSpace(ht["SLSymbol"].ToString()))
                    {
                        sbSql4org.Append(ht["SLSymbol"].ToString());
                    }
                    else
                    {
                        sbSql4org.Append(" = ");

                    }
                    sbSql4org.Append(" @StorageLocation ");
                    List.Add(dbHelper.CreateInDbParameter("@StorageLocation", DbType.String, ht["StorageLocation"].ToString()));

                }
                if (ht.ContainsKey("EquipOwner"))
                {
                    sbSql4org.Append(" and a.EquipOwner=@EquipOwner ");
                    List.Add(dbHelper.CreateInDbParameter("@EquipOwner", DbType.String, ht["EquipOwner"].ToString()));
                }
                if (ht.ContainsKey("EquipSource") && !string.IsNullOrWhiteSpace(ht["EquipSource"].ToString()))
                {
                    sbSql4org.Append(" and a.EquipSource=@EquipSource ");
                    List.Add(dbHelper.CreateInDbParameter("@EquipSource", DbType.String, ht["EquipSource"].ToString()));
                
                }
                if (ht.ContainsKey("EquipStatus") && !string.IsNullOrWhiteSpace(ht["EquipStatus"].ToString())) 
                {
                    sbSql4org.Append(" and a.EquipStatus=@EquipStatus ");
                    List.Add(dbHelper.CreateInDbParameter("@EquipStatus", DbType.Int32, Convert.ToInt32(ht["EquipStatus"])));
                }
                if (ht.ContainsKey("BorrowYN") && !string.IsNullOrWhiteSpace(ht["BorrowYN"].ToString()))
                {
                    sbSql4org.Append(" and a.BorrowYN=@BorrowYN ");
                    List.Add(dbHelper.CreateInDbParameter("@BorrowYN", DbType.Int32, Convert.ToInt32(ht["BorrowYN"])));
                }
                DataSet ds = base.GetListByPage("(" + sbSql4org.ToString() + ")", "", "UseStatus,T.ID desc", Convert.ToInt32(ht["StartIndex"].ToString()), Convert.ToInt32(ht["EndIndex"].ToString()), List.ToArray());
                int RowCount = base.GetRecordCount("(" + sbSql4org.ToString() + ") T", "", List.ToArray());
                ht.Add("RowCount", RowCount);
                return ds.Tables[0];

            }
            catch (Exception ex)
            {
                //写入日志
                //throw;
                return null;
            }
        }

        #region 获得设备详情信息
        /// <summary>
        /// 获得设备详情信息
        /// </summary>
        /// <param name="ht">查询条件</param>
        /// <returns>Model的List集合</returns>
        public DataTable GetEquipDetail(Hashtable ht)
        {
            try
            {
                StringBuilder sbSql4org;

                sbSql4org = new StringBuilder();
                sbSql4org.Append(" select a.*,b.Name as ClassName,room.name as WarehouseName from EquipDetail a ");
                sbSql4org.Append(" left join Building room on a.StorageLocation=convert(varchar(50) ,room.id)  ");
                sbSql4org.Append(" left join InstrumentEquip b on a.EquipKindId=b.Id ");
                sbSql4org.Append(" where 1=1 ");
                List<DbParameter> List = new List<DbParameter>();
                if (ht.ContainsKey("Id"))
                {
                    sbSql4org.Append(" and a.Id=@Id ");
                    List.Add(dbHelper.CreateInDbParameter("@Id", DbType.Int32, Convert.ToInt32(ht["Id"].ToString())));
                }
                if (ht.ContainsKey("EquipKindId"))
                {
                    sbSql4org.Append(" and a.EquipKindId=@EquipKindId ");
                    List.Add(dbHelper.CreateInDbParameter("@EquipKindId", DbType.Int32, Convert.ToInt32(ht["EquipKindId"].ToString())));
                }
                if (ht.ContainsKey("AssetName") && !string.IsNullOrWhiteSpace(ht["AssetName"].ToString()))
                {
                    sbSql4org.Append(" and a.AssetName like N'%'+@AssetName+'%' ");
                    List.Add(dbHelper.CreateInDbParameter("@AssetName", DbType.String, ht["AssetName"].ToString()));
                }
                if (ht.ContainsKey("Creator"))
                {
                    sbSql4org.Append(" and a.Creator=@Creator ");
                    List.Add(dbHelper.CreateInDbParameter("@Creator", DbType.String, ht["Creator"].ToString()));
                }

                if (ht.ContainsKey("IsDelete"))
                {
                    if (string.IsNullOrWhiteSpace(ht["IsDelete"].ToString()))
                    {
                        sbSql4org.Append(" and a.IsDelete <> 1 ");
                    }
                    else
                    {
                        sbSql4org.Append(" and a.IsDelete = @IsDelete ");
                        List.Add(dbHelper.CreateInDbParameter("@IsDelete", DbType.Int32, Convert.ToInt32(ht["IsDelete"])));
                    }
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
                DataSet ds = dbHelper.ExecuteQuery(CommandType.Text,ht["sql"].ToString(), (DbParameter[])(ht["DbParameter"]));
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

        #region 根据条形码得到一个对象实体
        /// <summary>
        /// 根据条形码得到一个对象实体
        /// </summary>
        public EmsModel.EquipDetail GetModelByBarcode(string ID)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();
            sbSql4org.Append("SELECT * FROM EquipDetail");
            sbSql4org.Append(" WHERE Barcode=@in_Barcode");

            EmsModel.EquipDetail model = new EmsModel.EquipDetail();
            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@in_Barcode", DbType.String,ID)};
            using (DbDataReader dr = dbHelper.ExecuteReader(CommandType.Text, sbSql4org.ToString(), parms4org))
            {
                if (dr.Read())
                {
                    DbDataReaderToModel(model, dr);
                    return model;
                }
                return null;
            }
        }
        #endregion

        #region 根据楼房id/楼层id/房间id，判断房间是否已存放仪器
        /// <summary>
        /// 根据楼房id/楼层id/房间id，判断房间是否已存放仪器
        /// </summary>
        public bool IsHasEquipByRoomIds(string buildid,string flag)
        {
            try
            {
                StringBuilder sbSql;
                DbParameter[] parms;
                string sql = string.Empty;
                if (flag == "build")
                {
                    sql = @"select convert(varchar(50) ,Id) from Building where IsDelete=0 and PID in
                            (select Id from Building where PID=@Id )";
                }
                else if (flag == "layer")
                {
                    sql = @"select convert(varchar(50) ,Id) from Building where IsDelete=0 and PID=@Id";
                }
                else
                {
                    sql = "@Id";
                }
                sbSql = new StringBuilder();
                sbSql.Append("SELECT COUNT(1) FROM EquipDetail");
                sbSql.Append(" where IsDelete=0 and StorageLocation in (" + sql + ") ");
                parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@Id", DbType.String,buildid),
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

        #region 根据Id得到一个对象实体
        /// <summary>
        /// 根据Id得到一个对象实体
        /// </summary>
        public EmsModel.EquipDetail GetEmsModel(int? ID)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();
            sbSql4org.Append("SELECT * FROM EquipDetail");
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
        public DataTable GetListByPageAndEquipId(Hashtable ht, bool ispage = true)
        {
            try
            {
                StringBuilder sbSql4org = new StringBuilder();
                sbSql4org.Append("select his.* from  ");
                sbSql4org.Append(@" (select oed.EquipId,oed.Count,oi.LoanName as UserIDCard,oed.LendTime,'借出' as Type,oed.Remarks from OrderEquipDetail oed 
                                 left join OrderInfo  oi on oi.Id=oed.OrderId where EquipId=@EquipId");
                sbSql4org.Append(" union ");
                sbSql4org.Append(@" select EquipKindId as EquipId,Count,Creator as UserIDCard,CreateTime as LendTime,'入库' as Type,'' as  Remarks
                                 from EquipInto where EquipKindId=@EquipId)his ");
                sbSql4org.Append(" where 1=1 ");
                List<DbParameter> List = new List<DbParameter>();                
                if (ht.ContainsKey("EquipId") && !string.IsNullOrEmpty(ht["EquipId"].ToString()))
                {
                    sbSql4org.Append("  and his.EquipId=@EquipId  ");
                    List.Add(dbHelper.CreateInDbParameter("@EquipId", DbType.String, ht["EquipId"].ToString()));
                }
                DataSet ds = base.GetListByPage("(" + sbSql4org.ToString() + ")", "", "LendTime desc ", Convert.ToInt32(ht["StartIndex"] ?? "1"), Convert.ToInt32(ht["EndIndex"] ?? "10"), List.ToArray(), ispage);
                int RowCount = base.GetRecordCount("(" + sbSql4org.ToString() + ") T", "", List.ToArray());
                ht.Add("RowCount", RowCount);
                return ds.Tables[0];

            }
            catch (Exception ex)
            {
                //写入日志
                //throw;
                return null;
            }
        }
        #endregion

        #region 判断耗材是否已存在
        /// <summary>
        /// 判断耗材是否已存在
        /// </summary>
        public bool IsInsEpExists(string name,byte type,Int32 Id)
        {
            try
            {
                StringBuilder sbSql;
                DbParameter[] parms;
                sbSql = new StringBuilder();
                sbSql.Append("SELECT COUNT(1) FROM EquipDetail");
                sbSql.Append(" where IsDelete=0 and Type=@Type and AssetName=@AssetName and IsConsume=1");
                if (Id != 0)
                {
                    sbSql.Append(" and Id!=@Id ");
                }
                parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@AssetName", DbType.String,name),
                            dbHelper.CreateInDbParameter("@Type", DbType.Byte,type),
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

        #region 获取办公家具的负责人
        /// <summary>
        /// 获取办公家具的负责人
        /// </summary>  
        public DataTable GetOfficeFurOwner()
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;

            sbSql4org = new StringBuilder();
            sbSql4org.Append(@"select distinct ed.EquipOwner as OwnerUID from EquipDetail ed                              
                                where ed.Type=@Type and ed.EquipOwner is not null ");
            sbSql4org.Append(" order by ed.EquipOwner desc");
            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@Type", DbType.String, "2")};
            return dbHelper.ExecuteQuery(CommandType.Text, sbSql4org.ToString(), parms4org).Tables[0];
        }
        #endregion

        public List<EmsModel.EquipDetail> GetEmsModelExperimentId(string ID)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();
            sbSql4org.Append(" SELECT * FROM [dbo].[EquipDetail] WHERE id IN( ");
            sbSql4org.Append(" SELECT EQUIPID FROM OrderEquipDetail ");
            sbSql4org.Append(" WHERE orderid= (select id from OrderInfo where experimentId=@in_ID) )");

            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@in_ID", DbType.String,ID)};
            using (DbDataReader dr = dbHelper.ExecuteReader(CommandType.Text, sbSql4org.ToString(), parms4org))
            {
                List<EmsModel.EquipDetail> lst = GetList(dr);
                return lst;
            }
        }
        public List<EmsModel.EquipDetail> GetEmsModelExperimentId(string ID,string type)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();
            sbSql4org.Append(" SELECT * FROM [dbo].[EquipDetail] WHERE id IN( ");
            sbSql4org.Append(" SELECT EQUIPID FROM OrderEquipDetail ");
            sbSql4org.Append(" WHERE orderid= (select id from OrderInfo where experimentId=@in_ID) and type=@in_Type)");

            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@in_ID", DbType.String,ID),
            dbHelper.CreateInDbParameter("@in_Type", DbType.String,type)
            };
            using (DbDataReader dr = dbHelper.ExecuteReader(CommandType.Text, sbSql4org.ToString(), parms4org))
            {
                List<EmsModel.EquipDetail> lst = GetList(dr);
                return lst;
            }
        }


        #region -------- 私有方法 --------
        #region 由一行数据得到一个实体
        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private EmsModel.EquipDetail GetEmsModel(DbDataReader dr)
        {
            EmsModel.EquipDetail EmsModel = new EmsModel.EquipDetail();
            DbDataReaderToModel(EmsModel, dr);

            return EmsModel;
        }
        #endregion

        #region 由DbDataReader得到泛型数据列表
        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<EmsModel.EquipDetail> GetList(DbDataReader dr)
        {
            List<EmsModel.EquipDetail> lst = new List<EmsModel.EquipDetail>();
            while (dr.Read())
            {
                lst.Add(GetEmsModel(dr));
            }
            return lst;
        }
        #endregion

        #region 由DataTable得到泛型数据列表
        /// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        internal List<EmsModel.EquipHistory> GetListJoin(DataTable dt)
        {
            List<EmsModel.EquipHistory> lst = new List<EmsModel.EquipHistory>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.EquipHistory mod = new EmsModel.EquipHistory();
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
        internal void DataRowToModelJoin(EmsModel.EquipHistory EmsModel, DataRow dr)
        {
            EmsModel.EquipId = dr["EquipId"] as int?; EmsModel.UserName = dr["UserName"] as string;
            EmsModel.UserIDCard = dr["UserIDCard"] as string; EmsModel.LendTime = dr["LendTime"] as DateTime?;
            EmsModel.Count = dr["Count"] as int?; EmsModel.Type = dr["Type"] as string; EmsModel.Remarks = dr["Remarks"] as string;           
        }
        #endregion
        #endregion

        /// <summary>
        /// 分页查询库存情况
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public DataTable GetListStock(Hashtable ht)
        {
            try
            {
                StringBuilder sbSql4org = new StringBuilder();
                sbSql4org.Append(" select AssetsClassName,IsConsume,count(*) as Total,Unit from EquipDetail  ");
                sbSql4org.Append(" where IsDelete <>1 ");

                List<DbParameter> List = new List<DbParameter>();
                if (ht.Contains("AssetsClassName") && !string.IsNullOrWhiteSpace(ht["AssetsClassName"].ToString()))
                {
                    sbSql4org.Append(" and AssetsClassName like N'%'+@AssetsClassName+'%' ");
                    List.Add(dbHelper.CreateInDbParameter("@AssetsClassName", DbType.String, ht["AssetsClassName"].ToString()));
                }
                if (ht.Contains("Type") && !string.IsNullOrWhiteSpace(ht["Type"].ToString()))
                {
                    sbSql4org.Append(" and Type = @Type ");
                    List.Add(dbHelper.CreateInDbParameter("@Type", DbType.Int32, Convert.ToInt32(ht["Type"].ToString())));
                }
                sbSql4org.Append(" group by AssetsClassName,IsConsume,Unit ");

                DataSet ds = base.GetListByPage(" (" + sbSql4org.ToString() + ") ", "", "AssetsClassName", Convert.ToInt32(ht["StartIndex"].ToString()), Convert.ToInt32(ht["EndIndex"].ToString()), List.ToArray());

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

        /// <summary>
        /// 分页查询科研设备信息
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public DataTable GetListStock2(Hashtable ht)
        {
            try
            {
                StringBuilder sbSql4org = new StringBuilder();
                sbSql4org.Append(" select AssetsClassName,IsConsume,count(*) as Total,Unit from EquipDetail a ");
                sbSql4org.Append(" left join Building b on a.StorageLocation=convert(varchar(50) ,b.id) ");
                sbSql4org.Append(" left join SectionPlace c on b.SectionPlaceId=c.Id ");
                sbSql4org.Append(" where a.IsDelete <>1 and a.Type='1' ");

                List<DbParameter> List = new List<DbParameter>();
                if (ht.Contains("AssetsClassName") && !string.IsNullOrWhiteSpace(ht["AssetsClassName"].ToString()))
                {
                    sbSql4org.Append(" and a.AssetsClassName like N'%'+@AssetsClassName+'%' ");
                    List.Add(dbHelper.CreateInDbParameter("@AssetsClassName", DbType.String, ht["AssetsClassName"].ToString()));
                }
                if (ht.Contains("LoginUserIDCard"))
                {
                    sbSql4org.Append(" and (c.Director = @LoginUserIDCard or c.ViceDirector = @LoginUserIDCard)");
                    List.Add(dbHelper.CreateInDbParameter("@LoginUserIDCard", DbType.String, ht["LoginUserIDCard"].ToString()));
                }
                if (ht.Contains("StorageLocation") && !string.IsNullOrWhiteSpace(ht["StorageLocation"].ToString()))
                {
                    if (ht["StorageLocation"].ToString() == "0")
                    {
                        sbSql4org.Append(" and (a.StorageLocation = '0' or a.StorageLocation = null)");
                    }
                    if (ht["StorageLocation"].ToString() == "1")
                    {
                        sbSql4org.Append(" and a.StorageLocation != '0' and a.StorageLocation != null");
                    }
                }
                if (ht.Contains("SectionPlaceID") && !string.IsNullOrWhiteSpace(ht["SectionPlaceID"].ToString()))
                {
                    sbSql4org.Append(" and c.Id = @SectionPlaceID");
                    List.Add(dbHelper.CreateInDbParameter("@SectionPlaceID", DbType.Int32, Convert.ToInt32(ht["SectionPlaceID"].ToString())));
                }
                if (ht.Contains("Building") && !string.IsNullOrWhiteSpace(ht["Building"].ToString()))
                {
                    sbSql4org.Append(" and b.Id = @Building");
                    List.Add(dbHelper.CreateInDbParameter("@Building", DbType.Int32, Convert.ToInt32(ht["Building"].ToString())));
                }
                sbSql4org.Append(" group by AssetsClassName,IsConsume,Unit ");

                DataSet ds = base.GetListByPage(" (" + sbSql4org.ToString() + ") ", "", "AssetsClassName", Convert.ToInt32(ht["StartIndex"].ToString()), Convert.ToInt32(ht["EndIndex"].ToString()), List.ToArray());

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

        /// <summary>
        /// 分页查询库存情况
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int GetDataCount(Hashtable ht)
        {
            try
            {
                StringBuilder sbSql4org = new StringBuilder();
                sbSql4org.Append(" select SUM(Count) from EquipDetail  ");
                sbSql4org.Append(" where 1=1 ");

                List<DbParameter> List = new List<DbParameter>();
                if (ht.Contains("AssetsClassName") && !string.IsNullOrWhiteSpace(ht["AssetsClassName"].ToString()))
                {
                    sbSql4org.Append(" and AssetsClassName like N'%'+@AssetsClassName+'%' ");
                    List.Add(dbHelper.CreateInDbParameter("@AssetsClassName", DbType.String, ht["AssetsClassName"].ToString()));
                }
                if (ht.Contains("Type") && !string.IsNullOrWhiteSpace(ht["Type"].ToString()))
                {
                    sbSql4org.Append(" and Type = @Type ");
                    List.Add(dbHelper.CreateInDbParameter("@Type", DbType.Int32, Convert.ToInt32(ht["Type"].ToString())));
                }
                if (ht.ContainsKey("IsDelete"))
                {
                    if (string.IsNullOrWhiteSpace(ht["IsDelete"].ToString()))
                    {
                        sbSql4org.Append(" and IsDelete <> 1 ");
                    }
                    else
                    {
                        sbSql4org.Append(" and IsDelete = @IsDelete ");
                        List.Add(dbHelper.CreateInDbParameter("@IsDelete", DbType.Int32, Convert.ToInt32(ht["IsDelete"])));
                    }
                }
                object obj = dbHelper.ExecuteScalar(CommandType.Text, sbSql4org.ToString(), List.ToArray());
                return Convert.ToInt32(obj);

            }
            catch (Exception)
            {
                //写入日志
                throw;
            }
        }

        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="ht">查询条件</param>
        /// <returns>Model的List集合</returns>
        public DataTable ExportEquip(Hashtable ht)
        {
            try
            {
                if (!ht.Contains("ColumnsName") || string.IsNullOrWhiteSpace(ht["ColumnsName"].ToString()))
                {
                    #region MyRegion

                    string ColumnsName = @"[AssetNumber]
                              ,[EquipStatus]
                              ,[Type]
                              ,[Barcode]
                              ,[ImageName]
                              ,[Count]
                              ,[ClassNumber]
                              ,[AssetsClassName]
                              ,[IntlClassCode]
                              ,[IntlClassName]
                              ,[AssetName]
                              ,[Unit]
                              ,[UsageStatus]
                              ,[UsageDirection]
                              ,[JYBBBSYFX]
                              ,[AcquisitionMethod]
                              ,[AcquisitionDate]
                              ,[BrandStandardModel]
                              ,[EquipmentUse]
                              ,[UseDepartment]
                              ,[UsePeople]
                              ,[Factory]
                              ,[WorthType]
                              ,[UseNature]
                              ,[Worth]
                              ,[FinanceRecordType]
                              ,[FiscalFunds]
                              ,[NonFiscalFunds]
                              ,[FinanceRecordDate]
                              ,[VoucherNumber]
                              ,[UseTime]
                              ,[ExpectedScrapDate]
                              ,[DepreciationState]
                              ,[NetWorth]
                              ,[OutFactoryNumber]
                              ,[Supplier]
                              ,[FundsSubject]
                              ,[PurchaseModality]
                              ,[CountryCode]
                              ,[Operator]
                              ,[GuaranteeEndDate]
                              ,[EquipmentNumber]
                              ,[InvoiceNumber]
                              ,[CompactNumber]
                              ,[BasicFunds]
                              ,[ItemFunds1]
                              ,[ItemFunds2]
                              ,[ItemFunds3]
                              ,[ItemFunds4]
                              ,[ItemFundsMoney1]
                              ,[ItemFundsMoney2]
                              ,[ItemFundsMoney3]
                              ,[ItemFundsMoney4]
                              ,[Remarks]
                              ,[UseStatus]
                              ,[StorageLocation1]
                              ,[IsConsume]
                              ,[EquipSource]
                              ,[EquipOwner]";

                    #endregion
                    ht["ColumnsName"] = ColumnsName;
                }
                StringBuilder sbSql4org = new StringBuilder();
                sbSql4org.Append(" select " + ht["ColumnsName"].ToString() + " from EquipDetail ");
                sbSql4org.Append(" where 1=1 ");
                List<DbParameter> List = new List<DbParameter>();
                if (ht.ContainsKey("Id"))
                {
                    sbSql4org.Append(" and Id=@Id ");
                    List.Add(dbHelper.CreateInDbParameter("@Id", DbType.Int32, Convert.ToInt32(ht["Id"].ToString())));
                }
                if (ht.ContainsKey("EquipSource") && !string.IsNullOrWhiteSpace("EquipSource"))
                {
                    sbSql4org.Append(" and EquipSource=@EquipSource ");
                    List.Add(dbHelper.CreateInDbParameter("@EquipSource", DbType.Int32, Convert.ToInt32(ht["EquipSource"].ToString())));
                }
                if (ht.ContainsKey("ClassName") && !string.IsNullOrWhiteSpace("ClassName"))
                {
                    sbSql4org.Append(" and ClassName=@ClassName ");
                    List.Add(dbHelper.CreateInDbParameter("@ClassName", DbType.String, ht["ClassName"].ToString()));
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
                sbSql.Append("SELECT COUNT(1) FROM EquipDetail");
                sbSql.Append(" where 1=1 ");
                if (ht.Contains("AssetNumber"))
                {
                    sbSql.Append(" and AssetNumber=@AssetNumber ");
                    list.Add(dbHelper.CreateInDbParameter("@AssetNumber", DbType.String, ht.Contains("AssetNumber").ToString()));
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

        /// <summary>
        /// 修改状态
        /// </summary>
        public bool UpdateStatus(Hashtable ht)
        {
            try
            {
                List<DbParameter> list = new List<DbParameter>();
                StringBuilder sbSql = new StringBuilder();
                sbSql.Append("update EquipDetail set EquipStatus=@EquipStatus");
                sbSql.Append(" where Id=@Id ");

                list.Add(dbHelper.CreateInDbParameter("@Id", DbType.Int32, Convert.ToInt32(ht["Id"].ToString())));
                list.Add(dbHelper.CreateInDbParameter("@EquipStatus", DbType.Int32, Convert.ToInt32(ht["EquipStatus"].ToString())));
                object obj = dbHelper.ExecuteNonQuery(CommandType.Text, sbSql.ToString(), list.ToArray());
                return int.Parse(obj.ToString()) > 0;
            }
            catch (Exception)
            {
                //写入日志
                //throw;
                return false;
            }
        }
    }
}
