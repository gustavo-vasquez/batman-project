$(function () {
    $("#fechaNacimiento").datepicker({
        showOn: "focus",
        //buttonImage: "../img/calendar.gif",
        //buttonImageOnly: true,
        showAnim: "drop",
        firstDay: 7
    });
});

//Validador personalizado para los campos tipo fecha para resolver un problema que se da con el Chrome.
$.validator.addMethod('date',
    function (value, element, params) {
        if (this.optional(element)) {
            return true;
        }

        var ok = true;
        try {
            $.datepicker.parseDate('dd/mm/yy', value);
        }
        catch (err) {
            ok = false;
        }
        return ok;
    });