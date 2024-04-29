<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
        <%--<link rel="stylesheet" href="/resources/demos/style.css">--%>
        <script src="https://code.jquery.com/jquery-3.6.0.js"></script>
        <script src="https://code.jquery.com/ui/1.13.2/jquery-ui.js"></script>

        <script type="text/javascript">
            $(document).ready(function () {
                $(function () {
                    //$("#BirthdayTextBox").datepicker();
                    $('#<%=BirthdayTextBox.ClientID %>').datepicker();

                $('#<%=BirthdayTextBox.ClientID %>').on("change", function () {
                    $('#<%=BirthdayTextBox.ClientID %>').datepicker("option", "dateFormat", "yy-mm-dd");
                });

            });
        });
        </script>
    </div>
    <%-- <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>
    --%>
    <div class="row">
        <%-- <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>--%>
        <div class="col-md-4">
            <h2></h2>
            <p>
                姓名:
                <asp:TextBox runat="server" ID="NameTextBox" Text="" AutoCompleteType="Disabled"></asp:TextBox>
            </p>
            <p>
                年齡:
                <asp:TextBox runat="server" ID="AgeTextBox" Text="" TextMode="Number" AutoCompleteType="Disabled"></asp:TextBox>
            </p>
            <p>
                生日:
                <asp:TextBox runat="server" ID="BirthdayTextBox" Text="" AutoCompleteType="Disabled"></asp:TextBox>
            </p>

            <p>
                <asp:Button Text="建立帳號" ID="FunctionButton" runat="server" OnClick="FunctionButton_Click" />
            </p>
            <p>
                <asp:HiddenField ID="HiddenFieldToken" runat="server" />
            </p>

            <p>
                <asp:GridView ID="GridView1" runat="server" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="False" >
                    <Columns>

                        <asp:BoundField DataField="Name"
                            HeaderText="姓名" >
                        <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Age" DataFormatString=""
                            HeaderText="年齡" >
                        <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Birthday"
                            HeaderText="生日" >

                        <ItemStyle Width="100px" />
                        </asp:BoundField>

                        <asp:ButtonField ButtonType="Link"
                            CommandName="Up"
                            Text="更新" >

                        <ItemStyle Width="100px" />
                        </asp:ButtonField>

                        <asp:ButtonField ButtonType="Link"
                            CommandName="Del"
                            Text="刪除" >
                        <ItemStyle Width="100px" />
                        </asp:ButtonField>
                    </Columns>
                    <EmptyDataTemplate>
                        <table cellspacing="0" rules="all" border="1" id="MainContent_GridView1" style="border-collapse: collapse;">
                            <tbody>
                                <tr>
                                    <th scope="col">姓名</th>
                                    <th scope="col">年齡</th>
                                    <th scope="col">生日</th>
                                    <th scope="col">&nbsp;</th>
                                    <th scope="col">&nbsp;</th>
                                </tr>
                                <tr>
                                    <td  style="width:500px;" colspan="5">無資料</td>
                                  <%--  <td  style="width:100px;"></td>
                                    <td  style="width:100px;"></td>
                                    <td  style="width:100px;"></td>
                                    <td  style="width:100px;"></td>--%>
                                </tr>
                            </tbody>
                        </table>
                    </EmptyDataTemplate>
                </asp:GridView>
            </p>

        </div>

    </div>
</asp:Content>
