using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                ALBUM_DATA();//活動相片
            }

        }
        protected void ALBUM_DATA() //活動相片
        {
            try
            {
                string[] photo_arr = { "a.jpg", "b.jpg", "c.jpg", "d.jpg", "e.jpg" };
                string[] name_arr = { "圖a", "圖b", "圖c", "圖d", "圖e" };

                string HTML = ""; string title = "";
                HTML = "<div id='slideshow6' class='W6 owl-carousel owl-theme'>";
                for (int i = 0; i <= 4; i++)
                {
                    //if (DTC.Rows[i]["WA_name"].ToString().Length >= 32) { title = DTC.Rows[i]["WA_name"].ToString().Substring(0, 32) + "..."; } else { title = DTC.Rows[i]["WA_name"].ToString(); }
                    HTML += @"<div class='item'>";
                    HTML += @"<div class='vid-div d-flex flex-column' style='height:280px'>";
                    HTML += @"<img class='vid-img img-fluid' alt='' src='" + "/photo/" + photo_arr[i] + @"' /><span class='vid-title' style='font-weight:bold;'>" + title + "</span></div>";
                    HTML += @"</div>";
                }
                HTML += @"</div>";

                WEB_ALBUM.InnerHtml += HTML;
            }
            catch { Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "ErrMsg", "alert('產生活動相片錯誤!');", true); }
        }
    }
}