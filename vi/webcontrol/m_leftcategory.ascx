<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="m_leftcategory.ascx.cs" Inherits="web_portal.vi.webcontrol.m_leftcategory" %>
<div class="col large-3 hide-for-medium ">
						<div id="shop-sidebar" class="sidebar-inner col-inner">
				<aside id="woocommerce_product_categories-2" class="widget woocommerce widget_product_categories">
				      <span class="widget-title shop-sidebar">
				          Danh mục sản phẩm
				      </span>
                      <div class="is-divider small"></div>
                          <ul class="product-categories">
                          <asp:Repeater runat="server" ID="plistcategory" OnItemDataBound="plistcategory_OnItemDataBound">
                              <ItemTemplate>
                                <li class="cat-item cat-item-6<%#Container.ItemIndex+1 %> current-cat cat-parent">
                                    <a href="category.aspx?pid=<%#Eval("CategoryId")%>">
                                        &nbsp;<%#Eval("NameVi")%>
                                    </a>
                                    <ul class='children'>
                                        <asp:Repeater runat="server" ID="plistsub">
                                            <ItemTemplate>
                                                <li class="cat-item cat-item-9<%#Container.ItemIndex+1 %>">
                                                    <a href="subcategory.aspx?pid=<%#Eval("CategoryId")%>">
                                                       <%#Eval("NameVi")%>
                                                    </a>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        
                                    </ul>
                                 </li>
                              </ItemTemplate>
                          </asp:Repeater>
                       
                     </ul>
                     <%--<span class="widget-title shop-sidebar">
				          Partner
				      </span>--%>
                      <div class="is-divider small"></div>
                          <ul class="product-categories" style="display: none">
                          <asp:Repeater runat="server" ID="plistsp">
                              <ItemTemplate>
                                <li class="cat-item cat-item-6<%#Container.ItemIndex+1 %> current-cat cat-parent">
                                    <a href="partner.aspx?pid=<%#Eval("ServiceProviderId")%>">
                                        &nbsp;<%#Eval("CompanyNameVi")%>
                                    </a>
                                 </li>
                              </ItemTemplate>
                          </asp:Repeater>
                       
                     </ul>
				</aside>
             </div>
			</div>
            
         