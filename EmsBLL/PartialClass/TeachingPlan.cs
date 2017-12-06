using EmsModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EmsBLL
{
    public partial class TeachingPlan
    {
        BLLCommon common = new BLLCommon();

        /// <summary>
        /// 获得Model根据Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public EmsModel.JsonModel GetPlan(string Id)
        {
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("Id", Id);
                List<EmsModel.TeachingPlan> modList = dal.GetModelList(ht);
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
        /// 分页查询根据条件
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

        /// <summary>
        /// 获得下拉列表
        /// </summary>
        /// <param name="ht">查询条件</param>
        /// <returns>符合数据</returns>
        public JsonModel GetSelectOption(Hashtable ht)
        {
            try
            {

                DataTable dt = dal.GetSelectOption(ht);
                //定义JSON标准格式实体中
                JsonModel jsonModel = null;
                if (dt.Rows.Count <= 0)
                {
                    jsonModel = new JsonModel()
                    {
                        Status = "no",
                        Msg = "无数据"
                    };
                    return jsonModel;
                }
                string dtJson = common.DataTableToJson(dt);
                //将分页数据实体封装到JSON标准实体中
                jsonModel = new JsonModel()
                {
                    Data = dtJson,
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
                List<EmsModel.TeachingPlan> modListTP = dal.GetData(ht["Id"].ToString());
                if (modListTP[0].IsDelete == 2)
                {
                    jsonModel.Status = "no";
                    jsonModel.Msg = "课程已归档，不能删除！";
                    return jsonModel;
                }

                //判断计划下是否存在实验
                Hashtable htPE = new Hashtable();
                htPE.Add("PlanId", ht["Id"].ToString());
                htPE.Add("IsDelete", "全部");
                htPE.Add("PageIndex", 1);
                htPE.Add("PageSize", 10);
                htPE = common.AddStartEndIndex(ht);           
                EmsDAL.PlanExperiment peDAL = new EmsDAL.PlanExperiment();
                DataTable modListPE = peDAL.GetList(htPE);
                if (modListPE.Rows.Count > 0)
                {
                    jsonModel.Status = "no";
                    jsonModel.Msg = "请先删除实验，再删除课程！";
                    return jsonModel; 
                }

                //修改为删除状态
                ht.Add("IsDelete", 1);
                ht.Add("UpdateTime", DateTime.Now);
                ht.Add("TableName", "TeachingPlan");
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

        /// <summary>
        /// 添加课程
        /// </summary>
        /// <param name="ht">参数Key:Id</param>
        /// <returns></returns>
        public JsonModel AddPlan(EmsModel.TeachingPlan model)
        {
            try
            {
                JsonModel jsonModel = new JsonModel();
                int obj = new EmsDAL.PlanExperiment().getTeachingPlan(model.MainTeacher.ToString(), model.Name.ToString(), model.LearnYear.ToString());
                if (obj > 0)
                {
                    jsonModel.Status = "cf";
                    jsonModel.Msg = "课程名称重复！";
                }
                else
                {
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
        /// 是否归档
        /// </summary>
        /// <param name="ht">参数Key:Id</param>
        /// <returns></returns>
        public JsonModel Filing(Hashtable ht)
        {
            try
            {
                //定义JSON标准格式实体中
                JsonModel jsonModel = new JsonModel();

                //判断计划是否归档
                List<EmsModel.TeachingPlan> modListTP = dal.GetData(ht["Id"].ToString());
                if (modListTP[0].IsDelete == 2)
                {
                    jsonModel.Status = "ok";
                    jsonModel.Msg = "已归档";
                }
                else
                {
                    jsonModel.Status = "no";
                    jsonModel.Msg = "未归档";
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
        /// 修改课程
        /// </summary>
        /// <param name="ht">参数Key:Id</param>
        /// <returns></returns>
        public JsonModel UpdatePlan(Hashtable ht)
        {
            try
            {
                //定义JSON标准格式实体中
                JsonModel jsonModel = new JsonModel();

                JsonModel IsFiling = Filing(ht);
                if (IsFiling.Status == "ok")
                {
                    jsonModel.Status = "no";
                    jsonModel.Msg = "计划已归档，不能修改！";
                }

                int obj = new EmsDAL.PlanExperiment().getTeachingPlan(ht["MainTeacher"].ToString(), ht["Name"].ToString(), ht["LearnYear"].ToString());
                if (obj > 0)
                {
                    jsonModel.Status = "cf";
                    jsonModel.Msg = "课程名称重复！";
                }
                else
                {

                    EmsModel.TeachingPlan ModelPlan = dal.GetData(ht["Id"].ToString())[0];
                    ModelPlan.Name = ht["Name"].ToString();//课程名称
                    ModelPlan.MainTeacher = ht["MainTeacher"].ToString();//主讲教师
                    ModelPlan.GuideTeacher1 = ht["GuideTeacher1"].ToString();//指导教师1
                    ModelPlan.GuideTeacher2 = ht["GuideTeacher2"].ToString();//指导教师2
                    ModelPlan.Contents = ht["Contents"].ToString();//课程内容
                    ModelPlan.LearnYear = Convert.ToInt32(ht["LearnYear"].ToString());//学年学期ID
                    //ModelPlan.Creator = Creator;//创建人登录名
                    //ModelPlan.CreateTime = DateTime.Now;//创建时间
                    ModelPlan.Editor = ht["Editor"].ToString();//修改人登录名
                    ModelPlan.UpdateTime = DateTime.Now;//修改时间

                    int result = dal.Update(ModelPlan);

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
        /// 获得教师下拉信息
        /// </summary>
        /// <param name="ht">参数Key:Id</param>
        /// <returns></returns>
        public JsonModel GetTeacherOption()
        {
            try
            {
                EmsModel.UserInfo user = new EmsModel.UserInfo();
                EmsBLL.UserInfo BLLUser = new EmsBLL.UserInfo();
                List<EmsModel.UserInfo> list = BLLUser.GetList(user);
                //定义JSON标准格式实体中
                JsonModel jsonModel = new JsonModel();
                if (list.Count > 0)
                {
                    jsonModel.Data = list;
                    jsonModel.Status = "ok";
                    jsonModel.Msg = "";
                }
                else
                {
                    jsonModel.Status = "no";
                    jsonModel.Msg = "";
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
