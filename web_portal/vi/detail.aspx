<%@ Page Title="Cafe Phương" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="detail.aspx.cs" Inherits="web_portal.vi.detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="shop-container">
	<div class="container">
	   <div class="woocommerce-notices-wrapper"></div>
    </div>
    <asp:Repeater runat="server" ID="plistinfo" OnItemDataBound="plistinfo_OnItemDataBound">
    <ItemTemplate>
<div id="product-5313" class="product type-product post-5313 status-publish first instock product_cat-khau-trang-y-te has-post-thumbnail shipping-taxable product-type-simple">
	<div class="row content-row row-divided row-large row-reverse">
	<div id="product-sidebar" class="col large-3 hide-for-medium shop-sidebar ">
		<aside id="woocommerce_products-3" class="widget woocommerce widget_products">
		    <span class="widget-title shop-sidebar">Sản phẩm mới</span>
            <div class="is-divider small"></div>
            <ul class="product_list_widget">
                   <asp:Repeater runat="server" ID="plistfocus">
                         <ItemTemplate>
                <li>
	                              <a href="detail.aspx?pid=<%#Eval("Id")%>">
		                 <img width="100" height="100" src="../styles/images/filedownload.svg" 
                                    class="attachment-woocommerce_gallery_thumbnail size-woocommerce_gallery_thumbnail" alt="<%#Eval("NameVi")%>" decoding="async" 
                                    data-lazy-srcset="../resources/products/100_<%#Eval("Picture")%> 100w, 
                                     ../resources/products/500_<%#Eval("Picture")%> 500w" data-lazy-sizes="(max-width: 100px) 100vw, 100px" 
                                 data-lazy-src="../resources/products/<%#Eval("Picture")%>" />
                               <noscript>
                                   <img width="100" height="100" title="<%#Eval("NameVi")%>"
                                   src="../resources/products/100_<%#Eval("Picture")%>" class="attachment-woocommerce_gallery_thumbnail size-woocommerce_gallery_thumbnail" alt="<%#Eval("NameVi")%>" decoding="async" 
                                   srcset="../resources/products/100_<%#Eval("Picture")%>,
                                   ../resources/products/500_<%#Eval("Picture")%> 500w" sizes="(max-width: 100px) 100vw, 100px" />
                               </noscript>
                               	<span class="product-title">
                               	    <%#Eval("NameVi")%>
                               	</span>
	                 </a>
	                 </li>
                      </ItemTemplate>
                     </asp:Repeater>
	

</ul>
       </aside>
	</div>

        <div class="col large-9">
	    
		<div class="product-main">
		<div class="row">
			<div class="large-6 col">
				
<div class="product-images relative mb-half has-hover woocommerce-product-gallery woocommerce-product-gallery--with-images woocommerce-product-gallery--columns-4 images" data-columns="4">

  <div class="badge-container is-larger absolute left top z-1">
</div>

  <div class="image-tools absolute top show-on-hover right z-3">
      </div>
      <!--slide hinh san pham -->
  <figure class="woocommerce-product-gallery__wrapper product-gallery-slider slider slider-nav-small mb-half"
        data-flickity-options='{
                "cellAlign": "center",
                "wrapAround": true,
                "autoPlay": false,
                "prevNextButtons":true,
                "adaptiveHeight": true,
                "imagesLoaded": true,
                "lazyLoad": 1,
                "dragThreshold" : 15,
                "pageDots": false,
                "rightToLeft": false       }'>
      <div data-thumb="../resources/products/100_<%#Eval("Picture")%>" class="woocommerce-product-gallery__image slide first">
                   <a href="../resources/products/<%#Eval("Picture")%>">
                       <img width="500" height="667" 
                       src="../resources/products/500_<%#Eval("Picture")%>" class="wp-post-image skip-lazy" alt="<%#Eval("NameVi")%>" decoding="async" title="<%#Eval("NameVi")%>" data-caption="<%#Eval("NameVi")%>" 
                       data-src="../resources/products/<%#Eval("Picture")%>" 
                       data-large_image="../resources/products/<%#Eval("Picture")%>" 
                       data-large_image_width="935" data-large_image_height="1247" 
                       srcset="../resources/products/500_<%#Eval("Picture")%> 500w, 
                       ../resources/products/768_<%#Eval("Picture")%> 768w,
                       ../resources/products/935_<%#Eval("Picture")%> 935w" sizes="(max-width: 500px) 100vw, 500px" />
                   </a>
               </div>
      <asp:Repeater runat="server" ID="plistslide">
          <ItemTemplate>
               <div data-thumb="../resources/products/100_<%#Eval("Picture")%>" class="woocommerce-product-gallery__image slide">
                   <a href="../resources/products/<%#Eval("Picture")%>">
                       <img width="500"   height="667" 
                       src="../resources/products/500_<%#Eval("Picture")%>" class="wp-post-image skip-lazy" alt="<%#Eval("NameVi")%>" decoding="async" title="<%#Eval("NameVi")%>" data-caption="<%#Eval("NameVi")%>" 
                       data-src="../resources/products/<%#Eval("Picture")%>" 
                       data-large_image="../resources/products/<%#Eval("Picture")%>" 
                       data-large_image_width="935" data-large_image_height="1247" 
                       srcset="../resources/products/500_<%#Eval("Picture")%> 500w, 
                       ../resources/products/768_<%#Eval("Picture")%> 768w,
                       ../resources/products/935_<%#Eval("Picture")%> 935w" sizes="(max-width: 500px) 100vw, 500px" />
                   </a>
               </div>
              
          </ItemTemplate>
      </asp:Repeater>
   
    </figure>

  <div class="image-tools absolute bottom left z-3">
        <a href="#product-zoom" class="zoom-button button is-outline circle icon tooltip hide-for-small" title="Zoom">
      <i class="icon-expand" ></i>    </a>
   </div>
</div>

	<div class="product-thumbnails thumbnails slider-no-arrows slider row row-small row-slider slider-nav-small small-columns-4"
		data-flickity-options='{
			"cellAlign": "left",
			"wrapAround": false,
			"autoPlay": false,
			"prevNextButtons": true,
			"asNavFor": ".product-gallery-slider",
			"percentPosition": true,
			"imagesLoaded": true,
			"pageDots": false,
			"rightToLeft": false,
			"contain": true
		}'>
					<div class="col is-nav-selected first">
				<a>
					<img src="../styles/images/filedownload.svg" alt="" 
                    width="500" height="500" class="attachment-woocommerce_thumbnail" 
                    data-lazy-src="../resources/products/500_<%#Eval("Picture")%>" /><noscript>
                    <img src="../resources/products/500_<%#Eval("Picture")%>" alt="<%#Eval("NameVi")%>" width="500" height="500" class="attachment-woocommerce_thumbnail" />
                                                               </noscript>				</a>
			</div>
            <asp:Repeater runat="server" ID="plistmore">
                <ItemTemplate>
                    <div class="col">
				<a>
					<img src="../styles/images/filedownload.svg" alt="" 
                    width="500" height="500" class="attachment-woocommerce_thumbnail" 
                    data-lazy-src="../resources/products/500_<%#Eval("Picture")%>" /><noscript>
                    <img src="../resources/products/500_<%#Eval("Picture")%>" alt="<%#Eval("NameVi")%>" width="500" height="500" class="attachment-woocommerce_thumbnail" />
                                                               </noscript>				</a>
			</div>
                </ItemTemplate>
            </asp:Repeater>
			
          </div>
			</div>


			<div class="product-info summary entry-summary col col-fit product-summary">
				<h3 class="product-title product_title entry-title">
	<%#Eval("NameVi")%></h3>

<div class="price-wrapper">
	<p class="price product-page-price ">
  </p>
</div>
<div class="product-short-description">
  <%#Eval("ShortDesVi")%>
 <%-- /* them o day  */--%>

 

 <%-- /^ --------------- end */--%>
</div>
<div class="product_meta">
  <span class="sku_wrapper">Mã: <span class="sku"><%#Eval("ProductCode")%></span></span>
   <span class="posted_in">Danh mục:
   <a href="category.aspx?pid=<%#Eval("CategoryId")%>">
       <asp:Label runat="server" ID="labelcategory"></asp:Label>
   </a></span>
   <asp:Repeater runat="server" ID="plistsp" Visible="false">
       <ItemTemplate>
            <span class="sku_wrapper">Brand:<span itemprop="brand" >
                    	<a href="partner.aspx?pid=<%#Eval("ServiceProviderId")%>">                            
                  <%#Eval("CompanyNameVi")%>
                  </a>
                                   </span></span>

  <span class="yith-wcbr-brands-logo" style="text-align: center">
	<a href="partner.aspx?pid=<%#Eval("ServiceProviderId")%>">
	    <img  width="300" height="100" src="../resources/serviceprovider/300_<%#Eval("Picture")%>" class="attachment-yith_wcbr_logo_size size-yith_wcbr_logo_size" alt="<%#Eval("NameVi")%>" decoding="async" loading="lazy" 
        srcset="../resources/partners/500_<%#Eval("Picture")%> 500w,
        ../resources/serviceprovider/300_<%#Eval("Picture")%> 300w,
        ../resources/serviceprovider/1024_<%#Eval("Picture")%> 1024w,
        ../resources/serviceprovider/768_<%#Eval("Picture")%> 768w,
        ../resources/serviceprovider/1536_<%#Eval("Picture")%> 1536w,
        ../resources/serviceprovider/2048_<%#Eval("Picture")%> 2048w,
        ../resources/serviceprovider/510_<%#Eval("Picture")%> 510w" sizes="(max-width: 500px) 100vw, 500px" />
	</a>		</span>
       </ItemTemplate>
   </asp:Repeater>
  
</div>

<div class="row row-collapse" style="border:#9999aa thin dotted"  id="row-1506302104">
	
		<div class="col-inner" style="padding-top: 10px;">
            <div class="container" >
    <h5 class="section-title section-title-normal"><b></b>
    <span style="font-size:18px">
              <strong>&nbsp;&nbsp;liên lạc trực tuyến</strong>
     </span><b></b></h5>
</div>
    	</div>
	    
				<div class="col-inner" style="padding-left: 10px">
	<a class="plain" href="tel:"  >
	    	<div class="icon-box featured-box icon-box-left text-left">
					<div class="icon-box-img" style="width:30px">
				<div class="icon">
					<div class="icon-inner" >
						<img width="256" height="256" src="../Styles/images/telephone.png" class="attachment-medium size-medium" alt="" decoding="async" loading="lazy" srcset="../styles/images/telephone.png 256w, ../styles/images/telephone.png 100w, ../styles/images/telephone.png 150w,../styles/images/telephone.png 30w" sizes="(max-width: 256px) 100vw, 256px" />					</div>
				</div>
			</div>
			<div class="icon-box-text last-reset" >
                <div>
                  <p>Hotline<br /><strong><asp:Label runat="server" ID="labelhottel"></asp:Label></strong></p>
                  </div>
		</div>
	</div>
	</a>
	

		</div>
				
				<div class="col-inner" style="padding-left: 10px"  >


	<a class="plain" href="tel:"  >
	    	<div class="icon-box featured-box icon-box-left text-left"  >
					<div class="icon-box-img" style="width:30px">
				<div class="icon">
					<div class="icon-inner" >
						<img align="left" width="40" height="256" src="../styles/images/email.png" class="attachment-medium size-medium" alt="" decoding="async" loading="lazy" srcset="../styles/images/email.png 256w, ../styles/images/email.png 100w, ../styles/images/email.png 150w, ../styles/images/email.png 30w" sizes="(max-width: 256px) 100vw, 256px" />										</div>
				</div>
			</div>
			<div class="icon-box-text last-reset">
                <div>
<p><strong><asp:Label runat="server" ID="labelemail"></asp:Label></strong></p>
</div>
		</div>
	</div>
	</a>
	

		</div>

</div>
 <%--<div class="social-icons share-icons share-row relative" >
     <a href="#" data-action="share/whatsapp/share" 
        class="icon button circle is-outline tooltip whatsapp show-for-medium" 
        title="Share on WhatsApp" aria-label="Share on WhatsApp">
         <i class="icon-whatsapp"></i>
     </a>
     <a href="#" data-label="Facebook" 
         onclick="window.open(this.href,this.title,'width=500,height=500,top=300px,left=300px');  return false;" 
         rel="noopener noreferrer nofollow" target="_blank" 
         class="icon button circle is-outline tooltip facebook" title="Share on Facebook" aria-label="Share on Facebook">
         <i class="icon-facebook" ></i>
     </a>
     <a href="" 
        onclick="window.open(this.href,this.title,'width=500,height=500,top=300px,left=300px');  return false;" rel="noopener noreferrer nofollow" target="_blank" class="icon button circle is-outline tooltip twitter" title="Share on Twitter" aria-label="Share on Twitter">
         <i class="icon-twitter" ></i>
     </a>
        <a href="#" rel="nofollow" class="icon button circle is-outline tooltip email" 
          title="Email to a Friend" aria-label="Email to a Friend">
            <i class="icon-envelop" ></i>
        </a>
     <a href="#" onclick="window.open(this.href,this.title,'width=500,height=500,top=300px,left=300px');  return false;" rel="noopener noreferrer nofollow" target="_blank" class="icon button circle is-outline tooltip pinterest" title="Pin on Pinterest" aria-label="Pin on Pinterest">
         <i class="icon-pinterest" ></i>
     </a>
     <a href="#" onclick="window.open(this.href,this.title,'width=500,height=500,top=300px,left=300px');  return false;"  rel="noopener noreferrer nofollow" target="_blank" class="icon button circle is-outline tooltip linkedin" title="Share on LinkedIn" aria-label="Share on LinkedIn"><i class="icon-linkedin" ></i></a>
 </div>--%>
			</div>
		</div>
		</div>
        

		<div class="product-footer">
			
	<div  class="woocommerce-tabs wc-tabs-wrapper container tabbed-content">
		<ul  class="tabs wc-tabs product-tabs small-nav-collapse nav nav-uppercase nav-line"  role="tablist">
				<li class="tab-description active" id="tab-title-description" role="tab" aria-controls="tab-description">
					<a href="#tab-description">
					Mô tả chi tiết</a>
				</li>
                <li style="display: none"  class="tab-specifications"   id="tab-title-specifications" role="tab" aria-controls="tab-specifications">
					<a  href="#tab-specifications">
						Specifications</a>
				</li>
                <li style="display: none" clsss="tab-accesories"  id="tab-title-accesories" role="tab" aria-controls="tab-accesories">
					<a   href="#tab-accesories">
						Accesories</a>
				</li>
               
               
		</ul>
		<div class="tab-panels">
				<div class="woocommerce-Tabs-panel woocommerce-Tabs-panel--description panel entry-content active" id="tab-description" role="tabpanel" aria-labelledby="tab-title-description">
                 <%#Eval("DescriptionVi")%>

                
				</div>
			<%--	<div class="woocommerce-Tabs-panel woocommerce-Tabs-panel--awp-specifications panel entry-content " id="tab-specifications" role="tabpanel" aria-labelledby="tab-title-specifications">
				     <%#Eval("SpecificationVi")%>
										<table class="vgkl_table" border="0" cellspacing="0">
<tbody>
<tr valign="top">
<td colspan="1" rowspan="1"><strong>Sieve diameters:</strong></td>
<td colspan="1" rowspan="1">200, 203 (8″), 250, 300, 305 (12″), 315 mm</td>
</tr>
<tr valign="top">
<td colspan="1" rowspan="1"><strong>Sample weight:</strong></td>
<td colspan="1" rowspan="1">approx. 6 kg</td>
</tr>
<tr valign="top">
<td colspan="1" rowspan="1"><strong>Weight of sieve set:</strong></td>
<td colspan="1" rowspan="1">max. 21 kg</td>
</tr>
<tr valign="top">
<td colspan="1" rowspan="1"><strong>Amplitude:</strong></td>
<td colspan="1" rowspan="1">max. 2 mm</td>
</tr>
<tr valign="top">
<td colspan="1" rowspan="1"><strong>Sound emission:</strong></td>
<td colspan="1" rowspan="1">≤ 70 dBA</td>
</tr>
<tr valign="top">
<td colspan="1" rowspan="1"><strong>Weight (without test sieves)</strong>:</td>
<td colspan="1" rowspan="1">approx. 53 kg</td>
</tr>
<tr valign="top">
<td colspan="1" rowspan="1"><strong>Dimensions:</strong></td>
<td colspan="1" rowspan="1">404 × 440 × 1000 mm</td>
</tr>
</tbody>
</table>
				</div>			
                <div class="woocommerce-Tabs-panel woocommerce-Tabs-panel--awp-specifications panel entry-content " id="tab-title-accesories" role="tabpanel" aria-labelledby="tab-title-accesories">

                     <%#Eval("AccesoriesVi")%>
									<table class="vgkl_table" border="0" cellspacing="0">
<tbody>
<tr valign="top">
<td colspan="1" rowspan="1"><strong>Sieve diameters:</strong></td>
<td colspan="1" rowspan="1">200, 203 (8″), 250, 300, 305 (12″), 315 mm</td>
</tr>
<tr valign="top">
<td colspan="1" rowspan="1"><strong>Dimensions:</strong></td>
<td colspan="1" rowspan="1">404 × 440 × 1000 mm</td>
</tr>
</tbody>
</table>
				</div>			--%>
		
        </div>

           
	</div>


	<div class="related related-products-wrapper product-section">
					<h3 class="product-section-title container-width product-section-title-related pt-half pb-half uppercase">
				Sản phẩm cùng loại</h3>
    <div class="row large-columns-3 medium-columns-3 large-columns-3 row-large slider row-slider slider-nav-reveal slider-nav-push"  data-flickity-options='{"imagesLoaded": true, "groupCells": "100%", "dragThreshold" : 5,"cellAlign": "left","wrapAround": true,"prevNextButtons": true,"percentPosition": true,"pageDots": true,"height":"100%", "rightToLeft": false, "autoPlay" : true}'>

       <asp:Repeater runat="server" ID="plistsame">
           <ItemTemplate>
               <div class="product-large col has-hover product type-product post-59<%#Container.ItemIndex+1 %> status-publish instock  has-post-thumbnail shipping-taxable product-type-simple">
	                        <div class="col-inner">
	
                        <div class="badge-container absolute left top z-1">
                        </div>
	<div class="product-small box">
	    
	        	<div class="box-image">
			<div class="image-fade_in_back">
				<a href="detail.aspx?pid=<%#Eval("Id")%>" aria-label='<%#Eval("NameVi")%>'>
					<img width="../resources/products/300_<%#Eval("Picture")%> 300w" height="500" src="../styles/images/filedownload.svg" 
                    class="attachment-woocommerce_thumbnail size-woocommerce_thumbnail" alt="" decoding="async" 
                    data-lazy-srcset="../resources/products/300_<%#Eval("Picture")%> 500w, 
                    ../resources/products/500_<%#Eval("Picture")%> 300w" data-lazy-sizes="(max-width: 600px) 300vw, 500px" 
                    data-lazy-src="../resources/products/300_<%#Eval("Picture")%>" />
                    <noscript><img width="300" height="300" 
                     src="../resources/products/300_<%#Eval("Picture")%>" class="attachment-woocommerce_thumbnail size-woocommerce_thumbnail" alt="<%#Eval("NameVi")%>" decoding="async" 
                     srcset="../resources/products/300_<%#Eval("Picture")%> 500w, 
                     ../resources/products/300_<%#Eval("Picture")%> 500w" sizes="(max-width: 500px) 300vw, 500px" /></noscript>
                     <img width="300" height="300" src="../styles/images/filedownload.svg" class="show-on-hover absolute fill hide-for-small back-image" alt="<%#Eval("NameVi")%>" decoding="async" 
                     data-lazy-srcset="../resources/products/500_<%#Eval("Picture")%> 500w, 
                     ../resources/products/300_<%#Eval("Picture")%> 300w" data-lazy-sizes="(max-width: 500px) 300vw, 500px" 
                     data-lazy-src="../resources/products/300_<%#Eval("Picture")%>" />
                     <noscript>
                         <img width="500" height="500" src="../resources/products/500_<%#Eval("Picture")%>" class="show-on-hover absolute fill hide-for-small back-image" alt="" decoding="async" 
                         srcset="../resources/products/500_<%#Eval("Picture")%> 500w,
                         ../resources/products/500_<%#Eval("Picture")%> 500w" sizes="(max-width: 500px) 500vw, 500px" />
                     </noscript>				</a>
			</div>
			<div class="image-tools is-small top right show-on-hover">
							</div>
			<div class="image-tools is-small hide-for-small bottom left show-on-hover">
							</div>
			<div class="image-tools grid-tools text-center hide-for-small bottom hover-slide-in show-on-hover">
							</div>

					</div>

	      <div class="box-text box-text-products text-center grid-style-2">
			<div class="title-wrapper">
			    <p class="name product-title woocommerce-loop-product__title">
			        <a href="#" class="woocommerce-LoopProduct-link woocommerce-loop-product__link">
			            <%#Eval("NameVi")%>
			        </a>
			    </p>
			</div><div class="price-wrapper">
</div>		</div>   	
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
</div>
</ItemTemplate>
</asp:Repeater>
		
	</div>
</asp:Content>
