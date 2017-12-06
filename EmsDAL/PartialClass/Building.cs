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
    public partial class Building : DALHelper
    {
        #region 获得楼房信息
        /// <summary>
        /// 获得楼房信息
        /// </summary>  
        public DataTable GetBuildingInfo(string pid, string type)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;

            sbSql4org = new StringBuilder();
            if (!string.IsNullOrEmpty(type))
            {
                sbSql4org.Append(@"select distinct build.* from Building build
                                left join Building layer on layer.PID=build.Id
                                left join Building room on room.PID=layer.Id
                                where build.PID=0 and room.Id in(select distinct Id  from Building where type=@Type and RoomNo is not null)
                                order by build.Id desc");
            }
            else
            {
                sbSql4org.Append(@"select distinct * from Building where IsDelete=0 and PID=@PID ");
                sbSql4org.Append(" order by Id desc");
            }
            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@PID", DbType.String, pid),
                dbHelper.CreateInDbParameter("@Type", DbType.String, type)};
            return dbHelper.ExecuteQuery(CommandType.Text, sbSql4org.ToString(), parms4org).Tables[0];
        }
        #endregion

        #region 根据楼房id获得楼层及房间信息
        /// <summary>
        /// 根据楼房id获得楼层及房间信息
        /// </summary>  
        public DataTable GetLayersAndRoomsById(string buildid, string type, string secplaceid)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;

            sbSql4org = new StringBuilder();
            sbSql4org.Append("select * from( ");
            sbSql4org.Append(@"select distinct room.*,0 as numname from Building room
                               left join SectionPlace sec on sec.Id=room.SectionPlaceId
                               where room.IsDelete=0 and room.PID in (select Id from Building where PID=@Id) ");
            if (!string.IsNullOrEmpty(secplaceid))//科所id不为空
            {
                sbSql4org.Append(@" and room.type=1 and room.RoomNo is not null and room.SectionPlaceId=@SectionPlaceId ");
            }
            if (!string.IsNullOrEmpty(type))
            {
                sbSql4org.Append(@" and room.type=@Type and room.RoomNo is not null ");
            }
            sbSql4org.Append(@" union ");
            sbSql4org.Append(@" select distinct *,cast(Name as int) as numname from Building 
                                where IsDelete=0 and PID=@Id ");
            if (!string.IsNullOrEmpty(type))
            {
                sbSql4org.Append(@" and Id in
								(select distinct PID from Building where IsDelete=0 and type=@Type and RoomNo is not null and PID in
                                (select Id from Building where PID=@Id)) ");
            }
            sbSql4org.Append(")T order by numname desc,Id desc ");
            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@Id", DbType.String, buildid),
                dbHelper.CreateInDbParameter("@Type", DbType.String, type),
                dbHelper.CreateInDbParameter("@SectionPlaceId", DbType.String, secplaceid)};
            return dbHelper.ExecuteQuery(CommandType.Text, sbSql4org.ToString(), parms4org).Tables[0];
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EmsModel.Building GetEmsModel(int? ID)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();
            sbSql4org.Append(@"SELECT room.*,sec.Name as secName,sec.Director as Director,'' as secDirector FROM Building room 
                              left join SectionPlace sec on sec.Id=room.SectionPlaceId ");
            sbSql4org.Append(" WHERE room.ID=@in_ID");

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

        #region 判断某楼房或某楼房的楼层是否已存在
        /// <summary>
        /// 判断某楼房或某楼房的楼层是否已存在
        /// </summary>
        /// <param name="name">楼房/楼层名称</param>       
        /// <param name="Pid">0/楼房Id</param>
        /// <param name="Id">楼房/楼层Id</param>
        /// <returns></returns>
        public bool IsNameExists(string name, Int32 Pid, Int32 Id)
        {
            try
            {
                StringBuilder sbSql;
                DbParameter[] parms;
                sbSql = new StringBuilder();
                sbSql.Append("SELECT COUNT(1) FROM Building");
                sbSql.Append(" where IsDelete=0 and Name=@Name and PID=@PID ");
                if (Id != 0)
                {
                    sbSql.Append(" and Id!=@Id ");
                }
                parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@Name", DbType.String,name),
                            dbHelper.CreateInDbParameter("@PID",DbType.Int32,Pid),
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

        #region 判断某楼房的某楼层的房间是否已存在
        /// <summary>
        /// 判断某楼房的某楼层的房间是否已存在
        /// </summary>
        /// <param name="roomno">房间号</param>      
        /// <param name="Pid">楼层Id</param>
        /// <param name="PPid">楼房Id</param>
        /// <param name="Id">房间Id</param>
        /// <returns></returns>
        public bool IsNameExists(string roomno, Int32 Pid, Int32 PPid, Int32 Id)
        {
            try
            {
                StringBuilder sbSql;
                DbParameter[] parms;
                sbSql = new StringBuilder();
                sbSql.Append("SELECT COUNT(1) FROM Building sub");
                sbSql.Append(" left join Building par on sub.PID=par.Id ");
                sbSql.Append(" where sub.IsDelete=0 and sub.RoomNo=@RoomNo and sub.PID=@PID and par.PID=@PPID ");
                if (Id != 0)
                {
                    sbSql.Append(" and sub.Id!=@Id ");
                }
                parms = new DbParameter[]{
							dbHelper.CreateInDbParameter("@RoomNo", DbType.String,roomno),
                            dbHelper.CreateInDbParameter("@PID",DbType.Int32,Pid),
                            dbHelper.CreateInDbParameter("@PPID",DbType.Int32,PPid),
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

        #region 根据flag("build","layer","room")获得房间信息
        /// <summary>
        /// 根据flag("build","layer","room")获得房间信息
        /// </summary>  
        public DataTable GetRoomInfo(string buildid, string flag)
        {
            DbParameter[] parms4org;

            string sql = string.Empty;
            if (flag == "build")
            {
                sql = @"select Id from Building where PID in
                            (select Id from Building where PID=@Id )";
            }
            else if (flag == "layer")
            {
                sql = @"select Id from Building where PID=@Id";
            }
            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@Id", DbType.String, buildid)};
            return dbHelper.ExecuteQuery(CommandType.Text, sql, parms4org).Tables[0];
        }
        #endregion

        #region 批量修改 是否删除列
        /// <summary>
        /// 修改数据 可批量
        /// </summary>
        public int UpdateBatch(SqlTransaction trans, string buildid, string flag)
        {
            try
            {
                DbParameter[] parms;
                string sql = string.Empty;
                if (flag == "build")
                {
                    sql = @"update Building set IsDelete=1 where Id=@in_ID or PID in
                              (select Id from Building where PID=@in_ID or Id=@in_ID)";
                }
                else if (flag == "layer")
                {
                    sql = @"update Building set IsDelete=1 where PID=@in_ID or Id=@in_ID";
                }
                else
                {
                    sql = @"update Building set IsDelete=1 where Id=@in_ID";
                }
                parms = new DbParameter[]{
						dbHelper.CreateInDbParameter("@in_ID", DbType.Int32,Convert.ToInt32(buildid))};
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

        #region 根据类型获得房间信息
        /// <summary>
        /// 根据类型获得房间信息
        /// </summary>  
        public DataTable GetRoomInfoByType(string type)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;

            sbSql4org = new StringBuilder();
            sbSql4org.Append(@"select distinct room.*,build.Name+'-'+layer.Name+'层-'+room.RoomNo+'('+room.Name+')' as RoomName from  Building room 
                                left join Building layer on room.PID=layer.Id
                                left join Building build on layer.PID=build.Id
                                where room.RoomNo is not null ");
            if (!string.IsNullOrEmpty(type))
            {
                sbSql4org.Append(" and room.Type=@Type ");
            }
            sbSql4org.Append(" order by room.Id desc");
            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@Type", DbType.String, type)};
            return dbHelper.ExecuteQuery(CommandType.Text, sbSql4org.ToString(), parms4org).Tables[0];
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

        public int UpdateStorageLocationMore(Hashtable ht)
        {
            using (SqlTransaction trans = dbHelper.BeginTransaction())
            {
                try
                {
                    StringBuilder sbSql4org = new StringBuilder();
                    List<DbParameter> list = new List<DbParameter>();
                    if (string.IsNullOrWhiteSpace(Convert.ToString(ht["home"])))//移除
                        sbSql4org.Append("update EquipDetail set StorageLocation=0 where id in (");
                    else
                    {
                        sbSql4org.Append("update EquipDetail set StorageLocation=@home where id in (");
                        list.Add(dbHelper.CreateInDbParameter("@home", DbType.Int32, ht["home"]));
                    }
                    if (!string.IsNullOrWhiteSpace(ht["itemid"].ToString()))
                    {
                        var ids = ht["itemid"].ToString().Split(',');
                        var strsql = "";
                        for (int i = 0; i < ids.Length; i++)
                        {
                            strsql += "@itemid" + i + ",";
                            list.Add(dbHelper.CreateInDbParameter("@itemid" + i, DbType.Int32, ids[i]));
                        }
                        if (!string.IsNullOrWhiteSpace(strsql)) strsql = strsql.Substring(0, strsql.Length - 1);
                        sbSql4org.Append(strsql + ")");
                    }
                    int number = dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql4org.ToString(), list.ToArray());
                    if (number > 0)
                    {
                        trans.Commit();
                        return number;
                    }
                    else
                    {
                        trans.Rollback();
                        return -1;
                    }
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return -1;
                }

            }
        }

        #region -------- 私有方法 --------

        #region 由一行数据得到一个实体
        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private EmsModel.Building GetEmsModel(DbDataReader dr)
        {
            EmsModel.Building EmsModel = new EmsModel.Building();
            EmsModel.Id = dr["Id"] as int?; EmsModel.Name = dr["Name"] as string; EmsModel.PID = dr["PID"] as int?; EmsModel.Creator = dr["Creator"] as string; EmsModel.CreateTime = dr["CreateTime"] as DateTime?; EmsModel.Editor = dr["Editor"] as string; EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?; EmsModel.IsDelete = dr["IsDelete"] as Byte?; EmsModel.Remarks = dr["Remarks"] as string; EmsModel.RoomNo = dr["RoomNo"] as string; EmsModel.Type = dr["Type"] as Byte?; EmsModel.SectionPlaceId = dr["SectionPlaceId"] as int?;
            EmsModel.SecName = dr["SecName"] as string;//科所名称
            EmsModel.Director= dr["Director"] as string;
            EmsModel.SecDirector = dr["SecDirector"] as string;//科所
            return EmsModel;
        }
        #endregion

        #region 由DbDataReader得到泛型数据列表
        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<EmsModel.Building> GetList(DbDataReader dr)
        {
            List<EmsModel.Building> lst = new List<EmsModel.Building>();
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
