(function () {
    function onJobOpportunityDetailClick(element) {
        var detailUrl = $(element).attr("data-url");
        if (detailUrl) {
            window.location = detailUrl;
        }
    };

    $('form[method="get"]').submit(function () {
        var self = $(this);
        var parameters = self.serialize().match(/(\w+=)/g);
        
        for (var i = 0; i < parameters.length; i++) {
            var param = parameters[i].slice(0,-1);
            var formElem = self.find('*[name=' + param + ']');

            if (!formElem.first().val() || !formElem.first().prop('checked') ) {
                formElem.prop('disabled', true);
            }
        }
    });

    $('#confirm-delete').on('show.bs.modal', function (e) {
        $(this)
            .find('.modal-body')
            .html("<h4>" + $(e.relatedTarget)
            .data('title') + "</h4>");
        $(this)
            .find('.btn-ok')
            .attr('href', $(e.relatedTarget)
            .data('href'));
    });
})()
