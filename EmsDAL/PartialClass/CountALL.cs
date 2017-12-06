using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using EmsModel;

namespace EmsDAL
{
    public partial class CountALL : DALHelper
    {
        public DataTable CountALLd()
        {
            try
            {
                StringBuilder sbSql4org = new StringBuilder();
                sbSql4org.Append("select count(AssetName) as sum,Type from EquipDetail group by Type");
                DataSet dt = dbHelper.ExecuteQuery(CommandType.Text, sbSql4org.ToString(), null);
                return dt.Tables[0];
            }
            catch (Exception)
            {
                //写入日志
                throw;
            }

           

        }
        //public List<EmsModel.View_CountALL> getlist(DataTable dt)
        //{
        //    List<EmsModel.View_CountALL> lst = new List<EmsModel.View_CountALL>();
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        EmsModel.View_CountALL mod = new EmsModel.View_CountALL();
        //        DataRowToModel1(mod,dt.Rows[i]);
        //        lst.Add(mod);
        //    }
            
        //    return lst;
        //}
        //public void DataRowToModel1(EmsModel.View_CountALL EmsModel1, DataRow dr)
        //{
        //     EmsModel1.sum= Convert.ToInt32( dr["sum"] as int?); EmsModel1.Type = Convert.ToInt32( dr["Name"] as int?);
        //}
    }
}
