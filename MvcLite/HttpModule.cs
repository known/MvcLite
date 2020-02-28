using System;
using System.Text;
using System.Web;

namespace MvcLite
{
    public class HttpModule : IHttpModule
    {
        private HttpContext context;

        public void Init(HttpApplication context)
        {
            context.BeginRequest += Context_BeginRequest;
            context.PostMapRequestHandler += Context_PostMapRequestHandler;
            context.AcquireRequestState += Context_AcquireRequestState;
            context.EndRequest += Context_EndRequest;
        }

        public void Dispose()
        {
        }

        private void Context_BeginRequest(object sender, EventArgs e)
        {
            var app = sender as HttpApplication;
            context = app.Context;
        }

        private void Context_PostMapRequestHandler(object sender, EventArgs e)
        {
            context.Handler = SessionHandler.Instance;
        }

        private void Context_AcquireRequestState(object sender, EventArgs e)
        {
            var url = context.Request.Url.LocalPath;
            context.Response.Write(url);
        }

        private void Context_EndRequest(object sender, EventArgs e)
        {
            context.Response.HeaderEncoding = Encoding.Default;
            context.Response.ContentEncoding = Encoding.Default;
        }
    }
}
