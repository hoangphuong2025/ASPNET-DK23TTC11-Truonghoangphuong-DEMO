<%@ Page Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="status.aspx.cs" Inherits="web_portal.webadmin.status" Title="gracefashion.net" %>
<%@ Register Src="~/webadmin/webcontrol/TextFreecode.ascx" TagName="TextFreecode" TagPrefix="uc1" %>
<%@ Register TagPrefix="uc1" Namespace="web_portal.webadmin.webcontrol" Assembly="web_portal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <script type="text/javascript">
      var openFile = function (event) {
          var input = event.target;

          var reader = new FileReader();
          reader.onload = function () {
              TheFileContents = reader.result;
              TheImageContents.style.display = 'block';
              document.getElementById("TheImageContents").innerHTML = '<h5>The image that you selected</h5><p><img width="200" height="auto" src="' + TheFileContents + '" /></p>';
          };
          reader.readAsDataURL(input.files[0]);

      };

      function checkpicture() {
          var en_viItemp = document.getElementById('p_check');
          if (en_viItemp == null) {
          }
          else {
              en_viItemp.style.display = 'none';
          }
      }
    function ItemMinimize_apps(minon, maxoff)
    {
      
        openitem(minon);
        closeitem(maxoff);
        
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
 <table class="main" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="left" class="heading" style="text-transform: capitalize; padding-left: 10px;">
                <asp:Label ID="lblTitle" runat="server" Text="Danh sách trạng thái "></asp:Label></td>
        </tr>
    </table>
<asp:Panel runat="server" ID="PANNELCREATE">
<table border="0" cellpadding="1" cellspacing="2" width="100%" class="main" style="line-height: 180%">
    
    <tr align=left>
        <td style="width: 20%"><asp:Label runat="server" ID="labelhiden" Visible="false" ></asp:Label>
         
        </td>
        <td>
        </td>
    </tr>    
    <tr>
        <td style="padding-left: 10px" align="left" >
           Tên </td>
        <td>
            <asp:TextBox ID="txt_namevi"  runat="server" Width="250"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_namevi"
                                    Display="Static" ErrorMessage="nhập tên hình" Font-Italic="True" Font-Size="Small"
                                    SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </td>
            
    </tr>
      <tr>
        <td style="padding-left: 10px" align="left" >
           Name </td>
        <td>
            <asp:TextBox ID="txt_nameen"  runat="server" Width="250"></asp:TextBox>
        
            </td>
            
    </tr>
   <tr>
        <td style="padding-left: 10px" align="left" >
           thứ tự</td>
        <td>
            <asp:TextBox ID="txt_index"  runat="server" Width="300"></asp:TextBox>
         </td>
            
    </tr>
     <tr>
        <td style="padding-left: 10px" align="left" >
           Link</td>
        <td>
            <asp:TextBox ID="txt_link"  runat="server" Width="300"></asp:TextBox>
         </td>
            
    </tr>
 
     <tr>
          <td colspan=2 style="padding-left: 10px">
             <table cellpadding=0 cellspacing=0 width="100%">
                 <tr>
                    <td style="width: 20%" >
                        Hình ảnh(1000x667)</td>
                    <td>
                        <input id="File1" accept='images/*' runat="server" onchange='openFile(event);' style="width: 280px" type="file" /></td>
                </tr>
                 <tr>
                                <td style="width: 20%; ">
                                </td>
                                <td>
                                 <div id="TheImageContents" style="display:<%=Display %>" >
                                 <asp:Image runat="server" id="ImgView1"  />                     
                                  <asp:CheckBox runat="server" ID="p_check" Text ="không hiển thị hình"/>
                                     </div> 
                                    </td>
                 </tr>
                 <asp:Panel runat="server" ID="PANNELFILE" Visible="false">
                 <tr>
                   <td>Tên file </td>
                   <td><asp:Label runat="server" ID="f_filename"></asp:Label></td>
                   
                 </tr>     
                 </asp:Panel>
       </table>
        
     
       
       </td>
     </tr>
     
    <tr>       
         <td></td> 
        <td align=left style="padding-top:10px;">                                         
            <asp:Button ID="btnAdd" runat="server" Text="Thêm Mới" OnClick="btnAdd_ckick" Width="120" CssClass="back_button main_bordersub" />                                                            
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
    
   
    <tr >
        <td align="center">         
         <table  class="list_table"  cellpadding=0 cellspacing=0 width="100%">
              
         <asp:Repeater runat=server ID="p_list" OnItemDataBound="p_list_ItemDataBound">
         <HeaderTemplate>           
             <tr class="list_title">
                <td width="10%" style="padding-left:3px;">Stt</td>
                <td align="left" width="20%" style="padding-left:5px;">Mô tả</td>
                <td align="left" width="15%" style="padding-left:5px;">English</td>
                <td align="left" width="15%" style="padding-left:5px;">Hình ảnh</td>
                <td align="left" width="15%" style="padding-left:5px;">Indexs</td>
                <td width="10%" style="padding-left:5px;">Chọn</td>
              </tr>            
         </HeaderTemplate>
              <ItemTemplate>                
                  <tr class="list_row">
                    <td style="padding-left:5px;" ><%#Container.ItemIndex+1 %></td>
                    <td align="left" ><a href="status.aspx?act=view&pid=<%#Eval("Id")%>&nguid=<%=DateTime.Now.Ticks.ToString() %>"><%#Eval("NameVi")%></a></td>
                    <td align="left">
                          <%#Eval("NameEn")%>
                    </td>
                    <td align="left">
                        <img src="../resources/status<%#Eval("Picture")%>"/>
                    </td>
                    <td align="left"><%#Eval("Indexs")%></td>
                    <td align="left"><input type="checkbox" name="checkbtn" value='<%#Eval("Id")%>' /></td>
                  </tr>
               
                </ItemTemplate>               
             </asp:Repeater> 
          </table>
        </td>
    </tr>
   
    <tr>
        <td align="center" style="padding-bottom:10px;padding-top:10px;">
            <asp:Button ID="btnAddList" runat="server"  CssClass="back_button"
                 OnClick="btnAddList_Click" Text="Thêm mới" Width="80px" Visible="false" />&nbsp;<asp:Button
                    ID="btnDelete" runat="server"  CssClass="back_button"
                    OnClick="btnDelete_Click" Text="Xóa" Width="80px" Visible="false" /></td>
    </tr>
</table>

</asp:Panel>
</asp:Content>

