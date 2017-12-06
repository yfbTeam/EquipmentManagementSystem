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
    public partial class InstrumentEquip : DALHelper
    {
        /// <summary>
        /// 查询根据条件
        /// </summary>
        /// <param name="ht">查询条件</param>
        /// <returns>Model的List集合</returns>
        public List<EmsModel.InstrumentEquip> GetList(Hashtable ht)
        {
            try
            {
                ht = Dispose(ht);

                DataSet ds = base.GetListByPage(" (" + ht["sql"].ToString() + ") ", "", "", Convert.ToInt32(ht["StartIndex"].ToString()), Convert.ToInt32(ht["EndIndex"].ToString()), (DbParameter[])(ht["DbParameter"]));
                return GetList(ds.Tables[0]);

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
                ht = Dispose(ht);
                return base.GetRecordCount(" (" + ht["sql"].ToString() + ") T", "", (DbParameter[])(ht["DbParameter"]));
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// SQL分类列表
        /// </summary>
        /// <param name="ht"></param>
        /// <returns>参数值</returns>
        private Hashtable Dispose(Hashtable ht)
        {
            try
            {
                StringBuilder sbSql4org = new StringBuilder();
                sbSql4org.Append(" SELECT * FROM InstrumentEquip ");
                sbSql4org.Append(" where 1=1 ");

                List<DbParameter> List = new List<DbParameter>();
                if (ht.ContainsKey("Id"))
                {
                    sbSql4org.Append(" and Id = @Id ");
                    List.Add(dbHelper.CreateInDbParameter("@Id", DbType.Int32, Convert.ToInt32(ht["Id"].ToString())));
                }
                if (ht.ContainsKey("Name") && !string.IsNullOrWhiteSpace(ht["Name"].ToString()))
                {
                    sbSql4org.Append(" and Name like N'%'+@Name+'%' ");
                    List.Add(dbHelper.CreateInDbParameter("@Name", DbType.String, ht["Name"].ToString()));
                }
                if (ht.ContainsKey("Number") && !string.IsNullOrWhiteSpace(ht["Number"].ToString()))
                {
                    sbSql4org.Append(" and Number = @Number ");
                    List.Add(dbHelper.CreateInDbParameter("@Number", DbType.String, ht["Number"].ToString()));
                }
                if (ht.ContainsKey("Model") && !string.IsNullOrWhiteSpace(ht["Model"].ToString()))
                {
                    sbSql4org.Append(" and Model = @Model ");
                    List.Add(dbHelper.CreateInDbParameter("@Model", DbType.String,ht["Model"].ToString()));
                }
                if (ht.ContainsKey("IsDelete"))
                {
                    if (string.IsNullOrWhiteSpace(ht["IsDelete"].ToString()))
                    {
                        sbSql4org.Append(" and IsDelete <> 1 ");
                    }
                    else
                    {
                        sbSql4org.Append(" and IsDelete = @IsDelete  ");
                        List.Add(dbHelper.CreateInDbParameter("@IsDelete", DbType.Int32, Convert.ToInt32(ht["IsDelete"].ToString())));
                    }
                }
                if (ht.ContainsKey("UseStatus"))
                {
                    if (string.IsNullOrWhiteSpace(ht["UseStatus"].ToString()))
                    {
                        sbSql4org.Append(" and UseStatus = 0 ");
                    }
                    else
                    {
                        sbSql4org.Append(" and UseStatus = @UseStatus  ");
                        List.Add(dbHelper.CreateInDbParameter("@UseStatus", DbType.Int32, Convert.ToInt32(ht["UseStatus"].ToString())));
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

            }
            catch (Exception)
            {
                //写入日志
                //throw;
            }
            return ht;
        }

        #region 分页查询库存情况

        /// <summary>
        /// SQL分类列表
        /// </summary>
        /// <param name="ht"></param>
        /// <returns>参数值</returns>
        private Hashtable DisposeStock(Hashtable ht)
        {
            try
            {
                StringBuilder sbSql4org = new StringBuilder();
                sbSql4org.Append(" select a.*,b.Name as WarehouseName,ISNULL(c.WJCCount,'0') as WJCCount,ISNULL(d.YJCCount,'0') as YJCCount from InstrumentEquip a ");
                sbSql4org.Append(" left join Warehouse b on a.WarehouseId=b.Id ");
                sbSql4org.Append(" left join ");
                sbSql4org.Append(" (select EquipKindId,Count(*) as WJCCount from EquipDetail where EquipStatus<>1 group by EquipKindId) c on a.Id=c.EquipKindId ");
                sbSql4org.Append(" left join  ");
                sbSql4org.Append(" (select EquipKindId,Count(*) as YJCCount from EquipDetail where EquipStatus=1 group by EquipKindId) d on a.Id=d.EquipKindId ");
                sbSql4org.Append(" where 1=1 ");

                List<DbParameter> List = new List<DbParameter>();
                if (ht.ContainsKey("Id"))
                {
                    sbSql4org.Append(" and a.Id = @Id ");
                    List.Add(dbHelper.CreateInDbParameter("@Id", DbType.Int32, Convert.ToInt32(ht["Id"].ToString())));
                }
                if (ht.ContainsKey("Name") && !string.IsNullOrWhiteSpace(ht["Name"].ToString()))
                {
                    sbSql4org.Append(" and a.Name like N'%'+@Name+'%' ");
                    List.Add(dbHelper.CreateInDbParameter("@Name", DbType.String, ht["Name"].ToString()));
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
                        List.Add(dbHelper.CreateInDbParameter("@IsDelete", DbType.Int32, Convert.ToInt32(ht["IsDelete"].ToString())));
                    }
                }
                if (ht.ContainsKey("WarehouseId") && !string.IsNullOrWhiteSpace(ht["WarehouseId"].ToString()))
                {
                    sbSql4org.Append(" and a.WarehouseId = @WarehouseId  ");
                    List.Add(dbHelper.CreateInDbParameter("@WarehouseId", DbType.Int32,  Convert.ToInt32(ht["WarehouseId"].ToString())));
                }
                if (ht.ContainsKey("Number") && !string.IsNullOrWhiteSpace(ht["Number"].ToString()))
                {
                    sbSql4org.Append(" and a.Number = @Number ");
                    List.Add(dbHelper.CreateInDbParameter("@Number", DbType.String, ht["Number"].ToString()));
                }
                if (ht.ContainsKey("Model") && !string.IsNullOrWhiteSpace(ht["Model"].ToString()))
                {
                    sbSql4org.Append(" and a.Model = @Model ");
                    List.Add(dbHelper.CreateInDbParameter("@Model", DbType.String, ht["Model"].ToString()));
                }
                if (ht.ContainsKey("Type") && !string.IsNullOrWhiteSpace(ht["Type"].ToString()))
                {
                    sbSql4org.Append(" and a.Type = @Type  ");
                    List.Add(dbHelper.CreateInDbParameter("@Type", DbType.Int32, Convert.ToInt32(ht["Type"].ToString())));
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
                //throw;
            }
            return ht;
        }
        /// <summary>
        /// 分页查询库存情况
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public DataTable GetListStock(Hashtable ht)
        {
            try
            {
                ht = DisposeStock(ht);

                DataSet ds = base.GetListByPage(" (" + ht["sql"].ToString() + ") ", "", "", Convert.ToInt32(ht["StartIndex"].ToString()), Convert.ToInt32(ht["EndIndex"].ToString()), (DbParameter[])(ht["DbParameter"]));
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
        /// 获得总条数
        /// </summary>
        /// <param name="ht">查询条件</param>
        /// <returns>总条数</returns>
        public int GetListByPageCountStock(Hashtable ht)
        {
            try
            {
                ht = DisposeStock(ht);
                return base.GetRecordCount(" (" + ht["sql"].ToString() + ") T", "", (DbParameter[])(ht["DbParameter"]));
            }
            catch
            {
                return 0;
            }
        }

        #endregion

        /// <summary>
        /// 获得分类详情
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public DataTable GetIEDetails(Hashtable ht)
        {
            try
            {
                StringBuilder sbSql4org = new StringBuilder();
                sbSql4org.Append(" select a.*,b.Name as WarehouseName from InstrumentEquip a ");
                sbSql4org.Append(" left join Warehouse b on a.WarehouseId =b.Id ");
                sbSql4org.Append(" where 1=1 ");

                List<DbParameter> List = new List<DbParameter>();
                if (ht.ContainsKey("Id"))
                {
                    sbSql4org.Append(" and a.Id = @Id ");
                    List.Add(dbHelper.CreateInDbParameter("@Id", DbType.Int32, Convert.ToInt32(ht["Id"].ToString())));
                }
                //if (ht.ContainsKey("Name") && !string.IsNullOrWhiteSpace(ht["Name"].ToString()))
                //{
                //    sbSql4org.Append(" and a.Name like N'%'+@Name+'%' ");
                //    List.Add(dbHelper.CreateInDbParameter("@Name", DbType.String, ht["Name"].ToString()));
                //}
                if (ht.ContainsKey("IsDelete"))
                {
                    if (string.IsNullOrWhiteSpace(ht["IsDelete"].ToString()))
                    {
                        sbSql4org.Append(" and a.IsDelete <> 1 ");
                    }
                    else
                    {
                        sbSql4org.Append(" and a.IsDelete = @IsDelete ");
                        List.Add(dbHelper.CreateInDbParameter("@IsDelete", DbType.Int32, Convert.ToInt32(ht["IsDelete"].ToString())));
                    }
                }
                //if (ht.ContainsKey("WarehouseId") && !string.IsNullOrWhiteSpace(ht["WarehouseId"].ToString()))
                //{
                //    sbSql4org.Append(" and a.WarehouseId  = @WarehouseId  ");
                //    List.Add(dbHelper.CreateInDbParameter("@WarehouseId", DbType.Int32, Convert.ToInt32(ht["WarehouseId"].ToString())));
                //}
                //if (ht.ContainsKey("Number") && !string.IsNullOrWhiteSpace(ht["Number"].ToString()))
                //{
                //    sbSql4org.Append(" and a.Number = @Number ");
                //    List.Add(dbHelper.CreateInDbParameter("@Number", DbType.String, ht["Number"].ToString()));
                //}
                //if (ht.ContainsKey("Model") && !string.IsNullOrWhiteSpace(ht["Model"].ToString()))
                //{
                //    sbSql4org.Append(" and a.Model = @Model ");
                //    List.Add(dbHelper.CreateInDbParameter("@Model", DbType.String, ht["Model"].ToString()));
                //}

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

        #region 获取泛型数据列表 分页
        ///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public List<EmsModel.InstrumentEquip> GetListByPageAndWareid(EmsModel.InstrumentEquip EmsMod,int startIndex, int endIndex, string joinStr,string selwareid)
        {
            string sql = GetListSql();
            //条件
            string strWhere = "";
            //排序
            string orderby = "UseStatus,T.ID desc ";
            //参数
            List<DbParameter> parmsList = new List<DbParameter>();
            if (!string.IsNullOrEmpty(selwareid)) { strWhere += " and inse.WarehouseId=@sel_WarehouseId "; parmsList.Add(dbHelper.CreateInDbParameter("@sel_WarehouseId", DbType.String, selwareid)); }
            if (EmsMod.Number != null) { strWhere += " and inse.Number=@in_Number "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Number", DbType.String, EmsMod.Number)); } if (EmsMod.Name != null) { strWhere += " and inse.Name like '%'+@in_Name+'%' "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); } if (EmsMod.Model != null) { strWhere += " and inse.Model like '%'+@in_Model+'%' "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Model", DbType.String, EmsMod.Model)); } if (EmsMod.Count != null) { strWhere += " and inse.Count=@in_Count "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Count", DbType.String, EmsMod.Count)); } if (EmsMod.Unit != null) { strWhere += " and inse.Unit=@in_Unit "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Unit", DbType.String, EmsMod.Unit)); } if (EmsMod.Type != null) { strWhere += " and inse.Type=@in_Type "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Type", DbType.String, EmsMod.Type)); } if (EmsMod.WarehouseId != null) { strWhere += " and inse.WarehouseId " + joinStr + "@in_WarehouseId "; parmsList.Add(dbHelper.CreateInDbParameter("@in_WarehouseId", DbType.String, EmsMod.WarehouseId)); } if (EmsMod.Company != null) { strWhere += " and inse.Company=@in_Company "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Company", DbType.String, EmsMod.Company)); } if (EmsMod.Remarks != null) { strWhere += " and inse.Remarks=@in_Remarks "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); } if (EmsMod.Creator != null) { strWhere += " and inse.Creator=@in_Creator "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); } if (EmsMod.CreateTime != null) { strWhere += " and inse.CreateTime=@in_CreateTime "; parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); } if (EmsMod.Editor != null) { strWhere += " and inse.Editor=@in_Editor "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); } if (EmsMod.UpdateTime != null) { strWhere += " and inse.UpdateTime=@in_UpdateTime "; parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); } if (EmsMod.IsDelete != null) { strWhere += " and inse.IsDelete=@in_IsDelete "; parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); } if (EmsMod.UseStatus != null) { strWhere += " and UseStatus=@in_UseStatus "; parmsList.Add(dbHelper.CreateInDbParameter("@in_UseStatus", DbType.String, EmsMod.UseStatus)); }
            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;
            DataSet ds = GetListByPage(sql + strWhere, orderby, startIndex, endIndex, parms);
            return GetListJoin(ds.Tables[0]);
        }
        #endregion

        #region 获取列表的sql语句
        public string GetListSql()
        {
            StringBuilder sbSql4org = new StringBuilder();
            sbSql4org.Append("SELECT inse.*,wh.Name as WarehouseName ");
            sbSql4org.Append(" FROM InstrumentEquip inse");
            sbSql4org.Append(" left join Warehouse wh on inse.WarehouseId=wh.Id ");
            sbSql4org.Append(" where 1=1 ");
            return sbSql4org.ToString();
        }
        #endregion

        #region 获取列表总数量
        public int GetListByPageCountAndWareid(EmsModel.InstrumentEquip EmsMod,string joinStr,string selwareid)
        {
            string sql = GetListSql();
            string strWhere = "";

            List<DbParameter> parmsList = new List<DbParameter>();
            if (!string.IsNullOrEmpty(selwareid)) { strWhere += " and inse.WarehouseId=@sel_WarehouseId "; parmsList.Add(dbHelper.CreateInDbParameter("@sel_WarehouseId", DbType.String, selwareid)); }
            if (EmsMod.Number != null) { strWhere += " and inse.Number=@in_Number "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Number", DbType.String, EmsMod.Number)); } if (EmsMod.Name != null) { strWhere += " and inse.Name like '%'+@in_Name+'%' "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Name", DbType.String, EmsMod.Name)); } if (EmsMod.Model != null) { strWhere += " and inse.Model like '%'+@in_Model+'%' "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Model", DbType.String, EmsMod.Model)); } if (EmsMod.Count != null) { strWhere += " and inse.Count=@in_Count "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Count", DbType.String, EmsMod.Count)); } if (EmsMod.Unit != null) { strWhere += " and inse.Unit=@in_Unit "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Unit", DbType.String, EmsMod.Unit)); } if (EmsMod.Type != null) { strWhere += " and inse.Type=@in_Type "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Type", DbType.String, EmsMod.Type)); } if (EmsMod.WarehouseId != null) { strWhere += " and inse.WarehouseId " + joinStr + "@in_WarehouseId "; parmsList.Add(dbHelper.CreateInDbParameter("@in_WarehouseId", DbType.String, EmsMod.WarehouseId)); } if (EmsMod.Company != null) { strWhere += " and inse.Company=@in_Company "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Company", DbType.String, EmsMod.Company)); } if (EmsMod.Remarks != null) { strWhere += " and inse.Remarks=@in_Remarks "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Remarks", DbType.String, EmsMod.Remarks)); } if (EmsMod.Creator != null) { strWhere += " and inse.Creator=@in_Creator "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Creator", DbType.String, EmsMod.Creator)); } if (EmsMod.CreateTime != null) { strWhere += " and inse.CreateTime=@in_CreateTime "; parmsList.Add(dbHelper.CreateInDbParameter("@in_CreateTime", DbType.String, EmsMod.CreateTime)); } if (EmsMod.Editor != null) { strWhere += " and inse.Editor=@in_Editor "; parmsList.Add(dbHelper.CreateInDbParameter("@in_Editor", DbType.String, EmsMod.Editor)); } if (EmsMod.UpdateTime != null) { strWhere += " and inse.UpdateTime=@in_UpdateTime "; parmsList.Add(dbHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, EmsMod.UpdateTime)); } if (EmsMod.IsDelete != null) { strWhere += " and inse.IsDelete=@in_IsDelete "; parmsList.Add(dbHelper.CreateInDbParameter("@in_IsDelete", DbType.String, EmsMod.IsDelete)); } if (EmsMod.UseStatus != null) { strWhere += " and UseStatus=@in_UseStatus "; parmsList.Add(dbHelper.CreateInDbParameter("@in_UseStatus", DbType.String, EmsMod.UseStatus)); }

            DbParameter[] parms = parmsList.ToArray();//将参数集合转换为对应的数组;

            return GetRecordCount(sql+ strWhere, parms);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EmsModel.InstrumentEquip GetEmsModel(int? ID)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();
            sbSql4org.Append("SELECT * FROM InstrumentEquip");
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
        /// 得到一个对象实体
        /// </summary>
        public EmsModel.InstrumentEquip GetModelByNumber(string Number)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();
            sbSql4org.Append("SELECT * FROM InstrumentEquip");
            sbSql4org.Append(" WHERE Number=@in_Number");

            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@in_Number", DbType.String,Number)};
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

        #region 判断耗材是否已存在
        /// <summary>
        /// 判断耗材是否已存在
        /// </summary>
        public bool IsInsEpExists(string number, string name, string model, Int32 Id)
        {
            try
            {
                StringBuilder sbSql;
                DbParameter[] parms;
                sbSql = new StringBuilder();
                sbSql.Append("SELECT COUNT(1) FROM InstrumentEquip");
                sbSql.Append(" where IsDelete=0 and Number=@Number and Name=@Name and Model=@Model ");
                if (Id != 0)
                {
                    sbSql.Append(" and Id!=@Id ");
                }
                parms = new DbParameter[]{
                            dbHelper.CreateInDbParameter("@Number", DbType.String,number),
							dbHelper.CreateInDbParameter("@Name", DbType.String,name),
                            dbHelper.CreateInDbParameter("@Model", DbType.String,model),
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

        #region -------- 私有方法 --------

        #region 由DataTable得到泛型数据列表
        /// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        internal List<EmsModel.InstrumentEquip> GetListJoin(DataTable dt)
        {
            List<EmsModel.InstrumentEquip> lst = new List<EmsModel.InstrumentEquip>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.InstrumentEquip mod = new EmsModel.InstrumentEquip();
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
        internal void DataRowToModelJoin(EmsModel.InstrumentEquip EmsModel, DataRow dr)
        {
            EmsModel.Id = dr["Id"] as int?; EmsModel.Number = dr["Number"] as string; EmsModel.Name = dr["Name"] as string; EmsModel.Model = dr["Model"] as string; EmsModel.Count = dr["Count"] as int?; EmsModel.Unit = dr["Unit"] as string; EmsModel.Type = dr["Type"] as int?; EmsModel.WarehouseId = dr["WarehouseId"] as int?; EmsModel.Company = dr["Company"] as string; EmsModel.Remarks = dr["Remarks"] as string; EmsModel.Creator = dr["Creator"] as string; EmsModel.CreateTime = dr["CreateTime"] as DateTime?; EmsModel.Editor = dr["Editor"] as string; EmsModel.UpdateTime = dr["UpdateTime"] as DateTime?; EmsModel.IsDelete = dr["IsDelete"] as Byte?; EmsModel.UseStatus = dr["UseStatus"] as Byte?;
            EmsModel.WarehouseName = dr["WarehouseName"] as string; //额外添加的字段WarehouseName
            EmsModel.CreateName = dr["CreateName"] as string; //额外添加的字段CreateName            
        }
        #endregion

        #region 由一行数据得到一个实体
        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private EmsModel.InstrumentEquip GetEmsModel(DbDataReader dr)
        {
            EmsModel.InstrumentEquip EmsModel = new EmsModel.InstrumentEquip();
            DbDataReaderToModel(EmsModel, dr);

            return EmsModel;
        }
        #endregion

        #region 由DbDataReader得到泛型数据列表
        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<EmsModel.InstrumentEquip> GetList(DbDataReader dr)
        {
            List<EmsModel.InstrumentEquip> lst = new List<EmsModel.InstrumentEquip>();
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
