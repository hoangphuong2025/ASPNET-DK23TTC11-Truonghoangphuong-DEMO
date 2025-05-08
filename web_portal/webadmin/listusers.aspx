<%@ Page Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" Codebehind="listusers.aspx.cs"
    Inherits="web_portal.webadmin.listusers" Title="" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
function uploadbrower(str)
{		
    ss ="./uploadvideo.aspx?cmd=chang&pathdir=/"+str;
    window.open(ss,"","scrollbars=no,toolbar=no,location=no,directories=no,width=500,height=420,resizable=no,menubar=no") ;		  
}
function setPicValue() 
{       
      refresh();
} 
function setpicture(values)
{
   var tempsrc  ="file://"+values;
  	var en_viItem=document.getElementById('IDB1');
  	var imgss=document.getElementById('ctl00_ContentPlaceHolder1_ImgView1');
  	if(en_viItem==null)
  	{
  	}
  	else
  	{
  	     if(imgss==null)
  	     {  	   
  	        //checkfile.value ="error";   
  	     }  	   
  	     else
  	     {  	         	       
  	       en_viItem.style.display='inline';  	      	      
  	       imgss.src=tempsrc;
  	       //aspnetForm.checkfile.value=imgss.src;
  	       //alert(aspnetForm.checkfile.value);
  	     }    
  	     
  	} 	
  		
}
function checkpicture()
{
  var en_viItemp=document.getElementById('p_check');
  if(en_viItemp==null)
   {    
   }
  else
  {
     en_viItemp.style.display='none';
  } 
}
    </script>

    <table class="main" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="left" class="heading" style="text-transform: capitalize; padding-left: 10px;">
                <asp:Label ID="lblTitle" runat="server" Text="Danh sách nhân viên"></asp:Label>
            </td>
        </tr>
    </table>
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="main">
      
        <tr>
            <td align="center" style="padding-left: 10px">
                <asp:Panel runat="server" ID="PANNELCREATE" Visible="false">
                    <table border="0" cellpadding="1" cellspacing="1"  style="text-align:left;width:100%;line-height:180%">
                        <asp:Label runat="server" ID="pmcid" Visible="false"></asp:Label>
                        
                        <tr>
                            <td width="130">
                                Tên nhân viên</td>
                            <td>
                                <asp:TextBox ID="p_name" runat="server" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="p_name"
                                    Display="Static" ErrorMessage="nhập tên nhân viên" Font-Italic="True" Font-Size="Small"
                                    SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </td>
                             <td width="100" align="left">
                                Địa chỉ</td>
                            <td>
                                <asp:TextBox ID="p_address" TextMode="MultiLine" Rows="3" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Tên truy cập</td>
                            <td>
                                <asp:TextBox ID="p_username" runat="server" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="p_username"
                                    Display="Static" ErrorMessage="nhập tên truy cập" Font-Italic="True" Font-Size="Small"
                                    SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </td>
                              <td>
                                Thuộc phòng</td>
                            <td>
                                <asp:DropDownList runat="server" ID="p_kindofbusiness">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Mật khẩu</td>
                            <td>
                                <asp:TextBox ID="p_pass" TextMode="Password" runat="server" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="p_pass"
                                    Display="Static" ErrorMessage="nhập mật khẩu" Font-Italic="True" Font-Size="Small"
                                    SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </td>
                              <td>
                                Thuộc nhóm</td>
                            <td>
                                <asp:DropDownList runat="server" ID="plist_group">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                          
                        </tr>
                      
                        <tr>
                            <td>
                                Số điện thoại</td>
                            <td>
                                <asp:TextBox runat="server" Style="width: 200px" ID="p_tel"></asp:TextBox>
                            </td>
                              <td>
                                Trạng thái</td>
                            <td>
                                <asp:DropDownList runat="server" ID="plist_status">
                                </asp:DropDownList>
                            </td>
                        </tr>
                       <tr>
                            <td>
                                Zalo chat </td>
                            <td>
                                <asp:TextBox runat="server" Style="width: 200px" ID="p_nickchat"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                         <tr>
                            <td>
                                Facebook</td>
                            <td>
                                <asp:TextBox runat="server" Style="width: 200px" ID="p_skyper"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                        <asp:CheckBoxList runat="server" ID="plistsub1" RepeatColumns="1" Width="100%"  >
                                                                </asp:CheckBoxList>
                            <td class="separateline" colspan="4"></td>
                        </tr>
                        <tr>
                            <td colspan="4" align="left" style="font-weight: 600; padding-bottom: 10px; padding-top: 10px;">
                                Quyền truy cập</td>
                        </tr>
                       
                        <tr>
                            <td align="left" colspan="4">
                               <div class="scroll_left" <%=StrHeight%>>
                                  <table cellpadding="0" cellspacing="0" width="100%" style="line-height: 20px;">
                                    <tr>
                                        <td class="vientable">
                                            <asp:DataList runat="server" Width="100%" ID="plistmain" ItemStyle-VerticalAlign="Top" RepeatColumns="4"
                                                CellPadding="3" CellSpacing="3" OnItemDataBound="plistmain_ItemDataBound" ItemStyle-Width="25%">
                                                <ItemTemplate>
                                                    <table cellpadding="3" cellspacing="3" width="100%" border=0>
                                                        <tr>
                                                            <td valign="top" style="font-weight: bold; font-size: 10pt; text-transform: capitalize">
                                                                <%#Eval("NameVi")%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                <asp:Label runat="server" ID="hidenlabelmain" Visible="false"></asp:Label>
                                                                <asp:Label runat="server" ID="hiddenlabelsub" Visible="false"></asp:Label>
                                                                <asp:CheckBoxList runat="server" ID="plistsub" RepeatColumns="1" Width="100%"  >
                                                                </asp:CheckBoxList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </td>
                                    </tr>
                                </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan=4 align="center"> 
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td align="center" style="padding-bottom:10px;padding-top:10px;">
                                            <asp:Button ID="btnAdd" runat="server" Text="Thêm Mới" OnClick="btnAdd_ckick" Width="120" CssClass="back_button main_sub" />
                                            <asp:Button CssClass="back_button main_sub" ID="pchangepass" runat="server" Width="180" Text="Thay đổi mật khẩu"
                                                Visible="false" OnClick="pchangepass_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4" style="text-align: left" valign="middle">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Lỗi xảy ra" />
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4" align="left">
                                <asp:Label runat="server" ID="p_label" CssClass="textlighttd"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel runat="server" ID="PANNELLIST" Visible="true">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="center" style="padding-top: 20px">
                                <table cellpadding="0" cellspacing="0" width="98%" class="list_table" border="0">
                                    <asp:Repeater runat="server" ID="p_list" OnItemDataBound="p_list_ItemDataBound">
                                        <HeaderTemplate>
                                            <tr class="list_title">
                                                <td width="15%">
                                                    Tên truy cập</td>
                                                <td width="30%">
                                                    Tên nhân viên</td>
                                                <td width="15%">
                                                    Nhóm</td>
                                                <td width="15%">
                                                    Trạng thái
                                                </td>
                                                <td width="15%">
                                                    Ngày tạo
                                                </td>
                                                <td width="5%"><img alt="select" src="../styles/admin/images/checkbox.jpg" /></td>
                                            </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr class="list_row">
                                                <td align="left" style="padding-left: 5px;">
                                                    <%#Eval("UserLogin")%>
                                                </td>
                                                <td align="left" style="padding-left: 5px;">
                                                    <a href="listusers.aspx?menuid=12&act=view&pid=<%#Eval("UserId")%>&n=<%=DateTime.Now.Ticks.ToString()%>">
                                                        <%#Eval("Name")%>
                                                    </a>
                                                </td>
                                                <td align="left" style="padding-left: 5px;">
                                                    <asp:Label runat="server" ID="pgroup"></asp:Label></td>
                                                <td align="center">
                                                    <asp:Label runat="server" ID="pnamestatus"></asp:Label></td>
                                                <td align="center">
                                                   <%#DataBinder.Eval(Container.DataItem, "Edate", "{0:dd/MM/yyyy HH:mm }")%>
                                                </td>
                                                <td align="center">
                                                    <input type="checkbox" name="checkbtn" value='<%#Eval("UserId")%>' /></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Label CssClass="textlighttd" runat="server" ID="p_error"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="height: 10px;">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="padding-bottom: 10px;padding-top: 10px">
                                <asp:Button ID="btnAddList" runat="server" CssClass="back_button main_sub" OnClick="btnAddList_Click"
                                    Text=" Thêm mới  " Width="120" />&nbsp;<asp:Button ID="btnDelete" runat="server" CssClass="back_button main_sub"
                                        OnClick="btnDelete_Click" Text=" Xóa "  Width="120"/></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        
    </table>
</asp:Content>
