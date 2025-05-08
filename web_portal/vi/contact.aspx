<%@ Page Title="Cafe Phương" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="web_portal.vi.contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div id="content" class="content-area page-wrapper" role="main">
	<div class="row row-main">
		<div class="large-12 col">
			<div class="col-inner">
						<div class="row"  id="row-1354664780">

        <div id="col-211867600" class="col wrap-lien-he medium-6 small-12 large-6"  >
				<div class="col-inner"  >
			<asp:Repeater runat="server" ID="plistintro">
    <ItemTemplate>
<p><strong><%#Eval("NameVi")%></strong></p>
<p><strong>Địa chỉ:</strong> <%#Eval("AddressVi")%><br />

<strong>Hotline:</strong> <%#Eval("Tel")%><br />
<strong>Email:</strong> <%#Eval("Email")%></p>
</ItemTemplate>
</asp:Repeater>
		</div>
        <div>
            <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.4728023386638!2d106.76784119999999!3d10.775053999999999!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x317525d28630d467%3A0xbd5ee8d77777c535!2zNzIyIE5ndXnhu4VuIFRo4buLIMSQ4buLbmgsIFBoxrDhu51uZyBUaOG6oW5oIE3hu7kgTOG7o2ksIFRo4bunIMSQ4bupYywgSOG7kyBDaMOtIE1pbmg!5e0!3m2!1svi!2s!4v1744276231313!5m2!1svi!2s" width="600" height="450" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
        </div>
       
        					</div>
    
    
	<div id="col-853241620" class="col medium-6 small-12 large-6">
	  
		<div class="section-content relative">
			
<div class="row h-sp" id="row-1103555160">
				<div class="col-inner" style="top: -40px;">
<div class="container section-title-container" >
    <h5 class="section-title section-title-center">
    <span class="section-title-main" >Liên hệ với chúng tôi</span></h5>
</div>
		</div>
	
</div>
<div class="row" id="row-106910523">

	<div id="col-2016597387">
				<div class="col-inner">
			
			
<style type="text/css">.super-form-5262 > * {visibility:hidden;}</style>
<div id="super-form-5262" style="margin: 0px;" class="super-form super-form-5262 style-default super-default-rounded super-field-size-huge super-adaptive super-rendered super-second-responsiveness super-window-third-responsiveness super-initialized" data-hide="true" data-field-size="huge">
    
     <input type="hidden" name="super_ajax_nonce" value="38c4384564">
      <input type="text" name="super_hp" size="25" value="">
      <div class="super-shortcode super-field super-hidden" data-super-tab-index="0">
      <input class="super-shortcode-field" type="hidden" value="5262" name="hidden_form_id">
      </div>
      <div class="super-grid super-shortcode">
          <div class="super-shortcode super_one_half super-column column-number-1 grid-level-0 first-column ">
                                                  <div class="super-shortcode super-field super-text  super-ungrouped  " data-super-tab-index="1">
                                                      <div class="super-field-wrapper ">
                                                                                                                                                      <input class="super-shortcode-field" type="text" name="name" data-email="Họ tên:" data-absolute-default="" data-default-value=""><span class="super-adaptive-placeholder" data-placeholder="Full name" data-placeholderfilled="Full name"></span>
                                                                                                                                                  </div>
                                                      <div class="super-error-msg">Field is required!</div>
                                                  </div>
                                              </div>
          <div class="super-shortcode super_one_half super-column column-number-2 grid-level-0  ">
          <div class="super-shortcode super-field super-text  super-ungrouped  " data-super-tab-index="2">
                                                            <div class="super-field-wrapper "><input class="super-shortcode-field" type="tel" name="phonenumber" data-validation="phone" data-email="Tel:" data-absolute-default="" data-default-value="">
                                                        <span class="super-adaptive-placeholder" data-placeholder="Tel" data-placeholderfilled="Điện thoại"></span></div>
                                                        <div class="super-error-msg">Field is required!</div>
                                                        </div>
        </div>
      </div>
      <div class="super-grid super-shortcode">
                                                        <div class="super-shortcode super_one_half super-column column-number-1 grid-level-0 first-column ">
                                                            <div class="super-shortcode super-field super-text  super-ungrouped  " data-super-tab-index="3">
                                                                <div class="super-field-wrapper ">
                                                                    <input class="super-shortcode-field" type="email" name="email" data-validation="email" data-email="Email:" data-absolute-default="" data-default-value="">
                                                                    <span class="super-adaptive-placeholder" data-placeholder="E-mail" data-placeholderfilled="E-mail"></span>
                                                                </div>
                                                                <div class="super-error-msg">Field is required!</div>
                                                            </div>
                                                        </div>
                                                        <div class="super-shortcode super_one_half super-column column-number-2 grid-level-0  ">
                                                            <div class="super-shortcode super-field super-dropdown  super-ungrouped  " data-super-tab-index="4">
                                                        <div class="super-error-msg">Field is required!</div>
                                                        </div
                                                        >
                                                        </div>
                                                    </div>
      <div class="super-grid super-shortcode">
                                                              <div class="super-shortcode super_one_full super-column column-number-1 grid-level-0 first-column ">
                                                                  <div class="super-shortcode super-field super-textarea  super-ungrouped  " data-super-tab-index="5"><div class="super-field-wrapper "><textarea class="super-shortcode-field" name="question" data-email="Lời nhắn:" data-absolute-default="" data-default-value=""></textarea><span class="super-adaptive-placeholder" data-placeholder="Lời nhắn cho chúng tôi..." data-placeholderfilled="Lời nhắn"></span></div><div class="super-error-msg">Field is required!</div></div>
                                                              </div>
                                                          </div>
      <div data-color="#33af6c" data-light="#47c380" data-dark="#15914e" data-hover-color="#f5983e" data-hover-light="#ffac52" data-hover-dark="#d77a20" data-font="#ffffff" data-font-hover="#ffffff" data-radius="rounded" data-type="flat" class="super-extra-shortcode super-shortcode super-field super-form-button super-clear-none super-button super-radius-rounded super-type-flat super-button-large super-button-align-center super-button-width-fullwidth super-button-icon-option-right super-button-icon-visibility-visible" data-super-tab-index="6"><div data-href="" class="super-button-wrap no_link" style="background-color: rgb(51, 153, 255);"><div class="super-button-name" data-action="submit" data-normal="Send to Us" data-loading="Đang gửi..." style="color: rgb(255, 255, 255);">Gởi cho chúng tôi<i class="fas fa-arrow-right" style="color: rgb(255, 255, 255);"></i></div><span class="super-after"></span></div></div>
     
      <span class="super-load-icon"></span>
</div>
		</div>
					</div>
	

	
</div>
		</div>
		
<style>
#section_634801570 {
  padding-top: 10px;
  padding-bottom: 10px;
}
#section_634801570 .section-bg-overlay {
  background-color: rgba(30, 155, 77, 0);
}
#section_634801570 .section-bg.bg-loaded {
  background-image: url(../styles/images/Rectangle-7-1.png);
}
#section_634801570 .section-bg {
  background-position: center;
}
</style>
</div>
	</div>
		</div>
	</div>
  
</div>
</div>

</asp:Content>
