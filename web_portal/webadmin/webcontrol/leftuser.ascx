<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="leftuser.ascx.cs" Inherits="web_portal.webadmin.webcontrol.leftuser" %>

<%--<table border="0" cellpadding="5" cellspacing="0" width="100%" >
   <tr>
     <td valign="top" style="background-color: #eeeeee">
        <table border="0" cellpadding="5" cellspacing="0" width="100%" class="menu_left">
	    <tr>
    	    <td class="menu_left_heading">Quản Lý website</td>
    	    
        </tr>
        
    </table>
   </td>
  </tr>
 </table>  --%> 

<table cellpadding=0 cellspacing=0 width="100%" style="background-color:#ffffff">
<tr>
    	<td align="left" colspan="3">
    	
       	 <asp:Repeater runat="server" ID="pmain"  OnItemDataBound="pmain_ItemDataBound">
       	    <ItemTemplate>
        	  <table border="0" cellpadding="0" cellspacing="0" width="100%">
        	   <asp:Panel runat="server" ID="PANELOK">
            	<tr>
                	<td class="menu_left_title" onclick="javascript:ItemMinimize('<%#Eval("MainId")%>');">
                    	<table border="0" cellpadding="0" cellspacing="0" width="100%">
                        	<tr>
                            	<td width="20">
                            	    <img src="../styles/admin/images/bullet_open.png" />
                            	</td>
                                <td><%#Eval("NameVi")%></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                </asp:Panel>
                <tr>
                	<td align="center" style="background-color: #eeeeee;font-weight: 400">
                	  <div id="IDM_<%#Eval("MainId")%>">
                    	<table border="0" cellpadding="5" cellspacing="0" width="90%" class="menu_left_list" style="line-height:180%">
                    	   <asp:Repeater runat="server" ID="psub">
                    	     <ItemTemplate>
                               <tr>
                                      <td >
                                       <img width="7" height="8" src="../styles/admin/images/arrowright.png" />
                                   </td>
                            	<td align="left" class="dotted" >
                            	    <a target="<%#Eval("Target")%>" href="./<%#Eval("Url")%>"><%#Eval("NameVi")%></a>
                            	</td>
                              </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                              <tr>
                                <td style="height:6px;"></td>
                              </tr>
                            </FooterTemplate>
                           </asp:Repeater>                                        
                        </table>
                       </div>                      
                    </td>
                </tr>
  
            </table>
            </ItemTemplate>
         </asp:Repeater> 
       
        </td>
    </tr>
    
 <%--  <tr>
      <td style="background-color:#bcbcbc">
         <table cellpadding=0 cellspacing=0 width="100%" style="line-height:150%;padding-bottom:5px;padding-top:5px;">
            <tr>
               <td style="padding-left:5px;font-weight:600;text-align:left">Welcome:</td>
               <td align="left" style="color:#555555"><asp:Label runat="server" ID="pname"></asp:Label></td>
            </tr>
           <tr>
                <td colspan="2"><a href="menusub.aspx">Menu sub</a></td>

            </tr>
            <tr>
                <td colspan="2"><a href="menumain.aspx">Menu Main</a></td>

            </tr>
            <tr>
               <td style="padding-left:5px;font-weight:500;text-align:left">Đăng nhập lần cuối</td>           
               <td align="left" >
                <asp:Label runat="server" ID="labelogin"></asp:Label></td>
            </tr>
         </table>
      </td>
   </tr> --%>
</table> 
                              