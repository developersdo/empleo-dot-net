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
                var header = request.getResponseHeader("X-Responded-JSON");

                if (typeof(header) !== 'undefined') {
                    var headerJson = JSON.parse(header);
                    if (!$.isEmptyObject(headerJson) && headerJson.status == "401") {
                        // SweetAlert replacing default alert
                        swal('','Debes iniciar sesion para poder dar like a los empleos','warning');
                    } else if (!$.isEmptyObject(response) && !response.error ) {
                        updateLikesCount($link, (like ? response.data.Likes : response.data.DisLikes));
                        disableLinks();
                    }
                }else{
                    updateLikesCount($link, (like ? response.data.Likes : response.data.DisLikes));
                    disableLinks();
                }
            });

            req.fail(function (response) {
                if (typeof (response) !== 'undefined' && response.error) {
                    swal('', response.message, 'error');
                } else {
                    swal('Oops...','Ha ocurrido un error, disculpa los inconvenientes','error');
                }
            });
        }
    };
};


(function () {
    var like = new Like();

    $('.like-job').click(function (e) { like.performLike(e); });
})();