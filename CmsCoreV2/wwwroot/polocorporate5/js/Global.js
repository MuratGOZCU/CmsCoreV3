$(document).ready(function () {
    formOpenClose();
   
});

function formOpenClose() {
    $('.openbtn').click(function () {
        GoOn('slider');
        $(this).addClass('open');
        $('.call .callform').addClass('open');

    });
    $('.closebtn').click(function () {
        $('.openbtn').removeClass('open');
        $('.call .callform').removeClass('open');
    });
}
var isOpen = true;
$(window).scroll(function () {
    if ($(window).scrollTop() > 500 && $('.call .callform').hasClass('open')) {
        $('.openbtn').removeClass('open');
        $('.call .callform').removeClass('open');
    }
    if ($(window).scrollTop() < 500 && !$('.call .callform').hasClass('open')) {
        $('.openbtn').addClass('open');
        $('.call .callform').addClass('open');

    }
})

function GoOn(id) {
    $("html, body").animate({ scrollTop: $('#' + id).offset().top - 50 }, 1000, function () {
        $('.openbtn').addClass('open');
        $('.call .callform').addClass('open');
    });
}
