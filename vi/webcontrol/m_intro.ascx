<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="m_intro.ascx.cs" Inherits="web_portal.vi.webcontrol.m_intro" %>
<div class="bg section-bg fill bg-fill"></div>
		 <div class="section-content relative">
            <div class="row align-equal align-center" id="row-182748072">

    	<div id="col-1794707944" class="col medium-6 small-12 large-6" data-animate="bounceInLeft">
				<div class="col-inner">

<asp:Repeater runat="server" ID="pintro">
    <ItemTemplate>
        
  <div class="container section-title-container">
    <h3 class="section-title section-title-normal">
        <b></b><span class="section-title-main"><%#Eval("TitleVi")%></span><b></b>
    </h3>
</div>
<p>
   <%-- <span style="color: #007cba;text-transform: uppercase;font-weight: bold">
        <strong></strong>&nbsp;
    </span>--%>
    <%#Eval("ShortDesVi")%><br>
  <a href="intro.aspx?nguid=<%=DateTime.Now.Ticks.ToString()%>" target="_self" class="button primary" style="border-radius:5px;">
    <span>chi tiết...</span>
  </a>

		</p>
  </ItemTemplate>
</asp:Repeater>
        </div>
					</div>

	     <div id="col-1591220887" class="col medium-6 small-12 large-6" data-animate="fadeInRight">
				<div class="col-inner">
	                <div class="img has-hover img-ttp x md-x lg-x y md-y lg-y" id="image_246805195">
		  <div class="img-inner dark">
			       <img width="1280" height="844" src="../resources/intro/intro.jpg?nguid=235443" class="attachment-original size-original lazyloaded" alt="" decoding="async" sizes="(max-width: 1280px) 100vw, 1280px" srcset="../resources/intro/intro.jpg 1280w, ../resources/intro/intro.jpg 500w, ../resources/intro/intro.jpg 300w, ../resources/intro/intro.jpg 1024w, ../resources/intro/intro.jpg 768w" data-ll-status="loaded">
                    <noscript>
                      <img width="1280" height="844" src="../resources/intro/intro.jpg?nguid=333" class="attachment-original size-original" alt="" decoding="async" srcset="../resources/intro/intro.jpg 1280w,../resources/intro/intro.jpg 500w, ../resources/intro/intro.png 300w, ../resources/intro/intro.png 1024w,../resources/intro/intro.jpg 768w" sizes="(max-width: 1280px) 100vw, 1280px" />
                  </noscript>						
			</div>
             <style>
#image_246805195 {
  width: 100%;
}
</style>
	</div>
	
		           </div>
		  </div>
       </div>
		</div>
       <style>
            #section_2029704460 {
              padding-top: 60px;
              padding-bottom: 60px;
            }
           
            #section_2029704460 .section-bg.bg-loaded 
            {
                background-color: #b0e0e6;
            }
            
   </style>