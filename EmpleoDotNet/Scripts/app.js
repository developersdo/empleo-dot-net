(function () {
    function onJobOpportunityDetailClick(element) {
        var detailUrl = $(element).attr("data-url");
        if (detailUrl) {
            window.location = detailUrl;
        }
    };

    $('form').submit(function () {
        var self = $(this);
        var parameters = self.serialize().match(/(\w+=)/g);

        for (var i = 0; i < parameters.length; i++) {
            var param = parameters[i];
            param = param.slice(0,param.length - 1);
            var formElem = self.find('*[name=' + param + ']');

            if (!formElem.val()) {
                formElem.prop('disabled', true);
            }
        }
    });
})()
