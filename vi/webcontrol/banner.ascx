<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="banner.ascx.cs" Inherits="web_portal.vi.webcontrol.banner" %>
<div class="slider-wrapper relative h-banner" id="slider-151359409" >
    <div class="slider slider-nav-circle slider-nav-large slider-nav-light slider-style-normal"
        data-flickity-options='{
            "cellAlign": "center",
            "imagesLoaded": true,
            "lazyLoad": 1,
            "freeScroll": false,
            "wrapAround": true,
            "autoPlay": 6000,
            "pauseAutoPlayOnHover" : true,
            "prevNextButtons": true,
            "contain" : true,
            "adaptiveHeight" : true,
            "dragThreshold" : 10,
            "percentPosition": true,
            "pageDots": true,
            "rightToLeft": false,
            "draggable": true,
            "selectedAttraction": 0.1,
            "parallax" : 0,
            "friction": 0.6}'
        >
        <asp:Repeater runat="server" ID="plistslide">
            <ItemTemplate>
                <div class="img has-hover x md-x lg-x y md-y lg-y" id="image_991343986">
		<a class="" href="#"  >
		    						<div class="img-inner dark" >
			<img width="2161" height="795" src="../styles/images/filedownload.svg" class="attachment-original size-original" alt="<%#Eval("NameVi")%>" decoding="async" fetchpriority="high" 
                    data-lazy-srcset="../resources/slides/2161_<%#Eval("Picture")%> 2161w,
                                      ../resources/slides/500_<%#Eval("Picture")%> 500w, 
                                      ../resources/slides/300_<%#Eval("Picture")%> 300w,
                                      ../resources/slides/1024_<%#Eval("Picture")%> 1024w,
                                      ../resources/slides/768_<%#Eval("Picture")%> 768w,
                                      ../resources/slides/1536_<%#Eval("Picture")%> 1536w,
                                      ../resources/slides/2048_<%#Eval("Picture")%> 2048w" 
                                      data-lazy-sizes="(max-width: 2161px) 100w, 2161px" 
                                      data-lazy-src="../resources/slides/<%#Eval("Picture")%>"  />
                                      <noscript><img width="2161" height="795" 
                                      src="../resources/slides/<%#Eval("Picture")%>" class="attachment-original size-original" alt="<%#Eval("NameVi")%>" decoding="async" fetchpriority="high" 
                                      srcset="../resources/slides/<%#Eval("Picture")%>,
                                              ../resources/slides/500_<%#Eval("Picture")%> 500w,
                                              ../resources/slides/300_<%#Eval("Picture")%> 300w,
                                              ../resources/slides/1024_<%#Eval("Picture")%> 1024w,
                                              ../resources/slides/768_<%#Eval("Picture")%> 768w,
                                              ../resources/slides/1536_<%#Eval("Picture")%> 1536w,
                                              ../resources/slides/2048_<%#Eval("Picture")%> 2048w" sizes="(max-width: 2161px) 100vw, 2161px" /></noscript>						
					</div>
						</a>		
<style>
#image_991343986 {
  width: 100%;
}
</style>
	</div>
            </ItemTemplate>
        </asp:Repeater>

     </div>

     <div class="loading-spin dark large centered"></div>

     	</div>