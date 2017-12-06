using EmsModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EmsBLL
{
    public partial class LearnYear
    {
        BLLCommon common = new BLLCommon();

        /// <summary>
        /// 获得Model根据Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public EmsModel.JsonModel GetModel(string Id)
        {
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("Id", Id);
                List<EmsModel.LearnYear> modList = dal.GetModelList(ht);
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
        /// 获得Model集合
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public EmsModel.JsonModel GetModelList(Hashtable ht)
        {
            try
            {
                List<EmsModel.LearnYear> modList = dal.GetModelList(ht);
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
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="ht">查询条件</param>
        /// <returns></returns>
        public JsonModel GetPage(Hashtable ht)
        {
            try
            {
                //增加起始条数、结束条数
                ht = common.AddStartEndIndex(ht);
                int PageIndex = Convert.ToInt32(ht["PageIndex"]);
                int PageSize = Convert.ToInt32(ht["PageSize"]);

                if (ht.Contains("UserRoleName") && ht["UserRoleName"].ToString() == "管理员")
                {
                    ht.Remove("Creator");
                }

                DataTable modList = dal.GetPage(ht);
                //定义分页数据实体
                PagedDataModel<string> pagedDataModel = null;
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
                List<string> list=new List<string> ();
                list.Add(common.DataTableToJson(modList));
                //总条数
                int RowCount = Convert.ToInt32(ht["RowCount"].ToString());
                //总页数
                int PageCount = (int)Math.Ceiling(RowCount * 1.0 / PageSize); 
                //将数据封装到PagedDataModel分页数据实体中
                pagedDataModel = new PagedDataModel<string>()
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
        /// 添加
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public JsonModel Add(Hashtable ht)
        {
            try
            {
                EmsModel.LearnYear Model = new EmsModel.LearnYear();
                Model.Name = ht["Name"].ToString();//学期名称
                Model.StartDate = Convert.ToDateTime(ht["StartDate"].ToString());//开学时间
                Model.EndDate = Convert.ToDateTime(ht["EndDate"].ToString());//结束时间
                Model.DataCollectionTime = Convert.ToByte(ht["DataCollectionTime"].ToString());//数据采集时间
                Model.Creator = ht["Creator"].ToString();//创建人
                Model.CreateTime = DateTime.Now;//创建时间
                //Model.Editor = ht["Editor"].ToString();//修改人
                //Model.UpdateTime = Convert.ToDateTime(ht["UpdateTime"].ToString());//修改时间
                Model.Remarks = ht["Remarks"].ToString();//备注
                Model.IsDelete = 0;//是否删除

                int result = dal.Add(Model);
                //定义JSON标准格式实体中
                JsonModel jsonModel = new JsonModel();
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
        /// 修改
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public JsonModel Update(Hashtable ht)
        {
            try
            {

                EmsModel.LearnYear Model = dal.GetModelList(ht)[0];
                Model.Name = ht["Name"].ToString();//学期名称
                Model.StartDate = Convert.ToDateTime(ht["StartDate"].ToString());//开学时间
                Model.EndDate = Convert.ToDateTime(ht["EndDate"].ToString());//结束时间
                Model.DataCollectionTime = Convert.ToByte(ht["DataCollectionTime"].ToString());//数据采集时间
                //Model.Creator = ht["Creator"].ToString();//创建人
                //Model.CreateTime = Convert.ToDateTime(ht["CreateTime"].ToString());//创建时间
                Model.Editor = ht["Editor"].ToString();//修改人
                Model.UpdateTime = DateTime.Now;//修改时间
                Model.Remarks = ht["Remarks"].ToString();//备注
                //Model.IsDelete = 0;//是否删除

                int result = dal.Update(Model);

                //定义JSON标准格式实体中
                JsonModel jsonModel = new JsonModel();

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

        #region 获取学期列表数据 分页
        /// <summary>
        /// 获取学期列表数据 分页
        /// </summary>
        /// <param name="Mod">查询条件</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量，每页显示条数</param>
        /// <returns></returns>
        public EmsModel.JsonModel GetJsonModel(EmsModel.LearnYear Mod, int pageIndex, int pageSize)
        {
            List<EmsModel.LearnYear> modList = dal.GetListByPageAndSear(Mod, ((pageIndex - 1) * pageSize) + 1, (pageIndex * pageSize));
            //定义分页数据实体
            PagedDataModel<EmsModel.LearnYear> pagedDataModel = null;
            //定义JSON标准格式实体中
            JsonModel jsonModel = null;
            if (modList.Count > 0)
            {
                var list = modList;
                //总条数
                int rowCount = dal.GetListByPageCountAndSear(Mod);
                //总页数
                int pageCount = (int)Math.Ceiling(rowCount * 1.0 / pageSize);
                //将数据封装到PagedDataModel分页数据实体中
                pagedDataModel = new PagedDataModel<EmsModel.LearnYear>()
                {
                    PageCount = pageCount,
                    PagedData = list,
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    RowCount = rowCount
                };
                //将分页数据实体封装到JSON标准实体中
                jsonModel = new JsonModel()
                {
                    Data = pagedDataModel,
                    Msg = "成功",
                    Status = "ok",
                    BackUrl = ""
                };
                return jsonModel;
            }
            else
            {
                jsonModel = new JsonModel()
                {
                    Status = "no",
                    Msg = "失败"
                };
                return jsonModel;
            }
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EmsModel.LearnYear GetEmsModel(int? ID)
        {
            return dal.GetEmsModel(ID);
        }
        #endregion

        #region 判断学期名称是否已存在
        /// <summary>
        /// 判断学期名称是否已存在
        /// </summary>
        public bool IsNameExists(string name, Int32 Id = 0)
        {
            bool bln = dal.IsNameExists(name, Id);
            return bln;
        }
        #endregion
    }
}
