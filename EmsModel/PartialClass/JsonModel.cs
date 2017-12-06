using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmsModel
{
    /// <summary>
    /// JSON数据实体
    /// </summary>
    public class JsonModel
    {
        public object Data { get; set; }
        public string Msg { get; set; }
        public string Status { get; set; }
        public string BackUrl { get; set; }

    }
}
