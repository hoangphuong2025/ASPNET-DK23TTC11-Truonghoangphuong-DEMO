<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="m_menu.ascx.cs" Inherits="web_portal.vi.webcontrol.m_menu" %>
<div id="main-menu" class="mobile-sidebar no-scrollbar mfp-hide">
	<div class="sidebar-menu no-scrollbar ">
		<ul class="nav nav-sidebar nav-vertical nav-uppercase">
			<li class="header-search-form search-form html relative has-icon">
	<div class="header-search-form-wrapper">
		<div class="searchform-wrapper ux-search-box relative is-normal">
		    <form role="search" method="get" class="searchform" action="#">
	<div class="flex-row relative">
						<div class="flex-col flex-grow">
			<label class="screen-reader-text" for="woocommerce-product-search-field-1">Search:</label>
			<input type="search" id="woocommerce-product-search-field-1" class="search-field mb-0" placeholder="Tìm kiếm…" value="" name="s" autocomplete="off">
			<input type="hidden" name="post_type" value="product">
							<input type="hidden" name="lang" value="vi">
					</div>
		<div class="flex-col">
			<button type="submit" value="search" class="ux-search-submit submit-button secondary button icon mb-0" aria-label="Submit">
				<i class="icon-search"></i>			</button>
		</div>
	</div>
	<div class="live-search-results text-left z-top">
	    <div class="autocomplete-suggestions" style="position: absolute; display: none; max-height: 300px; z-index: 9999;"></div>
	</div>
</form>
</div>	</div>
</li><li class="menu-item menu-item-type-post_type menu-item-object-page menu-item-home current-menu-item page_item page-item-347 current_page_item menu-item-5150">
         <a href="default.aspx" aria-current="page">Trang Chủ</a>
     </li>
<li class="menu-item menu-item-type-post_type menu-item-object-page menu-item-5340">
    <a href="intro.aspx" >Giới thiệu</a>
</li>
<li class="menu-item menu-item-type-custom menu-item-object-custom menu-item-has-children menu-item-5571 has-child" aria-expanded="false">
    <a href="products.aspx">SẢn phẩm</a>
<button class="toggle"><i class="icon-angle-down"></i></button>
   <ul class="sub-menu nav-sidebar-ul children">
       <asp:Repeater runat="server">
           <ItemTemplate>
               <li class="menu-item menu-item-type-taxonomy menu-item-object-product_cat menu-item-5324"><a href="#">Thiết bị bảo hộ y tế</a></li>
           </ItemTemplate>
       </asp:Repeater>
	
	
</ul>
</li>

<%--<li class="menu-item menu-item-type-post_type menu-item-object-page menu-item-5424">
    <a href="#serviceprovider.aspx">Khách hàng</a>
</li>--%>
<li class="menu-item menu-item-type-post_type menu-item-object-page menu-item-5462">
    <a href="contact.aspx">Liên hệ</a>
</li>
		</ul>
	</div>
</div>