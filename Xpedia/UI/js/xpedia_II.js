// on ready function
  $(document).ready(function() {
	"use strict";
	
	
	// Preloader 
	jQuery(window).on('load', function() {
		jQuery("#status").fadeOut();
		jQuery("#preloader").delay(350).fadeOut("slow");
	});
	
	/**** select2 js ****/
	
	$(".myselect").select2();
	
	
	/*--------------------------
	nice Select active
	---------------------------- */ 
	$('select').niceSelect();
	
	//-----------Search box jquery------------//

			$( ".searchd" ).on( "click", function() {
			  $( ".searchbox" ).addClass( "open", 1000);
			});

			$( ".close" ).on( "click", function() {
			  $( ".searchbox" ).removeClass( "open", 1000);
			});	
	
	// Menu js for Position fixed
        $(window).scroll(function() {
            var window_top = $(window).scrollTop() + 1;
            if (window_top > 160) {
                $('.hs_navigation_header_wrapper').addClass('menu_fixed animated fadeInDown');
            } else {
                $('.hs_navigation_header_wrapper').removeClass('menu_fixed animated fadeInDown');
            }
        });
	
	
        // ===== Scroll to Top ==== 
        $(window).scroll(function() {
            if ($(this).scrollTop() >= 100) {
                $('#return-to-top').fadeIn(200);
            } else {
                $('#return-to-top').fadeOut(200);
            }
        });
        $('#return-to-top').on('click', function() {
            $('body,html').animate({
                scrollTop: 0
            }, 500);
        });
		
		
	// Main Slider Animation

        (function($) {

            //Function to animate slider captions 
            function doAnimations(elems) {
                //Cache the animationend event in a variable
                var animEndEv = 'webkitAnimationEnd animationend';

                elems.each(function() {
                    var $this = $(this),
                        $animationType = $this.data('animation');
                    $this.addClass($animationType).one(animEndEv, function() {
                        $this.removeClass($animationType);
                    });
                });
            }

            //Variables on page load 
            var $myCarousel = $('#carousel-example-generic'),
                $firstAnimatingElems = $myCarousel.find('.carousel-item:first').find("[data-animation ^= 'animated']");

            //Initialize carousel 
            $myCarousel.carousel();

            //Animate captions in first slide on page load 
            doAnimations($firstAnimatingElems);

            //Pause carousel  
            $myCarousel.carousel('pause');


            //Other slides to be animated on carousel slide event 
            $myCarousel.on('click slide.bs.carousel', function(e) {
                var $animatingElems = $(e.relatedTarget).find("[data-animation ^= 'animated']");
                doAnimations($animatingElems);
            });


        })(jQuery);
		
		 /*----------------------------------------------------------------------------------*/
  /* 		Date and Tiem Picker
/*-----------------------------------------------------------------------------------*/
  $('.datepicker').datepicker({ dateFormat: 'D dd M yy' });
  $('.horizontal-datepicker').datepicker({ dateFormat: 'dd M yy' });
  
  
  $(document).ready(function() {
              $('.btc_team_slider_wrapper .owl-carousel').owlCarousel({
                loop: true,
                margin: 10,
				autoplay:true,
                responsiveClass: true,
				smartSpeed: 1200,
				navText : ['<i class="flaticon-left-arrow" aria-hidden="true"></i>','<i class="flaticon-right-arrow" aria-hidden="true"></i>'],
                responsive: {
                  0: {
                    items: 1,
                    nav: true
                  },
                  600: {
                    items: 2,
                    nav: true
                  },
                  1000: {
                    items: 3,
                    nav: true,
                    loop: true,
                    margin: 20
                  }
                }
              })
            })
			
			$(document).ready(function() {
              $('.btc_ln_slider_wrapper .owl-carousel').owlCarousel({
                loop: true,
                margin: 10,
				autoplay:false,
                responsiveClass: true,
				smartSpeed: 1200,
				navText : ['<i class="flaticon-left-arrow" aria-hidden="true"></i>','<i class="flaticon-right-arrow" aria-hidden="true"></i>'],
                responsive: {
                  0: {
                    items: 1,
                    nav: true
                  },
                  600: {
                    items: 2,
                    nav: true
                  },
                  1000: {
                    items: 3,
                    nav: true,
                    loop: true,
                    margin: 20
                  }
                }
              })
            })
		
  
  
  
   $(document).ready(function() {
            $('.prs_pn_slider_wraper .owl-carousel').owlCarousel({
                loop: true,
                margin: 10,
                autoplay: true,
                responsiveClass: true,
                smartSpeed: 1200,
                navText: ['<i class="flaticon-play-button"></i>', '<i class="flaticon-play-button"></i>'],
                responsive: {
                    0: {
                        items: 1,
                        nav: true
                    },
					500: {
                        items: 3,
                        nav: true
                    },
                    700: {
                        items: 4,
                        nav: true
                    },
                    1000: {
                        items: 6,
                        nav: true,
                        loop: true,
                        margin: 20
                    }
                }
            })
        })
		
		
		 // testimonial-slider js here
    $("#testimonial-slider").owlCarousel({
        navigationText :["<i class='flaticon-angle-pointing-to-left'></i>", "<i class='flaticon-angle-arrow-pointing-to-right'></i>"],
        items : 3,
        itemsDesktop : [1199, 3],
        itemsDesktopSmall : [980, 1],
        itemsTablet: [768, 1],
        itemsMobile : [479, 1],
        slideSpeed: 1500,
        paginationSpeed: 1500,
        navigation : true,
        pagination : false,
        afterAction: function(el){
           //remove class active
           this
           .$owlItems
           .removeClass('active')

           //add class active
           this
           .$owlItems //owl internal $ object containing items
           .eq(this.currentItem + 1)
           .addClass('active')    
        }         
    }); 
		
  // Magnific popup-video

	$('.test-popup-link').magnificPopup({ 
    type: 'iframe',
    iframe: {
        markup: '<div class="mfp-iframe-scaler">'+
            '<div class="mfp-close"></div>'+
            '<iframe class="mfp-iframe" frameborder="0" allowfullscreen></iframe>'+
            '<div class="mfp-title">Some caption</div>'+
            '</div>',
        patterns: {
            youtube: {
                index: 'youtube.com/', 
                id: 'v=',
                src: 'https://www.youtube.com/embed/ryzOXAO0Ss0'
            }
        }
    }
    // other options
});

$(".album-slider").bxSlider({
		minSlides: 1,
		maxSlides: 10,
		slideWidth: 150,
		slideMargin: 17,
		ticker: true,
		tickerHover: true,
		speed: 20000,
		useCSS: false, 
		infiniteLoop: false
		
		});
		
		
		var $loop = $('.screen')
    if($loop.length > 0){
        $loop.owlCarousel({
            center: true,
            loop:true,
            nav: false,
            autoplay:false,
            autoplayTimeout:2000,
            margin:0,
            responsive:{
                320:{
                    items:1,
                    margin:10
                },
                481:{
                    items:1,
                    margin:0
                },
				767:{
                    items:2,
                    margin:0
                },
                991:{
                    items:3
                }
            }
        });
    }
	
});	