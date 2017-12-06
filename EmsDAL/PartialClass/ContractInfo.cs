using EmsCommon;
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
    public partial class ContractInfo : DALHelper
    {
        public DataTable GetPage(Hashtable ht)
        {
            try
            {
                StringBuilder sbSql4org = new StringBuilder();
                StringBuilder sbAttaorg = new StringBuilder();
                StringBuilder sbEquiporg = new StringBuilder();
                sbSql4org.Append("select * from (");
                sbSql4org.Append("select c.*,atta=stuff((select '|'+a.AttachmentName from AttachmentInfo a ");
                sbSql4org.Append(" where c.Id=a.ContractID and a.IsDelete=" + (int)Status.正常 + " for xml path('')),1,1,''),");
                sbSql4org.Append(" equip=stuff((select '|'+e.AssetName from EquipDetail e inner join ContractEquip ce on e.ID=ce.EquipDetailID ");
                sbSql4org.Append(" where c.Id=ce.ContractID and ce.IsDelete=" + (int)Status.正常 + "  for xml path('')),1,1,'')");
                sbSql4org.Append(" from ContractInfo c where c.IsDelete=" + (int)Status.正常);
                sbSql4org.Append(" ) t where 1=1 {0} {1}");
                List<DbParameter> List = new List<DbParameter>();
                if (ht.ContainsKey("ContractName") && !string.IsNullOrWhiteSpace(ht["ContractName"].ToString()))
                {
                    sbSql4org.Append(" and ContractName like N'%'+@ContractName+'%' ");
                    List.Add(dbHelper.CreateInDbParameter("@ContractName", DbType.String, ht["ContractName"].ToString()));
                }
                if (ht.ContainsKey("AttachmentName") && !string.IsNullOrWhiteSpace(ht["AttachmentName"].ToString()))
                {
                    sbAttaorg.Append(" and atta like N'%'+@AttachmentName+'%' ");
                    List.Add(dbHelper.CreateInDbParameter("@AttachmentName", DbType.String, ht["AttachmentName"].ToString()));
                }
                if (ht.ContainsKey("EquipName") && !string.IsNullOrWhiteSpace(ht["EquipName"].ToString()))
                {
                    sbEquiporg.Append(" and equip like N'%'+@EquipName+'%' ");
                    List.Add(dbHelper.CreateInDbParameter("@EquipName", DbType.String, (ht["EquipName"].ToString())));
                }

                if (ht.ContainsKey("Creator"))
                {
                    sbSql4org.Append(" and a.Creator=@Creator ");
                    List.Add(dbHelper.CreateInDbParameter("@Creator", DbType.String, ht["Creator"].ToString()));
                }
                if (ht.ContainsKey("IsDelete"))
                {
                    if (ht["IsDelete"].ToString() == "全部")
                    {
                        sbSql4org.Append(" and a.IsDelete <> 1 ");
                    }
                    else
                    {
                        sbSql4org.Append(" and a.IsDelete = @IsDelete  ");
                        List.Add(dbHelper.CreateInDbParameter("@IsDelete", DbType.Int32, Convert.ToInt32(ht["IsDelete"].ToString())));
                    }
                }
                string sqlEnd = string.Format(sbSql4org.ToString(), sbAttaorg, sbEquiporg);
                DataSet ds = base.GetListByPage("(" + sqlEnd + ")", "", "", Convert.ToInt32(ht["StartIndex"].ToString()), Convert.ToInt32(ht["EndIndex"].ToString()), List.ToArray());

                int RowCount = base.GetRecordCount("(" + sqlEnd + ") T", "", List.ToArray());
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

        public DataTable GetModelList(Hashtable ht)
        {
            try
            {
                StringBuilder sbSql4org = new StringBuilder();
                sbSql4org.Append(" select c.*,atta=stuff((select '|'+a.AttachmentName from AttachmentInfo a");
                sbSql4org.Append(" where c.Id=a.ContractID and a.IsDelete=" + (int)Status.正常 + " for xml path('')),1,1,''),");
                sbSql4org.Append(" url=stuff((select '|'+a.AttachmentPath from AttachmentInfo a");
                sbSql4org.Append(" where c.Id=a.ContractID and a.IsDelete=" + (int)Status.正常 + " for xml path('')),1,1,''),");
                sbSql4org.Append(" equipids=stuff((select '|'+ cast(ce.EquipDetailID as varchar(8)) from ContractEquip ce");
                sbSql4org.Append(" where c.Id=ce.ContractID and ce.IsDelete=" + (int)Status.正常 + " for xml path('')),1,1,''),");
                sbSql4org.Append(" equipiNames=stuff((select '|'+ ed.AssetName from ContractEquip ce");
                sbSql4org.Append(" left join EquipDetail ed on ce.EquipDetailID=ed.Id");
                sbSql4org.Append(" where c.Id=ce.ContractID and ce.IsDelete=" + (int)Status.正常 + " for xml path('')),1,1,''),");
                sbSql4org.Append(" AssetNumbers=stuff((select '|'+ ed.AssetNumber from ContractEquip ce");
                sbSql4org.Append(" left join EquipDetail ed on ce.EquipDetailID=ed.Id");
                sbSql4org.Append(" where c.Id=ce.ContractID and ce.IsDelete=" + (int)Status.正常 + " for xml path('')),1,1,''),");
                sbSql4org.Append(" Statuss=stuff((select '|'+ CAST(ed.EquipStatus as varchar(8)) from ContractEquip ce");
                sbSql4org.Append(" left join EquipDetail ed on ce.EquipDetailID=ed.Id");
                sbSql4org.Append(" where c.Id=ce.ContractID and ce.IsDelete=" + (int)Status.正常 + " for xml path('')),1,1,''),");
                sbSql4org.Append(" [Types]=stuff((select '|'+ CAST(ed.Type as varchar(8)) from ContractEquip ce");
                sbSql4org.Append(" left join EquipDetail ed on ce.EquipDetailID=ed.Id");
                sbSql4org.Append(" where c.Id=ce.ContractID and ce.IsDelete=" + (int)Status.正常 + " for xml path('')),1,1,''),");
                sbSql4org.Append(" units=stuff((select '|'+ ed.unit from ContractEquip ce");
                sbSql4org.Append(" left join EquipDetail ed on ce.EquipDetailID=ed.Id");
                sbSql4org.Append(" where c.Id=ce.ContractID and ce.IsDelete=" + (int)Status.正常 + " for xml path('')),1,1,'')");
                sbSql4org.Append(" from ContractInfo c where c.IsDelete=" + (int)Status.正常);
                List<DbParameter> List = new List<DbParameter>();
                if (ht.ContainsKey("Id") && !string.IsNullOrWhiteSpace(ht["Id"].ToString()))
                {
                    sbSql4org.Append(" and Id=@Id ");
                    List.Add(dbHelper.CreateInDbParameter("@Id", DbType.Int32, Convert.ToInt32(ht["Id"].ToString())));
                }
                if (ht.ContainsKey("ContractName") && !string.IsNullOrWhiteSpace(ht["ContractName"].ToString()))
                {
                    sbSql4org.Append(" and ContractName like N'%'+@ContractName+'%' ");
                    List.Add(dbHelper.CreateInDbParameter("@ContractName", DbType.String, ht["ContractName"].ToString()));
                }
                if (ht.ContainsKey("Creator") && !string.IsNullOrWhiteSpace(ht["Creator"].ToString()))
                {
                    sbSql4org.Append(" and Creator=@Creator ");
                    List.Add(dbHelper.CreateInDbParameter("@Creator", DbType.String, ht["Creator"].ToString()));
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


        public int UpdateContract(Hashtable ht) 
        {
            using (SqlTransaction trans = dbHelper.BeginTransaction())
            {
                try
                {
                    List<DbParameter> list = new List<DbParameter>();
                    StringBuilder sbSql4org = new StringBuilder();
                    list.Add(dbHelper.CreateInDbParameter("@ContractNumber", DbType.String, ht["ContractNumber"].ToString()));
                    list.Add(dbHelper.CreateInDbParameter("@Description", DbType.String, ht["Description"].ToString()));
                    list.Add(dbHelper.CreateInDbParameter("@IsDelete", DbType.Int32, (int)EmsCommon.Status.正常));
                    list.Add(dbHelper.CreateInDbParameter("@Creator", DbType.String, ht["Creator"].ToString()));
                    list.Add(dbHelper.CreateInDbParameter("@CreateTime", DbType.DateTime, DateTime.Now));
                    list.Add(dbHelper.CreateInDbParameter("@ContractName", DbType.String, ht["ContractName"].ToString()));
                    list.Add(dbHelper.CreateInDbParameter("@PartyB", DbType.String, ht["PartyB"].ToString()));
                    list.Add(dbHelper.CreateInDbParameter("@Money", DbType.Decimal, Convert.ToDecimal(ht["Money"])));
                    List<EmsModel.FileModel> files = ht["files"] as List<EmsModel.FileModel>;
                    List<string> equips = ht["equips"] as List<string>;
                    string operat = string.Empty;
                    if (Convert.ToString(ht["operator"]) == "edit")
                    {
                        list.Add(dbHelper.CreateInDbParameter("@Id", DbType.Int32, Convert.ToInt32(ht["Id"])));
                        sbSql4org.Append(" update ContractInfo set ContractName=@ContractName,ContractNumber=@ContractNumber,Description=@Description,PartyB=@PartyB,[Money]=@Money  where Id=@Id;");
                        //sbSql4org.Append(" update  ContractEquip set IsDelete=" + (int)EmsCommon.Status.删除 + " where  ContractID=@Id;");
                        sbSql4org.Append(" delete from  ContractEquip  where  ContractID=@Id;");
                        //sbSql4org.Append(" update AttachmentInfo set IsDelete=" + (int)EmsCommon.Status.删除 + " where ContractID=@Id;");
                        sbSql4org.Append(" delete from  AttachmentInfo where ContractID=@Id;");
                        operat = "@Id";
                    }
                    else
                    {
                        sbSql4org.Append("declare @CID int;insert into ContractInfo(ContractName,ContractNumber,PartyB,[Money],Description,Creator,CreateTime,IsDelete) Values(@ContractName,@ContractNumber,@PartyB,@Money,@Description,@Creator,@CreateTime,@IsDelete);set @CID=@@IDENTITY;");
                        operat = "@CID";
                    }
                    for (int i = 0; i < files.Count; i++)
                        sbSql4org.Append("insert into AttachmentInfo(AttachmentName,AttachmentPath,Creator,IsDelete,ContractID) Values('" + files[i].name + "','" + files[i].path + "',@Creator,@IsDelete," + operat + ");");
                    for (int j = 0; j < equips.Count; j++)
                        sbSql4org.Append("insert into ContractEquip(ContractID,EquipDetailID,Creator,CreateTime,IsDelete) Values(" + operat + "," + equips[j] + ",@Creator,@CreateTime,@IsDelete);");
                    int number = dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql4org.ToString(), list.ToArray());
                    if (number > 0)
                    {
                        trans.Commit();
                        return number;
                    }
                    else
                        return -1;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return -1;
                }
            }
        }

        public int DeleteContract(Hashtable ht)
        {
            using (SqlTransaction trans = dbHelper.BeginTransaction())
            {
                try
                {
                    StringBuilder sbSql4org = new StringBuilder();
                    DbParameter[] parms = new DbParameter[]{
				    dbHelper.CreateInDbParameter("@Id", DbType.Int32, Convert.ToInt32(ht["Id"])),
                    dbHelper.CreateInDbParameter("@IsDelete", DbType.Int32, EmsCommon.Status.删除)
                    };
                    sbSql4org.Append(" update ContractInfo set IsDelete=@IsDelete where Id=@Id;");
                    sbSql4org.Append(" update ContractEquip set IsDelete=@IsDelete where ContractID=@Id;");
                    sbSql4org.Append(" update AttachmentInfo set IsDelete=@IsDelete where ContractID=@Id;");
                    int number = dbHelper.ExecuteNonQuery(trans, CommandType.Text, sbSql4org.ToString(), parms);
                    if (number > 0) 
                    {
                        trans.Commit();
                        return number;
                    }
                    return -1;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return -1;
                }
            }
        }
    }
}
