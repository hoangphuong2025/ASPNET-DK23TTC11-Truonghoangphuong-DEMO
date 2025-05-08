
/*
 * Lazy Load - jQuery plugin for lazy loading images
 *
 * Copyright (c) 2007-2012 Mika Tuupola
 *
 * Licensed under the MIT license:
 *   http://www.opensource.org/licenses/mit-license.php
 *
 * Project home:
 *   http://www.appelsiini.net/projects/lazyload
 *
 * Version:  1.8.0
 *
 * Modified by dongyuwei@lightinthebox.com, since 2012-08-29
 * dongyuwei's Modification:
 * 1 adjust for jquery v1.3.1(data api has bug?)
 * 2 handle img `error` event
 * 3 `scroll` event optimization
 * 4 ipad support(`touchmove` event)
 * 5 unbind `scroll` event after all imgs loaded
 *
 */
(function($,window){var $window=$(window);$.fn.lazyload=function(options){var elements=this;var $container;var settings={threshold:0,event:"scroll",effect:"show",container:window,data_attribute:"original",skip_invisible:true,appear:null,load:null,timer:50};function update(){elements.each(function(){var $this=$(this);if(settings.skip_invisible&&!$this.is(":visible")){return}if(!$.belowthefold(this,settings)&&!$.rightoffold(this,settings)){$this.trigger("appear")}})}if(options){if(undefined!==options.effectspeed){options.effect_speed=options.effectspeed;delete options.effectspeed}$.extend(settings,options)}$container=(settings.container===undefined||settings.container===window)?$window:$(settings.container);var scrollMonitor;if(0===settings.event.indexOf("scroll")){var timer;scrollMonitor=function(event){if(timer){clearTimeout(timer)}timer=setTimeout(function(){update()},settings.timer)};$container.bind('scroll',scrollMonitor)}this.each(function(){var self=this;var $self=$(self);self.loaded=false;$self.one("appear",function(){if(!self.loaded){if(settings.appear){var elements_left=elements.length;settings.appear.call(self,elements_left,settings)}$self.is(":visible")&&$self.css('opacity',0);var src=$self.attr('data-'+settings.data_attribute);$self.bind("load",function(){self.loaded=true;$self[0].removeAttribute('data-'+settings.data_attribute);$self.unbind('load');$self.is(":visible")&&$self.animate({'opacity':1},300);var temp=$.grep(elements,function(element){return!element.loaded});elements=$(temp);if(elements.length===0){$container.unbind('scroll',scrollMonitor)}if(settings.load){var elements_left=elements.length;settings.load.call(self,elements_left,settings)}}).bind('error',function(){$self.attr("src",src);$self.unbind('error')}).attr("src",src)}})});$window.bind("resize",function(event){update()});$window.bind("touchmove",function(event){update()});update();return this};$.belowthefold=function(element,settings){var fold;if(settings.container===undefined||settings.container===window){fold=$window.height()+$window.scrollTop()}else{fold=$(settings.container).offset().top+$(settings.container).height()}return fold<=$(element).offset().top-settings.threshold};$.rightoffold=function(element,settings){var fold;if(settings.container===undefined||settings.container===window){fold=$window.width()+$window.scrollLeft()}else{fold=$(settings.container).offset().left+$(settings.container).width()}return fold<=$(element).offset().left-settings.threshold};$.abovethetop=function(element,settings){var fold;if(settings.container===undefined||settings.container===window){fold=$window.scrollTop()}else{fold=$(settings.container).offset().top}return fold>=$(element).offset().top+settings.threshold+$(element).height()};$.leftofbegin=function(element,settings){var fold;if(settings.container===undefined||settings.container===window){fold=$window.scrollLeft()}else{fold=$(settings.container).offset().left}return fold>=$(element).offset().left+settings.threshold+$(element).width()};$.inviewport=function(element,settings){return!$.rightofscreen(element,settings)&&!$.leftofscreen(element,settings)&&!$.belowthefold(element,settings)&&!$.abovethetop(element,settings)};$.extend($.expr[':'],{"below-the-fold":function(a){return $.belowthefold(a,{threshold:0})},"above-the-top":function(a){return!$.belowthefold(a,{threshold:0})},"right-of-screen":function(a){return $.rightoffold(a,{threshold:0})},"left-of-screen":function(a){return!$.rightoffold(a,{threshold:0})},"in-viewport":function(a){return!$.inviewport(a,{threshold:0})},"above-the-fold":function(a){return!$.belowthefold(a,{threshold:0})},"right-of-fold":function(a){return $.rightoffold(a,{threshold:0})},"left-of-fold":function(a){return!$.rightoffold(a,{threshold:0})}});$(document).ready(function(){$("img[data-src]").lazyload({data_attribute:'src',skip_invisible:false,threshold:100})})})(jQuery,window);