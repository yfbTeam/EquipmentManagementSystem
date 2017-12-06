using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS.Web.Inventory
{
    public partial class InventoryListResult : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hid_UserIDCard.Value = UserInfo.UniqueNo;
            if (!IsPostBack)
            {
                string itemid = HttpContext.Current.Request.QueryString["itemid"];
                if (!string.IsNullOrEmpty(itemid))
                {
                    hid_Id.Value = itemid;
                    hid_Type.Value = HttpContext.Current.Request.QueryString["type"];
                }
            }
        }

        protected void ExportInventoryEquip_Click(object sender, EventArgs e)
        {
            try
            {
                string type = HttpContext.Current.Request.QueryString["type"];
                DataTable dt = JsonToDataTable(hidExcelCenter.Value);
                string fileName = HttpUtility.UrlDecode("盘点单", System.Text.Encoding.UTF8) +
                                                  DateTime.Now.ToShortDateString() + ".xls";
                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                Response.Clear();
                Response.Charset = "gb2312";
                Response.ContentType = "application/vnd.ms-excel";  
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
                Response.AppendHeader("Content-Disposition", "attachment;filename=" + System.Web.HttpUtility.UrlEncode(fileName));
                Response.Write("<html><head><META http-equiv=\"Content-Type\" content=\"text/html; charset=gb2312\"></head><body>");
                Response.Write(@"<table style='BORDER-COLLAPSE: collapse;' borderColor=#e5e5e5 height=40 cellPadding=1 width=250 align=center border=1>
                    <thead>
                        <tr>                                             
                            <td style='BACKGROUND:#e5e5e5;'>资产号</td>
                            <td style='BACKGROUND:#e5e5e5;'>资产名称</td>" +
                            (type == "2" ? "<td style='BACKGROUND:#e5e5e5;'>负责人</td>" : "") +
                            (type == "0" ? "<td style='BACKGROUND:#e5e5e5;'>状态</td>" : "") +
                            @"<td style='BACKGROUND:#e5e5e5;'>计量单位</td>
                            <td style='BACKGROUND:#e5e5e5;'>存放地点</td>  
                            <td style='BACKGROUND:#e5e5e5;'>设备来源</td>
                            <td style='BACKGROUND:#e5e5e5;'>是否拟盘亏</td>                                                      
                     </tr>
                    </thead><tbody>");
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow row = dt.Rows[i];
                        Response.Write(@"<tr><td >" + row["AssetNumber"].ToString() + @"</td>                                       
                                        <td>" + row["AssetName"].ToString() + "</td>" +
                                             (type == "2" ? "<td>" + row["CreateName"].ToString() + "</td>" : "") +
                                             (type == "0" ? "<td>" + GetEquipStatusName(row["Status"].ToString()) + "</td>" : "") +
                                            "<td>" + row["Unit"].ToString() + @"</td>
                                        <td>" + row["Storage"].ToString() + @"</td>
                                        <td>" + GetEquipSource(row["EquipSource"].ToString()) + @"</td>
                                        <td>" + GetIsloss(row["loss"].ToString()) + "</td></tr>");
                    }
                }
                Response.Write(@"</tbody></table>");   
                Response.Write(tw.ToString());
                Response.Write("</body></html>");
                Response.End();
                hw.Close();
                hw.Flush();
                tw.Close();
                tw.Flush();
            }
            catch (Exception ex)
            {

            }

        }
        #region 处理设备状态值
        /// <summary>
        /// 处理设备状态值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string GetEquipStatusName(string value)
        {
            string ReturnValue = "";
            switch (value)
            {
                case "0":
                    ReturnValue = "未借出";
                    break;
                case "1":
                    ReturnValue = "已借出";
                    break;
                case "2":
                    ReturnValue = "维修";
                    break;
                case "3":
                    ReturnValue = "停用";
                    break;
                case "4":
                    ReturnValue = "报废";
                    break;
                default:
                    break;
            }
            return ReturnValue;
        }
        #endregion

        #region 设备来源
        /// <summary>
        /// 设备来源
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string GetEquipSource(string value)
        {
            string ReturnValue = "";
            switch (value)
            {
                case "0":
                    ReturnValue = "本院资产";
                    break;
                case "1":
                    ReturnValue = "资产系统";
                    break;
                default:
                    break;
            }
            return ReturnValue;
        }
        #endregion

        #region 是否拟盘亏
        /// <summary>
        /// 是否拟盘亏
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string GetIsloss(string value)
        {
            string ReturnValue = "";
            switch (value)
            {
                case "0":
                    ReturnValue = "<span style='color:red;'>是</span>";
                    break;
                case "1":
                    ReturnValue = "否";
                    break;               
                default:
                    break;
            }
            return ReturnValue;
        }
        #endregion

        #region Json 字符串 转换为 DataTable数据集合
        /// <summary>
        /// Json 字符串 转换为 DataTable数据集合
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public DataTable JsonToDataTable(string json)
        {
            DataTable dataTable = new DataTable();  //实例化
            DataTable result;
            try
            {
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                javaScriptSerializer.MaxJsonLength = Int32.MaxValue; //取得最大数值
                ArrayList arrayList = javaScriptSerializer.Deserialize<ArrayList>(json);
                if (arrayList.Count > 0)
                {
                    foreach (Dictionary<string, object> dictionary in arrayList)
                    {
                        if (dictionary.Keys.Count<string>() == 0)
                        {
                            result = dataTable;
                            return result;
                        }
                        if (dataTable.Columns.Count == 0)
                        {
                            foreach (string current in dictionary.Keys)
                            {
                                dataTable.Columns.Add(current, dictionary[current].GetType());
                            }
                        }
                        DataRow dataRow = dataTable.NewRow();
                        foreach (string current in dictionary.Keys)
                        {
                            dataRow[current] = dictionary[current];
                        }

                        dataTable.Rows.Add(dataRow); //循环添加行到DataTable中
                    }
                }
            }
            catch
            {
            }
            result = dataTable;
            return result;
        }
        #endregion
    }
}