using EmsModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EmsBLL
{
    public partial class Repair
    {
        BLLCommon common = new BLLCommon();
        public JsonModel AddRepairDetails(Hashtable ht)
        {
            try
            {
                int result = dal.AddRepairDetails(ht);
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


        public JsonModel GetRepairDetails(int ID)
        {
            try
            {
                Hashtable ht = new Hashtable();
                DataTable modList = dal.GetRepairDetails(ID);
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


        public JsonModel GetRepairDetailsNo(int ID)
        {
            try
            {
                Hashtable ht = new Hashtable();
                DataTable modList = dal.GetRepairDetailsNo(ID);
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

        public JsonModel GetRepairAttachment(int ID)
        {
            try
            {
                Hashtable ht = new Hashtable();
                DataTable modList = dal.GetRepairAttachment(ID);
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


        public JsonModel RepairInfo(Hashtable ht)
        {
            try
            {
                int result = dal.RepairInfo(ht);
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

        public JsonModel UpdateStatus(Hashtable ht)
        {
            try
            {
                int result = dal.UpdateStatus(ht);
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


        public JsonModel DeteleRepair(Hashtable ht)
        {
            try
            {
                int result = dal.DeteleRepair(ht);
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


        public JsonModel deleteRepairDetails(Hashtable ht)
        {
            try
            {
                int result = dal.deleteRepairDetails(ht);
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

    }
}
