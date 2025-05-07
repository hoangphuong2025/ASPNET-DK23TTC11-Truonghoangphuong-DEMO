<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="m_leftpro.ascx.cs" Inherits="web_portal.vi.webcontrol.m_leftpro" %>
<div class="related related-products-wrapper product-section">
		<h3 class="product-section-title container-width product-section-title-related pt-half pb-half uppercase">
				Same Products			</h3>
    <div class="row large-columns-3 medium-columns-3 small-columns-2 row-small slider row-slider slider-nav-reveal slider-nav-push"  data-flickity-options='{"imagesLoaded": true, "groupCells": "100%", "dragThreshold" : 5, "cellAlign": "left","wrapAround": true,"prevNextButtons": true,"percentPosition": true,"pageDots": false, "rightToLeft": false, "autoPlay" : false}'>
	  <asp:Repeater runat="server" ID="plistleft">
	      <ItemTemplate>
	          <div class="product-small col has-hover product type-product post-<%#Container.ItemIndex+1 %> status-publish instock product_cat-khau-trang-y-te has-post-thumbnail shipping-taxable product-type-simple">
	            <div class="col-inner">
                    <div class="badge-container absolute left top z-1">
                    </div>
	                <div class="product-small box ">
	                 	<div class="box-image">
			<div class="image-fade_in_back">
				<a href="detail.aspx?pid=<%#Eval("Id")%>" aria-label="<%#Eval("NameVi")%>">
					<img width="500" height="500" src="../styles/images/filedownload.svg" class="attachment-woocommerce_thumbnail size-woocommerce_thumbnail" alt="" decoding="async" 
                          data-lazy-srcset="../resources/products/500_<%#Eval("Picture")%> 500w,
                                        ../resources/products/100_<%#Eval("Picture")%> 100w" 
                          data-lazy-sizes="(max-width: 500px) 100vw, 500px" 
                      data-lazy-src="../resources/products/500_<%#Eval("Picture")%>" />
                <noscript>
                    <img width="500" height="500" src="../resources/products/500_<%#Eval("Picture")%>" class="attachment-woocommerce_thumbnail size-woocommerce_thumbnail" alt="" decoding="async" 
                    srcset="../resources/products/500_<%#Eval("Picture")%> 500w,
                    ../resources/products/100_<%#Eval("Picture")%> 100w" sizes="(max-width: 500px) 100vw, 500px" />
                </noscript>
                <img width="500" height="500" src="../styles/images/filedownload.svg" class="show-on-hover absolute fill hide-for-small back-image" alt="" decoding="async" 
                   data-lazy-srcset="../resources/products/500_<%#Eval("Picture")%> 500w,
                   ../resources/products/100_<%#Eval("Picture")%> 100w" data-lazy-sizes="(max-width: 500px) 100vw, 500px" 
                   data-lazy-src="../resources/products/500_<%#Eval("Picture")%>" />
                   <noscript>
                       <img width="500" height="500" src="../resources/products/500_<%#Eval("Picture")%>" class="show-on-hover absolute fill hide-for-small back-image" alt="" decoding="async" 
                       srcset="../resources/products/500_<%#Eval("Picture")%> 500w,
                        ../resources/products/100_<%#Eval("Picture")%> 100w" sizes="(max-width: 500px) 100vw, 500px" />
                   </noscript>				
                 </a>
			</div>
			<div class="image-tools is-small top right show-on-hover">
							</div>
			<div class="image-tools is-small hide-for-small bottom left show-on-hover">
							</div>
			<div class="image-tools grid-tools text-center hide-for-small bottom hover-slide-in show-on-hover">
							</div>
					</div>

	                	<div class="box-text box-text-products text-center grid-style-2">
			<div class="title-wrapper"><p class="name product-title woocommerce-loop-product__title">
			                               <a href="detail.aspx?pid=<%#Eval("Id")%>" class="woocommerce-LoopProduct-link woocommerce-loop-product__link">
			                                   <%#Eval("NameVi")%>
                                             
			                               </a>
			                           </p></div><div class="price-wrapper">
</div>		</div>
	                </div>
		        </div>
             </div>
	      </ItemTemplate>
	  </asp:Repeater>
					

	
					


		
					


		
					


		
					


		
		</div>
	</div>