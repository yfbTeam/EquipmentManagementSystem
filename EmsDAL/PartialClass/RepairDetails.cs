using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace EmsDAL
{
    public partial class RepairDetails : DALHelper
    {
        public DataTable SelectRepairDetails(int ID)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();

            sbSql4org.Append(@"select * from  View_RepairList ");
            sbSql4org.Append(" where Id=@Id ");
            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("@Id",DbType.Int32, ID)
               };
            return dbHelper.ExecuteQuery(CommandType.Text, sbSql4org.ToString(), parms4org).Tables[0];
        }

        #region 获取泛型数据列表 分页
        ///<summary>
        ///获取泛型数据列表 分页
        /// </summary>
        public DataTable GetPage(Hashtable ht, bool ispage = true)
        {
            try
            {
                StringBuilder sbSql4org;
                sbSql4org = new StringBuilder();
                sbSql4org.Append(@" SELECT * FROM View_RepairList where 1=1 and IsDelete=0  ");
                List<DbParameter> List = new List<DbParameter>();
                if (ht.ContainsKey("ID") && !string.IsNullOrEmpty(ht["ID"].ToString()))
                {
                    sbSql4org.Append(" and ID=@ID ");
                    List.Add(dbHelper.CreateInDbParameter("@ID", DbType.String, ht["ID"].ToString()));
                }
                if (ht.ContainsKey("Name") && !string.IsNullOrEmpty(ht["Name"].ToString()))
                {
                    sbSql4org.Append(" and name like '%'+@Name+'%'  ");
                    List.Add(dbHelper.CreateInDbParameter("@Name", DbType.String, ht["Name"].ToString()));
                }
                if (ht.ContainsKey("RepairMan") && !string.IsNullOrEmpty(ht["RepairMan"].ToString()))
                {
                    sbSql4org.Append(" and RepairMan=@RepairMan ");
                    List.Add(dbHelper.CreateInDbParameter("@RepairMan", DbType.String, ht["RepairMan"].ToString()));
                }
                if (ht.ContainsKey("EquipID") && !string.IsNullOrEmpty(ht["EquipID"].ToString()))
                {
                    sbSql4org.Append(" and EquipID=@EquipID ");
                    List.Add(dbHelper.CreateInDbParameter("@EquipID", DbType.String, ht["EquipID"].ToString()));
                }
                if (ht.ContainsKey("RepairTime") && !string.IsNullOrEmpty(ht["RepairTime"].ToString()))
                {
                    sbSql4org.Append(" and RepairTime=@RepairTime ");
                    List.Add(dbHelper.CreateInDbParameter("@RepairTime", DbType.String, ht["RepairTime"].ToString()));
                }
                if (ht.ContainsKey("DamageCauses") && !string.IsNullOrEmpty(ht["DamageCauses"].ToString()))
                {
                    sbSql4org.Append(" and DamageCauses=@DamageCauses ");
                    List.Add(dbHelper.CreateInDbParameter("@DamageCauses", DbType.String, ht["DamageCauses"].ToString()));
                }
                if (ht.ContainsKey("Damagetime") && !string.IsNullOrEmpty(ht["Damagetime"].ToString()))
                {
                    sbSql4org.Append(" and Damagetime=@Damagetime ");
                    List.Add(dbHelper.CreateInDbParameter("@Damagetime", DbType.String, ht["Damagetime"].ToString()));
                }
                if (ht.ContainsKey("RepairLocation") && !string.IsNullOrEmpty(ht["RepairLocation"].ToString()))
                {
                    sbSql4org.Append(" and RepairLocation=@RepairLocation ");
                    List.Add(dbHelper.CreateInDbParameter("@RepairLocation", DbType.String, ht["RepairLocation"].ToString()));
                }
                if (ht.ContainsKey("CostOfRepairs") && !string.IsNullOrEmpty(ht["CostOfRepairs"].ToString()))
                {
                    sbSql4org.Append(" and CostOfRepairs=@CostOfRepairs ");
                    List.Add(dbHelper.CreateInDbParameter("@CostOfRepairs", DbType.String, ht["CostOfRepairs"].ToString()));
                }
                if (ht.ContainsKey("CompleteTime") && !string.IsNullOrEmpty(ht["CompleteTime"].ToString()))
                {
                    sbSql4org.Append(" and CompleteTime=@CompleteTime ");
                    List.Add(dbHelper.CreateInDbParameter("@CompleteTime", DbType.String, ht["CompleteTime"].ToString()));
                }
                if (ht.ContainsKey("EQtype") && !string.IsNullOrEmpty(ht["EQtype"].ToString()))
                {
                    sbSql4org.Append(" and EQtype=@EQtype ");
                    List.Add(dbHelper.CreateInDbParameter("@EQtype", DbType.String, ht["EQtype"].ToString()));
                }
                DataSet ds = base.GetListByPage("(" + sbSql4org.ToString() + ")", "", "", Convert.ToInt32(ht["StartIndex"] ?? "1"), Convert.ToInt32(ht["EndIndex"] ?? "10"), List.ToArray(), ispage);
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

        /// <summary>
        /// 由DataTable得到泛型数据列表
        /// </summary>
        public List<EmsModel.View_RepairList> GetList(DataTable dt)
        {
            List<EmsModel.View_RepairList> lst = new List<EmsModel.View_RepairList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmsModel.View_RepairList mod = new EmsModel.View_RepairList();
                DataRowToModel(mod, dt.Rows[i]);
                lst.Add(mod);
            }

            return lst;
        }


        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        public void DataRowToModel(EmsModel.View_RepairList EmsModel, DataRow dr)
        {
            EmsModel.ID = dr["ID"] as int?; EmsModel.RepairMan = dr["RepairMan"] as string; EmsModel.EquipID = dr["EquipID"] as int?; EmsModel.RepairTime = dr["RepairTime"] as DateTime?; EmsModel.DamageCauses = dr["DamageCauses"] as string; EmsModel.Damagetime = dr["Damagetime"] as DateTime?; EmsModel.RepairLocation = dr["RepairLocation"] as string; EmsModel.CostOfRepairs = dr["CostOfRepairs"] as string; EmsModel.CompleteTime = dr["CompleteTime"] as string; EmsModel.RepairStatus = dr["RepairStatus"] as int?; EmsModel.Remark = dr["Remark"] as string; EmsModel.EQtype = dr["EQtype"] as Byte?; EmsModel.name = dr["name"] as string; EmsModel.userName = dr["userName"] as string;
        }		
    }
}
