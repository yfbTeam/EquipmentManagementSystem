using EmsModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using EmsDAL;

namespace EmsBLL
{
    public partial class CountALL
    {
        
        BLLCommon common = new BLLCommon();
        public string CountALLb()
        {
            
            try
            {
                EmsDAL.CountALL ec = new EmsDAL.CountALL();
                DataTable dt = ec.CountALLd();
                return common.DataTableToJsonAndArry(dt);

            }
            catch (Exception)
            {
                //写入日志
                throw;
            }
            
        }
    }
}
