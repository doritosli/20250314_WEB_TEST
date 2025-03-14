<%@ Page Title="會員登入" Async="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="User_Login.aspx.cs" Inherits="web.Login.User_Login" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container p-3" style="background: #fffdf4">
        <ol class="breadcrumb" style="background: #fffdf4">
            <a href='#C' title='中央內容區塊' id='gotocenter' accesskey='C' name='gotocenter' onfocus='OnFocus()' onblur='UnFocus()'>:::</a>
            <li class="active"><span style="font-family: 微軟正黑體, sans-serif; font-size: medium;">您目前位置：</span></li>
            <li><a href="/" class="pathway"><span style="font-family: 微軟正黑體, sans-serif; font-size: medium;">首頁</span></a></li>
            <li><span class="divider"><span style="font-family: 微軟正黑體, sans-serif; font-size: medium;">/ </span></span><span><span style="font-family: 微軟正黑體, sans-serif; font-size: large;">會員登入</span></span></li>
        </ol>
        <div class="pt-1">
            <asp:UpdatePanel ID="UPL" runat="server">
                <ContentTemplate>
                    <div class="loginmodal-container" style="background: #fffdf4">
                        <div class="form-group">
                            <h2>會員登入</h2>
                        </div>
                        <div id="DLogin" runat="server">
                            <label for="MainContent_ACCT">
                                <div>
                                    <span style="font-family: 微軟正黑體, sans-serif; color: #696969; font-size: large;">帳號 </span><span style="color: red">*</span>
                                </div>
                            </label>
                            <asp:RequiredFieldValidator ID="FACCT" runat="server" ControlToValidate="ACCT" ErrorMessage="帳號不得空白" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ValidationGroup="Login" />
                            <div id="DACCT" runat="server" class="form-group">
                                <asp:TextBox runat="server" ID="ACCT" CssClass="form-control" placeholder="使用者帳號" AUTOCOMPLETE="off" aria-label="使用者帳號" onkeypress="if( event.keyCode == 13 ) { return false; }" />
                            </div>
                            <label for="MainContent_PSWD">
                                <div>
                                    <span style="font-family: 微軟正黑體, sans-serif; color: #696969; font-size: large;">密碼 </span><span style="color: red">*</span>
                                </div>
                            </label>
                            <asp:RequiredFieldValidator ID="FPSWD" runat="server" ControlToValidate="PSWD" ErrorMessage="密碼不得空白" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ValidationGroup="Login" />
                            <div id="DPSWD" runat="server" class="form-group position-relative">
                                <asp:TextBox runat="server" ID="PSWD" CssClass="form-control " TextMode="Password" placeholder="密碼" AUTOCOMPLETE="off" aria-label="使用者密碼" onkeypress="if( event.keyCode == 13 ) { return false; }" />
                                <a style="position: absolute; top: 8px; left: 300px;" href="#" name="eye">
                                    <i class="fa fa-eye-slash" aria-hidden="true"></i>
                                    <span class="sr-only">密碼明碼</span>
                                </a>
                            </div>
                            <div id="DKEEP" runat="server" style="text-align: left;" class="form-group" aria-label="記得我一週" title="記得我一週">
                                <asp:CheckBox ID="KEEP" runat="server" value="記得我一週" aria-label="記得我一週" title="記得我一週" />
                                <label for="MainContent_KEEP">記得我一週</label>
                            </div>
                            <%--語音撥放驗證碼--%>
                            <div id="audio" class="input-group" runat="server">
                                <label for="MainContent_KEYS">
                                    <asp:Image ID="CODE" runat="server" ImageUrl="/App_Ashx/ValidateCode.ashx" title="圖形驗證碼" alt="圖形驗證碼" /></label>
                                <asp:Label ID="MARK" runat="server" Text="=" Font-Size="Large" ForeColor="#0066ff"></asp:Label>
                                <asp:TextBox ID="KEYS" runat="server" placeholder="運算結果" CssClass="form-control" Font-Size="Large" Width="80px" onkeypress="if( event.keyCode == 13 ) { return false; }"></asp:TextBox>
                                <a id="audbtn" href="#" onclick="AudioPlay()" class="btn btn-dark" style="font-size: large; color: white;" title="語音播放圖形驗證碼" alt="語音播放圖形驗證碼">語音播放</a>
                            </div>
                            <div class="col-lg-12" style="padding-top: 10px;">
                                <div class="form-group">
                                    <asp:Button runat="server" ID="BUTN" Text="登入" CssClass="loginmodal-submit" CausesValidation="true" ValidationGroup="Login" />
                                    <asp:Label ID="LMSG" runat="server" ForeColor="Red"></asp:Label>
                                </div>
                            </div>
                            <div class="col-lg-12">
                                <a id="Losepswd" runat="server" name="BLUI" class="btn btn-link" style="padding: 0" href="/">忘記密碼?</a>
                                <a id="Loseacct" runat="server" name="BLUI" class="btn btn-link" style="padding: 0" href="/">忘記帳號?</a>
                                <a name="BLUI" class="btn btn-link" style="padding: 0" href="/">註冊帳號?</a>
                            </div>
                            <div class="col-md-12" id="back" runat="server">
                                <a href="/Default" class="btn btn-info btn-md">BACK</a>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.1/css/all.min.css">
    <style type="text/css">
        :focus {
            outline-width: 5px !important;
            outline-style: groove !important;
            outline-color: red !important;
            box-shadow: none !important;
        }
        a {
            display: inline-block;
        }
    </style>
    <script>
        $("#MainContent_DPSWD a").on('click', function (event) {
            event.preventDefault();
            if ($('#MainContent_DPSWD input').attr("type") == "text") {
                $('#MainContent_DPSWD input').attr('type', 'password');
                $('#MainContent_DPSWD i').addClass("fa-eye-slash");
                $('#MainContent_DPSWD i').removeClass("fa-eye");
            } else if ($('#MainContent_DPSWD input').attr("type") == "password") {
                $('#MainContent_DPSWD input').attr('type', 'text');
                $('#MainContent_DPSWD i').removeClass("fa-eye-slash");
                $('#MainContent_DPSWD i').addClass("fa-eye");
            }
        });
        function AudioPlay() {
            let checkText = "";
            fetch('/App_Ashx/ValidateCodeVoice.ashx', {
                method: 'GET'
            }).then(response => {
                return response.text();
            }).then(data => {
                checkText = data;
                if (checkText) {
                    var speech = new SpeechSynthesisUtterance(checkText);
                    window.speechSynthesis.speak(speech);
                }
            })
        };

    </script>
</asp:Content>
