using System;
using System.Web;
using System.IO;
using System.Web.SessionState;
using System.Text;

//-----TO DO : Set Physical Path
namespace AMS
{
    public class Handler : IHttpHandler, IReadOnlySessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            try
            {
               
                string[] files;
                foreach (string s in context.Request.Files)
                {
                    HttpPostedFile file = context.Request.Files[s];
                    var ImageType = context.Request.Params["ImageType"];
                    var ImageName = context.Request.Params["ImageName"];
                    string dirFullPath = string.Empty;
                    if (ImageType == "Logo")
                    {
                        dirFullPath = HttpContext.Current.Server.MapPath("~/Content/Images/Logo/");
                        files = Directory.GetFiles(dirFullPath);
                    }
                    string fileName = file.FileName;
                    string fileExtension = file.ContentType;
                    if (!string.IsNullOrEmpty(fileName))
                    {
                        if (true)
                        {
                            fileExtension = Path.GetExtension(fileName);
                            string pathToSave = dirFullPath + ImageName + fileExtension;
                            if ((File.Exists(pathToSave)))
                            {
                                File.Delete(pathToSave);
                            }
                            file.SaveAs(pathToSave);
                        }
                    }
                }
                //  database record update logic here  ()
                //context.Response.Write(str_image);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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