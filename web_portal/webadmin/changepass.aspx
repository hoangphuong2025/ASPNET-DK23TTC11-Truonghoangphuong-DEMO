<%@ Page Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="changepass.aspx.cs" Inherits="web_portal.webadmin.changepass" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table class="main" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="left" class="heading" style="text-transform: capitalize; padding-left: 10px;">
                Thay đổi mật khẩu
            </td>
        </tr>
    </table>
<table cellpadding="0" cellspacing="0" style="width: 100%" class="main">
    <tr>
        <td height="10">&nbsp;</td>
    </tr>
    <tr>
        <td align="center">
            <table border="0" cellpadding="0" cellspacing="0" width="98%" style="line-height: 200%;text-align: left">
                <tr>
                    <td >
                        Tên truy cập</td>
                    <td >
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="txt" Width="200px"></asp:TextBox></td>
                  
                </tr>
                <tr>
                    
                    <td >
                        Mật khẩu cũ</td>
                    <td>
                        <asp:TextBox ID="txtOldpassword" runat="server" CssClass="txt" TextMode="Password"
                            Width="200px"></asp:TextBox><font style="color: red">*</font>
                        <asp:RequiredFieldValidator ID="reOldPass" runat="server" ControlToValidate="txtOldpassword"
                            ErrorMessage="nhập mật khẩu cũ" Display=Static></asp:RequiredFieldValidator></td>
                </tr>
                         
                <tr>
                    <td style="width: 150px" >
                        Mật khẩu mới</td>
                    <td>
                        <asp:TextBox ID="txtPass" runat="server" CssClass="txt" TextMode="Password" Width="200px"></asp:TextBox>
                        <font style="color: red">*</font>
                        <asp:RequiredFieldValidator ID="rePass" runat="server" ControlToValidate="txtPass"
                            ErrorMessage="nhập mật khẩu mới" Display=Static></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td >
                        Xác nhận</td>
                    <td >
                        <asp:TextBox ID="txtConfirm" runat="server" CssClass="txt" TextMode="Password" Width="200px"></asp:TextBox>
                        <font style="color: red">*</font>
                        <asp:CompareValidator ID="comPass" runat="server" ControlToCompare="txtPass" ControlToValidate="txtConfirm"
                            ErrorMessage="Xác nhận mật khẩu không đúng"></asp:CompareValidator></td>
                </tr>
               
                <tr>
                    <td></td>
                    <td align="left">
                        <asp:Button ID="btnChange" runat="server" CssClass="back_button main_sub" OnClick="btnChange_Click"
                            Text="Thay đổi" Width="100px" />
                     </td>
                   
                </tr>
                <tr>        
                    <td colspan=2>
                        <asp:Label ID="lblErr" runat="server"></asp:Label></td>
                    <td>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td height="10">&nbsp;</td>
    </tr>
</table>
</asp:Content>
