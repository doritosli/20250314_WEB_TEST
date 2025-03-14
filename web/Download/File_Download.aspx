<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="File_Download.aspx.cs" Inherits="web.Download.File_Download" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-lg-12">
        <div class="container pt-3">
            <div class="row">
                <div class="col-md-12">
                    <ol class='breadcrumb'>
                        <li>您目前位置：</li>
                        <li class='breadcrumb-item'><a href='/'>首頁</a></li>
                        <li class='breadcrumb-item'>檔案下載</li>
                    </ol>
                </div>
                <asp:UpdatePanel ID="UPL" runat="server">
                    <ContentTemplate>
                        <%-- <div class="modal fade" id="MODEL" role="dialog" onkeypress="if( event.keyCode == 13 ) { return false; }">
                        <div class="modal-dialog modal-lg">
                            <div class="modal-content">
                                <div class="modal-header ">
                                    <h3 class="modal-title">檔案上傳</h3>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                                <div class="modal-body">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <asp:RequiredFieldValidator ID="FQR_year" runat="server" ControlToValidate="QR_year" ErrorMessage="年度不得空白" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ValidationGroup="QR" />
                                            <asp:RegularExpressionValidator ID="EQR_year" runat="server" ControlToValidate="QR_year" ValidationExpression="^([1-9][0-9]*){1,3}$" ErrorMessage="請輸入數字(不得為0)" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ValidationGroup="QR" />
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend"><span class="input-group-text">年度</span></div>
                                                <asp:TextBox ID="QR_year" runat="server" CssClass="form-control" MaxLength="3"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-md-12">
                                            <asp:RequiredFieldValidator ID="FQR_name" runat="server" ControlToValidate="QR_name" ErrorMessage="檔案名稱不得空白" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ValidationGroup="QR" />
                                            <asp:RegularExpressionValidator ID="EQR_name" runat="server" ControlToValidate="QR_name" ValidationExpression="^[\s\S]{1,100}$" ErrorMessage="名稱請輸入1至100字" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ValidationGroup="QR" />
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend"><span class="input-group-text">檔案名稱</span></div>
                                                <asp:TextBox ID="QR_name" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <div class="input-group mb-3">
                                                <asp:FileUpload ID="FileUploadS" runat="server" CssClass="form-control" Onchange="PreviewPDF(this)" />
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <div class="input-group mb-3">
                                                <div id="Show_File"></div>
                                                <iframe id="SS_fram" runat="server" style="width: 100%; height: 600px"></iframe>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button ID="ButtonADD" runat="server" Text="確認新增" CssClass="btn btn-success" CausesValidation="false" ValidationGroup="QR" />
                                        <asp:Button ID="ButtonCHG" runat="server" Text="確認修改" CssClass="btn btn-success" CausesValidation="false" ValidationGroup="QR" />
                                        <asp:Button ID="ButtonCEL" runat="server" CausesValidation="False" Text="取消" CssClass="btn btn-info" data-dismiss="modal" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>--%>
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-sm table-striped table-bordered table-hover" Style="word-break: break-all; word-wrap: normal; width: 100%;"
                            AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" AllowSorting="True" AllowPaging="True"
                            HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                            <Columns>
                                <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="Name" HeaderText="檔名" />
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="檔案下載" ItemStyle-Width="20%">
                                    <ItemTemplate>
                                        <asp:Button ID="ButtonDL" runat="server" CssClass="btn btn-primary" CausesValidation="False" CommandName="DL" Text="下載" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <%--<asp:GridView ID="GridViewP" runat="server" DataSourceID="SqlDataSourceP" CssClass="table table-sm table-striped table-bordered table-hover" Style="word-break: break-all; word-wrap: normal; width: 100%;"
                        AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" AllowSorting="True" AllowPaging="True"
                        HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" OnRowCommand="GridViewP_RowCommand" OnRowDataBound="GridViewP_RowDataBound" DataKeyNames="">
                        <Columns>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="序號" ItemStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="QR_year" HeaderText="年度" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="QR_name" HeaderText="檔案名稱" ItemStyle-HorizontalAlign="Center" />
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="檔案下載" ItemStyle-Width="20%">
                                <ItemTemplate>
                                    <asp:Button ID="ButtonDL" runat="server" CssClass="btn btn-primary" CausesValidation="False" CommandName="DL" Text="下載" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" />
                                    <asp:Button ID="ButtonUP" runat="server" CssClass="btn btn-info" CausesValidation="False" CommandName="UP" Text="修改" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>--%>
                        <div class="col-lg-12">
                            <asp:Label ID="LMSG" runat="server" ForeColor="Red"></asp:Label>
                        </div>
                        <div class="col-md-12" id="back" runat="server">
                            <p><a href="/Default" class="btn btn-info btn-md">BACK</a></p>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-md-12">
                <div class="input-group mb-3">
                    <div id="Show_File"></div>
                    <iframe id="SS_fram" runat="server" style="width: 100%; height: 600px"></iframe>
                </div>
            </div>
        </div>
    </div>

    <%--<asp:SqlDataSource ID="SqlDataSourceP" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
        SelectCommand="SELECT * FROM 記錄上傳檔案的資料表 ORDER BY QR_year desc"></asp:SqlDataSource>--%>

    <script src="../Scripts/jquery-ui-1.12.1.min.js"></script>
    <script>
        function PreviewPDF(input) {
            var file_type = input.files[0].name.substring(input.files[0].name.lastIndexOf('.') + 1).toLowerCase();
            var file_size = input.files[0].size / 1024 / 1024;
            var file_mesg = "";
            if (file_type != "pdf") { file_mesg = "檔案限 PDF 檔"; };
            if (file_size > 5) { file_mesg = "檔案上傳限制5MB"; };

            if (file_mesg != "") { alert(file_mesg); }//相對應檔案上傳大小限制有通過
            else {
                if (input.files && input.files[0]) {
                    var reader = new FileReader();
                    reader.readAsDataURL(input.files[0]);
                }
                reader.onload = function (e) {
                    var result = e.target.result;
                    $("#MainContent_SS_fram").attr("src", result);
                    $("#MainContent_SS_fram").show();
                }
            }
        };
    </script>
</asp:Content>
