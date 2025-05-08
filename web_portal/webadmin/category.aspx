<%@ Page Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="category.aspx.cs" Inherits="web_portal.webadmin.category" Title=" " %>
 
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
<table class="main" cellpadding=0 cellspacing=0 width="100%">
  <tr>
   	<td align="left" class="heading" style="padding-left:10px;"><asp:Label ID="lblTitle" runat="server" Text="danh mục"></asp:Label></td>
  </tr>
</table>
<asp:Panel runat="server" ID="PANNELCREATE">
<table cellpadding="0" cellspacing="0" border="0" width="100%" class="main"> 
   <tr>
     <td align="center">
        <table cellpadding="2" cellspacing="2" width="99%" style="line-height:160%">
    <tr align="left">
        <td style="height:10px">
         <asp:Label runat="server" ID="labelhiden" Visible="false"></asp:Label>
        </td>
        <td>
        </td>
    </tr>  
      <tr>
      <td colspan="2" style="text-align: center;padding: 10px 10px 10px 10px">
       <asp:Label runat="server" ID="p_label"></asp:Label>
      </td>
    </tr>  
    <tr>
        <td align="left" >
            Nhóm sản phẩm</td>
        <td align="left">
            <asp:DropDownList runat="server" ID="plistgroup"/>
            
            </td>
    </tr> 
    <tr>
        <td align="left" width="220">
            Danh Mục sản phẩm </td>
          <td align="left">
               <asp:TextBox ID="p_namevi"  runat="server" Width="350px"></asp:TextBox>       
          
            </td>
    </tr>        
    <tr style="display: none">
        <td align="left" >
            Danh Mục cấp 2</td>
        <td align="left">
               <asp:DropDownList runat="server" ID="prootlist"></asp:DropDownList>            
             
            
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="p_namevi"
                                    Display="Static" ErrorMessage="nhập tên danh mục" Font-Italic="True" Font-Size="Small"
                                    SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
    </tr>        
    <tr style="display: none"  >
        <td align="left" width="90">
            English </td>
        <td align="left">
            <asp:TextBox ID="p_nameen"  runat="server" Width="350px"></asp:TextBox>
            
            </td>
    </tr>    
   <tr>
        <td align="left" width="90">
           Danh mục Active(Trang chủ)</td>
        <td align="left">
            <asp:DropDownList runat="server">
                <asp:ListItem Text="hiển thị" Value="1"></asp:ListItem>
                <asp:ListItem Text="không hiển thị" Value="0"></asp:ListItem>
            </asp:DropDownList>
            
            </td>
    </tr>  
     <tr>
        <td align="left" width="90">
            Thứ tự </td>
        <td align="left">
            <asp:TextBox ID="p_index"  runat="server" Width="250px"></asp:TextBox>
            
            </td>
    </tr>  
    <tr >
        <td >
            Hình ảnh (width:500)</td>
      <td >          
          <table cellpadding=0 cellspacing=0 width="100%">
                 <tr>
                    
                    <td align="left">
                        <input id="File1" runat="server" onchange='openFile(event);'
                            type="file" /></td>
                </tr>
                 <tr>
                                
                    <td style="padding-top: 3px;">
                        <div  id="TheImageContents" style="display:<%=Display %>">
                            <asp:Image Width="400" runat="server" id="ImgView1"  />   <br/>                  
                        <asp:CheckBox runat="server" ID="p_check" Text ="không hiển thị hình"/>
                            </div> 
                      </td>
                 </tr>
                 <asp:Panel runat="server" ID="PANNELFILE" Visible="false">
                 <tr>
                   
                   <td>Tên file&nbsp;:&nbsp;<asp:Label runat="server" ID="f_filename"></asp:Label></td>
                   
                 </tr>     
                 </asp:Panel>
       </table>       
       </td>
     </tr>
    <tr>       
       <td></td>
        <td align="left">            
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" align="left">
                <tr>
                    <td>                        
                        <asp:Button ID="btnAdd" runat="server" Text=" Tạo mới " Width="120" OnClick="btnAdd_ckick" CssClass="back_button main_sub" />                                           
                        </td>
                </tr>
            </table>
        </td>
        
    </tr>
    
</table>
     </td>
   </tr>  
   </table>  
</asp:Panel>
<asp:Panel runat="server" ID="PANNELLIST">
<table border="0" cellpadding="0" cellspacing="0" width="100%" class="main">
    <tr>
        <td height="20"></td>
    </tr>
    <tr>
        <td align="center">         
         <table cellpadding=0 cellspacing=0 width="98%" class="list_table">
         <asp:Repeater runat=server ID="p_list" OnItemDataBound="p_list_ItemDataBound">
         <HeaderTemplate>           
             <tr class="list_title" style="text-align: center">
                <td >#</td>
                <td width="20%">Danh mục</td>  
                <td width="30%">English</td>  
                <td width="30%">Product Group</td>  
                <td >Thứ tự</td>  
                <td >
                    <img src="../Styles/images/checkbox.jpg" alt="remove"/>
                </td>
              </tr>            
         </HeaderTemplate>
              <ItemTemplate>                
                  <tr class="list_row" >
                    <td align="center">
                        <%#Container.ItemIndex+1 %>
                    </td>
                    <td align="left"  style="padding-left:5px;">
                        <a href="category.aspx?act=view&pid=<%#Eval("CategoryId")%>&nguid=<%=DateTime.Now.Ticks.ToString()%>">
                          <%#Eval("NameVi")%>
                        </a>
                    </td> 
                   <td align="left"  style="padding-left:5px;"><%#Eval("NameEn")%></td> 
                    <td align="left"  style="padding-left:5px;"><asp:Label runat="server" ID="labelgroupname"></asp:Label></td> 
                    <td style="padding-left:5px;text-align: center"><%#Eval("Indexs")%></td>                             
                    <td style="text-align: center" >
                        <input type="checkbox" name="checkbtn" value='<%#Eval("CategoryId")%>' />
                    </td>
                    
                  </tr>
                </ItemTemplate>      
             </asp:Repeater> 
          </table>
        </td>
    </tr>
  
    <tr>
     <td height="10">
     </td>
    </tr>
    <tr>
        <td align="center">
            <asp:Button ID="btnAddList" runat="server"  CssClass="back_button main_sub" Width="180" OnClick="btnAddList_Click" Text=" Thêm mới"  Visible="true" />&nbsp;
            <asp:Button ID="btnDelete" runat="server"  CssClass="back_button main_sub" Width="180" OnClick="btnDelete_Click" Text=" Xóa " /></td>
    </tr>
    <tr>
        <td height="20"></td>
    </tr>
</table>
</asp:Panel>
</asp:Content>
