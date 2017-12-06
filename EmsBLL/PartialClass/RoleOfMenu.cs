using EmsModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EmsBLL
{
    public partial class RoleOfMenu
    {
        #region 根据角色id获得角色下的菜单
        /// <summary>
        /// 根据角色id获得角色下的菜单
        /// </summary>
        /// <returns></returns>
        public List<EmsModel.RoleOfMenu> GetMenusByRoleid(string roleid)
        {
            return dal.GetMenusByRoleid(roleid);
        }
        #endregion

        #region 设置角色菜单
        /// <summary>
        /// 设置角色菜单
        /// </summary>
        /// <param name="roleid">角色id</param>
        /// <param name="menuids">菜单ids字符串，以逗号连接</param>
        /// <returns>返回 影响行数</returns>
        public JsonModel SetRoleMenu(string roleid, string menuids)
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
                        int result = DelMenusByRoleid(roleid, trans);//删除旧的角色菜单关系
                        
                        string[] idArray = menuids.Split(',');
                        int count = 0;
                        foreach (string menuid in idArray)
                        {
                            EmsModel.RoleOfMenu rm = new EmsModel.RoleOfMenu();
                            rm.RoleId = Convert.ToInt32(roleid);
                            rm.MenuId = Convert.ToInt32(menuid);
                            result = dal.Add(trans, rm);
                            if (result > 0)
                            {
                                count++;
                            }
                        }
                        if (idArray.Length != count)
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

        #region 根据角色id删除角色下的菜单
        /// <summary>
        /// 根据角色id删除角色下的菜单
        /// </summary>
        /// <param name="roleid">角色id</param>
        /// <returns>返回 影响行数</returns>
        public int DelMenusByRoleid(string roleid, SqlTransaction trans = null)
        {
            return dal.DelMenusByRoleid(roleid, trans);
        }
        #endregion
    }
}
