$(document).ready(function () {
    $("#TipoPersonaje").change(function () {
        console.log("hola");
        switch ($("#TipoPersonaje option:selected").val()) {

            case '1':
                $('#DivVillano').hide();
                $("#DivHeroe").load("/Heroe/Crear").fadeIn();
                break;

            case '2':
                $('#DivHeroe').hide();
                $("#DivVillano").load("/Villano/Crear").fadeIn();
                break;

            default:
                $('#DivHeroe').hide();
                $('#DivVillano').hide();
                break;
        }
    });
});