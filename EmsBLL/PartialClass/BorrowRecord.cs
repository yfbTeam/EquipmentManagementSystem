using EmsModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EmsBLL
{
    public partial class BorrowRecord
    { 
        BLLCommon common = new BLLCommon();
        public JsonModel GetPage(Hashtable ht)
        {
            try
            {
                //增加起始条数、结束条数
                ht = common.AddStartEndIndex(ht);
                int PageIndex = Convert.ToInt32(ht["PageIndex"]);
                int PageSize = Convert.ToInt32(ht["PageSize"]);

                if (ht.Contains("RoleID") && !string.IsNullOrEmpty(ht["AdminRoleID"].ToString()))
                {
                    string[] roles = ht["RoleID"].ToString().Split('㊣');
                    if (Array.IndexOf(roles, ht["AdminRoleID"].ToString()) != -1)
                    {
                        ht.Remove("EquipOwner");
                    }
                }

                DataTable modList = dal.GetPage(ht);
                //定义分页数据实体
                PagedDataModel<Dictionary<string, object>> pagedDataModel = null;
                //定义JSON标准格式实体中
                JsonModel jsonModel = null;
                if (modList.Rows.Count <= 0)
                {
                    jsonModel = new JsonModel()
                    {
                        Status = "no",
                        Msg = "无数据"
                    };
                    return jsonModel;
                }
                List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
                list = common.DataTableToList(modList);
                //总条数
              
                int RowCount = Convert.ToInt32(ht["RowCount"].ToString());
                //总页数
                int PageCount = (int)Math.Ceiling(RowCount * 1.0 / PageSize);
                //将数据封装到PagedDataModel分页数据实体中
                pagedDataModel = new PagedDataModel<Dictionary<string, object>>()
                {
                    PageCount = PageCount,
                    PagedData = list,
                    PageIndex = PageIndex,
                    PageSize = PageSize,
                    RowCount = RowCount
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
                JsonModel jsonModel = new JsonModel();
                jsonModel.Status = "error";
                jsonModel.Msg = ex.ToString();
                return jsonModel;
            }
        }


        public JsonModel SetBorrowRecord(Hashtable ht)
        {
            try
            {
                int result = dal.SetBorrowRecord(ht);
                //定义JSON标准格式实体中
                JsonModel jsonModel = new JsonModel();
                if (result > 0)
                {
                    jsonModel.Status = "ok";
                    jsonModel.Msg = "操作成功";
                }
                else
                {
                    jsonModel.Status = "no";
                    jsonModel.Msg = "操作失败";
                }
                return jsonModel;
            }
            catch (Exception ex)
            {
                JsonModel jsonModel = new JsonModel();
                jsonModel.Status = "error";
                jsonModel.Msg = ex.ToString();
                return jsonModel;
            }
        }


        public JsonModel DeleteBorrowRecord(Hashtable ht)
        {
            try
            {
                JsonModel jsonModel = new JsonModel();
                int result = dal.DeleteBorrowRecord(ht);
                if (result > 0)
                {
                    jsonModel.Status = "ok";
                    jsonModel.Msg = "删除成功";
                }
                else
                {
                    jsonModel.Status = "no";
                    jsonModel.Msg = "删除失败";
                }
                return jsonModel;
            }
            catch (Exception ex)
            {
                JsonModel jsonModel = new JsonModel();
                jsonModel.Status = "error";
                jsonModel.Msg = ex.ToString();
                return jsonModel;
            }
        }


        public JsonModel AuditingBorrow(Hashtable ht)
        {
            try
            {
                JsonModel jsonModel = new JsonModel();
                int result = dal.AuditingBorrow(ht);
                if (result > 0)
                {
                    jsonModel.Status = "ok";
                    jsonModel.Msg = "操作成功";
                }
                else
                {
                    jsonModel.Status = "no";
                    jsonModel.Msg = "操作失败";
                }
                return jsonModel;
            }
            catch (Exception ex)
            {
                JsonModel jsonModel = new JsonModel();
                jsonModel.Status = "error";
                jsonModel.Msg = ex.ToString();
                return jsonModel;
            }
        }


        public JsonModel GetPage(int ID)
        {
            return common.GetJsonModelByDataTable(dal.GetPage(ID));
        }

        public JsonModel GetPageList(int ID)
        {
            try
            {
                Hashtable ht = new Hashtable();
                DataTable modList = dal.GetPageList(ID);
                //定义JSON标准格式实体中
                JsonModel jsonModel = null;
                if (modList.Rows.Count <= 0)
                {
                    jsonModel = new JsonModel()
                    {
                        Status = "no",
                        Msg = "无数据"
                    };
                    return jsonModel;
                }
                List<string> list = new List<string>();
                list.Add(common.DataTableToJson(modList));
                jsonModel = new JsonModel()
                {
                    Data = list,
                    Msg = "",
                    Status = "ok",
                    BackUrl = ""
                };
                return jsonModel;
            }
            catch (Exception ex)
            {
                JsonModel jsonModel = new JsonModel();
                jsonModel.Status = "error";
                jsonModel.Msg = ex.ToString();
                return jsonModel;
            }
        }
    }
}
