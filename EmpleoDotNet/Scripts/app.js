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
            var param = parameters[i].slice(0, -1);
            var formElem = self.find("*[name=" + param + "]");

            if (!formElem.first().val() || !formElem.first().prop("checked")) {
                formElem.prop("disabled", true);
            }
        }
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

    $(".switch")
        .click(function () { 
            toggleHidePost($(this), toggleSwitchInput);
        });

    $("#switch-btn")
        .click(function () {
            toggleHidePost($(this), toggleSwitchBtn);
        });

    function toggleHidePost($node, callback) {
        var url = $node.data("href");
        var title = $node.data("title");
        $.post(url, "title=" + title, function (data) {
            callback(data, $node);
        });
    }

    function toggleSwitchBtn(data, $node) {
        if (data.isHidden) {
            $node.html("Mostrar");
            $node.toggleClass("btn-toggle-hide");
            $node.toggleClass("btn-toggle-show");
        } else {
            $node.html("Ocultar");
            $node.toggleClass("btn-toggle-hide");
            $node.toggleClass("btn-toggle-show");
        }
    }

    function toggleSwitchInput(data, $node) {
        var $input = $node.find(":input");
        if (data.isHidden) {
            $input.prop("checked", data.isHidden);
        } else {
            $input.prop("checked", false);
        }
    }

})()
