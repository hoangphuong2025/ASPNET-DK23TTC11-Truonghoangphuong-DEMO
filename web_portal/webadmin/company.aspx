<%@ Page Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="company.aspx.cs" Inherits="web_portal.webadmin.company" Title=" " %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table class="main" cellpadding=0 cellspacing=0 width="100%">
  <tr>
   	<td align="left" class="heading" style="text-transform:uppercase;padding-left:10px;">Thông tin công ty</td>
  </tr>
</table>
<table cellpadding=0 cellspacing=0 width="100%" class="main">
   <tr>
     <td  align="center" style="padding-left:10px;" >
        <table cellpadding=0 cellspacing=0 width="100%" border="0" style="line-height: 180%;text-align: left">
                <tr>
                   
                    <td style="padding-bottom: 10px" >
                   
                </tr>   
                <tr>
                    <td></td>
                 <td style="text-align: left"><asp:Label runat="server" ID="Label1"></asp:Label> </td>
               </tr>
                <tr>
                    <td>
                        Tên Công ty 
                        </td>
                    <td colspan="3" >
                        <asp:TextBox ID="txtName" runat="server" Width="700px" Rows="1"></asp:TextBox></td>
                </tr>    
                <tr >
                    <td>
                        Tên tiếng anh
                        </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtName_en" runat="server" Width="700px" Rows="1"></asp:TextBox></td>
                </tr>    
                    
                <tr>
                    <td>
                        Địa Chỉ</td>
                    <td >
                        <asp:TextBox ID="txtaddress" runat="server" Rows="4" TextMode="MultiLine" Width="350px"></asp:TextBox></td>
                    <td >
                        Email</td>
                    <td  >
                    <asp:TextBox ID="txtemail" runat="server" Width="220px"></asp:TextBox></td>
                </tr>
                <tr >
                    <td >
                        Address</td>
                    <td >
                        <asp:TextBox ID="txtAddress_en" runat="server" Rows="4" TextMode="MultiLine" Width="350px"></asp:TextBox></td>
                  <td>
                        Fax</td>
                    <td >
                        <asp:TextBox ID="txtfax" runat="server" Width="220px"></asp:TextBox></td>
                </tr>
                <tr>
                    
                    <td >
                        website</td>
                    <td >
                        <asp:TextBox ID="txtwebsite" runat="server" Width="200px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td >
                        Hot Line </td>
                    <td>
                        <asp:TextBox ID="p_copywriter" runat="server" Width="300px"></asp:TextBox></td>
                    <td style="display: none" >
                        Di động</td>
                    <td style="display: none">
                        <asp:TextBox ID="txtcalphone" runat="server" Width="300px"></asp:TextBox></td>
                    
                </tr>
                <tr>
                <td >
                        Số Điện Thoại</td>
                    <td >
                        <asp:TextBox ID="txttele" runat="server" Width="300px"></asp:TextBox></td>
                    <td style="display: none" >
                        Giám Đốc</td>
                    <td style="display: none"  >
                        <asp:TextBox ID="txtgiamdoc" runat="server" Width="300px"></asp:TextBox></td>
                    <td >
                    </td>
                </tr>
                <tr style="display: none"> 
                  <td colspan="4">Sơ đồ đường đi</td>                    
                </tr>
                <tr style="display: none"> 
                  <td colspan="4">
                    <asp:TextBox runat="server" ID="pmap" TextMode="MultiLine" Rows="15" Width="700"></asp:TextBox>
                  </td>                    
                </tr>
               
               
                <tr >
                    <td ></td>   
                    <td align="left"  style="padding-bottom: 5px;padding-top: 5px">
                        <asp:Button ID="btnSave" CssClass="back_button main_sub"  runat="server" OnClick="btnSave_Click" Text="Cập nhật" Width="120" />                                             
                        </td>
                
                </tr>
           
                
            </table>
         </td>
        </tr>                  
     </table>
</asp:Content>
