<%@ Page Title="" Language="C#" MasterPageFile="~/SitePro.Master" AutoEventWireup="true" CodeBehind="products.aspx.cs" Inherits="web_portal.vi.products" %>
<%@ Register Src="~/vi/webcontrol/m_leftcategory.ascx" TagName="m_leftcategory" TagPrefix="uc1" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<main id="main" class="">
<div class="row category-page-row">

		<%--<uc1:m_leftcategory id="m_leftcategory" runat="server">
                                                            </uc1:m_leftcategory>--%>

		<div class="col large-12">
		<div class="shop-container">
		<div class="woocommerce-notices-wrapper"></div>
        <div class="products row row-small large-columns-5 medium-columns-5 small-columns-2">
            <asp:Repeater runat="server" ID="plistproducts"  OnItemDataBound="plistpro_ItemDataBound">
                <ItemTemplate>
                    <div class="product-small col has-hover product type-product post-5433 status-publish first instock product_cat-quan-ao-bao-ho-y-te has-post-thumbnail shipping-taxable product-type-simple">
             	       <div class="col-inner">
                        <div class="badge-container absolute left top z-1">
                        </div>
                    	<div class="product-small box ">
	          	             <div class="box-image">
			<div class="image-fade_in_back">
				<a href="detail.aspx?pid=<%#Eval("Id")%>" aria-label="<%#Eval("NameVi")%>">
					<img width="500" height="500" src="../resources/products/500_<%#Eval("Picture")%>" 
                        class="attachment-woocommerce_thumbnail size-woocommerce_thumbnail" title="<%#Eval("NameVi")%>" alt="<%#Eval("NameVi")%>"  
					     data-lazy-srcset="../resources/products/500_<%#Eval("Picture")%> 500w, 
                        ../resources/products/100_<%#Eval("Picture")%> 100w, 
                        ../resources/products/300_<%#Eval("Picture")%> 300w,
                        ../resources/products/150_<%#Eval("Picture")%> 150w,
                        ../resources/products/600_<%#Eval("Picture")%> 600w" 
                        data-lazy-sizes="(max-width: 500px) 100vw, 500px" 
                        data-lazy-src="../resources/products/<%#Eval("Picture")%>" />
                        <noscript>
                           <img width="500" height="500" src="../resources/products/<%#Eval("Picture")%>" class="attachment-woocommerce_thumbnail size-woocommerce_thumbnail" alt="nopicture" decoding="async" 
                           srcset="../resources/products/500_<%#Eval("Picture")%>, 
                           ../resources/products/100_<%#Eval("Picture")%> 100w,
                           ../resources/products/300_<%#Eval("Picture")%> 300w,
                           ../resources/products/150_<%#Eval("Picture")%> 150w,
                           ../resources/products/600_<%#Eval("Picture")%> 600w" sizes="(max-width: 500px) 100vw, 500px" />
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
			<div class="title-wrapper center">
			    <p class="name product-title woocommerce-loop-product__title" style="text-transform: uppercase;font-weight: bold;text-align: center">
			        <a href="detail.aspx?pid=<%#Eval("Id")%>" class="woocommerce-LoopProduct-link woocommerce-loop-product__link">
			             <%#Eval("NameVi")%>
			        </a>
			    </p>
			</div>
                <%--<div class="price-wrapper">
                   <span class="product-price is-bold" style="color: #0000ff">
                       <%#Eval("Price")%>
                       <asp:Label runat="server" ID="labelprice"></asp:Label>
                   </span>
                  
                </div>	--%>
                <div class="price-wrapper" style="display: none">
                                <span class="price product-price">
                                 <span class="price">
                                     <asp:Panel ID="panelsaleprice" runat="server">
                                     <INS><span class="woocommerce-Price-amount amount">
                                                     <asp:Label runat="server" ID="labelpricesale"></asp:Label>
                                                <span class="woocommerce-Price-currencySymbol">vnđ</span>
                                                 </span>
                                     </INS>
                                      </asp:Panel>
                                       <asp:Panel ID="panelprice" runat="server">
                                     <DEL><span class="woocommerce-Price-amount amount">
                                            <asp:Label runat="server" ID="labelprices"></asp:Label>
                                    <span class="woocommerce-Price-currencySymbol">vnđ</span>
                                                 </span>
                                     </DEL> 
                                      </asp:Panel>
                                        
                                 </span>
                               </span>
                            </div>
                            <div class="add_to_cart_button center" style="display: none">
                <asp:Button runat="server" ID="btnadd" CssClass="single_add_to_cart_button button alt"
            CommandArgument='<%# Eval("id") %>' 
            Text="Đạt hàng" />
            </div>	
            </div>
            
	                      </div>
		               </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            </div><!-- row -->
		</div><!-- shop container -->
        <div style="text-align: right;padding-right: 20px">
             <cc1:CollectionPager id="CollectionPager1" LabelText="Page" runat="server" BackNextDisplay="HyperLinks"
                                    BackNextLocation="Right" BackText="« trước" FirstText="đầu tiên" ShowFirstLast="True"
                                    ResultsLocation="Top" LastText="cuối cùng" PageSize="20" NextText="kế tiếp »" PagingMode="QueryString" MaxPages="100" ResultsFormat="Hiển thị  {0}-{1} (của {2} )">
              </cc1:CollectionPager>
        </div>
        	</div>
    </div>
</main>
</asp:Content>
