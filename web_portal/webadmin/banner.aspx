<%@ Page Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="banner.aspx.cs" Inherits="web_portal.webadmin.banner" Title="gracefashion.net" %>
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
    
</script>
 <table class="main" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="left" class="heading" style="padding-left: 10px;">
                <asp:Label ID="lblTitle" runat="server" Text="Danh sách hình banner "></asp:Label></td>
        </tr>
    </table>
<asp:Panel runat="server" ID="PANNELCREATE">
    <table border="0" cellpadding="1" cellspacing="2" width="100%" class="main" >
       <tr>
         <td style="text-align: center">
          <table border="0" cellpadding="1" cellspacing="2" width="99%" style="line-height: 180%">
    
    <tr align=left>
        <td style="width: 20%"><asp:Label runat="server" ID="labelhiden" Visible="false" ></asp:Label>
         
        </td>
        <td>
        </td>
    </tr>    
    <tr>
        <td style="padding-left: 10px" align="left" >
           Tên hình</td>
        <td>
            <asp:TextBox ID="txt_namevi"  runat="server" Width="250"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_namevi"
                                    Display="Static" ErrorMessage="nhập tên hình" Font-Italic="True" Font-Size="Small"
                                    SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </td>
            
    </tr>
   <tr>
        <td style="padding-left: 10px" align="left" >
           Picture Name</td>
        <td>
            <asp:TextBox ID="txt_nameen"  runat="server" Width="300"></asp:TextBox>
         </td>
            
    </tr>
   <tr>
        <td style="padding-left: 10px" align="left" >
           Dòng mô tả </td>
        <td>
            <asp:TextBox ID="txt_desvi" TextMode="MultiLine" Rows="5"  runat="server" Width="300"></asp:TextBox>
            
            </td>
            
    </tr>
    <tr style="display: none">
        <td style="padding-left: 10px" align="left" >
          Description </td>
        <td>
            <asp:TextBox ID="txt_desen" TextMode="MultiLine" Rows="5"  runat="server" Width="300"></asp:TextBox>
            
            </td>
            
    </tr>
     <tr>
        <td style="padding-left: 10px" align="left" >
          Link picture</td>
        <td>
            <asp:TextBox ID="txt_url"  runat="server" Width="200"></asp:TextBox>
            
            </td>
            
    </tr>
     <tr>
        <td style="padding-left: 10px" align="left" >
          Indexs</td>
        <td>
            <asp:TextBox ID="txt_index"  runat="server" Width="100"></asp:TextBox>
            
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
                                 <asp:Image runat="server" id="ImgView1" Width="120" Height="120" />                     
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
            <asp:Button ID="btnAdd" runat="server" Text="Thêm Mới" OnClick="btnAdd_ckick" Width="120" CssClass="back_button main_sub" />  
            <asp:Button ID="btnAddMore" Visible="False" runat="server" Text="Thêm hình" OnClick="btnAddMore_ckick" Width="120" CssClass="back_button main_sub" />                                                                        
        </td>        
    </tr>
     <tr>
                <td align="center" colspan="2" style="text-align: left" valign="middle">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Lỗi xảy ra:" />
                    &nbsp;</td>
            </tr>
    <tr>
      <td colspan="2" style="padding-left: 20px;">
       <asp:Label runat="server" ID="p_label"></asp:Label>
      </td>
    </tr>
</table>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel runat="server" ID="PANNELLIST">
<table border="0" cellpadding="0" cellspacing="0" style="width: 100%" class="main">
    
   
    <tr>
        <td align="center" style="padding-top: 20px">         
         <table  class="list_table"  cellpadding=0 cellspacing=0 width="98%">
         <asp:Repeater runat="server" ID="p_list" OnItemDataBound="p_list_ItemDataBound">
         <HeaderTemplate>           
             <tr class="list_title">
                <td width="5%" style="padding-left:3px;">Stt</td>
                <td align="left" width="40%" style="padding-left:5px;">Mô tả</td>
                 <td align="left" width="35%" style="padding-left:5px;">Hình ảnh</td>
                <td align="left" style="padding-left:5px;">Indexs</td>
                <td style="text-align: center">
                       <img src="../Styles/images/checkbox.jpg" alt="remove"/>
                </td>
              </tr>            
         </HeaderTemplate>
              <ItemTemplate>                
                  <tr class="list_row">
                    <td style="padding-left:5px;text-align: center" ><%#Container.ItemIndex+1 %></td>
                    <td align="left" ><a href="banner.aspx?act=view&pid=<%#Eval("Id")%>&nguid=<%=DateTime.Now.Ticks.ToString() %>"><%#Eval("NameVi")%></a></td>
                   
                    <td align="left">
                       <a href="../resources/slides/<%#Eval("Picture")%>" target="_blank"> <img width="200" src="../resources/slides/<%#Eval("Picture")%>"/>
                       </a>
                    </td>
                    <td align="left"><%#Eval("Indexs")%></td>
                    <td align="left">
                        <input type="checkbox" name="checkbtn" value='<%#Eval("Id")%>' />
                    </td>
                  </tr>
               
                </ItemTemplate>               
             </asp:Repeater> 
          </table>
        </td>
    </tr>
   
    <tr>
        <td align="center" style="padding-bottom:10px;padding-top:10px;">
            <asp:Button ID="btnAddList" runat="server"  CssClass="back_button main_sub"
                 OnClick="btnAddList_Click" Text="Thêm mới" Width="120" Visible="true" />&nbsp;<asp:Button
                    ID="btnDelete" runat="server"  CssClass="back_button main_sub"
                    OnClick="btnDelete_Click" Text="Xóa" Width="120" /></td>
    </tr>
</table>
</asp:Panel>
 <asp:Panel runat="server" ID="PANELPIC" Visible="False">
     <table class="main" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td align="left" class="heading" style="text-transform: capitalize; padding-left: 10px;">
                                <asp:Label ID="Label2" runat="server" Text="Thêm hình của Banner"></asp:Label></td>
                        </tr>
                    </table>
     <table width="100%"  class="list_table">
                    <tr class="list_title">
                        <td style="width: 10%">BannerId</td>
                        <td style="width: 25%">Tiêu đề</td>
                        <td style="width: 60%">Hình</td>
                        <td width="5%"><img alt="select" src="../styles/admin/images/checkbox.jpg" /></td>
                    </tr>
                    <asp:Repeater runat="server" ID="plistpic" OnItemDataBound="plistpic_ItemDataBound">
                      <ItemTemplate>
                        <tr class="list_row">
                            <td><%#Eval("BannerId")%></td>
                              <td><%#Eval("Namevi")%></td>
                            <td>
                                <asp:Panel runat="server" ID="paneimg" Visible="false">
                                   <img src='../resources/slides/<%#Eval("Picture")%>' />    
                                </asp:Panel>
                              
                            </td>
                           
                            <td style="text-align: center"><input type="checkbox" name="checkbtnpic" value='<%#Eval("Id")%>' /></td>
                        </tr>
                    </ItemTemplate>
                    </asp:Repeater>
                    <tr>
                        <td colspan="5" align="center" style="padding-bottom: 10px;padding-top: 10px">
                        <asp:Button runat="server" ID="btndelepic" CssClass="back_button main_sub" Width="120" Text="Xóa hình" OnClick="btndelepic_Click"/>
                        </td>
                    </tr>
                 </table>
                 <table width="100%" style="line-height: 25px;">
                    <tr>
                        <td align="left" style="width: 15%">Tiêu đề</td>
                         <td align="left">
                             <asp:TextBox runat="server" ID="txtsub_namevi" TextMode="MultiLine" Rows="3" Columns="40"></asp:TextBox>
                         </td>
                        
                    </tr>
                    <tr>
                        <td align="left" >Title English</td>
                         <td align="left">
                             <asp:TextBox runat="server" ID="txtsub_nameen" TextMode="MultiLine" Rows="3" Columns="40"></asp:TextBox>
                         </td>
                        
                    </tr>
                       <tr>
                        <td align="left" >Thứ tự</td>
                         <td align="left">
                             <asp:TextBox runat="server" ID="txtsub_index"></asp:TextBox>
                         </td>
                        
                    </tr>
                    <tr>
                        <td align="left" >Chọn hình để upload</td>
                         <td align="left"><input id="File2" runat="server" style="width: 280px" type="file" /></td>
                        
                    </tr>
                    <tr>
                        <td></td>
                        <td align="left">
                            <asp:Button runat="server" ID="btnupload" CssClass="back_button main_sub" Text="Upload Picture" OnClick="btnupload_Click"/>
                            <asp:Button runat="server" ID="btnreturn" CssClass="back_button main_sub" Text="Quay lại Slides" OnClick="btnreturn_Click"/>
                        </td>
                    </tr>
                </table>
 </asp:Panel>
          
</asp:Content>

