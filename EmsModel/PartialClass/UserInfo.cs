using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmsModel
{
    public partial class UserInfo
    {
        /// <summary>
        /// 角色id
        /// </summary>
        public string RoleId { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 库房id
        /// </summary>
        public string WarehouseId { get; set; }
        /// <summary>
        /// 库房名称
        /// </summary>
        public string WarehouseName { get; set; }
    }
}
