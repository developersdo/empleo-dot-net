var Like = function () {
    var likeUrl = $('#like-url').val();

    var updateLikesCount = function (link, count) {
        link.find('span').html(count);
    };

    var disableLinks = function () {
        $('.like-job').each(function () {
            $(this).data('canlike', false);
            $(this).addClass('disabled');
        });
    };

    return {
        performLike: function (e) {
            e.preventDefault();

            var $link = $(e.currentTarget);

            if (!$link.data('canlike')) return;

            var like = $link.data('like');

            var antiForgeryToken = $("input[name=__RequestVerificationToken]").val();

            var req = $.post(likeUrl, { jobOpportunityId: $link.data('job'), like: like, __RequestVerificationToken: antiForgeryToken });

            req.success(function (response, textStatus, request) {
                console.log(textStatus);
                console.log(request);
                var header = request.getResponseHeader("X-Responded-JSON");
                console.log(header);
                if (typeof(header) !== 'undefined') {
                    var headerJson = JSON.parse(header);
                    if (headerJson.status == "401") {
                        alert("Debes iniciar sesion para poder dar like a los empleos");
                    }
                }else{
                    updateLikesCount($link, (like ? response.data.Likes : response.data.DisLikes));
                    disableLinks();
                }
            });
            console.log(req);
            req.fail(function (response) {
                // TODO: Find a better way to show this message.
                alert("Ha ocurrido un error, disculpa los inconvenientes");
            });
        }
    };
};


(function () {
    var like = new Like();

    $('.like-job').click(function (e) { like.performLike(e); });
})();