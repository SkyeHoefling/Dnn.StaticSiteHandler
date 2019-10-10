using DotNetNuke.Entities.Users;
using DotNetNuke.Services.FileSystem;
using System.IO;
using System.Linq;
using System.Web;

namespace Dnn.StaticSiteHandler
{
    public class HtmlServerHandler : IHttpHandler
    {
        public bool IsReusable => true;

        private const int Segment_Folder = 3;
        private const int Segment_PortalId = 2;
        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.IsAuthenticated)
            {
                var userInfo = UserController.GetUserByName(0, context.User.Identity.Name);
                context.Items["UserInfo"] = userInfo;
            }

            var path = context.Request.Path;
            
            var segments = path.Split('/');
            var folder = segments[Segment_Folder];
            var portalId = int.Parse(segments[Segment_PortalId]);
            var folderInfo = (FolderInfo)FolderManager.Instance.GetFolder(portalId, folder);

            var canViewFolder = UserController.Instance.GetCurrentUserInfo().IsSuperUser || DotNetNuke.Security.Permissions.FolderPermissionController.CanViewFolder(folderInfo);
            if (!canViewFolder)
            {
                context.Response.Redirect("~/");
                return;
            }

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
