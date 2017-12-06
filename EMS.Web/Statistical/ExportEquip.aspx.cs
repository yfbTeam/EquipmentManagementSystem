using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS.Web.Statistical
{
    public partial class ExportEquip : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 导出按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                Hashtable ht = GetColumns();
                DataTable dt = JsonToDataTable(hidExcelCenter.Value);
                StringBuilder sb = new StringBuilder();
                sb.Append("<table style=\"BORDER-COLLAPSE: collapse;\" borderColor=#e5e5e5 height=40 cellPadding=1 width=250 align=center border=1>");
                sb.Append("<tr>");
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    sb.Append("<td style=\"BACKGROUND:#e5e5e5;\">");
                    if (ht.Contains(dt.Columns[i].ToString()))
                    {
                        sb.Append(ht[dt.Columns[i].ToString()].ToString());
                    }
                    else
                    {
                        sb.Append(dt.Columns[i].ToString());
                    }
                    sb.Append("</td>");
                }
                sb.Append("</tr>");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append("<tr>");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        sb.Append("<td>");
                        sb.Append(HandleValue(dt.Columns[j].ToString(), dt.Rows[i][j].ToString()));
                        sb.Append("</td>");
                    }
                    sb.Append("</tr>");
                }
                sb.Append("</table>");
                ExportDsToXls(sb.ToString());
            }
            catch (Exception)
            {

                //throw;
            }

        }

        /// <summary>
        /// 字段中文名
        /// </summary>
        /// <returns></returns>
        private Hashtable GetColumns()
        {
            Hashtable ht = new Hashtable();
            #region 原有字段

            ht.Add("Id", "Id");
            ht.Add("EquipKindId", "设备分类Id");
            ht.Add("AssetNumber", "资产号");
            ht.Add("EquipIntoID", "设备入库ID");
            ht.Add("EquipStatus", "设备状态");
            ht.Add("Type", "类型");
            ht.Add("Barcode", "条形码");
            ht.Add("ImageName", "图片");
            ht.Add("ClassNumber", "分类号");
            ht.Add("AssetsClassName", "资产分类名称");
            ht.Add("IntlClassCode", "国际分类代码");
            ht.Add("IntlClassName", "国际分类名称");
            ht.Add("AssetName", "资产名称");
            ht.Add("Unit", "计量单位");
            ht.Add("UsageStatus", "使用状况");
            ht.Add("UsageDirection", "使用方向");
            ht.Add("JYBBBSYFX", "教育部报表使用方向");
            ht.Add("AcquisitionMethod", "取得方式");
            ht.Add("AcquisitionDate", "取得日期");
            ht.Add("BrandStandardModel", "品牌及规格型号");
            ht.Add("EquipmentUse", "设备用途");
            ht.Add("UseDepartment", "使用/管理部门");
            ht.Add("UsePeople", "使用人");
            ht.Add("Factory", "厂家");
            ht.Add("StorageLocation", "存放地点");
            ht.Add("WorthType", "价值类型");
            ht.Add("UseNature", "使用性质");
            ht.Add("Worth", "价值");
            ht.Add("FinanceRecordType", "财务入账形式");
            ht.Add("FiscalFunds", "财政性资金");
            ht.Add("NonFiscalFunds", "非财政性资金");
            ht.Add("FinanceRecordDate", "财政入账日期");
            ht.Add("VoucherNumber", "凭证号");
            ht.Add("UseTime", "使用年限（月）");
            ht.Add("ExpectedScrapDate", "预计报废时间");
            ht.Add("DepreciationState", "折旧状态");
            ht.Add("NetWorth", "净值");
            ht.Add("OutFactoryNumber", "出厂号");
            ht.Add("Supplier", "供货商");
            ht.Add("FundsSubject", "经费科目");
            ht.Add("PurchaseModality", "采购组织形式");
            ht.Add("CountryCode", "国别码");
            ht.Add("Operator", "经手人");
            ht.Add("GuaranteeEndDate", "保修截止日期");
            ht.Add("EquipmentNumber", "设备号");
            ht.Add("InvoiceNumber", "发票号");
            ht.Add("CompactNumber", "合同号");
            ht.Add("BasicFunds", "基本经费");
            ht.Add("ItemFunds1", "项目经费1");
            ht.Add("ItemFunds2", "项目经费2");
            ht.Add("ItemFunds3", "项目经费3");
            ht.Add("ItemFunds4", "项目经费4");
            ht.Add("ItemFundsMoney1", "项目经费1金额");
            ht.Add("ItemFundsMoney2", "项目经费2金额");
            ht.Add("ItemFundsMoney3", "项目经费3金额");
            ht.Add("ItemFundsMoney4", "项目经费4金额");
            ht.Add("Remarks", "备注");
            ht.Add("Creator", "创建人");
            ht.Add("CreateTime", "创建时间");
            ht.Add("Editor", "修改人");
            ht.Add("UpdateTime", "修改时间");
            ht.Add("IsDelete", "是否删除");
            ht.Add("StorageLocation1", "存放地点1");
            ht.Add("EquipSource", "设备来源 ");
            ht.Add("IsConsume", "是否耗材");
            ht.Add("EquipOwner", "负责人");
            ht.Add("Count", "数量");

            #endregion
            #region 扩展字段

            //ht.Add("Factory", "厂家");

            #endregion
            return ht;
        }

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

        /// <summary>
        /// 处理值
        /// </summary>
        /// <param name="ColumnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private string HandleValue(string ColumnName, string value)
        {
            string ReturnValue = "";
            switch (ColumnName)
            {
                case "EquipStatus":
                    ReturnValue = GetEquipStatusName(value);
                    break;
                case "IsConsume":
                    ReturnValue = GetIsConsumeName(value);
                    break;
                case "EquipSource":
                    ReturnValue = GetEquipSourceName(value);
                    break;
                case "Type":
                    ReturnValue = GetTypeName(value);
                    break;
                case "Barcode":
                case "ClassNumber":
                case "AcquisitionDate":
                case "FinanceRecordDate":
                case "ExpectedScrapDate":
                case "GuaranteeEndDate":
                //case "InvoiceNumber":
                case "Creator":
                case "CreateTime":
                case "Editor":
                case "UpdateTime":
                case "EquipOwner":
                    ReturnValue = "'" + value;
                    break;
                default:
                    ReturnValue = value;
                    break;
            }
            return ReturnValue;
        }

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

        /// <summary>
        /// 导出EXCEL方法
        /// </summary>
        /// <param name="page"></param>
        /// <param name="fileName"></param>
        /// <param name="html"></param>
        public void ExportDsToXls(string html)
        {

            string fileName = "导出设备信息" + DateTime.Now.ToString("yyyyMMddHHmm");//下载的文件默认名
            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
            Response.Clear();
            Response.Charset = "gb2312";
            Response.ContentType = "application/vnd.ms-excel";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + System.Web.HttpUtility.UrlEncode(fileName) + ".xls");
            Response.Write("<html><head><META http-equiv=\"Content-Type\" content=\"text/html; charset=gb2312\"></head><body>");

            Response.Write(html);

            Response.Write(tw.ToString());
            Response.Write("</body></html>");
            Response.End();
            hw.Close();
            hw.Flush();
            tw.Close();
            tw.Flush();
        }

        /// <summary>
        /// 处理耗材值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string GetIsConsumeName(string value)
        {
            string ReturnValue = "";
            switch (value)
            {
                case "0":
                    ReturnValue = "非耗材";
                    break;
                case "1":
                    ReturnValue = "耗材";
                    break;
                default:
                    break;
            }
            return ReturnValue;
        }
        /// <summary>
        /// 处理设备来源值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string GetEquipSourceName(string value)
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
        /// <summary>
        /// 处理设备类别值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string GetTypeName(string value)
        {
            string ReturnValue = "";
            switch (value)
            {
                case "0":
                    ReturnValue = "教学资产";
                    break;
                case "1":
                    ReturnValue = "科研资产";
                    break;
                case "2":
                    ReturnValue = "办公资产";
                    break;
                default:
                    break;
            }
            return ReturnValue;
        }
    }
}