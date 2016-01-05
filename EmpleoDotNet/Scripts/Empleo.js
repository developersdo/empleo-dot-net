'use strict';

var empleo = empleo || {};
empleo = {
    UpdateApprovalStatus: function (elem, jobId, isApproved) {
        var url = "/Administration/UpdateApprovalStatus";
        var data = {
            jobId: jobId,
            canShow: isApproved
        };

        $.post(url, data, function () {
            empleo.UpdateUI(elem.parent(), isApproved);
        });
    },

    UpdateUI: function (elem, isApproved) {
        elem.empty();
        elem.next().empty();
        if (isApproved) {
            elem.append('<span class="btn btn-primary">Aprobado</span>');
        } else {
            elem.append('<span class="btn btn-danger">Descartado</span>');
        }

        empleo.UpdateTotalCount();
    },

    UpdateTotalCount: function () {
        var total = parseInt($('.total .value').html());
        $('.total .value').html(total - 1);
    }
};

$(".approve-job, .discard-job").click(function () {
    var self = $(this);
    var jobId = self.closest('tr').data('job');
    var isApproved = self.hasClass('approve-job');
    empleo.UpdateApprovalStatus(self, jobId, isApproved);
});