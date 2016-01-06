$(document).ready(function () {
    if ($("#checkedForm").val()) {
        $('#editSuccess').modal({
            keyboard: false,
            autoshow: false,
            backdrop: "static"
        })
        $('#editSuccess').modal('show');
        $("#checkedForm").val("false");
    }
});