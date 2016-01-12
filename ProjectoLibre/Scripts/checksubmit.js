$(document).ready(function () {
    if ($("#successHidden").val()) {
        $('#editSuccess').modal({
            keyboard: false,
            autoshow: false,
            backdrop: "static"
        })
        $('#editSuccess').modal('show');
        $("#successHidden").val("false");
    }
});