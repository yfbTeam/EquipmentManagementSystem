using EmsModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EmsBLL
{
    public partial class Honor
    {
        BLLCommon common = new BLLCommon();
        /// <summary>
        /// 获得Model根据Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public EmsModel.JsonModel GetHonor(Hashtable ht)
        {
            return common.GetJsonModelByDataTable(dal.GetList(ht));
        }
        /// <summary>
        /// 查询根据条件
        /// </summary>
        /// <param name="ht">查询条件</param>
        /// <returns>符合数据</returns>
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
                        ht.Remove("Creator");
                    }
                }
                //if (ht.Contains("UserRoleName") && ht["UserRoleName"].ToString() == "管理员")
                //{
                //    ht.Remove("Creator");
                //}

                DataTable modList = dal.GetList(ht);
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

        /// <summary>
        /// 添加计划
        /// </summary>
        /// <param name="ht">参数Key:Id</param>
        /// <returns></returns>
        public JsonModel AddHonor(EmsModel.Honor model)
        {
            try
            {
                var data = dal.GetData(model);
                JsonModel jsonModel = new JsonModel();
                if (data != null)
                {
                    jsonModel.Status = "no";
                    jsonModel.Msg = "绩效名称已存在！";
                    return jsonModel;
                }
                int result = dal.Add(model);
                //定义JSON标准格式实体中
                if (result > 0)
                {
                    jsonModel.Status = "ok";
                    jsonModel.Msg = "添加成功";
                }
                else
                {
                    jsonModel.Status = "no";
                    jsonModel.Msg = "添加失败";
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
        /// <summary>
        /// 修改计划
        /// </summary>
        /// <param name="ht">参数Key:Id</param>
        /// <returns></returns>
        public JsonModel UpdateHonor(Hashtable ht)
        {
            try
            {
                
                EmsModel.Honor ModelPlan = dal.GetData(ht["Id"].ToString())[0];
                ModelPlan.Name = ht["Name"].ToString();//教学计划名称
                ModelPlan.HonorLevel = Convert.ToInt32(ht["HonorLevel"].ToString());//教学计划内容
                ModelPlan.ExperimentId = Convert.ToInt32(ht["ExperimentId"].ToString());//学年学期ID
                //ModelPlan.Creator = Creator;//创建人登录名
                //ModelPlan.CreateTime = DateTime.Now;//创建时间
                ModelPlan.Editor = ht["Editor"].ToString();//修改人登录名
                ModelPlan.UpdateTime = DateTime.Now;//修改时间
                JsonModel jsonModel = new JsonModel();
                if (ModelPlan.Name != ht["preName"].ToString())
                {
                    var data = dal.GetData(ModelPlan);
                    if (data != null)
                    {
                        jsonModel.Status = "no";
                        jsonModel.Msg = "绩效名称已存在！";
                        return jsonModel;
                    }
                }
                int result = dal.Update(ModelPlan);
                //定义JSON标准格式实体中
                if (result > 0)
                {
                    jsonModel.Status = "ok";
                    jsonModel.Msg = "修改成功";
                }
                else
                {
                    jsonModel.Status = "no";
                    jsonModel.Msg = "修改失败";
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
        /// <summary>
        /// 标记删除
        /// </summary>
        /// <param name="ht">参数Key:Id</param>
        /// <returns></returns>
        public JsonModel MarkDelete(Hashtable ht)
        {
            try
            {

                //定义JSON标准格式实体中
                JsonModel jsonModel = new JsonModel();

                //判断计划是否归档
                List<EmsModel.Honor> modList = dal.GetData(ht["Id"].ToString());
                if (modList[0].IsDelete == 2)
                {
                    jsonModel.Status = "no";
                    jsonModel.Msg = "荣誉已归档，不能删除！";
                    return jsonModel;
                }


                //修改为删除状态
                ht.Add("IsDelete", 1);
                ht.Add("UpdateTime", DateTime.Now);
                ht.Add("TableName", "Honor");
                EmsDAL.DALHelper HelperDAL = new EmsDAL.DALHelper();
                int result = HelperDAL.UpdateIsDelete(ht);

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
    }
}
