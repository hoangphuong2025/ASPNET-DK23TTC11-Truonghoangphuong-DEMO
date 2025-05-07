<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="m_header.ascx.cs" Inherits="web_portal.vi.webcontrol.m_header" %>
	<div class="header-wrapper">
		<div id="top-bar" class="header-top hide-for-sticky nav-dark hide-for-medium">
    <div class="flex-row container">
      <div class="flex-col hide-for-medium flex-left">
          <ul class="nav nav-left medium-nav-center nav-small  nav-divided">
              <li class="html custom html_topbar_left">
                  <p class="t-phone">
                      <i class="fas fa-phone-alt"></i> 
                  <a href="#"><asp:Label runat="server" ID="labelhottel"></asp:Label></a>
                  </p>
              </li>
              <li class="html custom html_topbar_right">
                  <p class="t-mail">
                    <i class="fas fa-envelope"></i>
                     <a mailto="sales@nuocda.com"><asp:Label runat="server" ID="labelemail"></asp:Label></a>
                  </p>
                </li>      
          </ul>
      </div>

      <div class="flex-col hide-for-medium flex-center">
          <ul class="nav nav-center nav-small  nav-divided">
                        </ul>
      </div>

      <div class="flex-col hide-for-medium flex-right">
         <ul class="nav top-bar-nav nav-right nav-small  nav-divided">
              <li class="header-search-form search-form html relative has-icon">
	<div class="header-search-form-wrapper" style="display: none">
		<div class="searchform-wrapper ux-search-box relative is-normal">
		     <form role="search" method="get" class="searchform" action="#">
	<div class="flex-row relative">
						<div class="flex-col flex-grow">
			<label class="screen-reader-text" for="woocommerce-product-search-field-0">Tìm kiếm:</label>
			<input type="search" id="woocommerce-product-search-field-0" class="search-field mb-0" placeholder="Tìm kiếm…" value="" name="s" autocomplete="off">
			<input type="hidden" name="post_type" value="product">
							<input type="hidden" name="lang" value="vi">
					</div>
		<div class="flex-col">
			<button type="submit" value="Tìm kiếm" class="ux-search-submit submit-button secondary button icon mb-0" aria-label="Submit">
				<i class="icon-search"></i>			</button>
		</div>
	</div>
	<div class="live-search-results text-left z-top"><div class="autocomplete-suggestions" style="position: absolute; display: none; max-height: 300px; z-index: 9999;"></div></div>
</form>
</div>	</div>
</li>
<asp:Panel runat="server" ID="panelcount">
 <li class="cart-item ">
<div>
<a href="yourcart.aspx?nguid=<%=DateTime.Now.Ticks.ToString()%>" title="Giỏ hàng" class="header-cart-link icon primary button round is-small">
    <i class="icon-shopping-basket" style="color: #ffffff">
      <asp:Label runat="server" ID="labelcount"></asp:Label>
  </i>
  </a>
</div>
 <ul class="nav-dropdown nav-dropdown-simple">
    <li class="html widget_shopping_cart">
      <div class="widget_shopping_cart_content">
	<p class="woocommerce-mini-cart__empty-message">
	     <asp:Label runat="server" ID="labeldes"></asp:Label>
	</p>
      </div>
    </li>
   </ul> 
 </li>
</asp:Panel>
<li id="menu-item-5157-vi" class="lang-item lang-item-277 lang-item-vi current-lang lang-item-first menu-item menu-item-type-custom menu-item-object-custom current_page_item menu-item-home menu-item-5157-vi menu-item-design-default">
    <a href="#" hreflang="vi" lang="vi" class="nav-top-link">
        <img src="../styles/images/covn.png" alt="VI" width="16" height="11" style="width: 16px; height: 11px;" class="lazyloaded" data-ll-status="loaded">
        <noscript>
            <img src="../styles/images/covn.png" alt="VI" width="16" height="11" style="width: 16px; height: 11px;" />
        </noscript>
    </a>
</li>

<li style="display: none" id="menu-item-5157-en" class="lang-item lang-item-281 lang-item-en menu-item menu-item-type-custom menu-item-object-custom menu-item-5157-en menu-item-design-default"><a href="#" hreflang="en-GB" lang="en-GB" class="nav-top-link">
                                                                                                                                                                               <img src="../styles/images/coen.png" alt="EN" width="16" height="11" style="width: 16px; height: 11px;" class="lazyloaded" data-ll-status="loaded">
                                                                                                                                                                               <noscript><img src="../styles/images/coen.png" alt="EN" width="16" height="11" style="width: 16px; height: 11px;" /></noscript>
                                                                                                                                                                           </a></li>
          </ul>
            
      </div>

      
    </div>
</div>
        <div id="masthead" class="header-main hide-for-sticky">
      <div class="header-inner flex-row container logo-left medium-logo-center" role="navigation">

          <!-- Logo -->
          <div id="logo" class="flex-col logo">
            <!-- Header logo -->
<a href="../vi/default.aspx" title="" rel="home">
    <img width="182" height="94" src="../styles/images/logo.png?nguid=<%=DateTime.Now.Ticks.ToString()%>" class="header_logo header-logo lazyloaded" alt="Cafe" data-ll-status="loaded">
    <noscript>
    <img width="182" height="94" src="../styles/images/logo.png" class="header_logo header-logo" alt="Cafe"/>
    </noscript>
      <img width="182" height="94" src="../styles/images/logo.png" class="header-logo-dark" alt="Cafe" data-lazy-src="../styles/images/logo.png">
      <noscript>
          <img  width="182" height="94" src="../styles/images/logo.png" class="header-logo-dark" alt="Cafe"/>
      </noscript></a>
          </div>

          <!-- Mobile Left Elements -->
          <div class="flex-col show-for-medium flex-left">
            <ul class="mobile-nav nav nav-left ">
              <li class="nav-icon has-icon">
  <div class="header-button">
      		<a href="#" data-open="#main-menu" data-pos="left" data-bg="main-menu-overlay" data-color="" class="icon primary button circle is-small" aria-label="Menu" aria-controls="main-menu" aria-expanded="false">
		
		  <i class="icon-menu"></i>
		  		</a>
	 </div> </li>            </ul>
          </div>
        
          <!-- Left Elements -->
          <div class="flex-col hide-for-medium flex-left
            flex-grow" style="">
            <ul class="header-nav header-nav-main nav nav-left  nav-uppercase">
              <li class="html custom html_top_right_text">
                  <aside id="custom_html-3" class="widget_text widget widget_custom_html amr_widget">
                      <div class="textwidget custom-html-widget">
                          <h2 class="slogan" style="opacity: 1;letter-spacing:2px">
	<span class="letter" style="opacity: 1; transform: scale(1) translateZ(0px);">M</span>
    <span class="letter" style="opacity: 1; transform: scale(1) translateZ(0px);">A</span>
    <span class="letter" style="opacity: 1; transform: scale(1) translateZ(0px);">N</span>
    <span class="letter" style="opacity: 1; transform: scale(1) translateZ(0px);">G</span> 
    &nbsp;
    <span class="letter" style="opacity: 1; transform: scale(1) translateZ(0px);">L</span>
    <span class="letter" style="opacity: 1; transform: scale(1) translateZ(0px);">Ạ</span>
    <span class="letter" style="opacity: 1; transform: scale(1) translateZ(0px);">I</span>  
    &nbsp;
    <span class="letter" style="opacity: 1; transform: scale(1) translateZ(0px);">H</span>
    <span class="letter" style="opacity: 1; transform: scale(1) translateZ(0px);">Ư</span> 
    <span class="letter" style="opacity: 0.99999; transform: scale(1.00003) translateZ(0px);">Ơ</span>
    <span class="letter" style="opacity: 0.999826; transform: scale(1.00052) translateZ(0px);">N</span> 
    <span class="letter" style="opacity: 0.999826; transform: scale(1.00052) translateZ(0px);">G</span> 
    &nbsp;
    <span class="letter" style="opacity: 0.999826; transform: scale(1.00052) translateZ(0px);">V</span> 
    <span class="letter" style="opacity: 0.999826; transform: scale(1.00052) translateZ(0px);">Ị</span> 
      &nbsp;
    <span class="letter" style="opacity: 0.999214; transform: scale(1.00236) translateZ(0px);">C</span>
    <span class="letter" style="opacity: 0.997718; transform: scale(1.00685) translateZ(0px);">U</span>
    <span class="letter" style="opacity: 0.994676; transform: scale(1.01597) translateZ(0px);">Ộ</span>
    <span class="letter" style="opacity: 0.989061; transform: scale(1.03282) translateZ(0px);">C</span>
    &nbsp;
    <span class="letter" style="opacity: 0.962319; transform: scale(1.11304) translateZ(0px);">S</span>
    <span class="letter" style="opacity: 0.933323; transform: scale(1.20003) translateZ(0px);">Ố</span>
    <span class="letter" style="opacity: 0.882508; transform: scale(1.35248) translateZ(0px);">N</span>
    <span class="letter" style="opacity: 0.790169; transform: scale(1.62949) translateZ(0px);">G</span>

    
</h2>
                      </div>
                  </aside>
</li>            </ul>
          </div>

          <!-- Right Elements -->
          <div class="flex-col hide-for-medium flex-right">
            <ul class="header-nav header-nav-main nav nav-right  nav-uppercase">
              <li class="html custom html_nav_position_text_top">
                  <a class="hotline-right" href="tel:"  >
                      <i class="fas fa-phone-alt"></i> <asp:Label runat="server" ID="labeltel"></asp:Label>
                  </a>
              </li>  
             </ul>
          </div>

          <!-- Mobile Right Elements -->
          <div class="flex-col show-for-medium flex-right">
            <ul class="mobile-nav nav nav-right ">
              <li class="lang-item lang-item-277 lang-item-vi current-lang lang-item-first menu-item menu-item-type-custom menu-item-object-custom current_page_item menu-item-home menu-item-5157-vi menu-item-design-default">
              <a href="#" hreflang="vi" lang="vi" class="nav-top-link">
              <img src="../styles/images/covn.png" alt="VI" width="16" height="11" style="width: 16px; height: 11px;" data-lazy-src="../styles/images/covn.png" alt="VI" width="16" height="11" style="width: 16px; height: 11px;" /></noscript></a></li>
<li class="lang-item lang-item-281 lang-item-en menu-item menu-item-type-custom menu-item-object-custom menu-item-5157-en menu-item-design-default">
   <%-- <a href="#" hreflang="en-GB" lang="en-GB" class="nav-top-link">
         <img src="../styles/images/coen.png" alt="EN" width="16" height="11" style="width: 16px; height: 11px;" data-lazy-src="../styles/images/coen.png">
         
     </a>--%>
</li>
            </ul>
          </div>

      </div>
     
      </div><div id="wide-nav" class="header-bottom wide-nav hide-for-sticky nav-dark hide-for-medium">
        <div class="flex-row container">
             <div class="flex-col hide-for-medium flex-left">
                       <ul class="nav header-nav header-bottom-nav nav-left  nav-box nav-spacing-large nav-uppercase">
                    <li id="menu-item-5150" class="menu-item menu-item-type-post_type menu-item-object-page menu-item-home current-menu-item page_item page-item-347 current_page_item menu-item-5150 <%=StringActiveHome %> menu-item-design-default">
                           <a href="../vi/default.aspx" aria-current="page" class="nav-top-link">Trang chủ</a>
                    </li>
                 
                    <asp:Repeater runat="server" ID="plistgroup" OnItemDataBound="plistgroup_OnItemDataBound">
                        <ItemTemplate>
                             <li id="menu-item-524<%#Eval("ProductGroupId")%>" class="menu-item menu-item-type-custom menu-item-object-custom menu-item-has-children menu-item-524<%#Eval("ProductGroupId")%> <%=StringActivePro %> menu-item-design-default has-dropdown">
                               <a href="products.aspx" class="nav-top-link"><%#Eval("NameVi")%><i class="icon-angle-down"></i></a>
                                <ul class="sub-menu nav-dropdown nav-dropdown-has-shadow">
                                    <asp:Repeater runat="server" ID="plistsub" OnItemDataBound="plistsub_OnItemDataBound">
                                    <ItemTemplate>
                                        <li id="menu-item-5244<%#Eval("CategoryId")%>" class="menu-item menu-item-type-custom menu-item-object-custom menu-item-has-children menu-item-5244<%#Eval("CategoryId")%>">
	                                         <a href="category.aspx?pid=<%#Eval("CategoryId")%>" class="nav-top-link"><%#Eval("NameVi")%>&nbsp;&nbsp;</a>
                                            
                                                 <ul style="padding-left: 30px;overflow: auto;width: 100%;padding-right: 20px" class="sub menu menu-item menu-item-type-custom with-full">
                                                      <asp:DataList Width="100%" RepeatColumns="4" runat="server" ID="plistsubsub">
                                                        <ItemTemplate>
                                                            <li style="white-space: nowrap;" id="menu-item-12" class="menu-item menu-item-type-taxonomy menu-item-object-product_cat  menu-item-52211<%#Eval("CategoryId")%>">
	                                                          <i class="icon-angle-right"></i> 
                                                                <a href="subcategory.aspx?pid=<%#Eval("CategoryId")%>"><%#Eval("NameVi")%></a>
                                             
	                                                         </li>
                                                        </ItemTemplate>
                                                      </asp:DataList>
                                                 </ul>
                                            
	                                     </li>
                                    </ItemTemplate>
                                  </asp:Repeater>
                              </ul>
                          </li>
                        </ItemTemplate>
                    </asp:Repeater> 
                     
                    <li id="menu-item-5462" class="menu-item menu-item-type-post_type menu-item-object-page menu-item-5462 <%=StringActiveLienHe %> menu-item-design-default">
                        <a href="contact.aspx" class="nav-top-link">Liên hệ</a>
                    </li>
                </ul>
            </div>
             <div class="flex-col hide-for-medium flex-right flex-grow">
              <ul class="nav header-nav header-bottom-nav nav-right  nav-box nav-spacing-large nav-uppercase">
               </ul>
            </div>
            
            
    </div>
</div>

<div class="header-bg-container fill">
    <div class="header-bg-image fill"></div><div class="header-bg-color fill"></div>
</div>	
	</div>