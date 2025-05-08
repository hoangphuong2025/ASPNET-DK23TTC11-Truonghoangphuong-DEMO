<%@ Page Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="intro.aspx.cs" Inherits="web_portal.webadmin.intro" Title="Untitled Page" %>
<%@ Register Src="~/webadmin/webcontrol/TextFreecode.ascx" TagName="TextFreecode" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<script>
    function ItemMinimize_apps(names) {
        if (names == 1) {
            openitem(1);
            closeitem(2);

        }
        if (names == 2) {
            openitem(2);
            closeitem(1);

        }
        
    }

    function openitem(name) {

        var MItem = document.getElementById('COL_'.concat(name));
        if (MItem == null) {

        }
        else {
            MItem.style.display = 'block';
            var MItem1 = document.getElementById('ok'.concat(name));
            if (MItem1 == null) {
            }
            else {
                MItem1.className = 'selectitem';
            }

        }

    }
    function closeitem(name) {

        var MItem = document.getElementById('COL_'.concat(name));
        if (MItem == null) {

        }
        else {
            MItem.style.display = 'none';
            var MItem1 = document.getElementById('ok'.concat(name));
            if (MItem1 == null) {
            }
            else {
                MItem1.className = 'none_selectitem';
            }

        }
    }
</script>


<table cellpadding=0 cellspacing=0 width="100%" border=0 class="main">
  <tr>
        <td class="heading" style="padding-left:10px;">         
            <asp:Label ID="lblTitle" runat="server" Text ="Danh sách giới thiệu" ></asp:Label>
        </td>
 </tr>

</table>

<asp:Panel runat="server" ID="PANNELCREATE">
<table border="0" cellpadding="1" cellspacing="2" width="100%" class="main">
   <tr> 
     <td align="center">
       <table border="0" cellpadding="1" cellspacing="2" width="99%" >
                    <tr>
                        <td></td>
                         <td style="padding-bottom:10px;padding-top:10px;">
                           <asp:Label runat="server" ID="p_label" CssClass="textlighttd"></asp:Label>
                         </td>      
                        <asp:Label runat="server" ID="labelhiden" Visible="false"></asp:Label>
                    </tr>    
                    <tr>
                        <td align="left">
                            Tiêu đề </td>
                        <td>
                            <asp:TextBox ID="p_title" runat="server" Width="300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="p_title"
                                                    Display="Static" ErrorMessage="nhập tiêu đề" Font-Italic="True" Font-Size="Small"
                                                    SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </td>
                            
                    </tr>             
                    <tr >
                        <td align="left">
                            Title Name</td>
                        <td>
                            <asp:TextBox ID="ptitle_en"  runat="server" Width="300px"></asp:TextBox>
                           
                            </td>
                            
                    </tr> 
                     <tr style="display:none">
                        <td align="left">
                            Title chinese</td>
                        <td>
                            <asp:TextBox ID="ptitle_chi"  runat="server" Width="300px"></asp:TextBox>
                           
                            </td>
                            
                    </tr> 
                    <tr>
                        <td align="left">
                            Thứ tự xuất hiện</td>
                        <td>
                            <asp:TextBox ID="p_index"  runat="server" Width="100px"></asp:TextBox>
                           
                            </td>
                            
                    </tr> 
                     <tr>
                        <td align="left">
                           Danh mục giới thiệu</td>
                        <td>
                            <asp:DropDownList runat="server" ID="pkindof">
                             <asp:ListItem Text="giới thiệu" Value="1"></asp:ListItem>
                         <%--    <asp:ListItem Text="chứng nhận chất lượng" Value="2"></asp:ListItem>
                             <asp:ListItem Text="Hỗ trợ" Value="3"></asp:ListItem>--%>
                            </asp:DropDownList>
                        </td>            
                    </tr>     
                    <tr>
                        <td align="left">
                            Trạng thái</td>
                        <td>
                            <asp:DropDownList runat="server" ID="p_status">
                             <asp:ListItem Text="Không hiển thị" Value="0"></asp:ListItem>
                             <asp:ListItem Text="hiển thị" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>            
                    </tr> 
                    <tr>
                         <td  colspan=2 align="left" style="padding-top:20px;">
                             <table cellpadding=0 cellspacing=0 border=0 style="text-align:left" width="100%">
             <tr>
                <td  width="200" style="padding-bottom:10px;padding-top:10px;padding-left:10px;"><span style="height:35px;padding-bottom:10px;padding-top:10px;cursor:pointer" id="Span1" class="selectitem">
                       &nbsp;&nbsp;Mô tả ngắn&nbsp;&nbsp; </span><span style="color:#555555">|</span>
                 <span id="Span2" style="height:35px;padding-bottom:10px;padding-top:10px;cursor:pointer;display: none"   onclick="javascript:ItemMinimize_apps('2');">
                       &nbsp;&nbsp;Description&nbsp;&nbsp;</span>
                  <span id="Span3"  style="display:none;height:35px;padding-bottom:10px;padding-top:10px;cursor:pointer;display: none"  onclick="javascript:ItemMinimize_apps('3');">
                 &nbsp;&nbsp;Description chinese&nbsp;&nbsp;</span></td>       
             </tr>
            <tr>
               <td  align="center">
                <div id="Div1" style="display:block">
                 <table cellpadding=0 cellspacing=0 width="100%">
                    <tr>
                                  <td align="left">
                        <uc1:TextFreecode id="TextFreecode3" runat="server">
                        </uc1:TextFreecode>            
                        </td>
                    </tr>
                 </table>
                 </div>
                
                
               </td>
             </tr>
          </table>
                        </td>
                    </tr>                   
                    <tr>
        <td  colspan=2 align="left" style="padding-top:20px;">
          <table cellpadding=0 cellspacing=0 border=0 style="text-align:left" width="100%">
             <tr>
                <td  width="200" style="padding-bottom:10px;padding-top:10px;padding-left:10px;"><span style="height:35px;padding-bottom:10px;padding-top:10px;cursor:pointer" id="ok1" class="selectitem"  onclick="javascript:ItemMinimize_apps('1');">
                       &nbsp;&nbsp;Mô tả chi tiết&nbsp;&nbsp; </span><span style="color:#555555">|</span>
                 <span id="ok2" style="height:35px;padding-bottom:10px;padding-top:10px;cursor:pointer;"   onclick="javascript:ItemMinimize_apps('2');">
                       &nbsp;&nbsp;Description&nbsp;&nbsp;</span>
                  <span id="ok3"  style="display:none;height:35px;padding-bottom:10px;padding-top:10px;cursor:pointer"  onclick="javascript:ItemMinimize_apps('3');">
                 &nbsp;&nbsp;Description chinese&nbsp;&nbsp;</span></td>       
             </tr>
             <tr>
               <td style="height:5px;"></td>
             </tr>
             <tr>
               <td  align="center">
                <div id="COL_1" style="display:block">
                 <table cellpadding=0 cellspacing=0 width="100%">
                    <tr>
                                  <td align="left">
                        <uc1:TextFreecode id="TextFreecode1" runat="server">
                        </uc1:TextFreecode>            
                        </td>
                    </tr>
                 </table>
                 </div>
                 <div id="COL_2" style="display:none">
                 <table cellpadding=0 cellspacing=0 width="100%">
                    <tr>
                                  <td align="left">
                        <uc1:TextFreecode id="TextFreecode2" runat="server">
                        </uc1:TextFreecode>            
                        </td>
                    </tr>
                 </table>
                 </div>
                
               </td>
             </tr>
          </table>
        </td>
    </tr>         
                    <tr>        
                        <td colspan="2" align="center" style="padding-bottom:10px;padding-top:10px;">            
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                <tr>
                                    <td align="center">                      
                                        <asp:Button ID="btnAdd" runat="server" Text=" Đồng ý" Width="120" CssClass="back_button main_sub" OnClick="btnAdd_Click" />                                           
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
   
   </table>
   </td>
  </tr>
</table>   

</asp:Panel>
<asp:Panel runat="server" ID="PANNELLIST" Visible="false">
<table border="0" cellpadding="0" cellspacing="0" style="width: 100%" class="main">
    
    <tr>
        <td align="center" style="padding-top:10px;padding-bottom:10px;">         
        <table  align="center" cellpadding="0" cellspacing="0" width="99%" class="list_table">
            <asp:Repeater runat="server" ID="p_list" OnItemDataBound ="p_list_ItemDataBound">
         <HeaderTemplate>            
              <tr class="list_title">
                <td  style="padding-left:3px;">#</td>
                <td  width="50%" style="padding-left:5px;text-align: center">Tiêu đề</td>
                <td  width="20%" style="padding-left:5px;text-align: center">Trạng thái</td>
                <td  width="15%" style="text-align: center;padding-left:5px;">Danh mục</td>
                <td  style="text-align: center">thứ tự</td>
                <td style="text-align: center">
                    <img src="../styles/admin/images/checkbox.jpg" />
                </td>
              </tr>
            
         </HeaderTemplate>
              <ItemTemplate>                
                  <tr class="list_row" height="30">
                    <td  align="center" style="padding-left:2px;" ><a href="intro.aspx?menuid=4&act=view&pid=<%#Eval("IntroId")%>&nguid=<%=DateTime.Now.Ticks.ToString()%>"><%#Eval("IntroId")%></a></td>
                    <td  align="left" style="padding-left:10px;" ><a href="intro.aspx?menuid=4&act=view&pid=<%#Eval("IntroId")%>&nguid=<%=DateTime.Now.Ticks.ToString()%>"><%#Eval("TitleVi")%></a></td>
                  
                    <td  style="text-align: center"><asp:Label runat="server" ID="p_statusname"></asp:Label></td>  
                    <td  style="text-align: center" ><asp:Label runat="server" ID="labelcategory"></asp:Label></td>  
                    <td  style="text-align: center" ><%#Eval("Indexs")%></td>  
                    <td style="text-align: center"><input type="checkbox" name="checkbtn" value='<%#Eval("IntroId")%>' /></td>
                  </tr>               
                </ItemTemplate>    
                       
             </asp:Repeater> 
          </table>
        </td>
    </tr>
   
    <tr>
      <td align="center"><asp:Label CssClass="textlighttd" runat="server" ID="p_error"></asp:Label></td>
    </tr>     
    <tr>
     <td height="10">
     </td>
    </tr>   
    <tr>
        <td align="center" style="padding-bottom:10px;padding-top:10px;">
            <asp:Button ID="btnAddList" runat="server"  CssClass="back_button main_sub"
                  Text="Thêm mới" Width="120" OnClick="btnAddList_Click" />&nbsp;<asp:Button
                    ID="btnDelete" runat="server"  CssClass="back_button main_sub"
                     Text="Xóa" Width="120" OnClick="btnDelete_Click" /></td>
    </tr>
</table>

</asp:Panel>
</asp:Content>
