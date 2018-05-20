(function () {

    function onJobOpportunityDetailClick(element) {
        var detailUrl = $(element).attr("data-url");
        if (detailUrl) {
            window.location = detailUrl;
        }
    };

    $('form[method="get"]').submit(function () {
        var self = $(this);
        var parameters = self.serialize();
        parameters.split("&").forEach(function (val) {
            var param = val.replace(/=\w+|=/, "");
            var paramValue = val.replace(/\w+=/, "");
            if (paramValue === "") {
                var formElem = self.find("*[name=" + param + "]");
                formElem.prop("disabled", true);
            }
        });
    });

    $("#confirm-delete").on("show.bs.modal", function (e) {
        $(this)
            .find(".modal-body")
            .html("<h4>" + $(e.relatedTarget)
            .data("title") + "</h4>");
        $(this)
           .find(".btn-ok")
            .attr("href", $(e.relatedTarget)
            .data("href"));
    });

    if ($(":checkbox").size() > 0) {
        $(':checkbox').iCheck({
            checkboxClass: 'icheckbox_flat-green',
            radioClass: 'iradio_flat'
        });
    }

})()