using EmsModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EmsBLL
{
    public partial class PlanExperiment
    {
        BLLCommon com = new BLLCommon();


        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EmsModel.PlanExperiment GetEmsModel(int? ID)
        {
            return dal.GetEmsModel(ID);
        }
        #endregion


        /// <summary>
        /// 获得Model根据Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public EmsModel.JsonModel GetExperiment(string Id)
        {
            try
            {
                DataTable modList = dal.GetData3(Id);
                PagedDataModel<Dictionary<string, object>> pagedDataModel = null;
                //定义JSON标准格式实体中
                JsonModel jsonModel = null;
                if (modList.Rows.Count == 0)
                {
                    jsonModel = new JsonModel()
                    {
                        Status = "no",
                        Msg = "无数据"
                    };
                    return jsonModel;
                }
                List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
                list = com.DataTableToList(modList);
                //将数据封装到PagedDataModel分页数据实体中
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
                JsonModel jsonModel = new JsonModel();
                jsonModel.Status = "error";
                jsonModel.Msg = ex.ToString();
                return jsonModel;
            }
        }


        public List<EmsModel.View_Calendar_Land> GetDataFroDateTime(string dateTime, string isStatus)
        {
            return dal.GetDataFroDateTime(dateTime, isStatus);
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
                ht = com.AddStartEndIndex(ht);
                int PageIndex = Convert.ToInt32(ht["PageIndex"]);
                int PageSize = Convert.ToInt32(ht["PageSize"]);

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
                list = com.DataTableToList(modList);
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
                string dtJson = com.DataTableToJson(dt);
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

                //判断实验是否归档
                List<EmsModel.PlanExperiment> modListPE = dal.GetData(ht["Id"].ToString());
                if (modListPE[0].IsDelete == 2)
                {
                    jsonModel.Status = "no";
                    jsonModel.Msg = "实验已归档，不能删除！";
                    return jsonModel;
                }
                else if (modListPE[0].Status == 1)
                {
                    jsonModel.Status = "no";
                    jsonModel.Msg = "实验已生成订单，不能删除！";
                    return jsonModel;
                }

                //修改为删除状态
                EmsDAL.DALHelper HelperDAL = new EmsDAL.DALHelper();
                ht.Add("IsDelete", 1);
                ht.Add("UpdateTime", DateTime.Now);
                ht.Add("TableName", "PlanExperiment");
                int result = HelperDAL.UpdateIsDelete(ht);

                if (result == 1)
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
        /// 添加实验
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonModel AddExperiment(Hashtable ht)
        {
            try
            { 
                
                EmsModel.PlanExperiment Model = new EmsModel.PlanExperiment();

                Model.Name = ht["Name"].ToString();//实验名称
                Model.Type = Convert.ToByte(ht["Type"].ToString());
                Model.IsOpen = Convert.ToByte(ht["IsOpen"].ToString());
                if (com.IsDateTime(ht["StartDate"].ToString()))
                {
                    Model.StartDate = Convert.ToDateTime(ht["StartDate"].ToString());
                }
                if (com.IsInt(ht["Week"].ToString()))
                {
                    Model.Week = Convert.ToInt32(ht["Week"].ToString());
                }
                Model.Weekday = Convert.ToInt32(ht["Weekday"].ToString());
                Model.ClassHour = Convert.ToInt32(ht["ClassHour"].ToString());
                Model.Part = ht["Part"].ToString();
                Model.ComputerRoom = Convert.ToInt32(ht["ComputerRoom"].ToString());
                Model.Place = Convert.ToInt32(ht["Place"].ToString());
                Model.GroupMemberNumber = Convert.ToInt32(ht["GroupMemberNumber"].ToString());
                Model.GroupNumber = Convert.ToInt32(ht["GroupNumber"].ToString());
                Model.NeedEquip = ht["NeedEquip"].ToString();
                Model.Contents = ht["Contents"].ToString();//实验内容
                Model.PlanId = Convert.ToInt32(ht["PlanId"].ToString());//课程Id
                Model.Status = 0;//状态(是否生成订单) 0 未生成订单
                Model.Creator = ht["Creator"].ToString();//创建人登录名
                Model.CreateTime = DateTime.Now;//创建时间
                Model.IsDelete = 0;//是否删除 0未删除
                Model.ClassName = ht["Class"].ToString();//上课班级
                Model.Category = Convert.ToByte(ht["Category"].ToString());//实验类别 0室内上课;1室外上课

                //定义JSON标准格式实体中
                JsonModel jsonModel = new JsonModel();


                int obj =new EmsDAL.PlanExperiment().getPlanExperiment(Model.Name.ToString(), Model.PlanId.ToString());
                if (obj > 0)
                {
                    jsonModel.Status = "cf";
                    jsonModel.Msg = "当前课程下已经有此实验！";
                }
                else
                {
                    int result = dal.Add(Model);
                    if (result == 0)
                    {
                        jsonModel.Status = "no";
                        jsonModel.Msg = "添加失败";
                    }
                    else
                    {
                        jsonModel.Status = "ok";
                        jsonModel.Msg = "添加成功";
                    }
                }
                return jsonModel;
                #region 保存实验班级信息--需求修改弃用
                
                //string[] ClassId = ht["Class"].ToString().Split(',');
                //if (string.IsNullOrWhiteSpace(ht["Class"].ToString()))
                //{
                //    ClassId = new string[0];
                //}

                ////定义JSON标准格式实体中
                //JsonModel jsonModel = new JsonModel();
                               
                ////事务
                //using (SqlTransaction trans = dal.GetTran())
                //{
                //    try
                //    { 
                //        int result = dal.Add(trans, Model);
                //        if (result == 0)
                //        {
                //            //回滚
                //            trans.Rollback();
                //            jsonModel.Status = "no";
                //            jsonModel.Msg = "添加失败";
                //            return jsonModel;
                //        }

                //        EmsDAL.ExperimentClassInfo DALEC = new EmsDAL.ExperimentClassInfo();
                //        int AddCount = 0;
                //        foreach (string id in ClassId)
                //        {
                //            EmsModel.ExperimentClassInfo ModelEC = new EmsModel.ExperimentClassInfo();
                //            ModelEC.ExperimentId = result;
                //            ModelEC.ClassId = Convert.ToInt32(id);
                //            int resultEC = DALEC.Add(trans, ModelEC);
                //            if (resultEC > 0)
                //            {
                //                AddCount++;
                //            }
                //        }
                //        if (ClassId.Length != AddCount)
                //        {
                //            //回滚
                //            trans.Rollback();
                //            jsonModel.Status = "no";
                //            jsonModel.Msg = "班级保存失败";
                //        }
                //        else
                //        {
                //            //提交
                //            trans.Commit();
                //            jsonModel.Status = "ok";
                //            jsonModel.Msg = "添加成功";
                //        }
                //        return jsonModel;
                //    }
                //    catch (Exception)
                //    {
                //        //回滚
                //        trans.Rollback();
                //        throw;
                //    }
                //}

                #endregion
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
        /// 修改实验
        /// </summary>
        /// <param name="ht">参数Key:Id</param>
        /// <returns></returns>
        public JsonModel UpdateExperiment(Hashtable ht)
        {
            try
            {
                int Id = Convert.ToInt32(ht["Id"].ToString());
                EmsModel.PlanExperiment Model = dal.GetData(ht["Id"].ToString())[0];
                Model.Name = ht["Name"].ToString();//实验名称
                Model.Type = Convert.ToByte(ht["Type"].ToString());
                Model.IsOpen = Convert.ToByte(ht["IsOpen"].ToString());
                Model.StartDate = Convert.ToDateTime(ht["StartDate"].ToString());
                Model.Week = Convert.ToInt32(ht["Week"].ToString());
                Model.Weekday = Convert.ToInt32(ht["Weekday"].ToString());
                Model.ClassHour = Convert.ToInt32(ht["ClassHour"].ToString());
                Model.Part = ht["Part"].ToString();
                Model.ComputerRoom = Convert.ToInt32(ht["ComputerRoom"].ToString());
                Model.Place = Convert.ToInt32(ht["Place"].ToString());
                Model.GroupMemberNumber = Convert.ToInt32(ht["GroupMemberNumber"].ToString());
                Model.GroupNumber = Convert.ToInt32(ht["GroupNumber"].ToString());
                Model.NeedEquip = ht["NeedEquip"].ToString();
                Model.Contents = ht["Contents"].ToString();//实验内容
                //Model.Creator = Creator;//创建人登录名
                //Model.CreateTime = DateTime.Now;//创建时间
                Model.Editor = ht["Editor"].ToString();//修改人登录名
                Model.UpdateTime = DateTime.Now;//修改时间
                Model.ClassName = ht["Class"].ToString();//上课班级
                Model.Category = Convert.ToByte(ht["Category"].ToString());//实验类别 0室内上课;1室外上课

                //定义JSON标准格式实体中
                JsonModel jsonModel = new JsonModel();
                int obj = new EmsDAL.PlanExperiment().getPlanExperiment(Model.Name.ToString(), Model.PlanId.ToString());
                if (obj > 0)
                {
                    jsonModel.Status = "cf";
                    jsonModel.Msg = "当前课程下已经有此实验！";
                }
                else
                {
                    int result = dal.Update(Model);
                    if (result == 0)
                    {
                        jsonModel.Status = "no";
                        jsonModel.Msg = "添加失败";
                    }
                    else
                    {
                        jsonModel.Status = "ok";
                        jsonModel.Msg = "添加成功";
                    }
                }
                return jsonModel;

                #region MyRegion
                
                //string[] ClassId = ht["Class"].ToString().Split(',');
                //if (string.IsNullOrWhiteSpace(ht["Class"].ToString()))
                //{
                //    ClassId = new string[0];
                //}

                ////定义JSON标准格式实体中
                //JsonModel jsonModel = new JsonModel();

                ////事务
                //using (SqlTransaction trans = dal.GetTran())
                //{
                //    try
                //    {
                //        int result = dal.Update(trans, Model);
                //        if (result == 0)
                //        {
                //            //回滚
                //            trans.Rollback();
                //            jsonModel.Status = "no";
                //            jsonModel.Msg = "修改失败";
                //            return jsonModel;
                //        }

                        

                //        EmsDAL.ExperimentClassInfo DALEC = new EmsDAL.ExperimentClassInfo();
                //        //清除实验班级
                //        DALEC.DeleteEC(trans, Id);

                //        int AddCount = 0;
                //        foreach (string id in ClassId)
                //        {
                //            EmsModel.ExperimentClassInfo ModelEC = new EmsModel.ExperimentClassInfo();
                //            ModelEC.ExperimentId = Id;
                //            ModelEC.ClassId = Convert.ToInt32(id);
                //            int resultEC = DALEC.Add(trans, ModelEC);
                //            if (resultEC > 0)
                //            {
                //                AddCount++;
                //            }
                //        }
                //        if (ClassId.Length != AddCount)
                //        {
                //            //回滚
                //            trans.Rollback();
                //            jsonModel.Status = "no";
                //            jsonModel.Msg = "班级保存失败";
                //        }
                //        else
                //        {
                //            //提交
                //            trans.Commit();
                //            jsonModel.Status = "ok";
                //            jsonModel.Msg = "修改成功";
                //        }
                //        return jsonModel;
                //    }
                //    catch (Exception)
                //    {
                //        //回滚
                //        trans.Rollback();
                //        throw;
                //    }
                //}

                #endregion
            }
            catch (Exception ex)
            {
                JsonModel jsonModel = new JsonModel();
                jsonModel.Status = "error";
                jsonModel.Msg = ex.ToString();
                return jsonModel;
            }
        }

        #region 班级
        /// <summary>
        /// 获得Model根据Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public EmsModel.JsonModel GetData2(Hashtable ht)
        {
            try
            {
                List<EmsModel.ClassInfo> modList = dal.GetData2(ht);
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
                    Data = modList,
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
        #endregion
    }
}
