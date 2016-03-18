(function () {
    $('.like-job').on('click', function (event) {
        event.preventDefault();

        var $link = $(this);

        if (!$link.data('canlike')) return;

        var like = $link.data('like');

        var req = $.post(window.$urls.LikeJobOpportunity, { jobOpportunityId: $link.data('job'), like: like });

        req.success(function (response) {
            $link.find('span').html(like ? response.data.Likes : response.data.DisLikes);
            $('.like-job').each(function () {
                $(this).data('canlike', false);
                $(this).addClass('disabled');
            });
        });

        req.fail(function (response) {
            // TODO: Find a better way to show this message.
            alert(response.responseJSON.message);
        });
    });
})();