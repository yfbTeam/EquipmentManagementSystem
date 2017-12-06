using EmsModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EmsBLL
{
    public partial class Dictionary
    {

        /// <summary>
        /// 获得Model
        /// </summary>
        /// <returns></returns>
        public JsonModel GetModel(Hashtable ht)
        {
            try
            {
                List<EmsModel.Dictionary> modList = dal.GetModel(ht["Id"].ToString());
                //定义JSON标准格式实体中
                JsonModel jsonModel = null;
                if (modList.Count == 0)
                {
                    jsonModel = new JsonModel()
                    {
                        Status = "no",
                        Msg = "无数据"
                    };
                    return jsonModel;
                }
                
                //将分页数据实体封装到JSON标准实体中
                jsonModel = new JsonModel()
                {
                    Data = modList[0],
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
        /// <summary>
        /// 获得学年学期List
        /// </summary>
        /// <returns></returns>
        public JsonModel GetLearnYearList()
        {
            try
            {
                List<EmsModel.Dictionary> modList = dal.GetList("学年学期");
                //定义JSON标准格式实体中
                JsonModel jsonModel = null;
                if (modList.Count == 0)
                {
                    jsonModel = new JsonModel()
                    {
                        Status = "no",
                        Msg = "无数据"
                    };
                    return jsonModel;
                }
                var list = modList;
                //将分页数据实体封装到JSON标准实体中
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

        /// <summary>
        /// 获得级别List
        /// </summary>
        /// <returns></returns>
        public JsonModel GetLevelList()
        {
            try
            {
                List<EmsModel.Dictionary> modList = dal.GetList("级别");
                //定义JSON标准格式实体中
                JsonModel jsonModel = null;
                if (modList.Count == 0)
                {
                    jsonModel = new JsonModel()
                    {
                        Status = "no",
                        Msg = "无数据"
                    };
                    return jsonModel;
                }
                var list = modList;
                //将分页数据实体封装到JSON标准实体中
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
        /// <summary>
        /// 获得实验类型
        /// </summary>
        /// <returns></returns>
        public JsonModel GetExpType()
        {
            try
            {
                List<EmsModel.Dictionary> modList = dal.GetList("实验类型");
                //定义JSON标准格式实体中
                JsonModel jsonModel = null;
                if (modList.Count == 0)
                {
                    jsonModel = new JsonModel()
                    {
                        Status = "no",
                        Msg = "无数据"
                    };
                    return jsonModel;
                }
                var list = modList;
                //将分页数据实体封装到JSON标准实体中
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
        /// <summary>
        /// 获得指定项
        /// </summary>
        /// <returns></returns>
        public JsonModel GetList(Hashtable ht)
        {
            try
            {
                List<EmsModel.Dictionary> modList = dal.GetList(ht);
                //定义JSON标准格式实体中
                JsonModel jsonModel = null;
                if (modList.Count == 0)
                {
                    jsonModel = new JsonModel()
                    {
                        Status = "no",
                        Msg = "无数据"
                    };
                    return jsonModel;
                }
                var list = modList;
                //将分页数据实体封装到JSON标准实体中
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
