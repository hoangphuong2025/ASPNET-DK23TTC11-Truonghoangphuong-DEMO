<%@ Page Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" Codebehind="productgroup.aspx.cs"
    Inherits="web_portal.webadmin.productgroup" Title=" " %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="main" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="left" class="heading" style="text-transform: uppercase; padding-left: 10px;">
                <asp:Label ID="lblTitle" runat="server" Text="Nhóm sản phẩm"></asp:Label>
            </td>
        </tr>
    </table>
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="main">
        <tr>
            <td height="10">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                <asp:Panel runat="server" ID="PANNELCREATE">
                    <table border="0" cellpadding="1" cellspacing="2" width="98%">
                       <asp:Label runat="server" ID="labelhiden" Visible=false></asp:Label>
                        <tr>
                            <td align="left" >
                                Tên nhóm </td>
                            <td>
                                <asp:TextBox ID="p_name" runat="server" Width="350"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="p_name"
                                    Display="Static" ErrorMessage="Nhập tên " Font-Italic="True" Font-Size="Small"
                                    SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                         <tr >
                            <td align="left" > Group name </td>
                            <td>
                                <asp:TextBox ID="p_nameen" runat="server" Width="350"></asp:TextBox>
                                
                            </td>
                        </tr>       
                          <tr style="display: none">
                            <td align="left" >
                                Chinese name </td>
                            <td>
                                <asp:TextBox ID="p_namechi" runat="server" Width="210px"></asp:TextBox>
                               
                            </td>
                        </tr>     
                           <tr>
                            <td align="left" width="130">
                                Người phụ trách</td>
                            <td>
                                <asp:DropDownList runat="server" ID="plistuser"></asp:DropDownList>
                                
                            </td>
                        </tr>   
                          <tr>
                            <td align="left" width="100">
                                Thứ tự </td>
                            <td>
                                <asp:TextBox ID="p_index" runat="server" Width="210px"></asp:TextBox>
                                
                            </td>
                        </tr> 
                                          
                        <tr>
                            <td>
                            </td>
                            <td align="left" style="padding-bottom:10px;padding-top:10px;">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" align="left">
                                    <tr>
                                        <td>
                                            <asp:Button Width="180" ID="btnAdd" runat="server" Text=" Thêm mới " OnClick="btnAdd_ckick" CssClass="back_button main_sub" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="text-align: left" valign="middle">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Lỗi xảy ra:" />
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label runat="server" ID="p_label"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel runat="server" ID="PANNELLIST">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                      
                        <tr>
                            <td align="center">
                                <table cellpadding="0" cellspacing="0" width="98%" class="list_table">
                                    <asp:Repeater runat="server" ID="p_list" OnItemDataBound="p_list_ItemDataBound">
                                        <HeaderTemplate>
                                            <tr class="list_title">
                                                <td >
                                                    # </td>
                                                <td width="40%" >
                                                    Tên nhóm</td>
                                                <td width="40%" >
                                                    Name</td>            
                                                <td width="10%">
                                                   <img src="../styles/admin/images/checkbox.jpg" /></td>
                                            </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr class="list_row">
                                                <td align="center">
                                                <a href="productgroup.aspx?menuid=1&act=view&pid=<%#Eval("ProductGroupId")%>">
                                                    <%#Eval("Indexs")%>
                                                  </a>  
                                                </td>
                                                <td align="left"  style="padding-left:5px;">
                                                    <a href="productgroup.aspx?menuid=1&act=view&pid=<%#Eval("ProductGroupId")%>">
                                                        <%#Eval("NameVi")%>
                                                    </a>
                                                </td>
                                                
                                               
                                                <td>  <%#Eval("NameEn")%></td>
                                                <td align="center">
                                                    <input type="checkbox" name="checkbtn" value='<%#Eval("ProductGroupId")%>' /></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="10">
                                &nbsp;
                            </td>
                        </tr>
                        <tr  >
                            <td align="center">
                                <asp:Button ID="btnAddList" runat="server" CssClass="back_button main_sub" OnClick="btnAddList_Click"
                                    Text=" Thêm mới"  Visible="false" Width="180" />&nbsp;<asp:Button ID="btnDelete" runat="server"
                                        CssClass="back_button main_sub"  OnClick="btnDelete_Click" Text=" Xóa " Width="180"  /></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td height="10">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
