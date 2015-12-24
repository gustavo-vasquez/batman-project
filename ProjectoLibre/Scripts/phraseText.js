$(document).ready(function () {
    var text = ["¡Soy Batman!",
                "¡Ven aquí pequeño!",
                "¿Quién es el Guasón?",
                "¡Vete a la mierda!",
                "Al suelo friki.",
                "Se oyen como renos pequeñitos."];
    var position = 1;
    //var elem = document.getElementById("phrase");
    $("#phrase").css({ "font-style": "italic", "font-family": "Trebuchet MS" });
    $("#phrase").html(text[0]);
    //elem.innerHTML = text[0];
    setInterval(change, 5000);

    function change() {
    
        $("#phrase").html(text[position]).fadeOut('fast');
        $("#phrase").html(text[position]).fadeIn('slow');
        //elem.innerHTML = text[position];
        position++;

        if (position >= text.length) {
            position = 0;
        }
    }
});

