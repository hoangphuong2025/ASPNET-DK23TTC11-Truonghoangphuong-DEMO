<%@ Page Title="" Language="C#" MasterPageFile="~/SitePro.Master" AutoEventWireup="true" CodeBehind="category.aspx.cs" Inherits="web_portal.vi.category" %>
<%@ Register Src="~/vi/webcontrol/m_leftcategory.ascx" TagName="m_leftcategory" TagPrefix="uc1" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  

<main id="main" class="">
<div class="row category-page-row">

		<uc1:m_leftcategory id="m_leftcategory" runat="server">
                                                            </uc1:m_leftcategory>

		<div class="col large-9">
		<div class="shop-container">
		
		<div class="woocommerce-notices-wrapper"></div>
        <div class="products row row-small large-columns-3 medium-columns-3 small-columns-2">
            <asp:Repeater runat="server" ID="plistproducts">
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
                        class="attachment-woocommerce_thumbnail size-woocommerce_thumbnail" alt="<%#Eval("NameVi")%>"  
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
			<div class="title-wrapper">
			    <p class="name product-title woocommerce-loop-product__title">
			        <a href="detail.aspx?pid=<%#Eval("Id")%>" class="woocommerce-LoopProduct-link woocommerce-loop-product__link">
			             <%#Eval("NameVi")%>
			        </a>
			    </p>
			</div>
                <div class="price-wrapper">
                </div>		
            </div>
	                      </div>
		               </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            </div><!-- row -->
		</div>
        <div style="text-align: right;padding-right: 20px">
             <cc1:CollectionPager id="CollectionPager1" LabelText="Page" runat="server" BackNextDisplay="HyperLinks"
                                    BackNextLocation="Right" BackText="« Pre" FirstText="First" ShowFirstLast="True"
                                    ResultsLocation="Top" LastText="End" PageSize="8" NextText="Next »" PagingMode="QueryString" MaxPages="100" ResultsFormat="Display {0}-{1} (of {2} )">
              </cc1:CollectionPager>
        </div>
        <!-- shop container -->		</div>
    </div>
</main>
</asp:Content>
