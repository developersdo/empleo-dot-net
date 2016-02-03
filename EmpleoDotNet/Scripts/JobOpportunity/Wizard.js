$(document).ready(function() {
    var owl = $("#wizzard").owlCarousel({
        slideSpeed: 300,
        paginationSpeed: 400,
        items: 1,
        itemsDesktop: false,
        itemsDesktopSmall: false,
        itemsTablet: false,
        itemsMobile: false
    });
    $(window).keydown(function(e) {
        if (e.keyCode === 13) {
            e.preventDefault();
        }
    });
    $("input").keydown(function(e) {
        if (e.keyCode === 13) {
            owl.trigger('next');
        }
    });
    $(".btn-next").click(function() {
        owl.trigger('next');
    });
    $(".btn-prev").click(function() {
        owl.trigger('prev');
    });
});