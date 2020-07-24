namespace Dnn.StaticSiteHandler
{
    internal class ContentTypeManager
    { 
        public string GetContentType(string extension)
        {
            switch (extension)
            {
                case "html":
                    return "text/html";
                case "js":
                    return "text/javascript";
                case "css":
                    return "text/css";
                case "svg":
                    return "image/svg+xml";
                case "woff":
                    return "aplication/font-woff";//"font/woff";
                case "woff2":
                    return "application/font-woff2";//"font/woff2";
                case "ttf":
                    return "application/font-ttf";//"font/ttf";
                case "jpg":
                case "jpeg":
                    return "image/jpeg";
                case "png":
                    return "image/png";
                case "gif":
                    return "image/gif";
                case "tiff":
                    return "image/tiff";
                case "webp":
                    return "image/webp";
                case "bmp":
                    return "image/bmp";

            }

            return string.Empty;
        }
    }
}
