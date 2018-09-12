/* NOVI ZAHTJEVI*/
$("#yes-delete-playlist").on('click', function () {
    var nameOfDeletingPlaylist = $(".playlist-name h1").text();

    $.ajax({
        url: "/Playlist/DeletePlaylist",
        type: "POST",
        data: { "playlistName": nameOfDeletingPlaylist },
        success: function () {
            window.location = "/";
        },
        error: function () {
            alert("Nesto je poslo po zlu...");
        }
    });
});

$("#yes-delete-song").on('click', function () {
    var nameOfDeletingSong = $(".yes-delete").attr("id");

    $.ajax({
        url: "/Song/DeleteSong",
        type: "POST",
        data: { "songId": nameOfDeletingSong },
        success: function () {
            window.location = "/Song/Index/Id";
        },
        error: function () {
            alert("Nesto je poslo po zlu...");
        }
    });
});


$(".action-rename").on('click', function () {
    var oldName = $(".playlist-name h1").text();
    var newName = $("#rename-playlist-input").val();
    var renamingPlaylist = { NewNamePlaylist: newName, OldNamePlaylist: oldName };
    $.ajax({
        url: "/Playlist/RenamePlaylist",
        type: "POST",
        data: renamingPlaylist,
        success: function () {
            location.reload();
        },
        error: function () {
            alert("Nesto je poslo po zlu...");
        }
    });
});

$(".adding-playlist button").on('click', function () {
    var nameOfPlaylist = $("#playlist-name-input").val();
    var urlOfPlaylist = $("#playlist-url-input").val();
    var playlist = { NameOfPlaylist: nameOfPlaylist, UrlOfPlaylist: urlOfPlaylist };

    $.ajax({
        url: "/Playlist/Add",
        type: "POST",
        data: playlist,
        success: function () {
            $(".main-div").css("display", "none");
            $(".thank-you-note").css("display", "flex");
            $(".adding-playlist input").val("");
        },
        error: function (jqXHR, exception) {
            alert("Nesto je poslo po zlu...");
            if (jqXHR.status === 0) {
                alert('Not connect.\n Verify Network.');
            } else if (jqXHR.status === 404) {
                alert('Requested page not found. [404]');
            } else if (jqXHR.status === 500) {
                alert('Internal Server Error [500].');
            } else if (exception === 'parsererror') {
                alert('Requested JSON parse failed.');
            } else if (exception === 'timeout') {
                alert('Time out error.');
            } else if (exception === 'abort') {
                alert('Ajax request aborted.');
            } else {
                alert('Uncaught Error.\n' + jqXHR.responseText);
            }
        }
    });
});

$(".clickable-card").on('click', function () {
    var clickedButton = $(this).attr("id");

    window.location = "/Playlist/Index/" + clickedButton;
});

$(".song-name-in-list").on("click", function () {
    var clickedButton = $(this).attr("id");


    $.ajax({
        url: "/Song/SongDetails",
        type: "POST",
        data: { "id": clickedButton },
        success: function (objekt) {
            $(".current-song-data h2").text(objekt.nameOfArtist + ", " + objekt.nameOfSong);
            $(".current-song-data p").text(objekt.funFact);
            $(".current-song-image img").attr("src", objekt.pictureURL);
        },
        error: function () {
            alert("fails");
        }
    });
});

$(".play-btn, .play-song-button").on("click", function () {
    var clickedButton = $(this).attr("id");

    $.ajax({
        url: "/Song/VideoURL",
        type: "POST",
        data: { "id": clickedButton },
        success: function (url) {
            $(".youtube-video").css("display", "flex");
            $(".youtube-frame").attr("src", "https://www.youtube.com/embed/" + url +"?cc_load_policy&amp;controls=2&amp;iv_load_policy=3&amp;modestbranding=0&amp;rel=0&amp;showinfo=0&amp;wmode=transparent&amp;fs=0&amp;enablejsapi=1&amp;widgetid=1");
            $("body").css("overflow", "hidden");
        },
        error: function () {
            alert("fails");
        }
    });
});

$(".delete-song-from-playlist").on("click", function () {
    var songId = $(this).attr("id");
    var playlistId = $(".playlist-name-h1-div h1").attr("id");
    var deletingSongFromPlaylist = { SongID: songId, PlaylistID: playlistId };

    $.ajax({
        url: "/Playlist/DeleteSongFromPlaylist",
        type: "POST",
        data: deletingSongFromPlaylist,
        success: function () {
            window.location = "/Playlist/Index/" + playlistId;
        },
        error: function () {
            alert("fails");
        }
    });
});

$(".lets-go-button").on("click", function () {
    $.ajax({
        url: "/Playlist/EnterPlaylist",
        type: "POST",
        success: function (id) {
            window.location = "/Playlist/Index/" + id;
        },
        error: function () {
            alert("fails");
        }
    });
});


$(".edit-button").on("click", function () {
    var clickedButton = $(this).attr("id");

    $.ajax({
        url: "/Song/GetEditingSong",
        data: { "id": clickedButton },
        type: "POST",
        success: function (song) {
            $(".trio-rio-edit").attr("id", song.songID);
            $("#song-input-name").val(song.nameOfSong);
            $("#artist-input-name").val(song.nameOfArtist);
            $("#song-input-url").val(song.songURL);
            $("#picture-input-url").val(song.pictureURL);
            $("#fun-fact-area").val(song.funFact);
            $("#duration-input-value").val(song.duration);
            $(".edit-song-popup").css("display", "flex");
        },
        error: function () {
            alert("greska");
        }
    });
});


$(".edit-song-submit-button").on("click", function () {

    var submitEditedSong = {
        SongID: $(".trio-rio-edit").attr("id"),
        NameOfSong: $("#song-input-name").val(),
        NameOfArtist: $("#artist-input-name").val(),
        SongURL: $("#song-input-url").val(),
        PictureURL: $("#picture-input-url").val(),
        Duration: $("#duration-input-value").val(),
        FunFact: $("#fun-fact-area").val()
    };

    $.ajax({
        url: "/Song/EditingSong",
        type: "POST",
        data: submitEditedSong,
        success: function () {
            window.location = "/Song/Index/Id";
        },
        error: function (jqXHR, exception) {
            window.location = "/Song/Index/Id";
            if (jqXHR.status === 0) {
                window.location = "/Song/Index/Id";
            } else if (jqXHR.status === 404) {
                alert('Requested page not found. [404]');
            } else if (jqXHR.status === 500) {
                alert('Internal Server Error [500].');
            } else if (exception === 'parsererror') {
                alert('Requested JSON parse failed.');
            } else if (exception === 'timeout') {
                alert('Time out error.');
            } else if (exception === 'abort') {
                alert('Ajax request aborted.');
            } else {
                alert('Uncaught Error.\n' + jqXHR.responseText);
            }
        }
    });
});


/*
treba posalt int i array u viewmodel

*/
$("#add-songs-to-playlist").on("click", function () {

    var wantedPlaylist = $(".playlist-song-adding-id").attr("id");

    var arrayOfSongAddingToPlaylist = [];
    $('input[name="adding-songs-to-playlist-checkbox"]:checked').each(function () {
        arrayOfSongAddingToPlaylist.push(this.id);
    });


    var fullDataAddingSongsToPlaylist = { PlaylistID: wantedPlaylist, ArrayOfSongAddingToPlaylist: arrayOfSongAddingToPlaylist };
    

    $.ajax({
        url: "/Playlist/AddSongsToPlaylist",
        type: "POST",
        traditional: true,
        data: fullDataAddingSongsToPlaylist,
        success: function () {
            window.location = "/Playlist/Index/" + wantedPlaylist;
        },
        error: function () {
            alert("fails");
        }
    });
});

