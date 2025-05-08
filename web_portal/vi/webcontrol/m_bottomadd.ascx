<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="m_bottomadd.ascx.cs" Inherits="web_portal.vi.webcontrol.m_bottomadd" %>
  
<!-- Root element of PhotoSwipe. Must have class pswp. -->
<div class="pswp" tabindex="-1" role="dialog" aria-hidden="true">

	<!-- Background of PhotoSwipe. It's a separate element as animating opacity is faster than rgba(). -->
	<div class="pswp__bg"></div>

	<!-- Slides wrapper with overflow:hidden. -->
	<div class="pswp__scroll-wrap">

		<!-- Container that holds slides.
		PhotoSwipe keeps only 3 of them in the DOM to save memory.
		Don't modify these 3 pswp__item elements, data is added later on. -->
		<div class="pswp__container">
			<div class="pswp__item"></div>
			<div class="pswp__item"></div>
			<div class="pswp__item"></div>
		</div>

		<!-- Default (PhotoSwipeUI_Default) interface on top of sliding area. Can be changed. -->
		<div class="pswp__ui pswp__ui--hidden">

			<div class="pswp__top-bar">

				<!--  Controls are self-explanatory. Order can be changed. -->

				<div class="pswp__counter"></div>

				<button class="pswp__button pswp__button--close" aria-label="Đóng (Esc)"></button>

				<button class="pswp__button pswp__button--zoom" aria-label="Phóng to/ thu nhỏ"></button>

				<div class="pswp__preloader">
					<div class="loading-spin"></div>
				</div>
			</div>

			<div class="pswp__share-modal pswp__share-modal--hidden pswp__single-tap">
				<div class="pswp__share-tooltip"></div>
			</div>

			<button class="pswp__button--arrow--left" aria-label="Ảnh trước (mũi tên trái)"></button>

			<button class="pswp__button--arrow--right" aria-label="Ảnh tiếp (mũi tên phải)"></button>

			<div class="pswp__caption">
				<div class="pswp__caption__center"></div>
			</div>

		</div>

	</div>

</div>
	
	<style id='global-styles-inline-css' type='text/css'>
body{--wp--preset--color--black: #000000;--wp--preset--color--cyan-bluish-gray: #abb8c3;--wp--preset--color--white: #ffffff;--wp--preset--color--pale-pink: #f78da7;--wp--preset--color--vivid-red: #cf2e2e;--wp--preset--color--luminous-vivid-orange: #ff6900;--wp--preset--color--luminous-vivid-amber: #fcb900;--wp--preset--color--light-green-cyan: #7bdcb5;--wp--preset--color--vivid-green-cyan: #00d084;--wp--preset--color--pale-cyan-blue: #8ed1fc;--wp--preset--color--vivid-cyan-blue: #0693e3;--wp--preset--color--vivid-purple: #9b51e0;--wp--preset--gradient--vivid-cyan-blue-to-vivid-purple: linear-gradient(135deg,rgba(6,147,227,1) 0%,rgb(155,81,224) 100%);--wp--preset--gradient--light-green-cyan-to-vivid-green-cyan: linear-gradient(135deg,rgb(122,220,180) 0%,rgb(0,208,130) 100%);--wp--preset--gradient--luminous-vivid-amber-to-luminous-vivid-orange: linear-gradient(135deg,rgba(252,185,0,1) 0%,rgba(255,105,0,1) 100%);--wp--preset--gradient--luminous-vivid-orange-to-vivid-red: linear-gradient(135deg,rgba(255,105,0,1) 0%,rgb(207,46,46) 100%);--wp--preset--gradient--very-light-gray-to-cyan-bluish-gray: linear-gradient(135deg,rgb(238,238,238) 0%,rgb(169,184,195) 100%);--wp--preset--gradient--cool-to-warm-spectrum: linear-gradient(135deg,rgb(74,234,220) 0%,rgb(151,120,209) 20%,rgb(207,42,186) 40%,rgb(238,44,130) 60%,rgb(251,105,98) 80%,rgb(254,248,76) 100%);--wp--preset--gradient--blush-light-purple: linear-gradient(135deg,rgb(255,206,236) 0%,rgb(152,150,240) 100%);--wp--preset--gradient--blush-bordeaux: linear-gradient(135deg,rgb(254,205,165) 0%,rgb(254,45,45) 50%,rgb(107,0,62) 100%);--wp--preset--gradient--luminous-dusk: linear-gradient(135deg,rgb(255,203,112) 0%,rgb(199,81,192) 50%,rgb(65,88,208) 100%);--wp--preset--gradient--pale-ocean: linear-gradient(135deg,rgb(255,245,203) 0%,rgb(182,227,212) 50%,rgb(51,167,181) 100%);--wp--preset--gradient--electric-grass: linear-gradient(135deg,rgb(202,248,128) 0%,rgb(113,206,126) 100%);--wp--preset--gradient--midnight: linear-gradient(135deg,rgb(2,3,129) 0%,rgb(40,116,252) 100%);--wp--preset--font-size--small: 13px;--wp--preset--font-size--medium: 20px;--wp--preset--font-size--large: 36px;--wp--preset--font-size--x-large: 42px;--wp--preset--spacing--20: 0.44rem;--wp--preset--spacing--30: 0.67rem;--wp--preset--spacing--40: 1rem;--wp--preset--spacing--50: 1.5rem;--wp--preset--spacing--60: 2.25rem;--wp--preset--spacing--70: 3.38rem;--wp--preset--spacing--80: 5.06rem;--wp--preset--shadow--natural: 6px 6px 9px rgba(0, 0, 0, 0.2);--wp--preset--shadow--deep: 12px 12px 50px rgba(0, 0, 0, 0.4);--wp--preset--shadow--sharp: 6px 6px 0px rgba(0, 0, 0, 0.2);--wp--preset--shadow--outlined: 6px 6px 0px -3px rgba(255, 255, 255, 1), 6px 6px rgba(0, 0, 0, 1);--wp--preset--shadow--crisp: 6px 6px 0px rgba(0, 0, 0, 1);}:where(.is-layout-flex){gap: 0.5em;}:where(.is-layout-grid){gap: 0.5em;}body .is-layout-flow > .alignleft{float: left;margin-inline-start: 0;margin-inline-end: 2em;}body .is-layout-flow > .alignright{float: right;margin-inline-start: 2em;margin-inline-end: 0;}body .is-layout-flow > .aligncenter{margin-left: auto !important;margin-right: auto !important;}body .is-layout-constrained > .alignleft{float: left;margin-inline-start: 0;margin-inline-end: 2em;}body .is-layout-constrained > .alignright{float: right;margin-inline-start: 2em;margin-inline-end: 0;}body .is-layout-constrained > .aligncenter{margin-left: auto !important;margin-right: auto !important;}body .is-layout-constrained > :where(:not(.alignleft):not(.alignright):not(.alignfull)){max-width: var(--wp--style--global--content-size);margin-left: auto !important;margin-right: auto !important;}body .is-layout-constrained > .alignwide{max-width: var(--wp--style--global--wide-size);}body .is-layout-flex{display: flex;}body .is-layout-flex{flex-wrap: wrap;align-items: center;}body .is-layout-flex > *{margin: 0;}body .is-layout-grid{display: grid;}body .is-layout-grid > *{margin: 0;}:where(.wp-block-columns.is-layout-flex){gap: 2em;}:where(.wp-block-columns.is-layout-grid){gap: 2em;}:where(.wp-block-post-template.is-layout-flex){gap: 1.25em;}:where(.wp-block-post-template.is-layout-grid){gap: 1.25em;}.has-black-color{color: var(--wp--preset--color--black) !important;}.has-cyan-bluish-gray-color{color: var(--wp--preset--color--cyan-bluish-gray) !important;}.has-white-color{color: var(--wp--preset--color--white) !important;}.has-pale-pink-color{color: var(--wp--preset--color--pale-pink) !important;}.has-vivid-red-color{color: var(--wp--preset--color--vivid-red) !important;}.has-luminous-vivid-orange-color{color: var(--wp--preset--color--luminous-vivid-orange) !important;}.has-luminous-vivid-amber-color{color: var(--wp--preset--color--luminous-vivid-amber) !important;}.has-light-green-cyan-color{color: var(--wp--preset--color--light-green-cyan) !important;}.has-vivid-green-cyan-color{color: var(--wp--preset--color--vivid-green-cyan) !important;}.has-pale-cyan-blue-color{color: var(--wp--preset--color--pale-cyan-blue) !important;}.has-vivid-cyan-blue-color{color: var(--wp--preset--color--vivid-cyan-blue) !important;}.has-vivid-purple-color{color: var(--wp--preset--color--vivid-purple) !important;}.has-black-background-color{background-color: var(--wp--preset--color--black) !important;}.has-cyan-bluish-gray-background-color{background-color: var(--wp--preset--color--cyan-bluish-gray) !important;}.has-white-background-color{background-color: var(--wp--preset--color--white) !important;}.has-pale-pink-background-color{background-color: var(--wp--preset--color--pale-pink) !important;}.has-vivid-red-background-color{background-color: var(--wp--preset--color--vivid-red) !important;}.has-luminous-vivid-orange-background-color{background-color: var(--wp--preset--color--luminous-vivid-orange) !important;}.has-luminous-vivid-amber-background-color{background-color: var(--wp--preset--color--luminous-vivid-amber) !important;}.has-light-green-cyan-background-color{background-color: var(--wp--preset--color--light-green-cyan) !important;}.has-vivid-green-cyan-background-color{background-color: var(--wp--preset--color--vivid-green-cyan) !important;}.has-pale-cyan-blue-background-color{background-color: var(--wp--preset--color--pale-cyan-blue) !important;}.has-vivid-cyan-blue-background-color{background-color: var(--wp--preset--color--vivid-cyan-blue) !important;}.has-vivid-purple-background-color{background-color: var(--wp--preset--color--vivid-purple) !important;}.has-black-border-color{border-color: var(--wp--preset--color--black) !important;}.has-cyan-bluish-gray-border-color{border-color: var(--wp--preset--color--cyan-bluish-gray) !important;}.has-white-border-color{border-color: var(--wp--preset--color--white) !important;}.has-pale-pink-border-color{border-color: var(--wp--preset--color--pale-pink) !important;}.has-vivid-red-border-color{border-color: var(--wp--preset--color--vivid-red) !important;}.has-luminous-vivid-orange-border-color{border-color: var(--wp--preset--color--luminous-vivid-orange) !important;}.has-luminous-vivid-amber-border-color{border-color: var(--wp--preset--color--luminous-vivid-amber) !important;}.has-light-green-cyan-border-color{border-color: var(--wp--preset--color--light-green-cyan) !important;}.has-vivid-green-cyan-border-color{border-color: var(--wp--preset--color--vivid-green-cyan) !important;}.has-pale-cyan-blue-border-color{border-color: var(--wp--preset--color--pale-cyan-blue) !important;}.has-vivid-cyan-blue-border-color{border-color: var(--wp--preset--color--vivid-cyan-blue) !important;}.has-vivid-purple-border-color{border-color: var(--wp--preset--color--vivid-purple) !important;}.has-vivid-cyan-blue-to-vivid-purple-gradient-background{background: var(--wp--preset--gradient--vivid-cyan-blue-to-vivid-purple) !important;}.has-light-green-cyan-to-vivid-green-cyan-gradient-background{background: var(--wp--preset--gradient--light-green-cyan-to-vivid-green-cyan) !important;}.has-luminous-vivid-amber-to-luminous-vivid-orange-gradient-background{background: var(--wp--preset--gradient--luminous-vivid-amber-to-luminous-vivid-orange) !important;}.has-luminous-vivid-orange-to-vivid-red-gradient-background{background: var(--wp--preset--gradient--luminous-vivid-orange-to-vivid-red) !important;}.has-very-light-gray-to-cyan-bluish-gray-gradient-background{background: var(--wp--preset--gradient--very-light-gray-to-cyan-bluish-gray) !important;}.has-cool-to-warm-spectrum-gradient-background{background: var(--wp--preset--gradient--cool-to-warm-spectrum) !important;}.has-blush-light-purple-gradient-background{background: var(--wp--preset--gradient--blush-light-purple) !important;}.has-blush-bordeaux-gradient-background{background: var(--wp--preset--gradient--blush-bordeaux) !important;}.has-luminous-dusk-gradient-background{background: var(--wp--preset--gradient--luminous-dusk) !important;}.has-pale-ocean-gradient-background{background: var(--wp--preset--gradient--pale-ocean) !important;}.has-electric-grass-gradient-background{background: var(--wp--preset--gradient--electric-grass) !important;}.has-midnight-gradient-background{background: var(--wp--preset--gradient--midnight) !important;}.has-small-font-size{font-size: var(--wp--preset--font-size--small) !important;}.has-medium-font-size{font-size: var(--wp--preset--font-size--medium) !important;}.has-large-font-size{font-size: var(--wp--preset--font-size--large) !important;}.has-x-large-font-size{font-size: var(--wp--preset--font-size--x-large) !important;}
</style>
<script  data-rocket-type='text/javascript' src='https://truongthinhphatholding.com.vn/wp-content/plugins/woocommerce/assets/js/jquery-blockui/jquery.blockUI.min.js?ver=2.7.0-wc.8.0.3' id='jquery-blockui-js' defer></script>
<script type='text/javascript' id='wc-add-to-cart-js-extra'>
/* <![CDATA[ */
var wc_add_to_cart_params = {"ajax_url":"\/wp-admin\/admin-ajax.php","wc_ajax_url":"\/?wc-ajax=%%endpoint%%","i18n_view_cart":"Xem gi\u1ecf h\u00e0ng","cart_url":"https:\/\/truongthinhphatholding.com.vn\/vi\/gio-hang\/","is_cart":"","cart_redirect_after_add":"no"};
/* ]]> */
</script>
<script type="rocketlazyloadscript" data-rocket-type='text/javascript' src='https://truongthinhphatholding.com.vn/wp-content/plugins/woocommerce/assets/js/frontend/add-to-cart.min.js?ver=8.0.3' id='wc-add-to-cart-js' defer></script>
<script type='text/javascript' src='https://truongthinhphatholding.com.vn/wp-content/plugins/woocommerce/assets/js/photoswipe/photoswipe.min.js?ver=4.1.1-wc.8.0.3' id='photoswipe-js' defer></script>
<script type='text/javascript' src='https://truongthinhphatholding.com.vn/wp-content/plugins/woocommerce/assets/js/photoswipe/photoswipe-ui-default.min.js?ver=4.1.1-wc.8.0.3' id='photoswipe-ui-default-js' defer></script>
<script type='text/javascript' id='wc-single-product-js-extra'>
/* <![CDATA[ */
var wc_single_product_params = {"i18n_required_rating_text":"Vui l\u00f2ng ch\u1ecdn m\u1ed9t m\u1ee9c \u0111\u00e1nh gi\u00e1","review_rating_required":"no","flexslider":{"rtl":false,"animation":"slide","smoothHeight":true,"directionNav":false,"controlNav":"thumbnails","slideshow":false,"animationSpeed":500,"animationLoop":false,"allowOneSlide":false},"zoom_enabled":"","zoom_options":[],"photoswipe_enabled":"1","photoswipe_options":{"shareEl":false,"closeOnScroll":false,"history":false,"hideAnimationDuration":0,"showAnimationDuration":0},"flexslider_enabled":""};
/* ]]> */
</script>
<script type='text/javascript' src='https://truongthinhphatholding.com.vn/wp-content/plugins/woocommerce/assets/js/frontend/single-product.min.js?ver=8.0.3' id='wc-single-product-js' defer></script>
<script type="rocketlazyloadscript" data-rocket-type='text/javascript' src='https://truongthinhphatholding.com.vn/wp-content/plugins/woocommerce/assets/js/js-cookie/js.cookie.min.js?ver=2.1.4-wc.8.0.3' id='js-cookie-js' defer></script>
<script type='text/javascript' id='woocommerce-js-extra'>
/* <![CDATA[ */
var woocommerce_params = {"ajax_url":"\/wp-admin\/admin-ajax.php","wc_ajax_url":"\/?wc-ajax=%%endpoint%%"};
/* ]]> */
</script>
<script type="rocketlazyloadscript" data-rocket-type='text/javascript' src='https://truongthinhphatholding.com.vn/wp-content/plugins/woocommerce/assets/js/frontend/woocommerce.min.js?ver=8.0.3' id='woocommerce-js' defer></script>
<script type="rocketlazyloadscript" id="rocket-browser-checker-js-after" data-rocket-type="text/javascript">
"use strict";var _createClass=function(){function defineProperties(target,props){for(var i=0;i<props.length;i++){var descriptor=props[i];descriptor.enumerable=descriptor.enumerable||!1,descriptor.configurable=!0,"value"in descriptor&&(descriptor.writable=!0),Object.defineProperty(target,descriptor.key,descriptor)}}return function(Constructor,protoProps,staticProps){return protoProps&&defineProperties(Constructor.prototype,protoProps),staticProps&&defineProperties(Constructor,staticProps),Constructor}}();function _classCallCheck(instance,Constructor){if(!(instance instanceof Constructor))throw new TypeError("Cannot call a class as a function")}var RocketBrowserCompatibilityChecker=function(){function RocketBrowserCompatibilityChecker(options){_classCallCheck(this,RocketBrowserCompatibilityChecker),this.passiveSupported=!1,this._checkPassiveOption(this),this.options=!!this.passiveSupported&&options}return _createClass(RocketBrowserCompatibilityChecker,[{key:"_checkPassiveOption",value:function(self){try{var options={get passive(){return!(self.passiveSupported=!0)}};window.addEventListener("test",null,options),window.removeEventListener("test",null,options)}catch(err){self.passiveSupported=!1}}},{key:"initRequestIdleCallback",value:function(){!1 in window&&(window.requestIdleCallback=function(cb){var start=Date.now();return setTimeout(function(){cb({didTimeout:!1,timeRemaining:function(){return Math.max(0,50-(Date.now()-start))}})},1)}),!1 in window&&(window.cancelIdleCallback=function(id){return clearTimeout(id)})}},{key:"isDataSaverModeOn",value:function(){return"connection"in navigator&&!0===navigator.connection.saveData}},{key:"supportsLinkPrefetch",value:function(){var elem=document.createElement("link");return elem.relList&&elem.relList.supports&&elem.relList.supports("prefetch")&&window.IntersectionObserver&&"isIntersecting"in IntersectionObserverEntry.prototype}},{key:"isSlowConnection",value:function(){return"connection"in navigator&&"effectiveType"in navigator.connection&&("2g"===navigator.connection.effectiveType||"slow-2g"===navigator.connection.effectiveType)}}]),RocketBrowserCompatibilityChecker}();
</script>
<script type='text/javascript' id='rocket-preload-links-js-extra'>
/* <![CDATA[ */
var RocketPreloadLinksConfig = {"excludeUris":"\/(.+\/)?feed\/?.+\/?|\/(?:.+\/)?embed\/|\/vi\/thanh-toan\/|\/vi\/gio-hang\/|\/vi\/tai-khoan\/|\/wc-api\/v(.*)|\/(index\\.php\/)?wp\\-json(\/.*|$)|\/wp-admin\/|\/logout\/","usesTrailingSlash":"1","imageExt":"jpg|jpeg|gif|png|tiff|bmp|webp|avif","fileExt":"jpg|jpeg|gif|png|tiff|bmp|webp|avif|php|pdf|html|htm","siteUrl":"https:\/\/truongthinhphatholding.com.vn","onHoverDelay":"100","rateThrottle":"3"};
/* ]]> */
</script>
<script type="rocketlazyloadscript" id="rocket-preload-links-js-after" data-rocket-type="text/javascript">
(function() {
"use strict";var r="function"==typeof Symbol&&"symbol"==typeof Symbol.iterator?function(e){return typeof e}:function(e){return e&&"function"==typeof Symbol&&e.constructor===Symbol&&e!==Symbol.prototype?"symbol":typeof e},e=function(){function i(e,t){for(var n=0;n<t.length;n++){var i=t[n];i.enumerable=i.enumerable||!1,i.configurable=!0,"value"in i&&(i.writable=!0),Object.defineProperty(e,i.key,i)}}return function(e,t,n){return t&&i(e.prototype,t),n&&i(e,n),e}}();function i(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}var t=function(){function n(e,t){i(this,n),this.browser=e,this.config=t,this.options=this.browser.options,this.prefetched=new Set,this.eventTime=null,this.threshold=1111,this.numOnHover=0}return e(n,[{key:"init",value:function(){!this.browser.supportsLinkPrefetch()||this.browser.isDataSaverModeOn()||this.browser.isSlowConnection()||(this.regex={excludeUris:RegExp(this.config.excludeUris,"i"),images:RegExp(".("+this.config.imageExt+")$","i"),fileExt:RegExp(".("+this.config.fileExt+")$","i")},this._initListeners(this))}},{key:"_initListeners",value:function(e){-1<this.config.onHoverDelay&&document.addEventListener("mouseover",e.listener.bind(e),e.listenerOptions),document.addEventListener("mousedown",e.listener.bind(e),e.listenerOptions),document.addEventListener("touchstart",e.listener.bind(e),e.listenerOptions)}},{key:"listener",value:function(e){var t=e.target.closest("a"),n=this._prepareUrl(t);if(null!==n)switch(e.type){case"mousedown":case"touchstart":this._addPrefetchLink(n);break;case"mouseover":this._earlyPrefetch(t,n,"mouseout")}}},{key:"_earlyPrefetch",value:function(t,e,n){var i=this,r=setTimeout(function(){if(r=null,0===i.numOnHover)setTimeout(function(){return i.numOnHover=0},1e3);else if(i.numOnHover>i.config.rateThrottle)return;i.numOnHover++,i._addPrefetchLink(e)},this.config.onHoverDelay);t.addEventListener(n,function e(){t.removeEventListener(n,e,{passive:!0}),null!==r&&(clearTimeout(r),r=null)},{passive:!0})}},{key:"_addPrefetchLink",value:function(i){return this.prefetched.add(i.href),new Promise(function(e,t){var n=document.createElement("link");n.rel="prefetch",n.href=i.href,n.onload=e,n.onerror=t,document.head.appendChild(n)}).catch(function(){})}},{key:"_prepareUrl",value:function(e){if(null===e||"object"!==(void 0===e?"undefined":r(e))||!1 in e||-1===["http:","https:"].indexOf(e.protocol))return null;var t=e.href.substring(0,this.config.siteUrl.length),n=this._getPathname(e.href,t),i={original:e.href,protocol:e.protocol,origin:t,pathname:n,href:t+n};return this._isLinkOk(i)?i:null}},{key:"_getPathname",value:function(e,t){var n=t?e.substring(this.config.siteUrl.length):e;return n.startsWith("/")||(n="/"+n),this._shouldAddTrailingSlash(n)?n+"/":n}},{key:"_shouldAddTrailingSlash",value:function(e){return this.config.usesTrailingSlash&&!e.endsWith("/")&&!this.regex.fileExt.test(e)}},{key:"_isLinkOk",value:function(e){return null!==e&&"object"===(void 0===e?"undefined":r(e))&&(!this.prefetched.has(e.href)&&e.origin===this.config.siteUrl&&-1===e.href.indexOf("?")&&-1===e.href.indexOf("#")&&!this.regex.excludeUris.test(e.href)&&!this.regex.images.test(e.href))}}],[{key:"run",value:function(){"undefined"!=typeof RocketPreloadLinksConfig&&new n(new RocketBrowserCompatibilityChecker({capture:!0,passive:!0}),RocketPreloadLinksConfig).init()}}]),n}();t.run();
}());
</script>
<script type="rocketlazyloadscript" data-rocket-type='text/javascript' src='https://truongthinhphatholding.com.vn/wp-includes/js/dist/vendor/wp-polyfill-inert.min.js?ver=3.1.2' id='wp-polyfill-inert-js' defer></script>
<script type="rocketlazyloadscript" data-rocket-type='text/javascript' src='https://truongthinhphatholding.com.vn/wp-includes/js/dist/vendor/regenerator-runtime.min.js?ver=0.13.11' id='regenerator-runtime-js' defer></script>
<script type="rocketlazyloadscript" data-rocket-type='text/javascript' src='https://truongthinhphatholding.com.vn/wp-includes/js/dist/vendor/wp-polyfill.min.js?ver=3.15.0' id='wp-polyfill-js'></script>
<script type="rocketlazyloadscript" data-rocket-type='text/javascript' src='https://truongthinhphatholding.com.vn/wp-includes/js/hoverIntent.min.js?ver=1.10.2' id='hoverIntent-js' defer></script>
<script type='text/javascript' id='flatsome-js-js-extra'>
/* <![CDATA[ */
var flatsomeVars = {"ajaxurl":"https:\/\/truongthinhphatholding.com.vn\/wp-admin\/admin-ajax.php","rtl":"","sticky_height":"70","assets_url":"https:\/\/truongthinhphatholding.com.vn\/wp-content\/themes\/flatsome\/assets\/js\/","lightbox":{"close_markup":"<button title=\"%title%\" type=\"button\" class=\"mfp-close\"><svg xmlns=\"http:\/\/www.w3.org\/2000\/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 24 24\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\" class=\"feather feather-x\"><line x1=\"18\" y1=\"6\" x2=\"6\" y2=\"18\"><\/line><line x1=\"6\" y1=\"6\" x2=\"18\" y2=\"18\"><\/line><\/svg><\/button>","close_btn_inside":false},"user":{"can_edit_pages":false},"i18n":{"mainMenu":"Main Menu"},"options":{"cookie_notice_version":"1","swatches_layout":false,"swatches_box_select_event":false,"swatches_box_behavior_selected":false,"swatches_box_update_urls":"1","swatches_box_reset":false,"swatches_box_reset_extent":false,"swatches_box_reset_time":300,"search_result_latency":"0"},"is_mini_cart_reveal":""};
/* ]]> */
</script>
<script type="rocketlazyloadscript" data-minify="1" data-rocket-type='text/javascript' src='https://truongthinhphatholding.com.vn/wp-content/cache/min/1/wp-content/themes/flatsome/assets/js/flatsome.js?ver=1658287185' id='flatsome-js-js' defer></script>
<script type="rocketlazyloadscript" data-minify="1" data-rocket-type='text/javascript' src='https://truongthinhphatholding.com.vn/wp-content/cache/min/1/wp-content/themes/flatsome/inc/integrations/wp-rocket/flatsome-wp-rocket.js?ver=1658287185' id='flatsome-wp-rocket-js' defer></script>
<script type="rocketlazyloadscript" data-minify="1" data-rocket-type='text/javascript' src='https://truongthinhphatholding.com.vn/wp-content/cache/min/1/wp-content/themes/flatsome/inc/extensions/flatsome-live-search/flatsome-live-search.js?ver=1658287185' id='flatsome-live-search-js' defer></script>
<script type="rocketlazyloadscript" data-minify="1" data-rocket-type='text/javascript' src='https://truongthinhphatholding.com.vn/wp-content/cache/min/1/wp-content/themes/flatsome/assets/js/woocommerce.js?ver=1658287185' id='flatsome-theme-woocommerce-js-js' defer></script>
<script type='text/javascript' id='zxcvbn-async-js-extra'>
/* <![CDATA[ */
var _zxcvbnSettings = {"src":"https:\/\/truongthinhphatholding.com.vn\/wp-includes\/js\/zxcvbn.min.js"};
/* ]]> */
</script>
<script type="rocketlazyloadscript" data-rocket-type='text/javascript' src='https://truongthinhphatholding.com.vn/wp-includes/js/zxcvbn-async.min.js?ver=1.0' id='zxcvbn-async-js' defer></script>
<script type="rocketlazyloadscript" data-rocket-type='text/javascript' src='https://truongthinhphatholding.com.vn/wp-includes/js/dist/hooks.min.js?ver=c6aec9a8d4e5a5d543a1' id='wp-hooks-js'></script>
<script type="rocketlazyloadscript" data-rocket-type='text/javascript' src='https://truongthinhphatholding.com.vn/wp-includes/js/dist/i18n.min.js?ver=7701b0c3857f914212ef' id='wp-i18n-js'></script>
<script type="rocketlazyloadscript" id="wp-i18n-js-after" data-rocket-type="text/javascript">
wp.i18n.setLocaleData( { 'text direction\u0004ltr': [ 'ltr' ] } );
</script>
<script type='text/javascript' id='password-strength-meter-js-extra'>
/* <![CDATA[ */
var pwsL10n = {"unknown":"M\u1eadt kh\u1ea9u m\u1ea1nh kh\u00f4ng x\u00e1c \u0111\u1ecbnh","short":"R\u1ea5t y\u1ebfu","bad":"Y\u1ebfu","good":"Trung b\u00ecnh","strong":"M\u1ea1nh","mismatch":"M\u1eadt kh\u1ea9u kh\u00f4ng kh\u1edbp"};
/* ]]> */
</script>
<script type="rocketlazyloadscript" data-rocket-type='text/javascript' id='password-strength-meter-js-translations'>
( function( domain, translations ) {
	var localeData = translations.locale_data[ domain ] || translations.locale_data.messages;
	localeData[""].domain = domain;
	wp.i18n.setLocaleData( localeData, domain );
} )( "default", {"translation-revision-date":"2023-07-15 15:29:09+0000","generator":"GlotPress\/4.0.0-alpha.4","domain":"messages","locale_data":{"messages":{"":{"domain":"messages","plural-forms":"nplurals=1; plural=0;","lang":"vi_VN"},"%1$s is deprecated since version %2$s! Use %3$s instead. Please consider writing more inclusive code.":["%1$s \u0111\u00e3 ng\u1eebng ho\u1ea1t \u0111\u1ed9ng t\u1eeb phi\u00ean b\u1ea3n %2$s! S\u1eed d\u1ee5ng thay th\u1ebf b\u1eb1ng %3$s."]}},"comment":{"reference":"wp-admin\/js\/password-strength-meter.js"}} );
</script>
<script type="rocketlazyloadscript" data-rocket-type='text/javascript' src='https://truongthinhphatholding.com.vn/wp-admin/js/password-strength-meter.min.js?ver=6.3.3' id='password-strength-meter-js' defer></script>
<script type='text/javascript' id='wc-password-strength-meter-js-extra'>
/* <![CDATA[ */
var wc_password_strength_meter_params = {"min_password_strength":"3","stop_checkout":"","i18n_password_error":"Vui l\u00f2ng nh\u1eadp m\u1eadt kh\u1ea9u kh\u00f3 h\u01a1n.","i18n_password_hint":"G\u1ee3i \u00fd: M\u1eadt kh\u1ea9u ph\u1ea3i c\u00f3 \u00edt nh\u1ea5t 12 k\u00fd t\u1ef1. \u0110\u1ec3 n\u00e2ng cao \u0111\u1ed9 b\u1ea3o m\u1eadt, s\u1eed d\u1ee5ng ch\u1eef in hoa, in th\u01b0\u1eddng, ch\u1eef s\u1ed1 v\u00e0 c\u00e1c k\u00fd t\u1ef1 \u0111\u1eb7c bi\u1ec7t nh\u01b0 ! \" ? $ % ^ & )."};
/* ]]> */
</script>
<script type="rocketlazyloadscript" data-rocket-type='text/javascript' src='https://truongthinhphatholding.com.vn/wp-content/plugins/woocommerce/assets/js/frontend/password-strength-meter.min.js?ver=8.0.3' id='wc-password-strength-meter-js' defer></script>
<script type="rocketlazyloadscript" data-rocket-type='text/javascript'>
(function() {
				var expirationDate = new Date();
				expirationDate.setTime( expirationDate.getTime() + 31536000 * 1000 );
				document.cookie = "pll_language=vi; expires=" + expirationDate.toUTCString() + "; path=/; secure; SameSite=Lax";
			}());
</script>
<script>    window.lazyLoadOptions = { elements_selector: "img[data-lazy-src],.rocket-lazyload,iframe[data-lazy-src]", data_src: "lazy-src", data_srcset: "lazy-srcset", data_sizes: "lazy-sizes", class_loading: "lazyloading", class_loaded: "lazyloaded", threshold: 300, callback_loaded: function (element) { if (element.tagName === "IFRAME" && element.dataset.rocketLazyload == "fitvidscompatible") { if (element.classList.contains("lazyloaded")) { if (typeof window.jQuery != "undefined") { if (jQuery.fn.fitVids) { jQuery(element).parent().fitVids() } } } } } }; window.addEventListener('LazyLoad::Initialized', function (e) {
        var lazyLoadInstance = e.detail.instance; if (window.MutationObserver) {
            var observer = new MutationObserver(function (mutations) {
                var image_count = 0; var iframe_count = 0; var rocketlazy_count = 0; mutations.forEach(function (mutation) {
                    for (i = 0; i < mutation.addedNodes.length; i++) {
                        if (typeof mutation.addedNodes[i].getElementsByTagName !== 'function') { continue }
                        if (typeof mutation.addedNodes[i].getElementsByClassName !== 'function') { continue }
                        images = mutation.addedNodes[i].getElementsByTagName('img'); is_image = mutation.addedNodes[i].tagName == "IMG"; iframes = mutation.addedNodes[i].getElementsByTagName('iframe'); is_iframe = mutation.addedNodes[i].tagName == "IFRAME"; rocket_lazy = mutation.addedNodes[i].getElementsByClassName('rocket-lazyload'); image_count += images.length; iframe_count += iframes.length; rocketlazy_count += rocket_lazy.length; if (is_image) { image_count += 1 }
                        if (is_iframe) { iframe_count += 1 }
                    }
                }); if (image_count > 0 || iframe_count > 0 || rocketlazy_count > 0) { lazyLoadInstance.update() }
            }); var b = document.getElementsByTagName("body")[0]; var config = { childList: !0, subtree: !0 }; observer.observe(b, config)
        }
    }, !1)</script><script data-no-minify="1" async src="https://truongthinhphatholding.com.vn/wp-content/plugins/wp-rocket/assets/js/lazyload/16.1/lazyload.min.js"></script><script>                                                                                                                                                                                  function lazyLoadThumb(e) { var t = '<img loading="lazy" data-lazy-src="https://i.ytimg.com/vi/ID/hqdefault.jpg" alt="" width="480" height="360"><noscript><img src="https://i.ytimg.com/vi/ID/hqdefault.jpg" alt="" width="480" height="360"></noscript>', a = '<div class="play"></div>'; return t.replace("ID", e) + a } function lazyLoadYoutubeIframe() { var e = document.createElement("iframe"), t = "ID?autoplay=1"; t += 0 === this.dataset.query.length ? '' : '&' + this.dataset.query; e.setAttribute("src", t.replace("ID", this.dataset.src)), e.setAttribute("frameborder", "0"), e.setAttribute("allowfullscreen", "1"), e.setAttribute("allow", "accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture"), this.parentNode.replaceChild(e, this) } document.addEventListener("DOMContentLoaded", function () { var e, t, a = document.getElementsByClassName("rll-youtube-player"); for (t = 0; t < a.length; t++) e = document.createElement("div"), e.setAttribute("data-id", a[t].dataset.id), e.setAttribute("data-query", a[t].dataset.query), e.setAttribute("data-src", a[t].dataset.src), e.innerHTML = lazyLoadThumb(a[t].dataset.id), e.onclick = lazyLoadYoutubeIframe, a[t].appendChild(e) });</script>
<script type="rocketlazyloadscript">"use strict";var wprRemoveCPCSS=function wprRemoveCPCSS(){var elem;document.querySelector('link[data-rocket-async="style"][rel="preload"]')?setTimeout(wprRemoveCPCSS,200):(elem=document.getElementById("rocket-critical-css"))&&"remove"in elem&&elem.remove()};window.addEventListener?window.addEventListener("load",wprRemoveCPCSS):window.attachEvent&&window.attachEvent("onload",wprRemoveCPCSS);</script><noscript><link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto%3Aregular%2C300%2Cregular%2C700%7CDancing%20Script%3Aregular%2C400&#038;display=swap" /><link rel="stylesheet" href="https://truongthinhphatholding.com.vn/wp-content/cache/min/1/d763bb77d0be362462151d965b59cb9b.css" media="all" data-minify="1" /></noscript>