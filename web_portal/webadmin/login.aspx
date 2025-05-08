<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="web_portal.webadmin.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
	<HEAD>
		<TITLE>QUAN TRI WEBSITE</TITLE>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=utf-8">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<META NAME="Keywords" CONTENT="">
		<META NAME="Designer" CONTENT="">
		<META NAME="Publisher" CONTENT="">
		<META HTTP-EQUIV="PRAGMA" CONTENT="NO-CACHE">
		<META HTTP-EQUIV="CACHE-CONTROL" CONTENT="NO-STORE">
		<META HTTP-EQUIV="EXPIRES" CONTENT="0">	
        <link href="../styles/admin/css/login.css" rel="stylesheet" type="text/css" />
	</HEAD>
 <script language="javascript" type="text/javascript">
     function setCookie(c_name)
     {
       //var expiredays=10;
       var sizes  =window.screen.height-window.screen.availHeight;       
        var values =window.screen.availHeight-window.top.window.screenTop-50;
       //var values =form1.clientHeight + sizes+top.window.screenTop+self.window.screenTop-50;   
        //alert("top.window.screenTop:"+top.window.screenTop);
        
//       var exdate=new Date();
//       exdate.setDate(exdate.getDate()+expiredays);
//       document.cookie=c_name+ "=" +escape(value)+((expiredays==null) ? "" : ";expires="+exdate.toGMTString());
//       //alert(getCookie('screen'));
       var txt =window.document.getElementById("idscreen");
       if(txt===null)
       {
       }
       else
       {
          //txt.value=getCookie('screen');
          txt.value=values;
       }
     }
     function getCookie(c_name)
     {
     if (document.cookie.length>0)
       {
         c_start=document.cookie.indexOf(c_name + "=");
         if (c_start!=-1) 
            {
               c_start=c_start + c_name.length+1;
               c_end=document.cookie.indexOf(";",c_start);  
               if (c_end==-1) c_end=document.cookie.length;   
               return unescape(document.cookie.substring(c_start,c_end));   
             }
          }
        return "";
      }
    </script> 
<body style="text-align:center">
<center>
    <form id="form1" runat="server">
    <div style="text-align: center">
       <input type="text" runat="server" value="" id="idscreen"  name="idscreen" style="display:none"/>
       
       <table width="100%"  border=0 cellpadding=0 cellspacing=0 align="center" style="padding-top:150px;">
         <tr align="center">
            
                
                  <td style="width:15%">
                 </td>
                  <td style="width:70%" align="center" valign="middle">
                       <table cellpadding="0" cellspacing="0" border="0" style="width: 500px;text-align:center" class="vientable" >
            <tr bgcolor=Gainsboro>
                <td align="center" colspan="2" style="height: 30px; text-align: center" valign="middle" class="TextTitleHeader">                
                     Quản lý website </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 10px">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                
                    <asp:Label ID="lbPrompt" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td align="center" rowspan="2" valign="middle" colspan="2">
                    <span style="color: #0000ff; text-decoration: underline"></span></td>
            </tr>
            <tr>
            </tr>
            <tr>
                <td  align="center" colspan="2" style="text-align: left" valign="middle">
                    <table style="width: 100%;text-align: left" border="0" >
                        <tr>
                            <td class="TextTD" rowspan="5">
                                <img width="174" src="../styles/images/logo_login.png?nguid=<%=DateTime.Now.Ticks.ToString()%>" alt="logo" title="logo" /></td>
                            <td nowrap="nowrap">
                                Tên truy cập</td>
                            <td>
                                <asp:TextBox TabIndex="1"  
                                ID="txtNickSMS" runat="server" Width="150px"></asp:TextBox><span style="color: #000000">
                                </span>                         
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNickSMS"
                                    Display="Static" ErrorMessage="Nhập tên truy cập" Font-Italic="True" Font-Size="Small"
                                    SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr bgcolor=WhiteSmoke >
                            <td>
                                Mật khẩu </td>
                            <td style="width: 174px; height: 26px">
                                <asp:TextBox TabIndex="2" ID="txtPassWord"  runat="server"  TextMode="Password" Width="150px" Wrap="False"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassWord"
                                    Display="Static" ErrorMessage="Nhập mật khẩu" Font-Italic="True" Font-Size="Small"
                                    SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                        </tr>
                         <tr>
                            
                            <td nowrap="nowrap">
                                Ngôn ngữ </td>
                            <td >
                                <asp:DropDownList ID="pselect" runat="server" onchange="location = this.value;">
                                  <asp:ListItem Text="Vietnamese" Selected="True" Value="../webadmin/login.aspx"></asp:ListItem>
                                  <asp:ListItem Text="English"  Value="../webadmin_en/login.aspx"></asp:ListItem>
                                </asp:DropDownList>
                                </td>
                        </tr>
                        <tr>
                            <td >
                            </td>
                            <td style="width: 174px; height: 26px; text-align: left">
                                <asp:Button ID="btnLogin" TabIndex="3"  runat="server" OnClick="btnLogin_Click" CssClass="back_button main_sub" Width="120" Text="Ðăng nhập"
                                     /></td>
                        </tr>
                        <tr>
                           <td colspan=2><asp:Label ID="lblErr" runat="server" CssClass="error" ForeColor=red></asp:Label></td>
                        </tr>
                    </table>
                </td>           
           </tr>            
            <tr>
                <td align="right" colspan="2" style="height: 19px;padding-right:5px;padding-bottom:10px;padding-top:10px;" valign="middle">
                    <span style="font-size: 9pt" > Copyright ©  2025 VER 3.0</span>
                </td>
            
               
            </tr>   
          
        </table>
                 </td>
                 <td style="width:15%">
                 </td>
           </tr>
         </table>          
    </div>
 </form>
 </center>
</body>

</html>
