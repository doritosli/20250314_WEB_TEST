using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TextBox = System.Web.UI.WebControls.TextBox;

namespace web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // 應用程式啟動時執行的程式碼
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
    public class BSP : Page//使用基本網頁
    {
        protected string PG_idno;
        protected string PG_name;
        protected DropDownList FD_shid;
        protected SqlDataSource FD_data;
        protected HtmlIframe FD_fram;
        protected GridView[] FD_view;
        protected TextBox FD_text;
        protected Button FD_find;
        protected Button FD_load;
        protected void SHOW(string MODEL)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SHOW", "$('#" + MODEL + "').modal('show');", true);
        }
        protected void HIDE(string MODEL)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "HIDE", "$('#" + MODEL + "').modal('hide');$('.modal-backdrop').remove();$(document.body).removeClass('modal-open');$(document.body).css('padding-right','0px');", true);
        }
        protected void SMSG(string MSG)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "系統訊息", "alert('" + MSG.Replace("'", "").Replace("\r\n", "") + "')", true);
        }
        protected void SMSG(string MSG, Label LAB)
        {
            LAB.Text = MSG.Replace(@"\n", "<br>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "系統訊息", "alert('" + MSG.Replace("'", "").Replace("\r\n", "") + "')", true);
        }
        protected void SERR(Exception EXC)
        {
            string UD_idno = "";
            if (Session["UD_idno"] != null) { UD_idno = Session["UD_idno"].ToString(); }
            SMSG("操作錯誤或系統有誤!請洽資訊人員!");
        }
        protected void SERR(Exception EXC, Label LAB)
        {
            string UD_idno = "";
            if (Session["UD_idno"] != null) { UD_idno = Session["UD_idno"].ToString(); }
            SMSG("操作錯誤或系統有誤!請洽資訊人員!");
            LAB.Text = "操作錯誤或系統有誤!請洽資訊人員!";
        }
    }
}