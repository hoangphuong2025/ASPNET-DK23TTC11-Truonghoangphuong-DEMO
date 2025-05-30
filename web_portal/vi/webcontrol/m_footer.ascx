﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="m_footer.ascx.cs" Inherits="web_portal.vi.webcontrol.m_footer" %>
	
<!-- FOOTER 1 -->

<!-- FOOTER 2 -->
<div class="footer-widgets footer footer-2 dark">
		<div class="row dark large-columns-3 mb-0">
	   		<div id="text-7" class="col pb-0 widget widget_text">
	   		    <span class="widget-title" style="color:#ffffff">Susu</span>
                <div class="is-divider small"></div>
                <div class="textwidget">
                   <p>SuSu specializes in providing high quality solutions, products and a wide range of innovative laboratory equipment for numerous applications in research and development</p>
              </div>
		</div>
        <div id="text-5" class="col pb-0 widget widget_text">
            <span class="widget-title">Contact</span>
            <div class="is-divider small"></div>
            <asp:Repeater runat="server" ID="plistintro">
                <ItemTemplate>
                    <div class="textwidget">
            			      <p><strong>Address&nbsp;&nbsp;:&nbsp;&nbsp;</strong>&nbsp;&nbsp;<%#Eval("AddressVi")%> <br>
                                <strong>Hotline&nbsp;&nbsp;:&nbsp;&nbsp;</strong>&nbsp;&nbsp;<%#Eval("Description")%>  <br>
                                <strong>Email&nbsp;&nbsp;:&nbsp;&nbsp;</strong>&nbsp;&nbsp;<%#Eval("Email")%> 
                               </p>
                            </div>
                </ItemTemplate>
            </asp:Repeater>
            			
		</div>
          <div id="nav_menu-7" class="col pb-0 widget widget_nav_menu">
		          <span class="widget-title">Category</span>
                   <div class="is-divider small"></div>
                   <div class="menu-danh-muc-san-pham-container">
                    <ul id="menu-danh-muc-san-pham" class="menu">
                   <asp:Repeater runat="server" ID="plistsub">
                       <ItemTemplate>
                           <li id="menu-item-5302" class="menu-item menu-item-type-taxonomy menu-item-object-product_cat menu-item-5302">
                             <a href="category.aspx?pid=<%#Eval("CategoryId")%>"><%#Eval("NameVi")%></a>
                          </li>
                       </ItemTemplate>
                   </asp:Repeater>
               </ul>
           </div>
           </div>        
		</div>
</div>



<div class="absolute-footer dark medium-text-center small-text-center">
  <div class="container clearfix">

          <div class="footer-secondary pull-right">
                  <div class="footer-text inline-block small-block">
            <div class="icon-f">
<ul>
    <asp:Repeater runat="server" ID="plistsocial">
        <ItemTemplate>
            <li><a href="#">
                    <i class="fab fa-facebook-f"></i>
                </a></li>
        </ItemTemplate>
    </asp:Repeater>

<%--<li><a href="#"><i class="fab fa-youtube"></i></a></li>
<li><a href="#"><i class="fab fa-google-plus-g"></i></a></li>
<li><a href="#"><i class="fab fa-twitter"></i></a></li>--%>
</ul>
</div>          </div>
                      </div>
    
    <div class="footer-primary pull-left">
            <div class="copyright-footer">
        Copyright © 2025 nuocda.com      </div>
          </div>
  </div>
</div>

<%--<a href="#top" class="back-to-top button icon invert plain fixed bottom z-1 is-outline round hide-for-medium active" id="top-link" aria-label="Go to top"><i class="icon-angle-up"></i>
<a href="#top" class="back-to-top button icon invert plain fixed bottom z-1 is-outline round hide-for-medium" id="A1" aria-label="Go to top"><i class="icon-angle-up" ></i></a>--%>
<%--</a>--%>