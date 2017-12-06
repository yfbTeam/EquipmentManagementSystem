using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS.Web.Statistical
{
    public partial class ImportEquip : BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hidUserIDCard.Value = UserInfo.UniqueNo;

                //hidUserName.Value = base.UserName;
            }
        }
        /// <summary>
        /// 上传设备excel文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnImportEquip_Click(object sender, EventArgs e)
        {
            try
            {            
                if (FileUpEquip.HasFile)
                {
                    //string UploadPath = "c:\\wyr\\UploadFile\\";  //上传文件路径
                    string UploadPath = System.Configuration.ConfigurationManager.ConnectionStrings["UploadPath"].ConnectionString;//上传文件路径
                    if (!Directory.Exists(UploadPath))
                    {
                        Directory.CreateDirectory(UploadPath);
                        ////给文件夹Everyone赋完全控制权限
                        //DirectorySecurity folderSec = new DirectorySecurity();
                        //folderSec.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
                        //System.IO.Directory.SetAccessControl(UploadPath, folderSec);
                    }
                    string FileClientPath = FileUpEquip.PostedFile.FileName;
                    FileInfo file = new FileInfo(FileClientPath);
                    string FileExtensionName = file.Extension.ToLower();    //文件后缀名
                    if (FileExtensionName != ".xlsx" && FileExtensionName != ".xls")
                    {
                        return;
                    }
                    string NewName = DateTime.Now.ToString("yyyyMMddhhmmssfff") + FileExtensionName; // 文件名称，当前时间（yyyyMMddhhmmssfff）
                    string CompleteFilePath = UploadPath + NewName;        // 服务器端文件路径
                    FileUpEquip.SaveAs(CompleteFilePath);                                // 使用 SaveAs 方法保存文件
                    //this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script>ImportTeacher('" + CompleteFilePath + "');</script>", true);
                    CompleteFilePath = CompleteFilePath.Replace("\\", "\\\\");//增加转义字符 ，因为调用js方法在会转义一次字符串
                    Page.RegisterStartupScript("a", "<script>ImportEquip('" + CompleteFilePath + "');</script>");

                }
            }
            catch (Exception)
            {

                
            }
        }

        /// <summary>
        /// 下载模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DownLoad_Click(object sender, EventArgs e)
        {
            string fileName = System.Configuration.ConfigurationManager.ConnectionStrings["AssetTemp"].ConnectionString;//教师信息模板文件名
            string filePath = Server.MapPath("../Temp/" + fileName);//物理路径

            //以字符流的形式下载文件
            FileStream fs = new FileStream(filePath, FileMode.Open);
            byte[] bytes = new byte[(int)fs.Length];
            fs.Read(bytes, 0, bytes.Length);
            fs.Close();
            Response.ContentType = "application/octet-stream";
            //通知浏览器下载文件而不是打开
            Response.AddHeader("Content-Disposition", "attachment;  filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }
    }
}