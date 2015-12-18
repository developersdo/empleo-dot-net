function UpdateTotalCount() {    
    var total = parseInt($('.total .value').html());

    $('.total .value').html(total - 1);
}

function UpdateApprovalStatus(jobId, isApproved) {
    var self = $(this);
    var url = "/Administration/UpdateApprovalStatus";
    var data = {
        jobId: jobId,
        canShow: isApproved
    };
    
    $.post(url, data, function () {
        var parent = self.parent();
        parent.empty();
        parent.next().empty();
        if (isApproved) 
            parent.append('<span class="btn btn-primary">Aprobado</span>');
        else
            parent.append('<span class="btn btn-danger">Descartado</span>');

        UpdateTotalCount();
    });
}

$(".approve-job").click(function () {
    var self = $(this);
    var jobId = self.closest('tr').data('job');
    UpdateApprovalStatus.call(self,jobId, true);
});

$(".discard-job").click(function () {
    var self = $(this);
    var jobId = self.closest('tr').data('job');
    UpdateApprovalStatus.call(self,jobId, false);
});