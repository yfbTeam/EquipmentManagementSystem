using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace EmsDAL
{
    public partial class EquipInto : DALHelper
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EmsModel.EquipInto GetEmsModel(int? ID)
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;
            sbSql4org = new StringBuilder();
            sbSql4org.Append("SELECT * FROM EquipInto");
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
        public List<EmsModel.EquipInto> GetList()
        {
            StringBuilder sbSql4org;
            DbParameter[] parms4org;

            sbSql4org = new StringBuilder();
            sbSql4org.Append("SELECT * FROM EquipInto");

            parms4org = new DbParameter[]{
                dbHelper.CreateInDbParameter("1", DbType.Int32, 1)};

            using (DbDataReader dr = dbHelper.ExecuteReader(CommandType.Text, sbSql4org.ToString(), parms4org))
            {
                List<EmsModel.EquipInto> lst = GetList(dr);
                return lst;
            }

        }


        #region -------- 私有方法 --------
        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private EmsModel.EquipInto GetEmsModel(DbDataReader dr)
        {
            EmsModel.EquipInto EmsModel = new EmsModel.EquipInto();
            PrepareEmsModel(EmsModel, dr);

            return EmsModel;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<EmsModel.EquipInto> GetList(DbDataReader dr)
        {
            List<EmsModel.EquipInto> lst = new List<EmsModel.EquipInto>();
            while (dr.Read())
            {
                lst.Add(GetEmsModel(dr));
            }
            return lst;
        }

        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private void PrepareEmsModel(EmsModel.EquipInto EmsModel, DbDataReader dr)
        {
           //msModel.Id = GetInt(dr["ID"]);
            //EmsModel.OrderNo = GetString(dr["OrderNo"]);
            //EmsModel.LoanName = GetString(dr["LoanName"]);
            //EmsModel.ExperimentId = GetInt(dr["ExperimentId"]);
            //EmsModel.Attachment = GetString(dr["Attachment"]);
            //EmsModel.Type = GetByte(dr["Type"]);
            //EmsModel.Status = GetInt(dr["Status"]);
            //EmsModel.Remarks = GetString(dr["Remarks"]);
            //EmsModel.LendTime = GetDateTime(dr["LendTime"]);
            //EmsModel.ReturnTime = GetDateTime(dr["ReturnTime"]);
            //EmsModel.Creator = GetString(dr["Creator"]);
            //EmsModel.CreateTime = GetDateTime(dr["CreateTime"]);
            //EmsModel.Editor = GetString(dr["Editor"]);
            //EmsModel.UpdateTime = GetDateTime(dr["UpdateTime"]);
            //EmsModel.IsDelete = GetByte(dr["IsDelete"]);
           
        }
        #endregion
    }
}
