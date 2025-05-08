<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="m_sanphamtrangchu.ascx.cs" Inherits="web_portal.vi.webcontrol.m_sanphamtrangchu" %>
<div class="bg section-bg fill bg-fill parallax-active bg-loaded" data-parallax-container=".section" data-parallax-background="" data-parallax="-10" style="height: 454px; transform: translate3d(0px, 238.23px, 0px); backface-visibility: hidden;">
			
		</div>

		<div class="section-content relative">
			
<div class="row h-sp" id="row-1613948064">

	<div id="col-1656311300" class="col small-12 large-12">
				<div class="col-inner">
			
<div class="container section-title-container">
    <h3 class="section-title section-title-center"><b></b>
    <span class="section-title-main">Sản phẩm</span>
    <b></b></h3>
</div>
	<div id="gap-1821366232" class="gap-element clearfix" style="display:block; height:auto;">
		
<style>
#gap-1821366232 {
  padding-top: 30px;
}
</style>
	</div>
	

  
    <div class="row product-home large-columns-4 medium-columns-3 small-columns-2 row-small">
  	   <asp:Repeater runat="server" ID="plistpro">
  	       <ItemTemplate>
  	           <div class="col" data-animate="fadeInUp" data-animated="true">
					<div class="col-inner">
                            <div class="badge-container absolute left top z-1">
                            </div>
						<div class="product-small box product-home has-hover box-normal box-text-bottom">
							<div class="box-image">
								<div class="image-cover" style="padding-top:100%;">
									<a href="detail.aspx?pid=<%#Eval("Id")%>" aria-label='<%#Eval("NameVi")%>'>
										<img width="500" height="500" 
                                        src="../resources/products/<%#Eval("Picture")%>" 
                                           class="show-on-hover absolute fill hide-for-small back-image lazyloaded" alt="<%#Eval("NameVi")%>" decoding="async" sizes="(max-width: 500px) 100vw, 500px" 
                                           srcset="../resources/products/<%#Eval("Picture")%> 500w, 
                                                   ../resources/products/<%#Eval("Picture")%> 100w" 
                                                   data-ll-status="loaded">
                                            <noscript>
                                                <img width="500" height="500"
                                                   src="../resources/products/<%#Eval("Picture")%>" class="show-on-hover absolute fill hide-for-small back-image" alt="" decoding="async" 
                                                   srcset="../resources/products/500_<%#Eval("Picture")%> 500w, 
                                                   ../resources/products/100_<%#Eval("Picture")%> 100w" sizes="(max-width: 500px) 100vw, 500px" />
                                            </noscript>
                                              <img width="1280" height="960" 
                                                  src="../resources/products/<%#Eval("Picture")%>" class="attachment-original size-original lazyloaded" alt="<%#Eval("NameVi")%>" decoding="async" sizes="(max-width: 1280px) 100vw, 1280px" 
                                                  srcset="../resources/products/1280_<%#Eval("Picture")%> 1280w, 
                                                  ../resources/products/768_<%#Eval("Picture")%> 768w,
                                                  ../resources/products/500_<%#Eval("Picture")%> 500w" title="<%#Eval("NameVi")%>" data-ll-status="loaded">
                                                   <noscript>
                                                       <img width="1280" height="960" src="../resources/products/filedownload.svg" class="attachment-original size-original" alt="11111111111" decoding="async" 
                                                        srcset="../resources/products/1280_<%#Eval("Picture")%> 1280w, 
                                                               ../resources/products/768_<%#Eval("Picture")%> 768w, 
                                                               ../resources/products/500_<%#Eval("Picture")%> 500w" 
                                                               sizes="(max-width: 1280px) 100vw, 1280px" />
                                                   </noscript>			
                                             	</a>
								 </div>
								<div class="image-tools top right show-on-hover">
								</div>
								<div class="image-tools grid-tools text-center hide-for-small bottom hover-slide-in show-on-hover">
							   </div>
							</div>
							<div class="box-text text-center">
								<div class="title-wrapper">
								    <p class="name product-title woocommerce-loop-product__title">
								        <a href="detail.aspx?pid=<%#Eval("Id")%>" class="woocommerce-LoopProduct-link woocommerce-loop-product__link">
								            <%#Eval("NameVi")%>
								        </a>
								    </p>
								</div><div class="price-wrapper"></div>							</div>
						</div>
						</div>
					</div>
  	       </ItemTemplate>
  	   </asp:Repeater>
	     
	            
				</div>
		</div>
	</div>
</div>
		</div>

		
<style>
#section_1733944333 {
  padding-top: 30px;
  padding-bottom: 30px;
}
#section_1733944333 .section-bg.bg-loaded {
    background-color: #add8e6;
}
</style>