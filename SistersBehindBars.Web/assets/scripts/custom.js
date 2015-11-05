$(function () {
    var topoffset = 20;
    var slideQty = $('#featured .item').length;
    var windowHeight = $(window).height();
    var randSlide = Math.floor(Math.random() * slideQty);

    $('.carousel').carousel({
        pause: false
    });

    for (var i = 0; i < slideQty; i++) {
        var insertText = '<li data-target="#featured" data-slide-to="' + i + '" class="' + (i === randSlide ? "active" : "") + '"></li>';
        $('#featured ol').append(insertText);
    }

    $('.fullHeight').css('height', windowHeight);

    //replace img inside carousel with a background image
    $('#featured .item img').each(function() {
        var imgSrc = $(this).attr('src');
        $(this).parent().css({ 'background-image': 'url(' + imgSrc + ')' });
        $(this).remove();
    });

    //adjust height of fullHeight elements on window resize
    $(window).resize(function() {
        windowHeight = $(window).height();
        $('.fullHeight').css('height', windowHeight);
    });

    $('#featured .item').eq(randSlide).addClass('active');

    $('body').scrollspy({
        target: 'header .navbar',
        offset: topoffset + 40
    
    });

    $('.navbar-nav a').on('click', function () {
        var parent = this.parentElement;

        $('header .navbar-default .navbar-nav li').removeClass('active');
        $(parent).addClass('active');

        $('.navbar-collapse').collapse('hide');
    });

    $(function () {
        $('.navbar a[href*=#]:not([href=#])').click(function () {
            if (location.pathname.replace(/^\//, '') === this.pathname.replace(/^\//, '') &&
                location.hostname == this.hostname) {
                var target = $(this.hash);
                target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
                if (target.length) {
                    $('html,body').animate({
                        scrollTop: target.offset().top-topoffset
                    }, 500);
                    return false;
                }
            }
        });
    });
});