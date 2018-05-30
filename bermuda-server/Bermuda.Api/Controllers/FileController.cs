using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Bermuda.Api.Controllers
{
    [RoutePrefix("api/files")]
    public class FileController : ApiController
    {
        private const string ROOT_URL = "~/public";

        [HttpPost]
        [Route("img/upload")]
        public async Task<IHttpActionResult> UploadImg()
        {
            UplaodResult result = new UplaodResult();
            List<string> savedFilePath = new List<string>();
            string IMG_DIR = $"{ROOT_URL}/img/";

            if (!Request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

            var rootPath = HttpContext.Current.Server.MapPath(IMG_DIR);
            var provider = new MultipartFileStreamProvider(rootPath);

            if (!Directory.Exists(rootPath))
                Directory.CreateDirectory(rootPath);

            // read data
            await Request.Content.ReadAsMultipartAsync(provider);

            foreach (var item in provider.FileData)
            {
                try
                {
                    string name = item.Headers.ContentDisposition.FileName.Replace("\"", "");
                    string newFileName = Guid.NewGuid() + Path.GetExtension(name);
                    File.Move(item.LocalFileName, Path.Combine(rootPath, newFileName));

                    Uri baseuri = new Uri(Request.RequestUri.AbsoluteUri.Replace(Request.RequestUri.PathAndQuery, string.Empty));

                    string fileRelativePath = IMG_DIR + newFileName;
                    Uri fileFullPath = new Uri(baseuri, VirtualPathUtility.ToAbsolute(fileRelativePath));
                    savedFilePath.Add(fileFullPath.ToString());

                    result.file_name = newFileName;
                    result.url = fileFullPath.ToString();
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }
            }

            return Json(result);
        }

        [HttpDelete]
        [Route("delete")]
        public void DeleteImg([FromUri]string img)
        {
            var path = HttpContext.Current.Server.MapPath($"{ROOT_URL}/img/") + img;
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        private class UplaodResult
        {
            public string file_name { get; set; }
            public string url { get; set; }
        }
    }
}
