<%@ Page Title="Cafe Phương" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="web_portal.vi._default" %>
<%@ Register Src="./webcontrol/banner.ascx" TagName="banner" TagPrefix="uc1" %>
<%@ Register Src="./webcontrol/m_danhmucchinh.ascx" TagName="m_danhmucchinh" TagPrefix="uc1" %>
<%@ Register Src="./webcontrol/m_sanphamtrangchu.ascx" TagName="m_sanphamtrangchu" TagPrefix="uc1" %>
<%@ Register Src="./webcontrol/m_intro.ascx" TagName="m_intro" TagPrefix="uc1" %>
<%@ Register Src="./webcontrol/m_logo.ascx" TagName="m_logo" TagPrefix="uc1" %>
<%@ Register Src="./webcontrol/m_hoptac.ascx" TagName="m_hoptac" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div id="content" role="main" class="content-area">

		 <uc1:banner id="banner" runat="server">
                                                            </uc1:banner>


	<section class="section" id="section_663046847">
		 <uc1:m_danhmucchinh id="m_danhmucchinh" runat="server">
                                                            </uc1:m_danhmucchinh>
			
	</section>
	
	<section class="section has-parallax" id="section_1733944333">
	     <uc1:m_sanphamtrangchu id="m_sanphamtrangchu" runat="server">
                                                            </uc1:m_sanphamtrangchu>
		
	</section>
	
	<section class="section h-vct" id="section_2029704460">
		<uc1:m_intro id="m_intro" runat="server">
                                                            </uc1:m_intro>
	</section>
	
	<%--<section class="section has-parallax" id="section_2068333595">
	  <uc1:m_action id="m_action" runat="server">
                                                            </uc1:m_action>
	</section>--%>
	
	<section class="section" id="section_1533106778">
		<uc1:m_logo id="m_logo" runat="server">
                                                            </uc1:m_logo>
	</section>
	
	<%--<section class="section" id="section_634801570">
		<uc1:m_hoptac id="m_hoptac" runat="server">
                                                            </uc1:m_hoptac>
	</section>--%>
	
		
				
</div>
     	
</asp:Content>
