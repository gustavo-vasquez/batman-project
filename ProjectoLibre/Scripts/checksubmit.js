$(document).ready(function () {
    if ($("#checkedForm").val()) {
        $('#myModal').modal({
            keyboard: false,
            autoshow: false,
            backdrop: "static"
        })
        $('#myModal').modal('show');
        $("#checkedForm").val("false");
    }
});