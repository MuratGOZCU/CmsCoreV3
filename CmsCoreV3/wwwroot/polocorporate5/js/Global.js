$(document).ready(function () {
    formOpenClose();
   
});

function formOpenClose() {
    $('.openbtn').click(function () {
        GoOn('slider');
        
        $(this).addClass('open');
        /*$('.call .callform').addClass('open'); */
        $('.call').effect('slide', { direction: 'right', mode: 'show' }, 500);
        

    });
    $('.closebtn').click(function () {
        $('.openbtn').removeClass('open');
        /*$('.call .callform').removeClass('open');
        $('.call').removeClass('open');*/
        $('.call').effect('slide', { direction: 'right', mode: 'hide' }, 500);
    });
}
var isOpen = true;
$(window).scroll(function () {
    if ($(window).scrollTop() > 500 && $('.call .callform').hasClass('open')) {
        $('.openbtn').removeClass('open');
        /*$('.call .callform').removeClass('open');
        $('.call').removeClass('open');*/
        $('.call').effect('slide', { direction: 'right', mode: 'hide' }, 500);
    }
    if ($(window).scrollTop() < 500 && !$('.call .callform').hasClass('open')) {
        
        $('.openbtn').addClass('open');
        /*$('.call .callform').addClass('open');*/
        $('.call').effect('slide', { direction: 'right', mode: 'show' }, 500);

    }
})

function GoOn(id) {
    $("html, body").animate({ scrollTop: $('#' + id).offset().top - 50 }, 1000, function () {
        $('.openbtn').addClass('open');
        /*$('.call .callform').addClass('open');*/
        $('.call').effect('slide', { direction: 'right', mode: 'show' }, 500);
    });
}
