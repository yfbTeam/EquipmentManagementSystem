using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace EMSHandler.SystemSettings
{
    /// <summary>
    /// Building 的摘要说明
    /// </summary>
    public class Building : IHttpHandler
    {
        GetUserNameHandler nameCommon = new GetUserNameHandler();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action=context.Request.QueryString["action"];
            if (!string.IsNullOrEmpty(action))
            {
                switch (action)
                {
                    case "GetDataPage": GetDataPage(context); break;
                    case "GetBuildingData": GetBuildingData(context); break;
                    case "GetLayersAndRoomsById": GetLayersAndRoomsById(context); break;
                    case "GetModelById": GetModelById(context); break;
                    case "AddBuilding": AddBuilding(context); break;
                    case "EditBuilding": EditBuilding(context); break;
                    case "DeleteBuilding": DeleteBuilding(context); break;
                    case "GetRoomInfoByType": GetRoomInfoByType(context); break;
                    case "SetRoomDistributionEquip": SetRoomDistributionEquip(context); break;
                    case "MoveEquipOutRoom": MoveEquipOutRoom(context); break;
                    case "GetBuildingDataNew": GetBuildingDataNew(context); break;
                    case "GetLayersAndRoomsByIdNew": GetLayersAndRoomsByIdNew(context); break;
                    case "MoveEquipOutRoomNew": MoveEquipOutRoomNew(context); break;
                    default:
                        context.Response.Write("System Error");
                        break;
                }
            }
            else
            {
                context.Response.Write("System Error");
            }
            
        }

        #region 获取楼房列表数据 分页
        public void GetDataPage(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            //当前页
            int startIndex = Convert.ToInt32(context.Request["startIndex"]);
            //页容量
            int pageSize = Convert.ToInt32(context.Request["pageSize"]);
            int pid = Convert.ToInt32(context.Request["pid"]);
            EmsModel.Building build = new EmsModel.Building();
            build.PID = pid;
            build.IsDelete = 0;
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.JsonModel mod = new EmsBLL.Building().GetJsonModel(build, startIndex, pageSize);
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(mod) + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 获取楼房数据
        public void GetBuildingData(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            string type = context.Request["type"];
            type = string.IsNullOrEmpty(type) ? "" : type;
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            DataTable dt = new EmsBLL.Building().GetBuildingInfo("0", type);
            StringBuilder orgJson = new StringBuilder();
            string selid = "";
            if (dt.Rows.Count > 0)
            {
                selid = dt.Rows[0]["Id"].ToString();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var liclass = i == 0 ? " class='selected_build' " : "";
                    orgJson.Append("<li " + liclass + " id='buildli_" + dt.Rows[i]["Id"] + "' onclick='BuildLiClick(this)'>" + dt.Rows[i]["Name"] + "</li>");
                }
            }
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":\"" + orgJson.ToString() + "\",\"selid\":\"" + selid + "\"})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 根据楼房id获得楼层及房间信息
        public void GetLayersAndRoomsById(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            string itemid = context.Request["itemid"];
            string type = context.Request["type"];
            string secplaceid = context.Request["secplaceid"];
            bool istype = string.IsNullOrEmpty(type);
            type = istype ? "" : type;
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            DataTable dt = new EmsBLL.Building().GetLayersAndRoomsById(itemid, type, secplaceid);//获得楼层及房间信息
            StringBuilder orgJson = new StringBuilder();
            DataRow[] parLayer = dt.Select("Pid=" + itemid);//得到楼层信息
            if (parLayer.Count() > 0)
            {
                for (int i = 0; i < parLayer.Count(); i++)
                {
                    orgJson.Append("<dl class='listIndex' attr='terminal_brand_s'>");
                    orgJson.Append("<dt>第" + parLayer[i]["Name"].ToString() + "层</dt>");
                    orgJson.Append("<dd>");
                    if (istype)
                    {
                        orgJson.Append("<label><a href='javascript:void(0);' onclick=\"OpenIFrameWindow('新增房间', 'AddBulidingRoom.aspx?pid=" + parLayer[i]["Id"].ToString() + "&ppid=" + itemid + "&secplaceid=" + secplaceid + "','560px','360px');\"><span class='jiahao'>+</span><span class='addfuhao'>添加房间</span></a></label>");
                    }
                    DataRow[] subRoom = dt.Select(" Pid=" + parLayer[i]["Id"].ToString());//得到房间信息
                    if (subRoom.Count() > 0)
                    {
                        for (int j = 0; j < subRoom.Count(); j++)
                        {
                            if (istype)
                            {
                                orgJson.Append("<label><a href='javascript:void(0);' onclick=\"OpenIFrameWindow('编辑房间', 'AddBulidingRoom.aspx?itemid=" + subRoom[j]["Id"].ToString() + "&pid=" + parLayer[i]["Id"].ToString() + "&ppid=" + itemid + "&secplaceid=" + secplaceid + "','560px','360px');\"><span class='liangge'>" + subRoom[j]["RoomNo"] + "</span><span class='liangge'>" + subRoom[j]["Name"] + "</span></a><b class='del' style='display:none;' onclick=\"javascript: DeleteBuilding(this,'" + subRoom[j]["Id"].ToString() + "','room');\"><img src='/images/del.png'/></b></label>");

                            }
                            else
                            {
                                orgJson.Append("<label><a href='javascript:void(0);' onclick=\"OpenIFrameWindow('房间分配', 'RoomDistribution.aspx?itemid=" + subRoom[j]["Id"].ToString() + "&pid=" + parLayer[i]["Id"].ToString() + "&ppid=" + itemid + "&type=" + type + "','800px','500px');\"><span class='liangge'>" + subRoom[j]["RoomNo"] + "</span><span class='liangge'>" + subRoom[j]["Name"] + "</span></a></label>");
                            }

                            //orgJson.Append("<li style='float:left;border:2px solid #ddd;background:white;height:75px;width:75px;position;relative;'><a href='javascript:void(0);' onclick=\"OpenIFrameWindow('编辑房间', 'AddBulidingRoom.aspx?itemid=" + subRoom[j]["Id"].ToString() + "&pid=" + parLayer[i]["Id"].ToString() + "&ppid=" + itemid + "','800px','500px');\"><span>" + subRoom[j]["RoomNo"] + "" + subRoom[j]["Name"] + "</a></span>");
                            //   orgJson.Append("<div><span><a href='javascript:void(0)' onclick=\"javascript: DeleteBuilding('" + subRoom[j]["Id"].ToString() + "','room');\"><i class='iconfont'>&#xe60a;</i></a><span></div></li>");                        
                        }
                    }
                    orgJson.Append("</dd>");
                    orgJson.Append("</dl>");
                }
            }

            //输出Json
            //HttpContext.Current.Response.Write(orgJson.ToString());
            context.Response.Write(callback + "({\"result\":\"" + HttpUtility.UrlEncode(orgJson.ToString()).Replace("+", "%20") + "\"})");
            context.Response.End();
            
        }
        #endregion

        #region 根据id获取对象实体
        public void GetModelById(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            int buildid = Convert.ToInt32(context.Request["itemid"]);
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.Building build = new EmsBLL.Building().GetEmsModel(buildid);
            build.SecDirector = nameCommon.GetUserNameByUniqueNo(build.Director);
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(build) + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 添加楼房
        public void AddBuilding(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            string name = context.Request["name"], flag = context.Request["flag"];
            string roomno = context.Request["roomno"];
            EmsBLL.Building bllBuild = new EmsBLL.Building();
            int result, pid = Convert.ToInt32(context.Request["pid"]);
            bool isNameEx = flag == "room" ? bllBuild.IsNameExists(roomno, pid, Convert.ToInt32(context.Request["ppid"]), 0) : bllBuild.IsNameExists(name, pid);
            if (isNameEx)
            {
                result = -1;
            }
            else
            {
                EmsModel.Building build = new EmsModel.Building();
                build.Name = name;
                build.PID = pid;
                build.Creator = context.Request["useridcard"];
                build.CreateTime = DateTime.Now;
                build.IsDelete = 0;
                if (flag == "room")
                {
                    build.RoomNo = roomno;
                    string type = context.Request["type"];
                    build.Type = Convert.ToByte(type);
                    if (type == "1" && !string.IsNullOrEmpty(context.Request["secplace"]))
                    {
                        build.SectionPlaceId = Convert.ToInt32(context.Request["secplace"]);
                    }
                }
                result = bllBuild.Add(build);
            }
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + result + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 编辑楼房
        public void EditBuilding(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            int buildid = Convert.ToInt32(context.Request["itemid"]);
            string name = context.Request["name"], flag = context.Request["flag"];
            string roomno = context.Request["roomno"];
            EmsBLL.Building bllBuild = new EmsBLL.Building();
            int result, pid = Convert.ToInt32(context.Request["pid"]);
            bool isNameEx = flag == "room" ? bllBuild.IsNameExists(roomno, pid, Convert.ToInt32(context.Request["ppid"]), buildid) : bllBuild.IsNameExists(name, pid, buildid);
            if (isNameEx)
            {
                result = -1;
            }
            else
            {
                EmsModel.Building build = new EmsBLL.Building().GetEmsModel(buildid);
                build.Id = buildid;
                build.Name = name;
                build.Editor = context.Request["useridcard"];
                build.UpdateTime = DateTime.Now;
                if (flag == "room")
                {
                    build.RoomNo = roomno;
                    string type = context.Request["type"];
                    if (build.Type.ToString() != type && (new EmsBLL.EquipDetail().IsHasEquipByRoomIds(buildid.ToString(), flag)))
                    {
                        result = -7;
                    }
                    else
                    {
                        build.Type = Convert.ToByte(type);
                        if (type == "1" && !string.IsNullOrEmpty(context.Request["secplace"]))
                        {
                            build.SectionPlaceId = Convert.ToInt32(context.Request["secplace"]);
                        }
                        result = new EmsBLL.Building().Update(build);
                    }
                }
                else
                {
                    result = new EmsBLL.Building().Update(build);
                }
            }
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + result + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 删除楼房
        public void DeleteBuilding(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            int buildid = Convert.ToInt32(context.Request["intID"]);
            string flag = context.Request["flag"];
            EmsModel.Building build = new EmsBLL.Building().GetEmsModel(buildid);
            build.Id = buildid;
            build.IsDelete = 1;
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.JsonModel mod = new EmsBLL.Building().DeleteBuilding(build, flag);
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(mod) + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 根据类型获得房间信息
        public void GetRoomInfoByType(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            string type = context.Request["type"];
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            DataTable dt = new EmsBLL.Building().GetRoomInfoByType(type);
            StringBuilder orgJson = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    orgJson.Append("<option value='" + dt.Rows[i]["Id"] + "'>" + dt.Rows[i]["RoomName"] + "</option>");
                }
            }
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":\"" + orgJson.ToString() + "\"})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 为房间分配办公家具或科研设备
        public void SetRoomDistributionEquip(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            string roomid = context.Request["itemid"];
            string type = context.Request["type"];
            string idsStr = context.Request["idsStr"];
            string owneridcard = context.Request["owneridcard"];
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.JsonModel mod = new EmsBLL.Building().SetRoomDistributionEquip(roomid, type, idsStr, owneridcard);
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(mod) + "})");
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 将仪器设备移出房间
        public void MoveEquipOutRoom(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            int itemid = Convert.ToInt32(context.Request["itemid"]);
            EmsModel.EquipDetail equip = new EmsBLL.EquipDetail().GetEmsModel(itemid);
            equip.StorageLocation = "0";
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            int result = new EmsBLL.EquipDetail().Update(equip);
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + result + "})");
            HttpContext.Current.Response.End();
        }
        #endregion



        public void GetBuildingDataNew(HttpContext context) 
        {
            string callback = context.Request["jsoncallback"];
            string type = context.Request["type"];
            type = string.IsNullOrEmpty(type) ? "" : type;
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            DataTable dt = new EmsBLL.Building().GetBuildingInfo("0", type);
            StringBuilder orgJson = new StringBuilder();
            string selid = "";
            if (dt.Rows.Count > 0)
            {
                selid = dt.Rows[0]["Id"].ToString();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var liclass = i == 0 ? " class='on' " : "";
                    orgJson.Append("<a " + liclass + " id='buildli_" + dt.Rows[i]["Id"] + "' onclick='BuildLiClick(this)'>" + dt.Rows[i]["Name"] + "</a>");
                }
            }
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":\"" + orgJson.ToString() + "\",\"selid\":\"" + selid + "\"})");
            HttpContext.Current.Response.End();
        }

        public void GetLayersAndRoomsByIdNew(HttpContext context)
        {
            string callback = context.Request["jsoncallback"];
            string itemid = context.Request["itemid"];
            string type = context.Request["type"];
            string secplaceid = context.Request["secplaceid"];
            bool istype = string.IsNullOrEmpty(type);
            type = istype ? "" : type;
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.JsonModel jm = new EmsBLL.Building().GetLayersAndRoomsByIdNew(itemid, type, secplaceid);//获得楼层及房间信息

            //输出Json
            //HttpContext.Current.Response.Write(orgJson.ToString());
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(jm) + "})");
            context.Response.End();
            
        }

        public void MoveEquipOutRoomNew(HttpContext context)
        {
            Hashtable ht = new Hashtable(); 
            string callback = context.Request["jsoncallback"];
            ht.Add("itemid", context.Request["itemid"]);
            if (!string.IsNullOrWhiteSpace(context.Request["home"]))
            {
                ht.Add("home",context.Request["home"]);
            }
            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            EmsModel.JsonModel Model =  new EmsBLL.Building().UpdateStorageLocationMore(ht);
            //输出Json
            HttpContext.Current.Response.Write(callback + "({\"result\":" + jss.Serialize(Model) + "})");
            HttpContext.Current.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}