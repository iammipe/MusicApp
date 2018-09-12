if ($(window).width() < 500) {
    $(".play-btn").html("");
    $(".delete-song-from-playlist").html("");
} else if ($(window).width() > 500 && $(window).width() < 1000 ) {
    $(".play-btn").html("Play");
    $(".delete-song-from-playlist").html("Delete");
}
