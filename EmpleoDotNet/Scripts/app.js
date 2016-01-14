function onJobOpportunityDetailClick(element) {
    var detailUrl = $(element).attr("data-url");
    if (detailUrl) {
        window.location = detailUrl;
    }
};


// Changes the menu icons color when background is hidden

if (!isHomePage()) {
    $(window).scroll(function () {
        var scroll = $(window).scrollTop();
        if (scroll > 50) {
            $("header > .container a").css("color", "#fff");
        } else {
            $("header > .container a").css("color", "#14b1bb");
        }
    });
}

function isHomePage() {
    return window.location.pathname === "/";
}