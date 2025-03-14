using System;
using System.Web;
using System.Drawing;
using System.Web.SessionState;
using System.Speech.Synthesis;
using System.Threading;
using System.IO;

namespace GWDB.App_Ashx
{
    public class ValidateCodeVoice : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            if (context.Session["CheckText"] == null) { return; }
            string checkvalue = text_load(context);
            context.Response.ContentType = "text/plain";
            context.Response.Write(checkvalue);
        }
        public string text_load(HttpContext context)
        {
            string text = "";
            text = context.Session["CheckText"].ToString();
            return text;
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