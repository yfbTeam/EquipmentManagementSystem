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
    public partial class UserInfo
    {
        #region 获取用户数据
        public EmsModel.JsonModel GetJsonModel(EmsModel.UserInfo user)
        {
            //当前页
            int pageIndex = 1;
            //页容量
            int pageSize = 16;
            List<EmsModel.UserInfo> modList = GetList(user);
            //定义分页数据实体
            PagedDataModel<EmsModel.UserInfo> pagedDataModel = null;
            //定义JSON标准格式实体中
            JsonModel jsonModel = null;
            if (modList.Count > 0)
            {
                var list = modList;
                //总条数
                int rowCount = modList.Count;
                //总页数
                int pageCount = (int)Math.Ceiling(rowCount * 1.0 / pageSize);
                //将数据封装到PagedDataModel分页数据实体中
                pagedDataModel = new PagedDataModel<EmsModel.UserInfo>()
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

        #region 获取用户数据 分页
        /// <summary>
        /// 获取用户数据 分页
        /// </summary>
        /// <param name="Mod">查询条件</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量，每页显示条数</param>
        /// <returns></returns>
        public EmsModel.JsonModel GetJsonModel(EmsModel.UserInfo Mod, int pageIndex, int pageSize, string roleid, string joinStr)
        {

            List<EmsModel.UserInfo> modList = dal.GetListByPageAndRoleid(Mod, ((pageIndex - 1) * pageSize) + 1, (pageIndex * pageSize), roleid, joinStr);
            //定义分页数据实体
            PagedDataModel<EmsModel.UserInfo> pagedDataModel = null;
            //定义JSON标准格式实体中
            JsonModel jsonModel = null;
            if (modList.Count > 0)
            {
                var list = modList;
                //总条数
                int rowCount = dal.GetListByPageCountAndRoleid(Mod, roleid, joinStr);
                //总页数
                int pageCount = (int)Math.Ceiling(rowCount * 1.0 / pageSize);
                //将数据封装到PagedDataModel分页数据实体中
                pagedDataModel = new PagedDataModel<EmsModel.UserInfo>()
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
        public EmsModel.UserInfo GetEmsModel(int? ID)
        {
            return dal.GetEmsModel(ID);
        }
        public EmsModel.UserInfo GetEmsModelByKaNo(string KaNo)
        {
            return dal.GetEmsModelByKaNo(KaNo);
        }

        public EmsModel.UserInfo GetModelByUserIdCard(string userIdCard)
        {
            Hashtable htCunZai = new Hashtable();
            htCunZai.Add("IDCard", userIdCard);
            bool CunZai = dal.IsExists(htCunZai);
            EmsModel.UserInfo model = new EmsModel.UserInfo();
            if (CunZai)
            {
                model = dal.GetEmsModel(htCunZai);
            }
            return model;
        }

        #endregion

        #region 获取泛型数据列表
        /// <summary>
        /// 获取泛型数据列表
        /// </summary>
        public List<EmsModel.UserInfo> GetList(EmsModel.UserInfo user)
        {
            return dal.GetList(user);
        }
        #endregion


        #region 判断登录名是否已存在
        /// <summary>
        /// 判断登录名是否已存在
        /// </summary>
        public bool IsNameExists(string name, Int32 Id = 0)
        {
            bool bln = dal.IsNameExists(name, Id);
            return bln;
        }
        #endregion

        #region 判断登录
        /// <summary>
        /// 判断登录
        /// </summary>
        public EmsModel.UserInfo IsLogin(string LoginName, string PassWord)
        {
            EmsModel.UserInfo user = dal.IsLogin(LoginName, PassWord);
            if (user != null && user.UseStatus == 0)
            {
                List<string> roleidList = new List<string>(), roleNameList = new List<string>(),
                             wareidList = new List<string>(), wareNameList = new List<string>();
                DataTable roleDt = new EmsBLL.Role().GetRoleByUniqueNo(LoginName);
                if (roleDt.Rows.Count > 0)
                {
                    foreach (DataRow roleRow in roleDt.Rows)
                    {
                        roleidList.Add(roleRow["RoleId"].ToString());
                        roleNameList.Add(roleRow["Name"].ToString());
                    }
                    user.RoleId = string.Join("㊣", roleidList.ToArray());
                    user.RoleName = string.Join("㊣", roleNameList.ToArray());
                }
                DataTable wareDt = new EmsBLL.MenuInfo().GetWarehouseByLoginName(LoginName);
                if (wareDt.Rows.Count > 0)
                {
                    foreach (DataRow wareRow in wareDt.Rows)
                    {
                        wareidList.Add(wareRow["Id"].ToString());
                        wareNameList.Add(wareRow["Name"].ToString());
                    }
                    user.WarehouseId = string.Join("㊣", wareidList.ToArray());
                    user.WarehouseName = string.Join("㊣", wareNameList.ToArray());
                }
            }
            return user;
        }
        #endregion

        /// <summary>
        /// 读取Excel导入数据--教师
        /// </summary>
        /// <param name="ht">参数</param>
        /// <returns></returns>
        public JsonModel ImportTeacher(Hashtable ht)
        {
            try
            {
                BLLCommon common = new BLLCommon();
                DataTable dt = common.ExcelToDataTable(ht["FilePath"].ToString());

                EmsDAL.RoleOfUser DALRoleOfUser = new EmsDAL.RoleOfUser();
                int Yse = 0;//新增条数
                int No = 0;//失败条数
                int Update = 0;//更新条数
                int NoUpdate = 0;//存在相同数据条数
                StringBuilder sb = new StringBuilder();
                StringBuilder sbUp = new StringBuilder();
                StringBuilder sbNoUp = new StringBuilder();
                string isUpdate = System.Configuration.ConfigurationManager.AppSettings["ExportTeacherOperator"];
                string[] RoleIds = ht["RoleId"].ToString().Split(',');
                if (string.IsNullOrWhiteSpace(ht["RoleId"].ToString()))
                {
                    RoleIds = new string[0];
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    try
                    {
                        if (string.IsNullOrWhiteSpace(dr["身份证号"].ToString().Trim()) && string.IsNullOrWhiteSpace(dr["教师名"].ToString().Trim())
                            && string.IsNullOrWhiteSpace(dr["教师号"].ToString().Trim()))
                        {
                            continue;
                        }

                        EmsModel.UserInfo model = new EmsModel.UserInfo();
                        List<EmsModel.RoleOfUser> ListRoleOfUser = new List<EmsModel.RoleOfUser>();
                        foreach (string RoleId in RoleIds)
                        {
                            EmsModel.RoleOfUser ModelRoleOfUser = new EmsModel.RoleOfUser();
                            ModelRoleOfUser.LoginName = dr["教师号"].ToString().Trim();//登录名
                            ModelRoleOfUser.RoleId = Convert.ToInt32(RoleId);//权限ID
                            ListRoleOfUser.Add(ModelRoleOfUser);
                        }


                        Hashtable htCunZai = new Hashtable();
                        htCunZai.Add("IDCard", dr["身份证号"].ToString().Trim());
                        bool CunZai = dal.IsExists(htCunZai);
                        int Id = 0;
                        if (CunZai)
                        {
                            if (isUpdate.ToUpper() != "OFF")
                            {
                                model = dal.GetEmsModel(htCunZai);
                                model.LoginName = dr["教师号"].ToString().Trim();//登录名
                                model.Name = dr["教师名"].ToString().Trim();//用户名
                                //model.PassWord = Md5Encrypting(ht["Password"].ToString());//密码
                                //model.Creator = ht["Creator"].ToString();//创建人
                                //model.CreateTime = DateTime.Now;//创建时间
                                model.Editor = ht["Creator"].ToString();//创建人
                                model.UpdateTime = DateTime.Now;//创建时间
                                model.IsDelete = 0;//是否删除
                                model.Sex = dr["性别"].ToString().Trim();//性别
                                //model.KaNo = "";//卡号
                                //model.KaLv = "";//卡等级
                                //model.UseStatus = Convert.ToByte(ht["UseStatus"].ToString());//使用状态
                                //model.IDCard = dr["身份证号"].ToString().Trim();//身份证号
                                Id = dal.Update(model);
                                Update++;
                                sbUp.Append((i + 1).ToString() + ",");
                            }
                            else
                            {
                                NoUpdate++;
                                sbNoUp.Append((i + 1).ToString() + ",");
                            }
                        }
                        else
                        {
                            model.LoginName = dr["教师号"].ToString().Trim();//登录名
                            model.Name = dr["教师名"].ToString().Trim();//用户名
                            model.PassWord = common.Md5Encrypting(ht["Password"].ToString());//密码
                            model.Creator = ht["Creator"].ToString();//创建人
                            model.CreateTime = DateTime.Now;//创建时间
                            model.IsDelete = 0;//是否删除
                            model.Sex = dr["性别"].ToString().Trim();//性别
                            model.KaNo = "";//卡号
                            model.KaLv = "";//卡等级
                            model.UseStatus = Convert.ToByte(ht["UseStatus"].ToString());//使用状态
                            model.IDCard = dr["身份证号"].ToString().Trim();//身份证号

                            #region 事物添加教师账号、账号权限

                            //事务
                            using (SqlTransaction trans = dal.GetTran())
                            {
                                Id = dal.Add(trans, model);
                                if (Id > 0)
                                {
                                    //添加用户权限
                                    bool RoleOfUserIDBool = true;
                                    foreach (EmsModel.RoleOfUser ModelRoleOfUser in ListRoleOfUser)
                                    {
                                        int ModelRoleOfUserID = DALRoleOfUser.Add(trans, ModelRoleOfUser);
                                        if (ModelRoleOfUserID <= 0)
                                        {
                                            RoleOfUserIDBool = false;
                                            break;
                                        }
                                    }
                                    if (RoleOfUserIDBool)
                                    {
                                        trans.Commit();
                                        Yse++;
                                    }
                                    else
                                    {
                                        Id = 0;
                                        trans.Rollback();
                                    }
                                }
                                else
                                {
                                    Id = 0;
                                    trans.Rollback();
                                }
                            }
                            #endregion
                        }
                        if (Id <= 0)
                        {
                            No++;
                            sb.Append((i + 1).ToString() + ",");
                        }
                    }
                    catch (Exception ex)
                    {
                        //No++;
                        //sb.Append((i + 1).ToString() + ",");
                        JsonModel jsonModels = new JsonModel();
                        jsonModels.Status = "error";
                        jsonModels.Msg = ex.ToString();
                        return jsonModels;
                    }
                }

                JsonModel jsonModel = new JsonModel();
                jsonModel.Status = "ok";
                //jsonModel.Msg = "成功" + Yse + "条，失败" + No + "条，共" + dt.Rows.Count + "条";
                jsonModel.Msg = "成功" + (Yse + Update) + "条，失败" + No + "条";
                if (NoUpdate > 0) jsonModel.Msg += "，已有数据不处理" + NoUpdate + "条";
                if (sb.Length != 0)
                {
                    jsonModel.Msg += "\n失败数据行号：" + sb.ToString();
                }
                if (sbNoUp.Length != 0) jsonModel.Msg += "\n不处理数据行号：" + sbNoUp.ToString();
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
