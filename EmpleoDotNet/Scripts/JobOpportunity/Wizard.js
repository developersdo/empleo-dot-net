var currentSection = 0;
$(document).ready(function () {
    var owl = $("#wizard").owlCarousel({
        slideSpeed: 300,
        paginationSpeed: 400,
        items: 1,
        itemsDesktop: false,
        itemsDesktopSmall: false,
        itemsTablet: false,
        itemsMobile: false,
        dots: false,
        touchDrag: false,
        mouseDrag: false
    });    
    var sections = ["INFORMACIÓN DE LA EMPRESA", "INFORMACIÓN DEL PUESTO", "LA PRUEBA DE JOEL"];
    $('.section-title').html(sections[currentSection]);
    $('.tab').removeClass('active');
    $('.section-1').addClass('active');

    var validateScreen = function (callback) {
        var parsleyGroup = $(".active .item").data('parsley-group');
        if ($('form').parsley().validate({ group: parsleyGroup })) {
            callback();
        }
    };

    $('form').submit(function (e) {
        if(!$('form').parsley().validate()) {
            e.preventDefault();
        }
    });
    $(window).keydown(function(e) {
        if (e.keyCode === 13) {
            e.preventDefault();
        }
    });
    $("input").keydown(function(e) {
        if (e.keyCode === 13) {
            validateScreen(function() {
                owl.trigger('next');
            });
        }
    });
    $(".btn-next").click(function () {
        validateScreen(function () {
            owl.trigger('next');
            currentSection++;
            $('.section-title').html(sections[currentSection]);
            $('.tab').removeClass('active');
            $('.section-' + (currentSection+1)).addClass('active');
        });
    });
    $(".btn-prev").click(function () {
        owl.trigger('prev');
        currentSection--;
        $('.section-title').html(sections[currentSection]);
        $('.tab').removeClass('active');
        $('.section-' + (currentSection+1)).addClass('active');
    });
});