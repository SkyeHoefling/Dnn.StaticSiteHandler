using System.IO;
using System.Linq;
using System.Web;

namespace Dnn.StaticSiteHandler
{
    public class HtmlServerHandler : IHttpHandler
    {
        public bool IsReusable => true;

        public void ProcessRequest(HttpContext context)
        {
            var path = context.Request.Path;
            var filePath = path.Replace(".axd", ".resources");

            var fullFile = context.Server.MapPath($"~/{filePath}");

            using (FileStream fileStream = File.OpenRead(fullFile))
            using (var streamReader = new StreamReader(fileStream))
            {
                var content = streamReader.ReadToEnd();
                context.Response.Write(content);
            }

            var extension = path.Replace(".axd", string.Empty).Split('.').LastOrDefault();
            var manager = new ContentTypeManager();
            var contentType = manager.GetContentType(extension);
            if (!string.IsNullOrEmpty(contentType))
                context.Response.ContentType = contentType;
        }
    }
}
