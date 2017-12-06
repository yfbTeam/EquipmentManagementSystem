using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EmsBLL
{
    public partial class EquipborrowManage
    {
        public DataTable SelectRepairDetails(int BorrowYN, string EQtype, string name,int index)
        {
            return new EmsDAL.EquipborrowManage().SelectEquipborrowManage(BorrowYN, EQtype, name,index); 
        }


        public List<EmsModel.View_EquipDatail> GetList(DataTable dt)
        {
            return new EmsDAL.View_EquipDatail().GetList(dt);
        }


        public string setEquipDetail(string Ystr,string Dstr)
        {
            return new EmsDAL.EquipborrowManage().setEquipDetail(Ystr, Dstr);
        }

    }
}
