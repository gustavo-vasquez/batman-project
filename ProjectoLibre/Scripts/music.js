function reproducir(music) {

    if (music.duration > 0 && !music.paused) {
        music.pause();
        music.currentTime = 0; //Regreso el audio al comienzo
    }
    else {
        music.play();
    }
}