using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Xpedia.Areas.Manage.Helpers
{
    public class FileManager
    {
        public static string Upload(HttpPostedFileBase File,string path)
        {
            string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + File.FileName;
            string filePath = Path.Combine(HttpContext.Current.Server.MapPath(path), filename);
            File.SaveAs(filePath);

            return filename;
        }

        public static bool Delete(string filename,string path)
        {
            string filePath = Path.Combine(HttpContext.Current.Server.MapPath(path), filename);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }
            return false;
        }
    }
}