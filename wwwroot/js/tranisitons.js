$("#show-playlist-btn").on('click', function () {
    window.location = "/";
}); 

$(".new-card").on('click', function () {
    $(window).scrollTop(0);
    $(".add-playlist-confirmation").css("display", "flex");
    $("body").css("overflow", "hidden");
});

$("#see-songs-btn").on('click', function () {
    window.location = "/Song/Index/Id";
});

$(".play-song-button, .delete-song-button").on('click', function () {
    $(window).scrollTop(0);
});

/* X ZA IZACI IZ EDIT MODA*/
$(".return-edit-button").on('click', function () {
    $(".edit-song-popup").css("display","none");
});



$(".arrow-icon-az").on('click', function () {
    window.location = "/Song/Index/AZ";
});

$(".arrow-icon-playlists").on('click', function () {
    window.location = "/";
});

$(".arrow-icon-numbers").on('click', function () {
    window.location = "/Song/Index/Id";
});

$("#exit-add-playlist").on('click', function () {
    $(".add-playlist-confirmation").css("display", "none");
    $(".main-div").css("display", "flex");
    $(".thank-you-note").css("display", "none");
    $(".adding-playlist input").val("");
    $("body").css("overflow", "scroll");
    location.reload();
});

$(".delete-btn").on('click', function () {
    $(".delete-confirmation-playlist").css("display", "flex");
});

$("#no-delete-playlist").on('click', function () {
    $(".delete-confirmation-playlist").css("display", "none");
});

$(".delete-song-button").on("click", function () {
    $(".delete-confirmation-playlist").css("display", "flex");
});

$("#no-delete-song").on("click", function () {
    $(".delete-confirmation-song").css("display", "none");
});


/* -----------
EDIT BUTTON

--------- 
$(".edit-button").on("click", function () {
    $(".edit-song-popup").css("display", "flex");
});

$(".return-button").on("click", function () {
    $(".edit-song-popup").css("display", "none");
});

*/

/*----------------------------*/
$(".return-add-button").on("click", function () {
    $(".add-song-popup").css("display", "none");
});

$(".arrow-icon-add").on("click", function () {
    $(".add-song-popup").css("display", "flex");
});

/*----------------------------*/

$("#add-songs-exit").on("click", function () {
    $(".add-songs-popup").css("display", "none");
});

$(".edit-btn").on("click", function () {
    $(".add-songs-popup").css("display", "flex");
});

$(".delete-song-button").on("click", function () {
    $(".delete-confirmation-song").css("display", "flex");
    var songId = $(this).attr("id");
    DeleteSongConfirmationId(songId);
});

function DeleteSongConfirmationId(songId){
    $(".yes-delete").attr("id", songId);
}

$(".playlist-name-h1-div h1").dblclick(function () {
    $(".playlist-name-h1-div h1").css("display", "none");
    $(".doubleclick-input").css("display", "flex");
});

$(".return-rename").on('click', function () {
    $(".playlist-name-h1-div h1").css("display", "flex");
    $(".doubleclick-input").css("display", "none");
});

$(".arrow-icon-add").hover(function () {
    $(".arrow-add-show").css("visibility", "visible");
    $(".arrow-icon-add").css("cursor", "pointer");
    $(".song-card-div").css("z-index", "0");

}, function () {
    $(".arrow-add-show").css("visibility", "hidden");
    $(".arrow-icon-add").css("cursor", "default");
    $(".song-card-div").css("z-index", "100");
});

$(".arrow-icon-az").hover(function () {
    $(".arrow-az-show").css("visibility", "visible");
    $(".arrow-icon-az").css("cursor", "pointer");
    $(".song-card-div").css("z-index", "0");
}, function () {
    $(".arrow-az-show").css("visibility", "hidden");
    $(".arrow-icon-az").css("cursor", "default");
    $(".song-card-div").css("z-index", "100");
});

$(".arrow-icon-numbers").hover(function () {
    $(".arrow-numbers-show").css("visibility", "visible");
    $(".arrow-icon-numbers").css("cursor", "pointer");
    $(".song-card-div").css("z-index", "0");
}, function () {
    $(".arrow-numbers-show").css("visibility", "hidden");
    $(".arrow-icon-numbers").css("cursor", "default");
    $(".song-card-div").css("z-index", "100");
});

$(".arrow-icon-playlists").hover(function () {
    $(".arrow-playlists-show").css("visibility", "visible");
    $(".arrow-icon-playlists").css("cursor", "pointer");
    $(".song-card-div").css("z-index", "0");
}, function () {
    $(".arrow-playlists-show").css("visibility", "hidden");
    $(".arrow-icon-playlists").css("cursor", "default");
    $(".song-card-div").css("z-index", "100");
});

$(".youtube-video button").on("click", function () {
    $(".youtube-video").css("display", "none");
    $(".youtube-video iframe").attr("src", "");
    $("body").css("overflow", "scroll");
});