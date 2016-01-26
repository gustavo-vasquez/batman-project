function tog(v) {
    return v ? 'addClass' : 'removeClass';
}

$(document).on('input', '.clearable', function () {
    $(this)[tog(this.value)]('x');
}).on('mousemove', '.x', function (e) {
    $(this)[tog(this.offsetWidth - 18 < e.clientX - this.getBoundingClientRect().left)]('onX');
}).on('touchstart click', '.onX', function (ev) {
    ev.preventDefault();
    $(this).removeClass('x onX').val('').change();
});

$('.clearable').trigger("input");
// Uncomment the line above if you pre-fill values from LS or server


$(document).ready(function () {
    $("#nombreABuscar").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Practica/Sugerencias",
                type: "GET",
                dataType: "json",
                data: { term: request.term },
                success: function (data) {
                    response($.map(data, function (item) {
                        return { label: item.nombre, value: item.nombre };
                    }))

                }
            })
        },
        messages: {
            noResults: "", results: ""
        }
    });
})