using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmsModel
{
    public partial class EquipHistory
    {
        /// <summary>
        /// 仪器设备Id
        /// </summary>
        public int? EquipId { get; set; }
        /// <summary>
        /// 借用人姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 借用人身份证号
        /// </summary>
        public string UserIDCard { get; set; }
        /// <summary>
        /// 入库/借出数量
        /// </summary>
        public int? Count { get; set; }
        /// <summary>
        /// 入库/借出时间
        /// </summary>
        public DateTime? LendTime { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }       
    }
}
