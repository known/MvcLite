using System.Web;
using System.Web.SessionState;

namespace MvcLite
{
    class SessionHandler : IHttpHandler, IRequiresSessionState
    {
        public static readonly SessionHandler Instance = new SessionHandler();

        public void ProcessRequest(HttpContext context)
        {
        }

        public bool IsReusable { get; }
    }
}