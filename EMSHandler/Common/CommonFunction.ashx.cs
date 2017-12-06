using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMSHandler.Common
{
    /// <summary>
    /// CommonFunction 的摘要说明
    /// </summary>
    public class CommonFunction : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string action = context.Request["action"];
            if (!string.IsNullOrEmpty(action))
            {
                switch (action)
                {
                    case "ChangeUseStatus":
                        ChangeUseStatus(context);
                        break;
                    default:
                        break;
                }
            }
        }

        public void ChangeUseStatus(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            int itemid = Convert.ToInt32(context.Request["itemid"]);
            byte status = Convert.ToByte(context.Request["Status"]);
            string tablename = context.Request["tablename"];
            int result;
            switch (tablename)
            {
                case "UserInfo":
                    EmsModel.UserInfo user = new EmsBLL.UserInfo().GetEmsModel(itemid);
                    user.Id = itemid;
                    //user.IsDelete = 1;
                    user.UseStatus = status;
                    result = new EmsBLL.UserInfo().Update(user);
                    break;
                case "Student":
                    EmsModel.Student stu = new EmsBLL.Student().GetEmsModel(itemid);
                    stu.Id = itemid;
                    stu.UseStatus = status;
                    result = new EmsBLL.Student().Update(stu);
                    break;
                case "Warehouse":
                    EmsModel.Warehouse ware = new EmsBLL.Warehouse().GetEmsModel(itemid);
                    ware.Id = itemid;
                    ware.UseStatus = status;
                    result = new EmsBLL.Warehouse().Update(ware);
                    break;
                case "InstrumentEquip":
                    EmsModel.InstrumentEquip insEp = new EmsBLL.InstrumentEquip().GetEmsModel(itemid);
                    insEp.Id = itemid;
                    insEp.UseStatus = status;
                    result = new EmsBLL.InstrumentEquip().Update(insEp);
                    break;
                case "EquipDetail":
                    EmsModel.EquipDetail equip = new EmsBLL.EquipDetail().GetEmsModel(itemid);
                    equip.Id = itemid;
                    equip.UseStatus = status;
                    result = new EmsBLL.EquipDetail().Update(equip);
                    break;
                case "ClassInfo":
                    EmsModel.ClassInfo cla = new EmsBLL.ClassInfo().GetEmsModel(itemid);
                    cla.Id = itemid;
                    cla.UseStatus = status;
                    result = new EmsBLL.ClassInfo().Update(cla);
                    break;
                case "LearnYear":
                    EmsModel.LearnYear ley = new EmsBLL.LearnYear().GetEmsModel(itemid);
                    ley.Id = itemid;
                    ley.UseStatus = status;
                    result = new EmsBLL.LearnYear().Update(ley);
                    break;
                case "SectionPlace":
                    EmsModel.SectionPlace spla = new EmsBLL.SectionPlace().GetEmsModel(itemid);
                    spla.Id = itemid;
                    spla.UseStatus = status;
                    result = new EmsBLL.SectionPlace().Update(spla);
                    break;
                default:
                    result = 0;
                    break;
            }
            //输出Json
            context.Response.Write(callback + "({\"result\":" + result + "})");
            context.Response.End();
        }

        public bool IsReusable
        {
            get { throw new NotImplementedException(); }
        }

        bool IHttpHandler.IsReusable
        {
            get { throw new NotImplementedException(); }
        }

        //void IHttpHandler.ProcessRequest(HttpContext context)
        //{
        //    throw new NotImplementedException();
        //}
    }
}