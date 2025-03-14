using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace web.Album_Data
{
    public partial class Album_Data_Present : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //地圖顯示
            Page_Maps.InnerHtml += @"<ol class='breadcrumb'>";
            Page_Maps.InnerHtml += @"<li>您目前位置：</li>";
            Page_Maps.InnerHtml += @"<li class='breadcrumb-item'><a href='/'>首頁</a></li>";
            Page_Maps.InnerHtml += @"<li class='breadcrumb-item'>活動相片</li>";
            Page_Maps.InnerHtml += @"</ol>";
            //if (Request["PG_PAGE"] != null) { Page_Page.Focus(); }
            //if (Request["NUMS"] != null) { Page_Show.Focus(); }

            if (!IsPostBack)
            {
                ALBUM_DATA();//活動相片
            }
        }
        protected void ALBUM_DATA() 
        {
            string[] photo_arr = { "a.jpg", "b.jpg", "c.jpg", "d.jpg", "e.jpg" };
            string[] name_arr = { "圖a", "圖a", "圖c", "圖d", "圖e" };

            Page_Data.InnerHtml += @"<div class='input-group mb-3' style='text-align: center;'>";
            Page_Data.InnerHtml += @"<div class='col-md-12'>";
            Page_Data.InnerHtml += @"<h2><p><span style='font-family: arial, helvetica, sans-serif;'>◯◯◯◯活動</span></p></h2>";
            Page_Data.InnerHtml += @"</div>";
            Page_Data.InnerHtml += @"<div class='col-md-12'>";
            Page_Data.InnerHtml += @"<span style='font-size:1rem; font-weight:400; font-family: arial, helvetica, sans-serif;'>活動內容描述：○○○○年○○月○○日辦理○○○○活動</span>";
            Page_Data.InnerHtml += @"</div>";
            Page_Data.InnerHtml += @"</div>";

            //上方大圖
            Photo_Show.InnerHtml += @"<div id='sync1' class='owl-carousel owl-theme'>";
            for (int j = 0; j <= 4; j++)
            {
                Photo_Show.InnerHtml += @"<div class='item'>";
                Photo_Show.InnerHtml += @"<a href='" + "/photo/" + photo_arr[j] + @"' title='" + name_arr[j] + "活動照片-另開新視窗顯示大圖(" + photo_arr[j] + "檔)' target='_blank'>";
                Photo_Show.InnerHtml += @"<img src ='" + "/photo/" + photo_arr[j] + @"' alt='" + name_arr[j] + @"' style='width:100%' importance='high' /></img>";
                Photo_Show.InnerHtml += @"</a>";
                Photo_Show.InnerHtml += @"</div>";
            }
            Photo_Show.InnerHtml += @"</div>";

            //下方縮圖(預覽圖)
            Photo_Show.InnerHtml += @"<div id='sync2' class='owl-carousel owl-theme'>";
            for (int j = 0; j <= 4; j++)
            {
                Photo_Show.InnerHtml += @"<div class='item'>";
                Photo_Show.InnerHtml += @"<a href='" + "/photo/" + photo_arr[j] + @"' title='照片" + name_arr[j] + "上方顯示大圖'>";
                Photo_Show.InnerHtml += @"<img src ='" + "/photo/" + photo_arr[j] + @"' alt='" + name_arr[j] + @"' style='width:100%' loading='lazy' importance='low' /></img>";
                Photo_Show.InnerHtml += @"</a>";
                Photo_Show.InnerHtml += @"</div>";
            }
            Photo_Show.InnerHtml += @"</div>";
            Photo_Day.InnerHtml += @"<p align='right'>活動日期：2025-03-14 </p>";
        }
        //protected void Page_PreRenderComplete(object sender, EventArgs e)
        //{
        //    int IDNO = 0;//資料編號
        //    int ROWS = 0;//資料位置
        //    int PG_SIZE = 5;//每頁幾筆
        //    int PG_NUMS = 1;//目前頁數
        //    int PG_PAGE = 1;//全部頁數
        //    string FF_KIND = "%";
        //    if (!int.TryParse(Request["IDNO"], out IDNO)) { return; }
        //    if (Request["KIND"] != null) { FF_KIND = Request["KIND"].ToString(); }
        //    ////SqlDataSourceD.SelectParameters.Clear();
        //    ////SqlDataSourceD.SelectParameters.Add("KIND", DbType.String, FF_KIND);
        //    ////DataTable DTB = ((DataView)SqlDataSourceD.Select(DataSourceSelectArguments.Empty)).Table;
        //    //DataRow[] DR = DTB.Select("WA_idno=" + IDNO);
        //    //if (FF_KIND != "%") { Page_Maps.InnerHtml = Page_Maps.InnerHtml.Replace("</ol>", "<li class='breadcrumb-item active'><a href='/VW/Album_Data_Show?KIND=" + HttpUtility.UrlEncode(FF_KIND) + "'>" + INF.B_Item_Web.Select("IW_idno='" + HttpUtility.UrlEncode(FF_KIND) + "'")[0]["IW_name"].ToString() + "</a></span></li></ol>"); }
        //    //if (DR.Length == 1) { Page_Maps.InnerHtml = Page_Maps.InnerHtml.Replace("</ol>", "<li class='breadcrumb-item active'><a href='/VW/Album_Data_Present?KIND=" + HttpUtility.UrlEncode(FF_KIND) + "&IDNO=" + IDNO.ToString() + "'>" + DR[0]["WA_name"].ToString() + "</a></span></li></ol>"); } else { return; }

        //    //網頁標題
        //    Page.Title = "活動相片 ｜ 活動花絮";

        //    ////上下篇
        //    //for (int i = 0; i < DTB.Rows.Count; i++) { if (int.Parse(DTB.Rows[i]["WA_idno"].ToString()) == IDNO) { ROWS = i; } }
        //    //Page_Data.InnerHtml += @"<div class='input-group mb-3' style='text-align: center;'>";
        //    //Page_Data.InnerHtml += @"<div class='col-md-12'>";
        //    //Page_Data.InnerHtml += @"<h2><p><span style='font-family: arial, helvetica, sans-serif;'>" + DR[0]["WA_name"].ToString() + "</span></p></h2>";
        //    //Page_Data.InnerHtml += @"</div>";
        //    //Page_Data.InnerHtml += @"<div class='col-md-2'>";
        //    //if (ROWS - 1 >= 0) {Page_Data.InnerHtml += @"<a class='page-link' href='/VW/Album_Data_Present?KIND=" + HttpUtility.UrlEncode(FF_KIND) + "&IDNO=" + DTB.Rows[ROWS - 1]["WA_idno"].ToString() + "'>上一篇</a>";}         
        //    //Page_Data.InnerHtml += @"</div>";
        //    //Page_Data.InnerHtml += @"<div class='col-md-8'>";
        //    //Page_Data.InnerHtml += @"<span style='font-size:1rem; font-weight:400; font-family: arial, helvetica, sans-serif;'>活動內容描述：</span><span style='font-size:1rem; font-weight:400; font-family: arial, helvetica, sans-serif;'>" + DR[0]["WA_note"].ToString() + "</span>";
        //    //Page_Data.InnerHtml += @"</div>";
        //    //Page_Data.InnerHtml += @"<div class='col-md-2'>";
        //    //if (ROWS + 1 < DTB.Rows.Count) { Page_Data.InnerHtml += @"<a class='page-link' href='/VW/Album_Data_Present?KIND=" + HttpUtility.UrlEncode(FF_KIND) + "&IDNO=" + DTB.Rows[ROWS + 1]["WA_idno"].ToString() + "'>下一篇</a>";}
        //    //Page_Data.InnerHtml += @"</div>";
        //    //Page_Data.InnerHtml += @"</div>";
        //}
    }
}