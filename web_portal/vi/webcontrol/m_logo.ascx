<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="m_logo.ascx.cs" Inherits="web_portal.vi.webcontrol.m_logo" %>
<div class="bg section-bg fill bg-fill  bg-loaded" >

			
			
			

		</div>

		<div class="section-content relative">
			
<div class="row h-sp"  id="row-1769025968">

	<div id="col-518043402" class="col small-12 large-12"  >
				<div class="col-inner"  >
			
			
<div class="container section-title-container" ><h3 class="section-title section-title-center"><b></b>
<span class="section-title-main" >Các nhãn hàng Cafe</span><b></b></h3></div>
	<div id="gap-1946554593" class="gap-element clearfix" style="display:block; height:auto;">
		
<style>
#gap-1946554593 {
  padding-top: 30px;
}
</style>
	</div>
  
    <div class="row doi-tac large-columns-5 medium-columns-3 small-columns-2 slider row-slider slider-nav-circle slider-nav-outside"  data-flickity-options='{"imagesLoaded": true, "groupCells": "100%", "dragThreshold" : 5, "cellAlign": "left","wrapAround": true,"prevNextButtons": true,"percentPosition": true,"pageDots": false, "rightToLeft": false,"Height":100%, "autoPlay" : 3000}'>
        <asp:Repeater runat="server" ID="plistlogo">
            <ItemTemplate>
                 <div class="gallery-col col" >
          <div class="col-inner">
             <div class="box has-hover gallery-box box-none">
                    <div class="box-image" >
                       <img width="500" height="500" src="../styles/images/filedownload.svg" 
                       class="doi-tac" alt="<%#Eval("NameVi")%>" title="<%#Eval("NameVi")%>"  lightbox="false" type="slider" columns="5" slider_nav_style="circle" slider_nav_position="outside" auto_slide="3000" image_size="original" text_align="center" 
                       data-lazy-src="../resources/logo/<%#Eval("Picture")%>" />
                       <noscript>
                           <img width="500" height="500" src="../resources/logo/<%#Eval("Picture")%>" class="doi-tac" alt="" decoding="async" ids="5247,5248,5981,5982,5983" style="none" lightbox="false" type="slider" columns="5" slider_nav_style="circle" slider_nav_position="outside" auto_slide="3000" image_size="original" text_align="center" />
                       </noscript>   
                  </div>
                  <div class="box-text text-center" >
                 <p><%#Eval("CompanyNameVi")%></p>
              </div>
            </div>
                      </div>
         </div>
            </ItemTemplate>
        </asp:Repeater>
              <%--   <div class="gallery-col col" >
          <div class="col-inner">
                        <div class="box has-hover gallery-box box-none">
              <div class="box-image" >
                <img width="200" height="112" src="data:image/svg+xml,%3Csvg%20xmlns='http://www.w3.org/2000/svg'%20viewBox='0%200%20200%20112'%3E%3C/svg%3E" class="doi-tac" alt="" decoding="async" ids="5247,5248,5981,5982,5983" style="none" lightbox="false" type="slider" columns="5" slider_nav_style="circle" slider_nav_position="outside" auto_slide="3000" image_size="original" text_align="center" data-lazy-src="https://truongthinhphatholding.com.vn/wp-content/uploads/2020/07/logo-nam-anh-1.jpg" /><noscript><img width="200" height="112" src="https://truongthinhphatholding.com.vn/wp-content/uploads/2020/07/logo-nam-anh-1.jpg" class="doi-tac" alt="" decoding="async" ids="5247,5248,5981,5982,5983" style="none" lightbox="false" type="slider" columns="5" slider_nav_style="circle" slider_nav_position="outside" auto_slide="3000" image_size="original" text_align="center" /></noscript>                                                              </div>
              <div class="box-text text-center" >
                 <p></p>
              </div>
            </div>
                      </div>
         </div>
                 <div class="gallery-col col" >
          <div class="col-inner">
                        <div class="box has-hover gallery-box box-none">
              <div class="box-image" >
                <img width="200" height="112" src="data:image/svg+xml,%3Csvg%20xmlns='http://www.w3.org/2000/svg'%20viewBox='0%200%20200%20112'%3E%3C/svg%3E" class="doi-tac" alt="" decoding="async" ids="5247,5248,5981,5982,5983" style="none" lightbox="false" type="slider" columns="5" slider_nav_style="circle" slider_nav_position="outside" auto_slide="3000" image_size="original" text_align="center" data-lazy-src="https://truongthinhphatholding.com.vn/wp-content/uploads/2020/07/Neusoft.jpg" /><noscript><img width="200" height="112" src="https://truongthinhphatholding.com.vn/wp-content/uploads/2020/07/Neusoft.jpg" class="doi-tac" alt="" decoding="async" ids="5247,5248,5981,5982,5983" style="none" lightbox="false" type="slider" columns="5" slider_nav_style="circle" slider_nav_position="outside" auto_slide="3000" image_size="original" text_align="center" /></noscript>                                                              </div>
              <div class="box-text text-center" >
                 <p></p>
              </div>
            </div>
                      </div>
         </div>
                 <div class="gallery-col col" >
          <div class="col-inner">
                        <div class="box has-hover gallery-box box-none">
              <div class="box-image" >
                <img width="200" height="112" src="../styles/images/filedownload.svg" class="doi-tac" alt="" decoding="async" ids="5247,5248,5981,5982,5983" style="none" lightbox="false" type="slider" columns="5" slider_nav_style="circle" slider_nav_position="outside" auto_slide="3000" image_size="original" text_align="center" 
                    data-lazy-src="" />
                    <noscript>
                        <img width="200" height="112" src="https://truongthinhphatholding.com.vn/wp-content/uploads/2023/09/1.jpg" class="doi-tac" alt="" decoding="async" ids="5247,5248,5981,5982,5983" style="none" lightbox="false" type="slider" columns="5" slider_nav_style="circle" slider_nav_position="outside" auto_slide="3000" image_size="original" text_align="center" />
                    </noscript>                                                              </div>
              <div class="box-text text-center" >
                 <p></p>
              </div>
            </div>
                      </div>
         </div>
                 <div class="gallery-col col" >
          <div class="col-inner">
                        <div class="box has-hover gallery-box box-none">
              <div class="box-image" >
                <img width="200" height="112" src="data:image/svg+xml,%3Csvg%20xmlns='http://www.w3.org/2000/svg'%20viewBox='0%200%20200%20112'%3E%3C/svg%3E" class="doi-tac" alt="" decoding="async" ids="5247,5248,5981,5982,5983" style="none" lightbox="false" type="slider" columns="5" slider_nav_style="circle" slider_nav_position="outside" auto_slide="3000" image_size="original" text_align="center" data-lazy-src="https://truongthinhphatholding.com.vn/wp-content/uploads/2023/09/2.jpg" /><noscript><img width="200" height="112" src="https://truongthinhphatholding.com.vn/wp-content/uploads/2023/09/2.jpg" class="doi-tac" alt="" decoding="async" ids="5247,5248,5981,5982,5983" style="none" lightbox="false" type="slider" columns="5" slider_nav_style="circle" slider_nav_position="outside" auto_slide="3000" image_size="original" text_align="center" /></noscript>                                                              </div>
              <div class="box-text text-center" >
                 <p></p>
              </div>
            </div>
                      </div>
         </div>
                 <div class="gallery-col col" >
          <div class="col-inner">
                        <div class="box has-hover gallery-box box-none">
              <div class="box-image" >
                <img width="200" height="112" src="data:image/svg+xml,%3Csvg%20xmlns='http://www.w3.org/2000/svg'%20viewBox='0%200%20200%20112'%3E%3C/svg%3E" class="doi-tac" alt="" decoding="async" ids="5247,5248,5981,5982,5983" style="none" lightbox="false" type="slider" columns="5" slider_nav_style="circle" slider_nav_position="outside" auto_slide="3000" image_size="original" text_align="center" data-lazy-src="https://truongthinhphatholding.com.vn/wp-content/uploads/2023/09/3.jpg" /><noscript><img width="200" height="112" src="https://truongthinhphatholding.com.vn/wp-content/uploads/2023/09/3.jpg" class="doi-tac" alt="" decoding="async" ids="5247,5248,5981,5982,5983" style="none" lightbox="false" type="slider" columns="5" slider_nav_style="circle" slider_nav_position="outside" auto_slide="3000" image_size="original" text_align="center" /></noscript>                                                              </div>
              <div class="box-text text-center" >
                 <p></p>
              </div>
            </div>
                      </div>
         </div>--%>
         </div>
		</div>
					</div>

	
</div>
	<div id="gap-783257616" class="gap-element clearfix" style="display:block; height:auto;">
		
<style>
#gap-783257616 {
  padding-top: 30px;
}
</style>
	</div>
	
		</div>

		
<style>
#section_566537816 {
  padding-top: 30px;
  padding-bottom: 30px;
}
</style>