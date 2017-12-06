using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EmsBLL
{
   public partial class View_CountBG
    {
       public DataTable SelectView_CountBG()
       {
           return new EmsDAL.View_CountBG().SelectView_CountBG();
       }
    }
}
