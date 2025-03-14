using System;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using web;
using System.Collections.Generic;

namespace web.Download
{
    public partial class File_Download : BSP
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGridView();               
            }     
        }
        private void LoadGridView()
        {
            // 創建 DataTable
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));

            // 加入資料列
            dt.Rows.Add("Pdf1");
            dt.Rows.Add("Pdf2");
            dt.Rows.Add("Pdf3");

            // 綁定到 GridView
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        //protected void ButtonADD_Click(object sender, EventArgs e)
        //{
        //    string YEAR = QR_year.Text.ToString();
        //    DataTable DTE = null;
        //    DTE = DBS.GetDataTable("SELECT * FROM 記錄上傳檔案的資料表 WHERE QR_year = '" + YEAR + "'", INF.COMS);
        //    if (DTE.Rows.Count == 1) { SMSG("此年度已存在調查報告!"); SHOW("MODEL"); return; }
        //    else
        //    {
        //        if (!FileUploadS.HasFile) { SMSG("請先選擇檔案!"); SHOW("MODEL"); return; }//是否有上傳檔案
        //        string DIRS = Server.MapPath("~/App_Data/Question/report/");
        //        if (!Directory.Exists(DIRS)) { Directory.CreateDirectory(DIRS); }
        //        if (FileUploadS.PostedFile.ContentLength > 1024 * 1024 * 3) { SMSG("上傳檔案限3M內!"); return; }//上傳檔案大小限制
        //        string QR_TYPE = System.IO.Path.GetExtension(FileUploadS.FileName).ToLower();
        //        string QR_NAME = System.IO.Path.GetFileName(FileUploadS.FileName).ToLower();
        //        if (QR_TYPE != ".pdf") { SMSG("檔案格式僅能使用 pdf 檔上傳!"); return; }//檔案格式正確
        //        string QR_PATH = Guid.NewGuid().ToString() + QR_TYPE;
        //        FileUploadS.SaveAs(DIRS + QR_PATH);

        //        string SQL = @" INSERT INTO 記錄上傳檔案的資料表(QR_year,QR_name,QR_file,QR_type,AD_user,AD_time)
        //                        VALUES (@QR_year,@QR_name,@QR_file,@QR_type,@AD_user,GETDATE());";

        //        SqlDataSourceP.InsertCommand = SQL;
        //        SqlDataSourceP.InsertParameters.Clear();
        //        SqlDataSourceP.InsertParameters.Add("QR_year", QR_year.Text);
        //        SqlDataSourceP.InsertParameters.Add("QR_name", QR_name.Text);
        //        SqlDataSourceP.InsertParameters.Add("QR_file", QR_PATH);
        //        SqlDataSourceP.InsertParameters.Add("QR_type", QR_TYPE);
        //        SqlDataSourceP.InsertParameters.Add("AD_user", Session["UD_idno"].ToString());
        //        SqlDataSourceP.Insert(); SMSG("新增成功!");
        //    }
        //}

        //protected void ButtonCHG_Click(object sender, EventArgs e)
        //{
        //    string QR_IDNO = Session["QR_idno"].ToString();
        //    try
        //    {
        //        string SQL = "";

        //        if (!FileUploadS.HasFile)
        //        {
        //            SQL = @"UPDATE 記錄上傳檔案的資料表 
        //                    SET 
        //                    QR_year=@QR_year, 
        //                    QR_name=@QR_name,
        //                    UP_user=@UP_user, 
        //                    UP_time=GETDATE()
        //                    WHERE QR_idno=@QR_idno;";

        //            SqlDataSourceP.UpdateCommand = SQL;
        //            SqlDataSourceP.UpdateParameters.Clear();
        //            SqlDataSourceP.UpdateParameters.Add("QR_idno", QR_IDNO);
        //            SqlDataSourceP.UpdateParameters.Add("QR_year", QR_year.Text);
        //            SqlDataSourceP.UpdateParameters.Add("QR_name", QR_name.Text);
        //            SqlDataSourceP.UpdateParameters.Add("UP_user", Session["UD_idno"].ToString());
        //            SqlDataSourceP.Update(); SMSG("修改成功!");
        //        }
        //        else
        //        {
        //            string DIRS = Server.MapPath("~/App_Data/Question/report/");
        //            string QR_TYPE = System.IO.Path.GetExtension(FileUploadS.FileName).ToLower();
        //            if (QR_TYPE != ".pdf") { SMSG("檔案格式僅能使用 pdf 檔上傳!"); return; }//檔案格式正確
        //            string QR_PATH = Guid.NewGuid().ToString() + QR_TYPE;
        //            FileUploadS.SaveAs(DIRS + QR_PATH);

        //            SQL = @"UPDATE 記錄上傳檔案的資料表 
        //                    SET 
        //                    QR_year=@QR_year, 
        //                    QR_name=@QR_name,
        //                    QR_file=@QR_file,
        //                    QR_type=@QR_type,
        //                    UP_user=@UP_user, 
        //                    UP_time=GETDATE()
        //                    WHERE QR_idno=@QR_idno;";

        //            SqlDataSourceP.UpdateCommand = SQL;
        //            SqlDataSourceP.UpdateParameters.Clear();
        //            SqlDataSourceP.UpdateParameters.Add("QR_idno", QR_IDNO);
        //            SqlDataSourceP.UpdateParameters.Add("QR_year", QR_year.Text);
        //            SqlDataSourceP.UpdateParameters.Add("QR_name", QR_name.Text);
        //            SqlDataSourceP.UpdateParameters.Add("QR_file", QR_PATH);
        //            SqlDataSourceP.UpdateParameters.Add("QR_type", QR_TYPE);
        //            SqlDataSourceP.UpdateParameters.Add("UP_user", Session["UD_idno"].ToString());
        //            SqlDataSourceP.Update(); SMSG("修改成功!");
        //        }
        //    }
        //    catch (Exception ex) { SERR(ex, LMSG); }
        //}

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button DL = (Button)e.Row.FindControl("ButtonDL"); //下載
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            // 取得按鈕所在的行索引
            int index = Convert.ToInt32(e.CommandArgument);
            string fileName = GridView1.Rows[index].Cells[0].Text; // 取得檔案名稱
            string filePath = Server.MapPath("~/File/" + fileName + ".pdf");

            switch (e.CommandName)
            {
                case "DL":
                    try
                    {
                        if (!File.Exists(filePath)) { SMSG("找不到檔案"); return; }
                        byte[] BYTE = File.ReadAllBytes(filePath); MemoryStream FILE = new MemoryStream(BYTE);
                        Session["Load_Name"] = fileName + ".pdf";
                        Session["Load_Data"] = FILE;
                        SS_fram.Src = "/App_Ashx/Load_pdf.ashx";
                        //LOG.Log_Load("檔案下載", "pdf", Session["UD_idno"].ToString(), Page);
                    }
                    catch (Exception ex) { SERR(ex); }
                    break;

            }

        }
    }
}