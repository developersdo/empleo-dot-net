(function () {
    $(function () {
        console.log("Ready");
    });

    function onJobOpportunityDetailClick(element) {
        var detailUrl = $(element).attr("data-url");
        if (detailUrl) {
            window.location = detailUrl;
        }
    };

})()