using System;
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
            switch(extension)
            {
                case "html":
                    context.Response.ContentType = "text/html";
                    break;
                case "js":
                    context.Response.ContentType = "text/javascript";
                    break;
                case "css":
                    context.Response.ContentType = "text/css";
                    break;
                case "svg":
                    context.Response.ContentType = "image/svg+xml";
                    break;
                case "woff":
                    context.Response.ContentType = "aplication/font-woff";//"font/woff";
                    break;
                case "woff2":
                    context.Response.ContentType = "application/font-woff2";//"font/woff2";
                    break;
                case "ttf":
                    context.Response.ContentType = "application/font-ttf";//"font/ttf";
                    break;
            }

        }
    }
}
