using EmsModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace EmsBLL
{
    public partial class EquipDetail
    {
        BLLCommon common = new BLLCommon();
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
                        ht.Remove("EquipOwner");
                    }
                }

                DataTable modList = dal.GetPage(ht);
                //定义分页数据实体
                PagedDataModel<Dictionary<string,object>> pagedDataModel = null;
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
        #region 获得设备详情信息
        /// <summary>
        /// 获得设备详情信息
        /// </summary>
        /// <param name="ht">查询条件</param>
        /// <returns>符合数据</returns>
        public JsonModel GetEquipDetail(Hashtable ht)
        {
            try
            {
                DataTable dt = dal.GetEquipDetail(ht);
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
                List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
                list = common.DataTableToList(dt);
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
                JsonModel jsonModel = new JsonModel();
                jsonModel.Status = "error";
                jsonModel.Msg = ex.ToString();
                return jsonModel;
            }
        }
        #endregion        

        #region 根据条形码得到一个对象实体
        public EmsModel.EquipDetail GetModelByBarcode(string ID)
        {
            return dal.GetModelByBarcode(ID);
        }
        #endregion

        #region 根据Id获取仪器设备历史列表数据 分页
        /// <summary>
        /// 根据Id获取仪器设备历史列表数据 分页
        /// </summary>
        /// <param name="Mod">查询条件</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量，每页显示条数</param>
        /// <returns></returns>
        public EmsModel.JsonModel GetJsonModelByEquipId(Hashtable ht, bool ispage = true)
        {
            List<SqlParameter> pms = new List<SqlParameter>();
            int PageIndex = 0, PageSize = 0, PageCount = 0, RowCount = 0;
            if (ispage)
            {
                //增加起始条数、结束条数
                ht = common.AddStartEndIndex(ht);
                PageIndex = Convert.ToInt32(ht["PageIndex"]);
                PageSize = Convert.ToInt32(ht["PageSize"]);
            }
            DataTable modList = dal.GetListByPageAndEquipId(ht, ispage);
            //定义分页数据实体
            PagedDataModel<Dictionary<string, object>> pagedDataModel = null;
            //定义JSON标准格式实体中
            JsonModel jsonModel = null;
            if (modList.Rows.Count> 0)
            {
                //总条数
                RowCount = Convert.ToInt32(ht["RowCount"].ToString());
                if (ispage)
                {
                    //总页数
                    PageCount = (int)Math.Ceiling(RowCount * 1.0 / PageSize);
                }            
                List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
                list = common.DataTableToList(modList);
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
        
        #region 耗材入库
        /// <summary>
        /// 耗材入库
        /// </summary>
        /// <param name="equip">仪器设备对象</param>
        /// <returns></returns>
        public JsonModel EquipIntoCount(EmsModel.EquipDetail equip,int newCount)
        {
            //定义JSON标准格式实体中
            JsonModel jsonModel = new JsonModel();
            try
            {
                //事务
                using (SqlTransaction trans = dal.GetTran())
                {
                    try
                    {
                        EmsModel.EquipInto into = new EmsModel.EquipInto();
                        into.EquipKindId = equip.Id;
                        into.WarehouseId = 0;
                        into.Count = newCount;
                        into.Creator = equip.Editor;
                        into.CreateTime = DateTime.Now;
                        into.IsDelete = 0;
                        int result = dal.Update(trans,equip);//修改仪器设备数量
                        if (result == 0)
                        {
                            trans.Rollback();//回滚
                            jsonModel.Status = "no";
                            jsonModel.Msg = "保存失败";
                            return jsonModel;
                        }
                        result = new EmsDAL.EquipInto().Add(trans, into);
                        if (result==0)
                        {
                            trans.Rollback();//回滚
                            jsonModel.Status = "no";
                            jsonModel.Msg = "保存失败";
                            return jsonModel;
                        }
                        else
                        {
                            trans.Commit();//提交
                        }
                    }
                    catch (Exception)
                    {
                        trans.Rollback();//回滚
                        throw;
                    }
                }
                jsonModel.Status = "ok";
                jsonModel.Msg = "操作成功";
                return jsonModel;
            }
            catch (Exception ex)
            {
                jsonModel.Status = "error";
                jsonModel.Msg = ex.ToString();
                return jsonModel;
            }
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EmsModel.EquipDetail GetEmsModel(int? ID)
        {
            return dal.GetEmsModel(ID);
        }
        #endregion

        #region 根据楼房id/楼层id/房间id，判断房间是否已存放仪器
        /// <summary>
        /// 根据楼房id/楼层id/房间id，判断房间是否已存放仪器
        /// </summary>
        public bool IsHasEquipByRoomIds(string buildid, string flag)
        {
            return dal.IsHasEquipByRoomIds(buildid, flag);
        }
        #endregion

        #region 判断耗材是否已存在
        /// <summary
        /// 判断耗材是否已存在
        /// </summary>
        public bool IsInsEpExists(string name,byte type,Int32 Id = 0)
        {
            bool bln = dal.IsInsEpExists(name,type,Id);
            return bln;
        }
        #endregion

        #region 获取办公家具的负责人
        /// <summary>
        /// 获取办公家具的负责人
        /// </summary>  
        public JsonModel GetOfficeFurOwner()
        {
            return common.GetJsonModelByDataTable(dal.GetOfficeFurOwner());
        }
        #endregion

        /// <summary>
        /// 读取Excel导入数据--设备
        /// </summary>
        /// <param name="ht">参数</param>
        /// <returns></returns>
        public JsonModel ImportEquip(Hashtable ht)
        {
            try
            {
                DataTable dt = common.ExcelToDataTable(ht["FilePath"].ToString());

                int Yse = 0;
                int No = 0;
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    try
                    {
                        if (string.IsNullOrWhiteSpace(dr["资产编号"].ToString().Trim()) && string.IsNullOrWhiteSpace(dr["资产名称"].ToString().Trim()))
                        {
                            continue;
                        }
                        EmsModel.EquipDetail model = new EmsModel.EquipDetail();

                        Hashtable htCunZai = new Hashtable();
                        htCunZai.Add("AssetNumber", dr["资产编号"].ToString().Trim());
                        bool CunZai = dal.IsExists(htCunZai);
                        if (CunZai)
                        {
                            continue;
                        }
                        model.EquipKindId = 0;//设备分类Id
                        model.AssetNumber = dr["资产编号"].ToString().Trim();//资产编号
                        model.EquipIntoID = 0;//设备入库ID
                        model.EquipStatus = 0;//设备状态 0  未借出 ; 1 已借出;2 维修;3 停用;4 报废
                        if (dr["资产类别"].ToString().Trim() == "教学设备")
                        {
                            model.Type = 0;//类型 0教学设备;1科研设备;2办公设备
                        }
                        else if (dr["资产类别"].ToString().Trim() == "科研设备")
                        {
                            model.Type = 1;//类型 0教学设备;1科研设备;2办公设备
                        }
                        else if (dr["资产类别"].ToString().Trim() == "办公设备")
                        {
                            model.Type = 2;//类型 0教学设备;1科研设备;2办公设备
                        }
                        else
                        {
                            model.Type = 0;//类型 0教学设备;1科研设备;2办公设备
                        }
                        if (dr["是否耗材"].ToString().Trim() == "非耗材")
                        {
                            model.IsConsume = 0;//0 非耗材;1 耗材;
                        }
                        else if (dr["是否耗材"].ToString().Trim() == "耗材")
                        {
                            model.IsConsume = 1;//0 非耗材;1 耗材;
                        }
                        else
                        {
                            model.IsConsume = 0;//0 非耗材;1 耗材;
                        }

                        model.EquipSource = 1;//资产来源 0本院资产;1资产系统;
                        model.Barcode = model.AssetNumber;//条形码
                        model.ImageName = "";//图片
                        model.Count = 1;//数量
                        model.ClassNumber = dr["资产分类代码"].ToString().Trim();//分类号
                        model.AssetsClassName = dr["资产分类名称"].ToString().Trim();//资产分类名称
                        model.IntlClassCode = "";//国标分类代码
                        model.IntlClassName = dr["国标分类名称"].ToString().Trim();//国标分类名称
                        model.AssetName = dr["资产名称"].ToString().Trim();//资产名称
                        model.Unit = dr["计量单位"].ToString().Trim();//计量单位
                        model.UsageStatus = dr["使用状况"].ToString().Trim();//使用状况
                        model.UsageDirection = dr["使用方向"].ToString().Trim();//使用方向
                        model.JYBBBSYFX = dr["教育使用方向"].ToString().Trim();//教育部报表使用方向
                        model.AcquisitionMethod = dr["取得方式"].ToString().Trim();//取得方式
                        if (common.IsDateTime(dr["取得日期"].ToString().Trim()))
                        {
                            model.AcquisitionDate = Convert.ToDateTime(dr["取得日期"].ToString().Trim());//取得日期
                        }
                        model.BrandStandardModel = dr["规格型号"].ToString().Trim();//品牌及规格型号
                        model.EquipmentUse = dr["设备用途"].ToString().Trim();//设备用途
                        model.UseDepartment = dr["使用/管理部门"].ToString().Trim();//使用/管理部门
                        model.UsePeople = dr["使用人"].ToString().Trim();//使用人
                        model.Factory = dr["厂家"].ToString().Trim();//厂家
                        model.StorageLocation = "0";//存放地点
                        model.WorthType = dr["价值类型"].ToString().Trim();//价值类型
                        model.UseNature = dr["使用性质"].ToString().Trim();//使用性质
                        if (common.IsDecimal(dr["价值"].ToString().Trim()))
                        {
                            model.Worth = Convert.ToDecimal(dr["价值"].ToString().Trim());//价值
                        }
                        model.FinanceRecordType = dr["入账形式"].ToString().Trim();//财务入账形式
                        if (common.IsDecimal(dr["财政性资金"].ToString().Trim()))
                        {
                            model.FiscalFunds = Convert.ToDecimal(dr["财政性资金"].ToString().Trim());//财政性资金
                        }
                        if (common.IsDecimal(dr["非财政性资金"].ToString().Trim()))
                        {
                            model.NonFiscalFunds = Convert.ToDecimal(dr["非财政性资金"].ToString().Trim());//非财政性资金
                        }
                        if (common.IsDateTime(dr["财务入账日期"].ToString().Trim()))
                        {
                            model.FinanceRecordDate = Convert.ToDateTime(dr["财务入账日期"].ToString().Trim());//财务入账日期
                        }
                        model.VoucherNumber = dr["凭证号"].ToString().Trim();//凭证号
                        if (common.IsInt(dr["预计使用年限/寿命/种龄"].ToString().Trim()))
                        {
                            model.UseTime = Convert.ToInt32(dr["预计使用年限/寿命/种龄"].ToString().Trim());//使用年限（月）
                        }
                        //model.ExpectedScrapDate = Convert.ToDateTime(dr["资产编号"].ToString().Trim());//预计报废时间
                        model.DepreciationState = "";//折旧状态
                        model.NetWorth = 0;//净值
                        model.OutFactoryNumber = dr["出厂号"].ToString().Trim();//出厂号
                        model.Supplier = dr["供货商"].ToString().Trim();//供货商
                        model.FundsSubject = dr["经费科目"].ToString().Trim();//经费科目
                        model.PurchaseModality = dr["采购组织形式"].ToString().Trim();//采购组织形式
                        model.CountryCode = dr["国别码"].ToString().Trim();//国别码
                        model.Operator = dr["经办人"].ToString().Trim();//经手人
                        if (common.IsDateTime(dr["保修截止日期"].ToString().Trim()))
                        {
                            model.GuaranteeEndDate = Convert.ToDateTime(dr["保修截止日期"].ToString().Trim());//保修截止日期
                        }
                        model.EquipmentNumber = dr["设备号"].ToString().Trim();//设备号
                        model.InvoiceNumber = dr["发票号"].ToString().Trim();//发票号
                        model.CompactNumber = dr["合同号"].ToString().Trim();//合同号
                        model.BasicFunds = "";//基本经费
                        model.ItemFunds1 = dr["项目经费1"].ToString().Trim();//项目经费1
                        model.ItemFunds2 = "";//项目经费2
                        model.ItemFunds3 = "";//项目经费3
                        model.ItemFunds4 = "";//项目经费4
                        if (common.IsDecimal(dr["保修截止日期"].ToString().Trim()))
                        {
                            model.ItemFundsMoney1 = Convert.ToDecimal(dr["项目经费1金额"].ToString().Trim());//项目经费1金额
                        }
                        model.ItemFundsMoney2 = 0;//项目经费2金额
                        model.ItemFundsMoney3 = 0;//项目经费3金额
                        model.ItemFundsMoney4 = 0;//项目经费4金额
                        model.Remarks = dr["备注"].ToString().Trim();//备注
                        model.Creator = ht["Creator"].ToString();//创建人
                        model.CreateTime = DateTime.Now;//创建时间
                        model.IsDelete = 0;//是否删除
                        model.UseStatus = Convert.ToByte(ht["UseStatus"].ToString());//使用状态
                        model.StorageLocation1 = dr["存放地点"].ToString().Trim();//存放地点
                        

                        int Id = dal.Add(model);
                        if (Id > 0)
                        {
                            Yse++;
                        }
                        else
                        {
                            No++;
                            sb.Append((i + 2).ToString() + ",");
                        }
                    }
                    catch (Exception)
                    {
                        No++;
                        sb.Append((i + 2).ToString() + ",");
                    }
                }

                JsonModel jsonModel = new JsonModel();
                jsonModel.Status = "ok";
                //jsonModel.Msg = "成功" + Yse + "条，失败" + No + "条，共" + dt.Rows.Count + "条";
                jsonModel.Msg = "成功" + Yse + "条，失败" + No + "条";
                if (sb.Length != 0)
                {
                    jsonModel.Msg += "\n失败数据行号：" + sb.ToString();
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
        /// 分页查询库存情况
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public JsonModel GetPageStock(Hashtable ht)
        {
            try
            {
                //增加起始条数、结束条数
                ht = common.AddStartEndIndex(ht);
                int PageIndex = Convert.ToInt32(ht["PageIndex"]);
                int PageSize = Convert.ToInt32(ht["PageSize"]);
                DataTable dt = dal.GetListStock(ht);

                //定义分页数据实体
                PagedDataModel<Dictionary<string, object>> pagedDataModel = null;
                //定义JSON标准格式实体中
                JsonModel jsonModel = null;
                if (dt.Rows.Count <= 0)
                {
                    jsonModel = new JsonModel()
                    {
                        Status = "no",
                        Msg = "没有数据"
                    };
                    return jsonModel;
                }
                List<Dictionary<string,object>> list = common.DataTableToList(dt);
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
        /// 获得数据数量
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public JsonModel GetDataCount(Hashtable ht)
        {
            try
            {
                int count = dal.GetDataCount(ht);

                //定义JSON标准格式实体中
                JsonModel jsonModel = null;
                //将分页数据实体封装到JSON标准实体中
                jsonModel = new JsonModel()
                {
                    Data = count,
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


        public List<EmsModel.EquipDetail> GetEmsModelExperimentId(string ID,string type)
        {
            return dal.GetEmsModelExperimentId(ID,"1");
        }

        /// <summary>
        /// 分页查询科研设备信息
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public JsonModel GetPageStock2(Hashtable ht)
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
                        ht.Remove("LoginUserIDCard");
                    }
                }

                DataTable dt = dal.GetListStock2(ht);

                //定义分页数据实体
                PagedDataModel<Dictionary<string, object>> pagedDataModel = null;
                //定义JSON标准格式实体中
                JsonModel jsonModel = null;
                if (dt.Rows.Count <= 0)
                {
                    jsonModel = new JsonModel()
                    {
                        Status = "no",
                        Msg = "没有数据"
                    };
                    return jsonModel;
                }
                List<Dictionary<string, object>> list = common.DataTableToList(dt);
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
        /// 添加设备
        /// </summary>
        /// <param name="ht">参数</param>
        /// <returns></returns>
        public JsonModel AddEquip(Hashtable ht)
        {
            try
            {
                EmsModel.EquipDetail model = new EmsModel.EquipDetail();
                model.EquipKindId = 0;//设备分类
                //model.AssetNumber = ht["AssetNumber"].ToString();//资产号
                model.AssetNumber = "BY" + DateTime.Now.ToString("yyMMddhhmmssffff");//资产号
                model.EquipIntoID = 0;//设备入库ID
                model.EquipStatus = 0;//设备状态
                model.Type = Convert.ToByte(ht["Type"].ToString());//类型 0教学资产;1科研资产;2办公资产
                model.Barcode = model.AssetNumber;//条形码
                model.ImageName =Convert.ToString(ht["ImageNeme"]);//图片
                model.ImageUrl = Convert.ToString(ht["ImageUrl"]);//图片路径
                model.ClassNumber = Convert.ToString(ht["ClassNumber"]);//分类号
                model.AssetsClassName = Convert.ToString(ht["AssetsClassName"]);//资产分类名称
                model.IntlClassCode = Convert.ToString(ht["IntlClassCode"]);//国际分类代码
                model.IntlClassName = Convert.ToString(ht["IntlClassName"]);//国际分类名称
                model.AssetName = Convert.ToString(ht["AssetName"]);//资产名称
                model.Unit = Convert.ToString(ht["Unit"]);//单位
                //model.UsageStatus = ht["UsageStatus"].ToString();//使用状况
                model.UsageDirection = Convert.ToString(ht["UsageDirection"]);//使用方向
                //model.JYBBBSYFX = ht["JYBBBSYFX"].ToString();//教育部报表使用方向
                //model.AcquisitionMethod = ht["AcquisitionMethod"].ToString();//取得方式
                //model.AcquisitionDate = Convert.ToDateTime(ht["AcquisitionDate"].ToString());//取得日期
                model.BrandStandardModel = Convert.ToString(ht["BrandStandardModel"]);//品牌及规格型号
                model.Remarks = Convert.ToString(ht["Remarks"]);//备注
                model.Creator = Convert.ToString(ht["UserIDCard"]);//创建人
                model.CreateTime = DateTime.Now;//创建时间
                model.IsDelete = 0;//是否删除
                model.EquipSource = 0;//0本院资产;1资产系统
                model.IsConsume = 0;//非耗材
                model.Count = 1;//是否删除
                int result = dal.Add(model);
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
        /// 修改课程
        /// </summary>
        /// <param name="ht">参数Key:Id</param>
        /// <returns></returns>
        public JsonModel UpdateEquip(Hashtable ht)
        {
            try
            {
                EmsModel.EquipDetail model = dal.GetEmsModel(Convert.ToInt32(ht["ID"].ToString()));
                //model.EquipKindId = 0;//设备分类
                //model.AssetNumber = ht["AssetNumber"].ToString();//资产号
                //model.EquipIntoID = 0;//设备入库ID
                //model.EquipStatus = 0;//设备状态
                model.Type = Convert.ToByte(ht["Type"].ToString());//类型 0教学资产;1科研资产;2办公资产
                //model.Barcode = DateTime.Now.ToString("yyMMddhhmmssffff");//条形码
                model.ImageName = Convert.ToString(ht["ImageName"]);//图片
                model.ImageUrl = Convert.ToString(ht["ImageUrl"]);//图片路径
                model.ClassNumber = Convert.ToString(ht["ClassNumber"]);//分类号
                model.AssetsClassName = Convert.ToString(ht["AssetsClassName"]);//资产分类名称
                model.IntlClassCode = Convert.ToString(ht["IntlClassCode"]);//国际分类代码
                model.IntlClassName = Convert.ToString(ht["IntlClassName"]);//国际分类名称
                model.AssetName = Convert.ToString(ht["AssetName"]);//资产名称
                model.Unit = Convert.ToString(ht["Unit"]);//单位
                //model.UsageStatus = ht["UsageStatus"].ToString();//使用状况
                model.UsageDirection = Convert.ToString(ht["UsageDirection"]);//使用方向
                //model.JYBBBSYFX = ht["JYBBBSYFX"].ToString();//教育部报表使用方向
                //model.AcquisitionMethod = ht["AcquisitionMethod"].ToString();//取得方式
                //model.AcquisitionDate = Convert.ToDateTime(ht["AcquisitionDate"].ToString());//取得日期
                model.BrandStandardModel = Convert.ToString(ht["BrandStandardModel"]);//品牌及规格型号
                model.Remarks =Convert.ToString(ht["Remarks"]);//备注
                //model.Creator = ht["Creator"].ToString();//创建人
                //model.CreateTime = DateTime.Now;//创建时间
                model.Editor = Convert.ToString(ht["UserIDCard"]);//修改人
                model.UpdateTime = DateTime.Now;//修改时间
                //model.IsDelete = 0;//是否删除
                //model.EquipSource = 0;//0本院资产;1资产系统
                //model.IsConsume = 0;//非耗材
                //model.Count = 1;//数量
                model.ManualModify = 1;//是否手动修改 0未修改 1修改

                int result = dal.Update(model);

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

        /// <summary>
        /// 获得设备信息
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public JsonModel GetEquip(Hashtable ht)
        {
            try
            {
                EmsModel.EquipDetail model = dal.GetEmsModel(Convert.ToInt32(ht["Id"].ToString()));
                //定义JSON标准格式实体中
                JsonModel jsonModel = null;
                if (model == null)
                {
                    jsonModel = new JsonModel()
                    {
                        Status = "no",
                        Msg = ""
                    };
                    return jsonModel;
                }
                else
                {
                    //将分页数据实体封装到JSON标准实体中
                    jsonModel = new JsonModel()
                    {
                        Data = model,
                        Msg = "",
                        Status = "ok",
                        BackUrl = ""
                    };
                    return jsonModel;
                }
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
        /// 导出设备信息
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public JsonModel ExportEquipExcel(Hashtable ht)
        {
            try
            {
                
                DataTable modList = dal.ExportEquip(ht);
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
        /// 添加设备
        /// </summary>
        /// <param name="ht">参数</param>
        /// <returns></returns>
        public JsonModel UpdateStatus(Hashtable ht)
        {
            try
            {
                bool result = dal.UpdateStatus(ht);
                //定义JSON标准格式实体中
                JsonModel jsonModel = new JsonModel();
                if (result)
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

        
    }
}
