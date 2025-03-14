using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Speech.Synthesis;
using System.Threading;
using System.Web;

namespace web.Login
{
    public partial class User_Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PSWD.Attributes.Add("value", PSWD.Text);

            if (!IsPostBack)
            {
                Session["PG_site"] = @"<ol class='breadcrumb'><li class='active'>您目前位置：</li><a href='/DefaultBK' class='pathway'>後台首頁</a></li><li><span class='divider'>→</span><span>會員登入</span></li></ol>";
            }    
        }
    }
}