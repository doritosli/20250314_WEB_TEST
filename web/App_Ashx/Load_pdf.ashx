<%@ WebHandler Language="C#" Class="Load_pdf" %>
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.SessionState;

public class Load_pdf :IHttpHandler,IReadOnlySessionState
{
    public void  ProcessRequest(HttpContext context)
    {
        try
        {
            if (context.Session["Load_Data"] != null)
            {
                string NAME = (string)context.Session["Load_Name"];
                MemoryStream FILE = (MemoryStream)context.Session["Load_Data"];
                context.Response.Buffer = true;
                context.Response.Clear();
                context.Response.ContentType = "Application/pdf";
                context.Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(NAME, System.Text.Encoding.UTF8) + ";");
                context.Response.BinaryWrite(FILE.ToArray());
                context.Session["Load_Data"] = null;
                context.Session["Load_Name"] = null;
                context.Response.End();
            }
        }
        catch  {  }

    }
    public bool IsReusable { get { return false; } }
}

