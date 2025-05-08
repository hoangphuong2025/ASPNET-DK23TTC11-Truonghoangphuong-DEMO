<%@ Page Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="servicesprovider.aspx.cs" Inherits="web_portal.webadmin.servicesprovider" Title=" " %>

<%@ Import namespace="System.Collections.Generic"%>
<%@ Register Src="~/webadmin/webcontrol/TextFreecode.ascx" TagName="TextFreecode" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript">

    var openFile = function (event) {
        var input = event.target;

        var reader = new FileReader();
        reader.onload = function () {
            TheFileContents = reader.result;
            TheImageContents.style.display = 'block';
            document.getElementById("TheImageContents").innerHTML = '<h5>The image that you selected</h5><p><img width="100" height="auto" src="' + TheFileContents + '" /></p>';
        };
        reader.readAsDataURL(input.files[0]);

    };
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
<script>

function ItemMinimize_apps(names)
 {   
   if(names==1)
   {
      openitem(1);
      closeitem(2);
      
   }
  if(names==2)
   {
      openitem(2);
      closeitem(1);
      
   }
 
}

function openitem(name)
{
   
   var MItem=document.getElementById('COL_'.concat(name));
   if(MItem==null)
   {
    
   }
   else
   {
       MItem.style.display='block';
       var MItem1=document.getElementById('ok'.concat(name));
       if(MItem1==null)
       {
       }
       else
       {
         MItem1.className ='selectitem';
       }       
    }
}
function closeitem(name)
{
   
   var MItem=document.getElementById('COL_'.concat(name));
   if(MItem==null)
   {
  
   }
   else
   {
       MItem.style.display='none';
       var MItem1=document.getElementById('ok'.concat(name));
       if(MItem1==null)
       {
       }
       else
       {
         MItem1.className ='none_selectitem';
       }       
      
    }
}
</script>
 
<table cellpadding=0 cellspacing=0 width="100%" border=0>
  
      <tr>
            <td align="left" class="heading" style="text-transform: uppercase; padding-left: 10px;">
                <asp:Label ID="lblTitle" runat="server" Text="Danh Sách nhà cung cấp"></asp:Label></td>
        </tr>
</table>
<asp:Panel runat="server" ID="PANNELCREATE" Visible="false">
<table border="0" cellpadding="0" cellspacing="0" width="100%"  class="main">
   <tr> 
     <td align="center" style="padding-left:10px;">
        <table border="0" cellpadding="0" cellspacing="0" width="99%" style="text-align:left;line-height:180%;">
     <tr>
        <td colspan=2><asp:Label runat="server" ID="labelhidden" Visible=false></asp:Label></td>
     </tr>
    <tr>
        <td width="150" style="padding-top:10px;padding-bottom:10px;">
            Tên Người đại diện</td>
        <td>
            <asp:TextBox ID="p_name_vi"  runat="server" Width="200px"></asp:TextBox>
           
            </td>      
           <td >
            Customer Name</td>
        <td >
            <asp:TextBox ID="p_name_en"  runat="server" Width="200px"></asp:TextBox>            
            </td>          
    </tr> 
    
    <tr>
        <td  >
            Tên công ty</td>
        <td>
            <asp:TextBox ID="p_company_vi"  runat="server" Width="200px"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="p_company_vi"
                                    Display="Static" ErrorMessage="nhập tên công ty" Font-Italic="True" Font-Size="Small"
                                    SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </td>
            
    
        <td  style="display: none" >
            Company Name</td>
        <td style="display: none">
            <asp:TextBox ID="p_company_en"  runat="server" Width="200px"></asp:TextBox>
        
            </td>
            
    </tr> 
    <tr>
        <td>
            Mã Công ty</td>
        <td>
            <asp:TextBox ID="p_workpermit"  runat="server" Width="200px"></asp:TextBox>
            
            </td>
         <td >
           Số điện thoại </td>
        <td>
            <asp:TextBox runat="server" style="width: 200px" ID="p_tel"></asp:TextBox>
            </td>
    </tr>    
    <tr>
        <td >
           Địa chỉ</td>
        <td>
              <asp:TextBox ID="p_address_vi" TextMode="MultiLine" Rows="4"  runat="server" Width="200px"></asp:TextBox>
            </td>
            
   
        <td style="display: none" >
           Address</td>
        <td style="display: none">
              <asp:TextBox ID="p_address_en"  TextMode="MultiLine" Rows="4" runat="server" Width="200px"></asp:TextBox>
            </td>
            
    </tr>  
                             
    
    <tr>
        <td >
           Website</td>
        <td>
            <asp:TextBox runat="server" style="width: 200px" ID="p_website"></asp:TextBox>
            </td>
            
    
        <td >
           Email</td>
        <td>
            <asp:TextBox runat="server" style="width: 200px" ID="p_email"></asp:TextBox>
            </td>
            
    </tr>       
     <tr>
        <td >
           Thứ tự xuất hiện</td>
        <td>
            <asp:TextBox runat="server" style="width: 70px" ID="p_indexs"></asp:TextBox>
            </td>
           <td colspan=2></td> 
    </tr>   
    <tr>
     <td >
          Hình ảnh(min :149x36)</td>
      <td align="left" colspan=3>          
          <table cellpadding=0 cellspacing=0 width="100%">
               
                 <tr>
                 
                    <td align="left">
                        <input accept='images/*' id="File1" runat="server" onchange='openFile(event);'
                            type="file" /></td>
                      <td> </td>        
                </tr>
                 <tr>
                            
                                <td>
                                 <div id="TheImageContents" style="display:<%=Display %>">
                                 <asp:Image runat="server" id="ImgView1" Width="100" Height="70" />                     
                                  <asp:CheckBox runat="server" ID="p_check" Text ="không hiển thị hình"/>
                                     </div> 
                                    </td>
                                     <td> </td> 
                 </tr>
                 <asp:Panel runat="server" ID="PANNELFILE" Visible="false">
                 <tr>
                   
                   <td>Tên file: <asp:Label runat="server" ID="f_filename"></asp:Label></td>
                   <td> </td>
                 </tr>     
                 </asp:Panel>
       </table>       
       </td>
     </tr>          
      <tr>
        <td  colspan=4 align="left" style="padding-top:20px;">
          <table cellpadding=0 cellspacing=0 border=0 style="text-align:left" width="100%">
             <tr>
                <td  width="200" style="padding-bottom:10px;padding-top:10px;padding-left:10px;"><span style="height:35px;padding-bottom:10px;padding-top:10px;cursor:pointer" id="ok1" class="selectitem"  onclick="javascript:ItemMinimize_apps('1');">
                       &nbsp;&nbsp;Mô tả ngắn&nbsp;&nbsp; </span><span style="color:#555555">|</span>
                 <span id="ok2" style="height:35px;padding-bottom:10px;padding-top:10px;cursor:pointer;display: none"   onclick="javascript:ItemMinimize_apps('2');">
                       &nbsp;&nbsp;Mô tả ngắn gọn tiếng Anh &nbsp;&nbsp;</span>
                 </td>       
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
                <td align="center" colspan="4" style="text-align: left" valign="middle">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Lỗi xảy ra:" />
                    &nbsp;</td>
     </tr>
    <tr>
      <td colspan=4>
       <asp:Label runat="server" ID="p_label" CssClass="textlighttd"></asp:Label>
      </td>      
    </tr>
    <tr>
       <td></td>
       <td style="padding-bottom:5px;padding-top:5px;">
           <asp:Button runat="server" OnClick="btnAdd_ckick" ID="btnAdd" Text="Tạo mới" CssClass="back_button main_sub" Width="180"  />
       </td>
         <td colspan=2></td>
    </tr>
   </table>
     
    </td>
   </tr>
 </table>     
</asp:Panel>
<asp:Panel runat="server" ID="PANNELLIST" Visible=true>
<table border="0" cellpadding="0" cellspacing="0" style="width: 100%" class="main">
   
    <tr>
        <td  align="center">         
        <table cellpadding="0" cellspacing="0" width="99%" class="list_table" 
				        border="0">
         <asp:Repeater runat="server" ID="p_list">
         <HeaderTemplate>            
              <tr  class="list_title">
                <td  align="left" width="5%" style="text-align: center">#</td>
                
                <td  align="center" width="25%" style="padding-left:5px;">Tên công ty</td>  
                <td  align="center" width="20%" style="padding-left:5px;">Địa chỉ</td>
               
                <td  align="left" width="8%" style="padding-left:5px;">Thứ tự</td> 
                <td  align="center" width="5%" style="text-align: center">
                    <img src="../Styles/images/checkbox.jpg"/>
                </td>
              </tr>            
         </HeaderTemplate>
              <ItemTemplate>                
                  <tr class="list_row" height="30">
                    <td  align="center" style="padding-left:2px;"><%#Container.ItemIndex+1 %></td>
                    <td  align="left" style="padding-left:5px;"><a href="servicesprovider.aspx?act=view&pid=<%#Eval("ServiceProviderId")%>"><%#Eval("CompanyNameVi")%></a></td>                  
                    <td  align="left" style="padding-left:2px;"><%#Eval("AddressVi")%></td>                     
                   
                    <td  align="center" style="padding-left:2px;"><%#Eval("Indexs")%></td>                     
                    <td  align="center" >
                         <input type="checkbox" name="checkbtn" value='<%#Eval("ServiceProviderId")%>' />
                    </td>
                  </tr>               
                </ItemTemplate>    
             </asp:Repeater> 
          </table>
        </td>
    </tr>   
    <tr>
      <td align=center><asp:Label CssClass="textlighttd" runat="server" ID="p_error"></asp:Label></td>
    </tr>     
    <tr>
        <td align="center" style="padding-bottom:5px;padding-top:5px;">
            <asp:Button ID="btnAddList" runat="server"  CssClass="back_button main_sub"
                 OnClick="btnAddList_Click" Text="Thêm mới" Width="180px" />&nbsp;<asp:Button
                    ID="btnDelete" runat="server"  CssClass="back_button main_sub"
                    OnClick="btnDelete_Click" Text="Xóa" Width="180px" /></td>
    </tr>
</table>

</asp:Panel>
</asp:Content>
