using EmsModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EmsBLL
{
     public partial class MenuInfo
    {
        #region 获得权限设置处菜单信息
         /// <summary>
         /// 获得权限设置处菜单信息
         /// </summary>
         /// <returns></returns>
        public DataTable GetPermissionMenu(string roleid)
        {
            return dal.GetPermissionMenu(roleid);                    
        }
        #endregion

        #region 获得首页左侧导航处菜单信息
        /// <summary>
        /// 获得首页左侧导航处菜单信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetLeftNavigationMenu(string loginUID,string adminUID)
        {
            return dal.GetLeftNavigationMenu(loginUID, adminUID);
        }
        #endregion

        #region 根据登录名获得所属库房
        /// <summary>
        /// 根据登录名获得所属库房
        /// </summary>
        /// <returns></returns>
        public DataTable GetWarehouseByLoginName(string loginname)
        {
            return dal.GetWarehouseByLoginName(loginname);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EmsModel.MenuInfo GetEmsModel(int? ID)
        {
            return dal.GetEmsModel(ID);
        }
        #endregion        

        #region 根据菜单名称获取对象实体
        /// <summary>
        /// 根据菜单名称获取对象实体
        /// </summary>
        public EmsModel.MenuInfo GetEmsModelByName(string name)
        {
            return dal.GetEmsModelByName(name);
        }
        #endregion
    }
}
