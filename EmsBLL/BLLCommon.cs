using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

using NPOI;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using System.Security.Cryptography;
using EmsModel;

namespace EmsBLL
{
    public class BLLCommon
    {
        /// <summary>
        /// 根据第几页、每页条数增加起始条数、结束条数
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public Hashtable AddStartEndIndex(Hashtable ht)
        {
            try 
	        {	        
		        int PageIndex = Convert.ToInt32(ht["PageIndex"]);
                int PageSize = Convert.ToInt32(ht["PageSize"]);
                ht.Add("StartIndex", (((PageIndex - 1) * PageSize)+1).ToString());
                ht.Add("EndIndex", (PageIndex * PageSize).ToString());
	        }
	        catch (Exception)
	        {
		
		        throw;
	        }
            return ht;
        }

        /// <summary>
        /// DataTable转换成Json格式
        /// </summary>
        /// <param name="dt">要转换的DataTable</param>        
        /// <returns>Json字符串</returns>
        public string DataTableToJson(DataTable dt)
        {
            if (dt == null) return string.Empty;
            StringBuilder sb = new StringBuilder();
            sb.Append("{\"");
            sb.Append(dt.TableName);
            sb.Append("\":[");
            foreach (DataRow r in dt.Rows)
            {
                sb.Append("{");
                foreach (DataColumn c in dt.Columns)
                {
                    sb.Append("\"");
                    sb.Append(c.ColumnName);
                    sb.Append("\":\"");
                    sb.Append(r[c].ToString());
                    sb.Append("\",");
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append("},");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append("]}");
            return sb.ToString();
        }

        /// <summary>
        /// DataTable转换成List
        /// </summary>
        /// <param name="dt">要转换的DataTable</param>        
        /// <returns>List<Dictionary<string, object>></returns>
        public List<Dictionary<string, object>> DataTableToList(DataTable dt)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            foreach (DataRow dr in dt.Rows)
            {
                Dictionary<string, object> result = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    result.Add(dc.ColumnName, dr[dc].ToString());
                }
                list.Add(result);
            }
            return list;
        }

        /// <summary>
        /// Excel表格转DataTable
        /// </summary>
        /// <param name="FilePath">Excel文件物理路径</param>
        /// <returns>DataTable</returns>
        public DataTable ExcelToDataTable(string FilePath)
        {
            DataTable dt = new DataTable("table1");
            using (FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
            {
                IWorkbook workbook = WorkbookFactory.Create(fs);//使用接口，自动识别excel2003/2007格式
                ISheet sheet = workbook.GetSheetAt(0);//得到里面第一个sheet
                //表头  
                IRow headerRow = sheet.GetRow(0);//获得第一行
                int cellCount = headerRow.LastCellNum - 1;//获得最后一个单元格的列号
                for (int i = 0; i <= cellCount; i++)
                {
                    //DataColumn column = new DataColumn(headerRow.Cells[i].ToString());
                    DataColumn column;
                    if (headerRow.GetCell(i) == null)
                    {
                        column = new DataColumn("");
                    }
                    else
                    {
                        string ColumnName = headerRow.GetCell(i).StringCellValue.ToString().Trim();
                        //判断重名
                        if (dt.Columns.Contains(ColumnName))
                        {
                            int RepeatNum = 1;
                            //加重复数后缀，循环判断
                            while (dt.Columns.Contains(ColumnName + RepeatNum.ToString()))
                            {
                                RepeatNum++;
                            }
                            column = new DataColumn(ColumnName + RepeatNum.ToString());
                        }
                        else
                        {
                            column = new DataColumn(ColumnName);
                        }
                    }
                    dt.Columns.Add(column);
                }
                //内容
                for (int i = 1; i <= sheet.LastRowNum; i++)
                {
                    DataRow dr = dt.NewRow();
                    IRow Row = sheet.GetRow(i);
                    if (Row == null)
                    {
                        continue;
                    }
                    for (int j = 0; j <= cellCount; j++)
                    {
                        if (Row.GetCell(j) == null)
                        {
                            dr[j] = "";
                        }
                        else
                        {
                            dr[j] = Row.GetCell(j).ToString().Trim();
                        }
                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        /// <summary>
        /// 判断字符串是不是时间格式
        /// </summary>
        /// <param name="DateTime"></param>
        /// <returns></returns>
        public bool IsDateTime(string DateTime)
        {
            try
            {
                Convert.ToDateTime(DateTime);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 判断字符串是不是Decimal格式
        /// </summary>
        /// <param name="Decimal"></param>
        /// <returns></returns>
        public bool IsDecimal(string Decimal)
        {
            try
            {
                Convert.ToDecimal(Decimal);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 判断字符串是不是Int格式
        /// </summary>
        /// <param name="Int"></param>
        /// <returns></returns>
        public bool IsInt(string Int)
        {
            try
            {
                Convert.ToInt32(Int);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 判断字符串是不是Byte格式
        /// </summary>
        /// <param name="Int"></param>
        /// <returns></returns>
        public bool IsByte(string Byte)
        {
            try
            {
                Convert.ToByte(Byte);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Md5加密
        /// </summary>
        public string Md5Encrypting(string SourceStr)
        {

            var provider = new MD5CryptoServiceProvider();
            var bytes = Encoding.UTF8.GetBytes(SourceStr);
            var builder = new StringBuilder();

            bytes = provider.ComputeHash(bytes);

            foreach (var b in bytes)
                builder.Append(b.ToString("x2").ToLower());

            return builder.ToString();
        }

        #region 根据DataTable获取JsonModel
        public JsonModel GetJsonModelByDataTable(DataTable modList)
        {
            try
            {
                //定义JSON标准格式实体中
                JsonModel jsonModel = null;
                if (modList.Rows.Count <= 0)
                {
                    jsonModel = new JsonModel()
                    {
                        Data="",
                        Status = "no",
                        Msg = "失败"
                    };
                    return jsonModel;
                }
                List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
                list = new BLLCommon().DataTableToList(modList);
                PagedDataModel<Dictionary<string, object>> pagedDataModel = null;
                pagedDataModel = new PagedDataModel<Dictionary<string, object>>()
                {
                    PageCount = 1,
                    PagedData = list,
                    PageIndex = 1,
                    PageSize = 1,
                    RowCount = 1
                };
                //将分页数据实体封装到JSON标准实体中
                jsonModel = new JsonModel()
                {
                    Data = pagedDataModel,
                    Msg = "",
                    Status = "ok",
                    BackUrl = ""
                };                
                return jsonModel;
            }
            catch (Exception ex)
            {
                JsonModel jsonModel = new JsonModel()
                {
                    Data = "",
                    Status = "error",
                    Msg = ex.ToString()
                };
                return jsonModel;
            }
        }
        #endregion
    }
}
