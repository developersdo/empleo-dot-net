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

    var changePage = function(index, callback) {
        owl.trigger('to.owl.carousel', [index, 300, true]);
        currentSection = index;
        changeActiveTab();
        callback();
    };

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

        submitForm: function () {
            if (!$('form').parsley().validate()) {
                e.preventDefault();
            }
        },

        preventEnter: function (e) {
            if (e.keyCode === 13) {
                e.preventDefault();
            }
        },
        goNextOnEnter: function (e) {
            if (e.keyCode === 13) {
                validateScreen(function () {
                    owl.trigger('next');
                });
            }
        },

        focusField: function(fieldName) {
            var field = $('input[name= ' + fieldName + ']');
            var index = field.parents('.owl-item').index();
            changePage(index, function () {
                setTimeout(function() {
                    field.focus();
                }, 300);
            });
        }
    };
}

$(function () {
    var wizard = new Wizard();
    $('form').submit(function (e) { wizard.submitForm(); });
    $(window).keydown(function (e) { wizard.preventEnter(e); });
    $("input").keydown(function (e) { wizard.goNextOnEnter(e); });
    $(".btn-next").click(function () { wizard.next(); });
    $(".btn-prev").click(function () { wizard.previous(); });
    $('#validation-errors a').click(function () { wizard.focusField($(this).data('field')); });
});