<%@ Page Title="Cafe Phương" Language="C#" MasterPageFile="~/SiteIntro.Master" AutoEventWireup="true" CodeBehind="intro.aspx.cs" Inherits="web_portal.vi.intro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<main id="main" class="">
<div id="content" class="content-area page-wrapper" role="main">
	<div class="row row-main">
		<div class="large-12 col">
			<div class="col-inner">
			<asp:Repeater runat="server" ID="plistintro">
    <ItemTemplate>	
        
    
	<section class="section" id="section_1235628902">
	    

		<div class="bg section-bg fill bg-fill  bg-loaded">

		</div>
        <div class="section-content relative">
           <div class="row row-large align-top"  id="row-1249868135">

	<div id="col-378690074" class="col medium-12 small-12 large-12">
				<div class="col-inner text-left">
<h2 style="vertical-align: top"><strong><%#Eval("TitleVi")%></strong></h2>
<p style="text-align: justify;top:0px">
    <%#Eval("DescriptionVi")%>
</p>
		</div>
					</div>
	

	
</div>
		</div>

		
<style>
#section_1235628902 {
  padding-top:0px;
  padding-bottom: 0px;
 
}
</style>
	</section>
	
</ItemTemplate>
</asp:Repeater>

						
												</div>
		</div>
	</div>
</div>


</main> 

</asp:Content>
