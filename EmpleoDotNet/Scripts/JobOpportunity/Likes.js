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

            var req = $.post(likeUrl, { jobOpportunityId: $link.data('job'), like: like });

            req.success(function (response) {
                updateLikesCount($link, (like ? response.data.Likes : response.data.DisLikes));
                disableLinks();
            });

            req.fail(function (response) {
                // TODO: Find a better way to show this message.
                alert(response.responseJSON.message);
            });
        }
    };
};


(function () {
    var like = new Like();

    $('.like-job').click(function (e) { like.performLike(e); });
})();