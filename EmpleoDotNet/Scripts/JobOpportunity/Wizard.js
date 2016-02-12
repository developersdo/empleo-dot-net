"use strict";

var Wizard = function () {
    var currentSection = 0;
    var sections = ["INFORMACIÓN DE LA EMPRESA", "INFORMACIÓN DEL PUESTO", "LA PRUEBA DE JOEL"];
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

    var validateScreen = function (callback) {
        var parsleyGroup = $(".active .item").data('parsley-group');
        if ($('form').parsley().validate({ group: parsleyGroup })) {
            callback();
        }
    };

    var changeActiveTab = function () {
        $('.section-title').html(sections[currentSection]);
        $('.tab').removeClass('active');
        $('.section-' + (currentSection + 1)).addClass('active');
    }

    $('.section-title').html(sections[currentSection]);
    $('.tab').removeClass('active');
    $('.section-1').addClass('active');

    return {
        next: function () {
            validateScreen(function () {
                owl.trigger('next');
                currentSection++;
                changeActiveTab();
            });
        },

        previous: function () {
            owl.trigger('prev');
            currentSection--;
            changeActiveTab();
        },

        submitForm: function() {
            if (!$('form').parsley().validate()) {
                e.preventDefault();
            }
        },

        preventEnter: function () {
            if (e.keyCode === 13) {
                e.preventDefault();
            }
        },
        goNextOnEnter: function () {
            if (e.keyCode === 13) {
                validateScreen(function () {
                    owl.trigger('next');
                });
            }
        }
    };
}

$(function () {
    var wizard = new Wizard();
    $('form').submit(function (e) { wizard.submitForm(); });
    $(window).keydown(function (e) { wizard.preventEnter(); });
    $("input").keydown(function (e) { wizard.goNextOnEnter(); });
    $(".btn-next").click(function () { wizard.next();});
    $(".btn-prev").click(function () { wizard.previous(); });
});