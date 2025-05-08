<%@ Page Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="website.aspx.cs" Inherits="web_portal.webadmin.website" Title="" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <table class="main" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="left" class="heading" style="padding-left: 10px;">
                <asp:Label ID="lblTitle" runat="server" Text="Danh mục tin"></asp:Label></td>
        </tr>
    </table>
<asp:Panel runat="server" ID="PANNELCREATE">
<table border="0" cellpadding="1" cellspacing="2" width="100%" class="main">
    
    <tr>
        <td colspan="2" style="padding-top: 20px"><asp:Label runat="server" ID="labelhiden" Visible="false" ></asp:Label>
         
        </td>
      
    </tr> 
       <tr>
      <td colspan="2" style="padding-left: 10px;padding-bottom: 10px;padding-top: 10px ;text-align: center">
       <asp:Label runat="server" ID="p_label"></asp:Label>
      </td>
    </tr>
     <tr>
        <td align="left" style="width: 230px;padding-left: 10px" >
               Tiêu đề website(65 kí tự)</td>
        <td align="left">
            <asp:TextBox ID="ptitle" TextMode="MultiLine"  Rows="2" runat="server" Width="430px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ptitle"
                                    Display="Static" ErrorMessage="nhập tiêu đề website" Font-Italic="True" Font-Size="Small"
                                    SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </td>
            
    </tr>     
      <tr >
        <td align="left" style="width: 230px;padding-left: 10px" >
               Title website(65 kí tự)</td>
        <td align="left">
            <asp:TextBox ID="ptitle_en" TextMode="MultiLine"  Rows="2" runat="server" Width="430px"></asp:TextBox>
          
            </td>
            
    </tr>     
    <tr>
        <td align="left" style="padding-left: 10px">
            Từ khóa website(không giới hạn)</td>
        <td>
            <asp:TextBox ID="p_name" TextMode="MultiLine"  Rows="3" runat="server" Width="430px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="p_name"
                                    Display="Static" ErrorMessage="nhập từ khóa website" Font-Italic="True" Font-Size="Small"
                                    SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </td>
            
    </tr>  
    <tr >
        <td align="left" style="padding-left: 10px">
            KeyWord website(không giới hạn)</td>
        <td>
            <asp:TextBox ID="p_nameen" TextMode="MultiLine"  Rows="3" runat="server" Width="430px"></asp:TextBox>
           
            </td>
            
    </tr>  
     <tr>
        <td align="left" style="padding-left: 10px" >
            Mô tả website(120- 156 kí tự)</td>
        <td>
            <asp:TextBox ID="p_des" TextMode="MultiLine" Rows="3"  runat="server" Width="430px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="p_des"
                                    Display="Static" ErrorMessage="nhập Mô tả website" Font-Italic="True" Font-Size="Small"
                                    SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </td>
            
    </tr>  
      
         <tr>
        <td align="left" style="padding-left: 10px" >
            Description website(120- 156 chars)</td>
        <td>
            <asp:TextBox ID="p_desen" TextMode="MultiLine" Rows="3"  runat="server" Width="430px"></asp:TextBox>
          
            </td>
            
    </tr>  
     <tr>
        <td align="left" style="padding-left: 10px" >
            Website name</td>
        <td>
            <asp:TextBox ID="p_website"   runat="server" Width="430px"></asp:TextBox>
          
            </td>
            
    </tr>  
    <tr>
        <td align="left" style="padding-left: 10px" >
           PostCode</td>
        <td>
            <asp:TextBox ID="p_postcode"   runat="server" Width="430px"></asp:TextBox>
          
            </td>
            
    </tr>  
    <tr>
        <td align="left" style="padding-left: 10px" >
           PostCode Name</td>
        <td>
            <asp:TextBox ID="p_postcodename"   runat="server" Width="430px"></asp:TextBox>
          
            </td>
            
    </tr> 
     <tr>
        <td align="left" style="padding-left: 10px" >
           Address Locality</td>
        <td>
            <asp:TextBox ID="p_addressLocality"  TextMode="MultiLine" Rows="3"  runat="server" Width="430px"></asp:TextBox>
          
            </td>
            
    </tr>  
     <tr>
        <td align="left" style="padding-left: 10px" >
           AddressCountry</td>
        <td>
            <asp:TextBox ID="p_addressCountry"  TextMode="MultiLine" Rows="3"  runat="server" Width="430px"></asp:TextBox>
          
            </td>
            
    </tr>  
     <tr>
        <td align="left" style="padding-left: 10px" >
           Country Name</td>
        <td>
            <asp:TextBox ID="p_countryname"   runat="server" Width="430px"></asp:TextBox>
          
            </td>
            
    </tr>  
       <tr>
        <td align="left" style="padding-left: 10px" >
           Tel</td>
        <td>
            <asp:TextBox ID="p_tel"   runat="server" Width="430px"></asp:TextBox>
          
            </td>
            
    </tr>  
    <tr>       
         <td></td> 
        <td align=left style="padding-top:10px;">                                         
            <asp:Button ID="btnAdd" runat="server" Text="Thêm Mới" OnClick="btnAdd_ckick" CssClass="back_button main_sub" />   
            <asp:Button ID="btnDelete" runat="server" Visible="False" CssClass="back_button" OnClick="btnDelete_Click" Text="Xóa" Width="80px" />                                                         
        </td>        
    </tr>
   
 
</table>
</asp:Panel>
<asp:Panel runat="server" ID="PANNELLIST">
<table border="0" cellpadding="0" cellspacing="0" style="width: 100%" class="main">
    <tr >
        <td align="center" style="padding-top: 20px;">         
         <table  class="list_table"  cellpadding=0 cellspacing=0 width="98%">
              
         <asp:Repeater runat=server ID="p_list">
         <HeaderTemplate>           
             <tr class="list_title">
                  <td width="5%" style="padding-left:3px;">#</td>
                  <td align="left" width="30%" style="padding-left:5px;">Tiêu đề</td>
                <%--   <td align="left" width="15%" style="padding-left:5px;">Title</td>--%>
                  <td align="left" width="35%" style="padding-left:5px;">Từ khoá</td>
         <%--          <td align="left" width="15%" style="padding-left:5px;">Keyword</td>--%>
                  <td align="left" width="40%" style="padding-left:5px;">Mô tả</td>
            <%--        <td align="left" width="15%" style="padding-left:5px;">Description</td>--%>
                
              </tr>            
         </HeaderTemplate>
              <ItemTemplate>                
                  <tr class="list_row">
                    <td style="text-align: center"><%#Container.ItemIndex+1 %></td>
                    <td align="left" ><a href="website.aspx?act=view&pid=<%#Eval("Id")%>&n=<%=DateTime.Now.Ticks.ToString()%>"><%#Eval("TitleVi")%></a></td>
                <%--    <td align="left"><%#Eval("TitleEn")%></td>--%>
                    <td align="left"><%#Eval("DesKeyWordVi")%></td>
                 <%--   <td align="left"><%#Eval("DesKeyWordEn")%></td>--%>
                    <td align="left"><%#Eval("DesVi")%></td>
               <%--     <td align="left"><%#Eval("DesEn")%></td>--%>
                  </tr>
               
                </ItemTemplate>               
             </asp:Repeater> 
          </table>
        </td>
    </tr>
   
    <tr>
        <td align="center" style="padding-bottom:10px;padding-top:10px;">
            <asp:Button ID="btnAddList" runat="server"  CssClass="back_button main_sub"
                 OnClick="btnAddList_Click" Text="Thêm mới" Width="120" Visible="true" />&nbsp;</td>
    </tr>
</table>

</asp:Panel>
</asp:Content>

