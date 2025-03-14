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
            //LogIn_Snum("");
            //帳號密碼錯誤超過3次，就鎖住
            //if (Session["User_Login"] != null)
            //{
            //    if (int.Parse(Session["User_Login"].ToString()) >= 3) { LogIn_Lock(); return; }
            //}
            //if (!IsPostBack)
            //{
            //    if (Request["PKEY"] != null) { LogIn_Open(); }
            //    if (Request["GKEY"] != null) { LogIn_Link(); }
            //    else { LogIn_Auto(); }
            //}
        }
        //protected void BUTN_Click(object sender, EventArgs e)
        //{
        //    //0尚未驗證 //1尚未開通 //2登入成功 //3自登過期 //4帳號停用 
        //    //5格式有誤 //6驗證錯誤 //7帳號有誤 //8密碼有誤 //9位址錯誤 
        //    try
        //    {
        //        string MESG = ""; LMSG.Text = "";
        //        //鎖定檢查
        //        LogIn_Snum(ACCT.Text);
        //        if (int.Parse(Session["User_Login"].ToString()) >= 3) { LogIn_Lock(); return; }

        //        //空白檢查--不納入錯誤紀錄
        //        if (ACCT.Text == "") { MESG += "帳號為必須輸入資料!\\n"; }
        //        if (PSWD.Text == "") { MESG += "密碼為必須輸入資料!\\n"; }
        //        if (KEYS.Text == "") { MESG += "驗證碼必須輸入資料!\\n"; }
        //        if (MESG != "") { LogIn_Show(MESG); return; }

        //        //格式檢查
        //        //if (REG.Get_RegexIsMatch("UD_acct",ACCT.Text)!="")) { MESG += "帳號密碼格式有問題!\\n"; }
        //        //if (REG.Get_RegexIsMatch("UD_pswd",PSWD.Text)!="") { MESG += "帳號密碼格式有問題!\\n"; };
        //        if (MESG != "") { LogIn_Error(ACCT.Text, MESG, "5"); return; }

        //        //查驗證碼
        //        if (Session["CheckCode"] == null) { MESG += "驗證碼過期，請重新整理頁面!\\n"; }
        //        else if (Session["CheckCode"].ToString() != KEYS.Text) { MESG += "驗證碼輸入有誤!\\n"; }
        //        if (MESG != "") { LogIn_Error(ACCT.Text, MESG, "6"); return; }

        //        //開始登入
        //        LogIn_Begin(ACCT.Text, PSWD.Text);

        //        if (Session["UD_mode"] != null)
        //        {
        //            //是否自動登入
        //            if (KEEP.Checked)
        //            {
        //                string RKEY = Guid.NewGuid().ToString();
        //                string SQL = @" UPDATE 會員資料表 SET UD_rkey=@UD_rkey,UD_dead=@UD_dead WHERE UD_idno=@UD_idno";
        //                DateTime DATE = DateTime.Now.AddDays(7);
        //                using (SqlConnection CON = new SqlConnection(INF.COMS))
        //                {
        //                    using (SqlCommand CMD = new SqlCommand(SQL, CON))
        //                    {
        //                        CMD.Parameters.AddWithValue("UD_idno", Session["UD_idno"].ToString());
        //                        CMD.Parameters.AddWithValue("UD_rkey", RKEY);
        //                        CMD.Parameters.AddWithValue("UD_dead", DATE);
        //                        CON.Open(); CMD.ExecuteNonQuery();
        //                    }
        //                }
        //                SCK.SetCookie("CCCC2020", RKEY, DATE);
        //            }
        //            LogIn_Load(ACCT.Text);
        //        }
        //    }
        //    catch (Exception ex) { LogIn_Error(ACCT.Text, "未知錯誤：請洽資訊人員！", "X"); LOG.Log_Error(ex, "", Page); }
        //}

        //protected void LogIn_Open()//帳號新建開通
        //{
        //    string UD_rkey = Request["PKEY"].ToString();
        //    string SQL = "OPEN SYMMETRIC KEY xKey DECRYPTION BY CERTIFICATE xCert WITH PASSWORD = 'CCCCDB5371%#&!'; SELECT * FROM 會員資料表 WHERE UD_rkey = @UD_RKEY AND UD_mode='0'; CLOSE ALL SYMMETRIC KEYS;";
        //    SqlDataSource SDS = new SqlDataSource(INF.COMS, SQL);
        //    SDS.SelectParameters.Add("UD_RKEY", UD_rkey);
        //    DataTable DTB = ((DataView)SDS.Select(DataSourceSelectArguments.Empty)).Table;
        //    if (DTB.Rows.Count == 1)
        //    {
        //        DACCT.Visible = false;
        //        DPSWD.Visible = false;
        //        DKEEP.Visible = false;
        //        DKEYS.Visible = false;
        //        BUTN.Visible = false;
        //        string UD_idno = "";
        //        string PSWD = GET.GetRand(20, true, true, true, true);
        //        string MLTO = DTB.Rows[0]["UD_mail"].ToString();
        //        string FROM = INF.SM_user;
        //        string SUBT = INF.SS_name + @"--密碼通知信--";
        //        string BODY = @"網站首頁：https://" + Request.ServerVariables["HTTP_HOST"] + "\n首次登入密碼：" + PSWD + "";
        //        try
        //        {
        //            SDS.UpdateCommand = @"UPDATE 會員資料表 SET UD_pswd=@UD_PSWD,UD_mode='1',UD_rkey=NEWID(),UP_user=UD_idno,UP_time=GETDATE() WHERE UD_rkey=@UD_RKEY";

        //            //SDS.UpdateParameters.Add("UD_PSWD", GET.GetSalt256(PSWD, Guid.Parse(DTB.Rows[0]["UD_guid"].ToString())));
        //            //20200620修改 hash256 改成 blowfish
        //            SDS.UpdateParameters.Add("UD_PSWD", GET.blowfish_get(PSWD));

        //            SDS.UpdateParameters.Add("UD_RKEY", UD_rkey);
        //            SDS.Update();
        //            INF.SMPT.Send(new MailMessage(FROM, MLTO, SUBT, BODY));
        //            LOG.Log_Mail("密碼通知", "Y", UD_idno, MLTO, Page);
        //            LMSG.Text = "您帳號已開通，請至信箱收您預設密碼後登入!";
        //            Response.Write(@"<script>alert(""" + LMSG.Text + @""");</script>");
        //        }
        //        catch (Exception ex)
        //        {
        //            LOG.Log_Error(ex, UD_idno, Page);
        //            LOG.Log_Mail("密碼通知", "N", UD_idno, MLTO, Page);
        //            LMSG.Text = "帳號開通有特例狀況，請洽系統人員!";
        //            Response.Write(@"<script>alert(""" + LMSG.Text + @""");</script>");
        //        }
        //    }
        //    else if (DTB.Rows.Count > 1)
        //    {
        //        LMSG.Text = "帳號開通有特例狀況，請洽系統人員!";
        //        Response.Write(@"<script>alert(""" + LMSG.Text + @""");</script>");
        //    }
        //}
        //protected void LogIn_Link()
        //{
        //    string SQL = @" SELECT * FROM 會員資料表 WHERE UD_guid = @UD_guid";
        //    SqlDataSource SDS = new SqlDataSource(INF.COMS, SQL);
        //    SDS.SelectParameters.Add("UD_guid", Request["GKEY"].ToString());
        //    DataView DV = (DataView)SDS.Select(DataSourceSelectArguments.Empty);
        //    if (DV.Count == 1)
        //    {
        //        LogIn_Begin(DV[0]["UD_acct"].ToString(), DV[0]["UD_pswd"].ToString());
        //        LogIn_Load(ACCT.Text);
        //    }
        //}
        //protected void LogIn_Auto()//會員自動登入
        //{
        //    if (SCK.GetCookieValue("CCCC2020") != "")
        //    {
        //        string SQL = @" SELECT UD_acct,UD_pswd FROM 會員資料表 WHERE UD_rkey=@UD_rkey AND UD_dead>GETDATE()";
        //        SqlDataSource SDS = new SqlDataSource(INF.COMS, SQL);
        //        SDS.SelectParameters.Add("UD_rkey", SCK.GetCookieValue("CCCC2020"));
        //        DataView DV = (DataView)SDS.Select(DataSourceSelectArguments.Empty);
        //        if (DV == null) { LOG.Log_Login("", "3", Page); }
        //        else
        //        {
        //            if (DV.Table.Rows.Count == 1)
        //            {
        //                LogIn_Begin(DV.Table.Rows[0]["UD_acct"].ToString(), DV.Table.Rows[0]["UD_pswd"].ToString());
        //                if (Session["UD_mode"] != null) { LogIn_Load(DV.Table.Rows[0]["UD_acct"].ToString()); }
        //            }
        //        }
        //    }
        //}
        //private static string AccountSecretKey { get; set; }
        //protected void LogIn_Begin(string ACCT, string PSWD)//帳號登入看看
        //{
        //    //0尚未驗證 //1尚未開通 //2登入成功 //3自登過期 //4帳號停用
        //    //5格式有誤 //6驗證錯誤 //7帳號有誤 //8密碼有誤 //9位址錯誤 
        //    try
        //    {
        //        //讀取帳號
        //        string MESG = "";
        //        string SQL = @" 
        //                        UPDATE  會員資料表 SET UD_mode='3',UP_user=UP_user,UP_time=GETDATE()
        //                        WHERE   DATEADD(d,90, UD_pchg) < GETDATE() AND UD_mode='2' AND UD_acct=@UD_acct;
        //                        OPEN SYMMETRIC KEY xKey DECRYPTION BY CERTIFICATE xCert WITH PASSWORD = 'CCCCDB5371%#&!';
        //                        SELECT UD.*,ID_idno FROM 會員資料表 UD
        //                        LEFT JOIN U_User_Identity UI ON UD.UD_idno=UI.UD_idno WHERE UD_acct = @UD_acct; CLOSE ALL SYMMETRIC KEYS;";

        //        SqlDataSource SDS = new SqlDataSource(INF.COMS, SQL);
        //        SDS.SelectParameters.Add("UD_acct", ACCT);
        //        DataView DV = (DataView)SDS.Select(DataSourceSelectArguments.Empty);

        //        //判斷帳號
        //        if (DV.Count != 1) { MESG += "帳號或密碼錯誤，請重新登入!"; LogIn_Error(ACCT, MESG, "7"); return; }

        //        //判斷密碼
        //        string UD_pswd = DV[0]["UD_pswd"].ToString();
        //        string UD_guid = DV[0]["UD_guid"].ToString();

        //        bool CHK1 = false;
        //        bool CHK2 = false;
        //        bool CHK3 = false;
        //        //20200620修改 hash256 改成 blowfish
        //        if (UD_pswd.Length == 40) { CHK1 = UD_pswd == GET.GetSalt256(PSWD, Guid.Parse(UD_guid)); }
        //        if (UD_pswd.Length == 60) { CHK2 = GET.blowfish_check(PSWD, UD_pswd); }
        //        CHK3 = UD_pswd == PSWD;

        //        if (!(CHK1 || CHK2 || CHK3)) { MESG += "帳號或密碼錯誤，請重新登入!\\n"; LogIn_Error(ACCT, MESG, "8"); return; }

        //        //判斷位址
        //        if (DV[0]["UD_ipv4"].ToString() != "") { if (GET.GetClientIP(Page) != DV[0]["UD_ipv4"].ToString()) { MESG += "您的位址不正確!\\n"; LogIn_Error(ACCT, MESG, "9"); return; } }

        //        //例外排除
        //        if (DV[0]["UD_mode"].ToString() == "0") { MESG += "您的帳號未開通!\\n"; LogIn_Error(ACCT, MESG, "0"); return; }
        //        if (DV[0]["UD_mode"].ToString() == "4") { MESG += "您的帳號半年未登入已停用，如需重新啟用請洽各區召集學校!\\n北區聯繫方式:02-2882-4564轉2437!\\n中區聯繫方式:04-2632-8001轉11911!\\n南區聯繫方式:06-597-9566轉7409!\\n"; LogIn_Error(ACCT, MESG, "4"); return; }

        //        if (SCK.GetCookieValue("CCCC2020") == "") //過期或重登再跑
        //        {
        //            if (DV[0]["ID_idno"].ToString() == "SA" || DV[0]["ID_idno"].ToString() == "SU" || DV[0]["ID_idno"].ToString() == "SM" || DV[0]["ID_idno"].ToString() == "M1" || DV[0]["ID_idno"].ToString() == "M2" || DV[0]["ID_idno"].ToString() == "M3" || DV[0]["ID_idno"].ToString() == "SG" || ACCT == "yda05") //yda05 => 例外處理  青年署長官瀏覽成果報告使用
        //            {
        //                if (!DCODE.Visible)
        //                {
        //                    if (KEEP.Checked) { Session["KEEP"] = "T"; } else { Session["KEEP"] = "F"; }
        //                    Session["ACCT"] = ACCT;
        //                    Session["PSWD"] = PSWD;
        //                    string SQLA = "SELECT UD_acct,B.* FROM 會員資料表 A INNER JOIN U_User_Authenticator B ON A.UD_idno=B.UD_idno WHERE UD_acct=@UD_ACCT;";
        //                    SqlDataSource SDSA = new SqlDataSource(INF.COMS, SQLA);
        //                    SDSA.SelectParameters.Add("UD_acct", ACCT);
        //                    DataView DVA = (DataView)SDSA.Select(DataSourceSelectArguments.Empty);

        //                    if(DVA[0]["AU_type"].ToString() == "google")
        //                    {
        //                        //產生QR Code.
        //                        var tfa = new TwoFactorAuthenticator();
        //                        var setupInfo = tfa.GenerateSetupCode("CCCC", ACCT, DVA[0]["AU_guid"].ToString(), false, 4);
        //                        //用內建的API 產生
        //                        //限定辦公室IP  其餘地方登入將不出示QRCODE   雲科/青年署/北區/北區/南區/中區
        //                        string CL_ipv4 = GET.GetClientIP(Page);
                                
        //                        if (CL_ipv4.Substring(0, 7) == "140.125" || CL_ipv4.Substring(0, 7) == "140.111" || CL_ipv4 == "120.96.113.131" || CL_ipv4 == "120.96.113.59" || CL_ipv4 == "203.64.230.119" || CL_ipv4 == "140.128.124.84")
        //                        {
        //                            if (DVA[0]["AU_count"].ToString() != "1") { Code_pictrue.Visible = true; Code_pictrue.InnerHtml = "<img src='" + setupInfo.QrCodeSetupImageUrl + "' />"; }
        //                            else { Code_pictrue.InnerHtml = ""; Code_pictrue.Visible = false; }
        //                        }
        //                        else { Code_pictrue.Visible = false; }
        //                        DCODE.Visible = true;
        //                        DLogin.Visible = false;
                                
        //                    }
        //                    else
        //                    {
        //                        DLogin.Visible = false;
        //                        Code_pictrue.InnerHtml = ""; Code_pictrue.Visible = false;
        //                        string CODE = GET.GetRand(6, true, true, false, true);
        //                        DCODE.Visible = true;
        //                        string cSQL = @" INSERT INTO U_User_Code(UD_idno,UP_time,UD_code) VALUES(@UD_idno,DATEADD(MINUTE,5,GETDATE()),@UC_code);";
        //                        using (SqlConnection CON = new SqlConnection(INF.COMS))
        //                        {
        //                            using (SqlCommand CMD = new SqlCommand(cSQL, CON))
        //                            {
        //                                CMD.Parameters.AddWithValue("UD_idno", DV[0]["UD_idno"].ToString());
        //                                CMD.Parameters.AddWithValue("UC_code", CODE);
        //                                CON.Open(); CMD.ExecuteNonQuery();
        //                            }
        //                        }
        //                        string FROM = INF.SM_user;
        //                        string MLTO = DV[0]["UD_mail"].ToString();
        //                        string SUBT = "青年職涯輔導資訊平臺--多因子驗證信";
        //                        string BODY = CODE + "\n驗證碼時效為五分鐘!";
        //                        try
        //                        {
        //                            INF.SMPT.Send(new MailMessage(FROM, MLTO, SUBT, BODY));
        //                            LOG.Log_Mail("寄送驗證碼", MLTO, "Y", ACCT, Page);
        //                            LogIn_Show("需至您信箱取得驗證碼後輸入才可登入，信件已送出！");
        //                        }
        //                        catch (Exception ex)
        //                        {
        //                            LogIn_Show("錯誤：驗證碼送出失敗，請洽資訊人員！");
        //                            LOG.Log_Mail("寄送驗證碼", MLTO, "N", ACCT, Page);
        //                            LOG.Log_Error(ex, "", Page);
        //                        }
        //                    }
        //                    return;

        //                }
        //                else
        //                {
                            
        //                }
        //            }
        //        }
        //        Session.Clear();


        //        //載入資料
        //        Session["UD_idno"] = DV[0]["UD_idno"].ToString();//編號
        //        Session["UD_acct"] = DV[0]["UD_acct"].ToString();//帳號
        //        Session["UD_pswd"] = DV[0]["UD_pswd"].ToString();//密碼
        //        Session["UD_name"] = DV[0]["UD_name"].ToString();//名稱
        //        Session["UD_mail"] = DV[0]["UD_mail"].ToString();//名稱
        //        Session["UD_mode"] = DV[0]["UD_mode"].ToString();//狀態
        //        Session["UD_guid"] = DV[0]["UD_guid"].ToString();//憑證
        //        Session["UD_rkey"] = DV[0]["UD_rkey"].ToString();//金鑰
        //        Session["SH_idno"] = DV[0]["SH_idno"].ToString();//學校
        //        Session["ID_idno"] = DV[0]["ID_idno"].ToString();//身分
        //        Session["UD_jobn"] = DV[0]["UD_jobn"].ToString();//職稱
        //        Session["UD_sexc"] = DV[0]["UD_sexc"].ToString();//性別
        //        Session["IP_idno"] = GET.GetClientIP(Page);//IP
        //        //1.青年署用的，用來記搜尋的欄位   2.心得分享用的，舊系統都是一般會員，所以新系統要重新請使用者確認 
        //        Session["SQL_YDA"] = ""; Session["UP_date_ID_idno"] = "";
        //        //登入成功
        //        LOG.Log_Login(ACCT, "2", Page);
        //    }
        //    catch (Exception ex) { LogIn_Error(ACCT, "未知錯誤：請洽資訊人員！\\n", "X"); LOG.Log_Error(ex, "", Page); DCODE.Visible = false; }
        //}
        //protected void LogIn_Error(string ACCT, string MESG, string MODE)//登入錯誤處理
        //{
        //    LOG.Log_Login(ACCT, MODE, Page); LogIn_Show(MESG); LogIn_Snum(ACCT);
        //}
        //protected void LogIn_Show(string MESG)//登入錯誤顯示
        //{
        //    LMSG.Text = MESG.Replace("\\n", "<br>");
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "訊息", "alert('" + MESG + "')", true);
        //}

        //protected void LogIn_Snum(string ACCT)//錯誤登入次數
        //{
        //    //查同一IP或帳號
        //    string SQL = @" SELECT COUNT(*) FROM S_Log_Login WHERE (LL_clip=@LL_CLIP OR LL_lacc=ISNULL(@LL_LACC,'')) AND UP_time>DATEADD(MINUTE,-15,GETDATE()) AND LL_mode!='2'";
        //    using (SqlConnection CON = new SqlConnection(INF.COMS))
        //    {
        //        using (SqlCommand CMD = new SqlCommand(SQL, CON))
        //        {
        //            CMD.Parameters.AddWithValue("LL_CLIP", GET.GetClientIP(this));
        //            CMD.Parameters.AddWithValue("LL_LACC", ACCT);
        //            CON.Open(); Session["User_Login"] = CMD.ExecuteScalar().ToString();
        //        }
        //    }
        //    if (Session["User_Login"] != null)
        //    {
        //        if (int.Parse(Session["User_Login"].ToString()) >= 3) { LogIn_Lock(); }
        //    }

        //}
        //protected void LogIn_Load(string ACCT)//資料載入轉換
        //{
        //    //查詢會員權限
        //    string SQL = "";
        //    SQL = @"SELECT  F.*,'' AS UF_href 
        //            FROM    U_User_Identity AS U 
        //                    JOIN U_Identity_Function AS I ON U.ID_idno=I.ID_idno
        //                    JOIN S_System_Function AS F ON I.SF_idno=F.SF_idno 
        //            WHERE   SS_idno='CP' AND U.UD_idno=@UD_idno
				    //UNION
				    //SELECT F.*,'' AS UF_href 
				    //FROM U_User_Function AS U
				    //JOIN  S_System_Function AS F ON U.SF_idno=F.SF_idno 
				    //WHERE   SS_idno='CP' AND U.UD_idno=@UD_idno";
        //    SqlDataSource UDV = new SqlDataSource(INF.COMS, SQL);
        //    UDV.SelectParameters.Add("UD_idno", Session["UD_idno"].ToString());
        //    Session["UD_view"] = ((DataView)UDV.Select(DataSourceSelectArguments.Empty)).Table;

        //    // 查詢會員身份
        //    SQL = @"SELECT  UD_idno,ID_idno
        //            FROM    U_User_Identity 
        //            WHERE   UD_idno=@UD_idno";
        //    SqlDataSource UDI = new SqlDataSource(INF.COMS, SQL);
        //    UDI.SelectParameters.Add("UD_idno", Session["UD_idno"].ToString());
        //    Session["UD_iden"] = ((DataView)UDI.Select(DataSourceSelectArguments.Empty)).Table;

        //    FormsAuthentication.RedirectFromLoginPage(Session["UD_name"].ToString(), true);
        //    if (Session["UD_mode"].ToString() == "1") { Response.Redirect("/VU/User_Update_Password.aspx", false); return; }
        //    if (Session["UD_mode"].ToString() == "3") { Response.Redirect("/VU/User_Update_Password.aspx", false); return; }
        //}
        //protected void LogIn_Lock()//登入錯誤鎖定
        //{
        //    LMSG.Text = "您短時間內登入錯誤3次!請於15分鐘後再登入!";
        //    DACCT.Visible = false;
        //    DPSWD.Visible = false;
        //    DKEEP.Visible = false;
        //    DKEYS.Visible = false;
        //    BUTN.Visible = false;
        //    audio.Visible = false;
        //    DCODE.Visible = false;
        //    Losepswd.Visible = false;
        //    Loseacct.Visible = false;
        //    //audioPlay.Visible = false;
        //}

        //protected void BUTN_Au_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (Session["ACCT"] == null || Session["KEEP"] == null) { return; }
        //        string Au_ACCT = Session["ACCT"].ToString();
        //        string Au_KEEP = Session["KEEP"].ToString();
        //        string SQL = @" 
        //                        UPDATE  會員資料表 SET UD_mode='3',UP_user=UP_user,UP_time=GETDATE()
        //                        WHERE   DATEADD(d,90, UD_pchg) < GETDATE() AND UD_mode='2' AND UD_acct=@UD_acct;
        //                        OPEN SYMMETRIC KEY xKey DECRYPTION BY CERTIFICATE xCert WITH PASSWORD = 'CCCCDB5371%#&!';
        //                        SELECT UD.*,ID_idno FROM 會員資料表 UD
        //                        LEFT JOIN U_User_Identity UI ON UD.UD_idno=UI.UD_idno WHERE UD_acct = @UD_acct; CLOSE ALL SYMMETRIC KEYS;";

        //        SqlDataSource SDS = new SqlDataSource(INF.COMS, SQL);
        //        SDS.SelectParameters.Add("UD_acct", Session["ACCT"].ToString());
        //        DataView DV = (DataView)SDS.Select(DataSourceSelectArguments.Empty);

        //        string SQLA = "OPEN SYMMETRIC KEY xKey DECRYPTION BY CERTIFICATE xCert WITH PASSWORD = 'CCCCDB5371%#&!'; SELECT UD_acct,B.* FROM 會員資料表 A INNER JOIN U_User_Authenticator B ON A.UD_idno=B.UD_idno WHERE UD_acct=@UD_ACCT; CLOSE ALL SYMMETRIC KEYS;";
        //        SqlDataSource SDSA = new SqlDataSource(INF.COMS, SQLA);
        //        SDSA.SelectParameters.Add("UD_acct", Session["ACCT"].ToString());
        //        DataView DVA = (DataView)SDSA.Select(DataSourceSelectArguments.Empty);

                            
                        
        //        if (TCode.Text == "") { LogIn_Show("多因子驗證碼不得為空！"); return; }
        //        else
        //        {
        //            if (DVA[0]["AU_type"].ToString() == "google")
        //            {
        //                TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
        //                //第一個參數是你當初產生QRcode 所產生的Secret code 
        //                //第二個參數是用戶輸入的純數字Code
        //                var result = tfa.ValidateTwoFactorPIN(DVA[0]["AU_guid"].ToString(), TCode.Text);
        //                if (!result) { LogIn_Show("多因子驗證碼有誤！"); return; }
        //                else
        //                {
        //                    if(DVA[0]["AU_count"].ToString() != "1")
        //                    {
        //                        string cSQL = @" UPDATE U_User_Authenticator SET AU_count=@AU_count,UP_user=@UP_user,UP_time=GETDATE() WHERE UD_idno=@UD_idno;";
        //                        using (SqlConnection CON = new SqlConnection(INF.COMS))
        //                        {
        //                            using (SqlCommand CMD = new SqlCommand(cSQL, CON))
        //                            {
        //                                CMD.Parameters.AddWithValue("UD_idno", DV[0]["UD_idno"].ToString());
        //                                CMD.Parameters.AddWithValue("UP_user", DV[0]["UD_idno"].ToString());
        //                                CMD.Parameters.AddWithValue("AU_count", "1");
        //                                CON.Open(); CMD.ExecuteNonQuery();
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                string SQL_Code = "";
        //                string cSQL = @"DELETE U_User_Code WHERE UP_time<GETDATE();
        //                             SELECT TOP 1 UD_code FROM U_User_Code WHERE UD_idno=@UD_idno ORDER BY UP_time DESC;";
        //                using (SqlConnection CON = new SqlConnection(INF.COMS))
        //                {
        //                    using (SqlCommand CMD = new SqlCommand(cSQL))
        //                    {
        //                        CMD.Connection = CON;
        //                        CMD.Parameters.AddWithValue("UD_idno", DV[0]["UD_idno"].ToString());
        //                        CON.Open();
        //                        SQL_Code = CMD.ExecuteScalar().ToString();
        //                    }
        //                }
        //                if (TCode.Text != SQL_Code || SQL_Code == "") { LogIn_Show("多因子驗證碼有誤！"); return; }
        //            }    

        //        }
        //        Session.Clear();
        //        //載入資料
        //        Session["UD_idno"] = DV[0]["UD_idno"].ToString();//編號
        //        Session["UD_acct"] = DV[0]["UD_acct"].ToString();//帳號
        //        Session["UD_pswd"] = DV[0]["UD_pswd"].ToString();//密碼
        //        Session["UD_name"] = DV[0]["UD_name"].ToString();//名稱
        //        Session["UD_mail"] = DV[0]["UD_mail"].ToString();//名稱
        //        Session["UD_mode"] = DV[0]["UD_mode"].ToString();//狀態
        //        Session["UD_guid"] = DV[0]["UD_guid"].ToString();//憑證
        //        Session["UD_rkey"] = DV[0]["UD_rkey"].ToString();//金鑰
        //        Session["SH_idno"] = DV[0]["SH_idno"].ToString();//學校
        //        Session["ID_idno"] = DV[0]["ID_idno"].ToString();//身分
        //        Session["UD_jobn"] = DV[0]["UD_jobn"].ToString();//職稱
        //        Session["UD_sexc"] = DV[0]["UD_sexc"].ToString();//性別
        //        Session["IP_idno"] = GET.GetClientIP(Page);//IP
        //        //1.青年署用的，用來記搜尋的欄位   2.心得分享用的，舊系統都是一般會員，所以新系統要重新請使用者確認 
        //        Session["SQL_YDA"] = ""; Session["UP_date_ID_idno"] = "";
        //        //登入成功
        //        LOG.Log_Login(Session["UD_acct"].ToString(), "2", Page);
        //        if (Session["UD_mode"] != null)
        //        {
        //            //是否自動登入
        //            if (Au_KEEP=="T")
        //            {
        //                string RKEY = Guid.NewGuid().ToString();
        //                string SQLK = @" UPDATE 會員資料表 SET UD_rkey=@UD_rkey,UD_dead=@UD_dead WHERE UD_idno=@UD_idno";
        //                DateTime DATE = DateTime.Now.AddDays(7);
        //                using (SqlConnection CON = new SqlConnection(INF.COMS))
        //                {
        //                    using (SqlCommand CMD = new SqlCommand(SQLK, CON))
        //                    {
        //                        CMD.Parameters.AddWithValue("UD_idno", Session["UD_idno"].ToString());
        //                        CMD.Parameters.AddWithValue("UD_rkey", RKEY);
        //                        CMD.Parameters.AddWithValue("UD_dead", DATE);
        //                        CON.Open(); CMD.ExecuteNonQuery();
        //                    }
        //                }
        //                SCK.SetCookie("CCCC2020", RKEY, DATE);
        //            }
        //            LogIn_Load(Au_ACCT);
        //        }
        //    }
        //    catch (Exception ex) { LogIn_Error("", "未知錯誤：請洽資訊人員！\\n", "X"); LOG.Log_Error(ex, "", Page); DCODE.Visible = false; DLogin.Visible = true; }
        //}
    }
}