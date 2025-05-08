<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="m_danhmucchinh.ascx.cs" Inherits="web_portal.vi.webcontrol.m_danhmucchinh" %>
<div class="bg section-bg fill bg-fill bg-loaded">

		</div>

		<div class="section-content relative">
			
<div class="row align-center h-sp" id="row-539995534">

	<div id="col-1419312306" class="col small-12 large-12" data-animate="fadeInUp" data-animated="true">
				<div class="col-inner">
<div class="container section-title-container">
    <h3 class="section-title section-title-center"><b></b>
        <span class="section-title-main">Danh mục</span>
        <b></b>
    </h3>
</div>
	<div id="gap-1958833314" class="gap-element clearfix" style="display:block; height:auto;">
		
<style>
#gap-1958833314 {
  padding-top: 30px;
}
</style>
	</div>
	
		</div>
					</div>

	
</div>
<div class="row" id="row-2130836650">
    <asp:Repeater runat="server" ID="plistcate">
        <ItemTemplate>
            <div id="col-695779485" class="col medium-4 small-12 large-4" data-animate="fadeInUp" data-animated="true">
				<div class="col-inner">
	<div class="box has-hover img-danh-muc  has-hover box-shade dark box-text-bottom">

		<div class="box-image">
			<a href="category.aspx?pid=<%#Eval("CategoryId")%>">
			    			<div class="image-zoom-long">
				<img width="540" height="396" src="../resources/category/<%#Eval("Picture")%>" 
                   class="attachment-original size-original lazyloaded" alt="<%#Eval("NameVi")%>" decoding="async" sizes="(max-width: 540px) 100vw, 540px" 
                   srcset="../resources/category/540_<%#Eval("Picture")%> 540w,
                              ../resources/category/500_<%#Eval("Picture")%> 500w, 
                             ../resources/category/300_<%#Eval("Picture")%> 300w" data-ll-status="loaded">
                <noscript>
                    <img width="540" height="396" src="../resources/category/<%#Eval("Picture")%>" class="attachment-original size-original" alt="" decoding="async" 
                      srcset="../resources/category/540_<%#Eval("Picture")%> 540w,
                              ../resources/category/500_<%#Eval("Picture")%> 500w, 
                             ../resources/category/300_<%#Eval("Picture")%> 300w" sizes="(max-width: 540px) 100vw, 540px" />
                </noscript>		
                <div class="shade"></div>	
              </div>
			</a>		</div>

		<div class="box-text text-center">
			<div class="box-text-inner">
				
<h2><strong><a href="category.aspx?pid=<%#Eval("CategoryId")%>"><%#Eval("NameVi")%></a></strong></h2>
			</div>
		</div>
	</div>
	
		</div>
					</div>
        </ItemTemplate>
    </asp:Repeater>

	
	
</div>
		</div>
		
        <style>
#section_663046847 {
  padding-top: 0px;
  padding-bottom: 0px;
}
#section_663046847 .section-bg.bg-loaded {
    background-color: #87cefa;
}
@media (min-width:550px) {
  #section_663046847 {
    padding-top: 30px;
    padding-bottom: 30px;
  }
}
</style>