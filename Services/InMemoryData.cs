//using mnRelations.Models;
//using mnRelations.ModelView;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace mnRelations.Services
//{
//    public class InMemoryData : ISongs, IMusic, IPlaylist
//    {
//        static List<Song> songs = new List<Song>();
//        static List<Playlist> playlists = new List<Playlist>();
//        ModelViewMusic allData;
//        List<Playlist> tempList = new List<Playlist>();
        

//        public InMemoryData()
//        {
//            if (!songs.Any() && !playlists.Any())
//            {
//                Song songOne = new Song { SongID = 1, NameOfSong = "Here I go again", NameOfArtist = "Whitesnake", Duration = "4:29" , SongURL= "oohFGOmcxuo",
//                    FunFact = "Coverdale formed Whitesnake after leaving Deep Purple. Since he was well known in the UK, Whitesnake did well there, but they did not hit it big in the US " +
//                    "until this album, which had a very radio-friendly sound.",
//                    PictureURL = "https://img.discogs.com/Itb58x-GLbsgwqdB7mjdKdMsLVU=/fit-in/600x621/filters:strip_icc():format(jpeg):mode_rgb():quality(90)/discogs-images/R-1905099-1332411548.jpeg.jpg"
//                };
//                Song songTwo = new Song { SongID = 2, NameOfSong = "What Ive done", NameOfArtist = "Linkin park", Duration = "3:27" , SongURL = "8sgycukafqQ",
//                    FunFact= "In this song, Chester Bennington sings about things we've done that we regret - how we want to forget it all and move on. According to Bennington, the theme " +
//                    "of the song is 'admitting to your faults of the past and kind of accepting it and moving on and trying to become something better.'",
//                    PictureURL = "https://upload.wikimedia.org/wikipedia/en/9/94/WhatI%27veDoneCover.jpg"
//                };
//                Song songThree = new Song { SongID = 3, NameOfSong = "Castle of glass", NameOfArtist = "Linkin park", Duration = "4:50" , SongURL = "ScNNfyq3d_w",
//                    FunFact= "This moody, atmospheric rocker has lyrics about being but a small crack in the 'Castle of Glass', illustrating both belonging and futility. The song was born " +
//                    "out of Linkin Park's less-than-traditional methods of recording.",
//                    PictureURL = "https://images-na.ssl-images-amazon.com/images/I/51faD0DXDVL._SS500.jpg"
//                };
//                Song songFour = new Song { SongID = 4, NameOfSong = "Waiting for love", NameOfArtist = "Avicii", Duration = "3:51", SongURL = "cHHLHGNpCSA",
//                    FunFact= "Avicii worked with the French animation collective Blackmeal to create the song's charming lyric video. It took a team of six animators to create the nearly " +
//                    "four-minute clip, which explores the relationship between a boy and his dog.",
//                    PictureURL = "https://pbs.twimg.com/media/CFp4EXIUEAAb4Au.jpg"
//                };
//                Song songFive = new Song { SongID = 5, NameOfSong = "Hotel California", NameOfArtist = "Eagles", Duration = "6:30", SongURL = "Cck1TMtVedA",
//                    FunFact= "The lyrics for the song came with the album. Some listeners thought the line 'She's got the Mercedes Bends' was a misspelling of 'Mercedes Benz,' not realizing " +
//                    "the line was a play on words.",
//                    PictureURL = "https://trademarklawyermagazine.com/wp-content/uploads/2017/05/hqdefault.jpg"
//                };
//                Song songSix = new Song { SongID = 6, NameOfSong = "New rules", NameOfArtist = "Dua Lipa", Duration = "3:10", SongURL = "k2qgadSvNyU",
//                    FunFact= "Lipa said: 'It's the breakup song that I wish I had when I was breaking up with someone. This is me taking charge.'",
//                    PictureURL = "https://images.genius.com/685d5f086260ce1bccca9e7e8209d9f2.1000x1000x1.jpg"
//                };

//                Playlist playlistOne = new Playlist { PlaylistID = 1, PlaylistName = "Rock", PlaylistImage= "https://i.scdn.co/image/089f36d81503ca2da6f1a655a7dcf67d6d44c4e5" };
//                Playlist playlistTwo = new Playlist { PlaylistID = 2, PlaylistName = "LP", PlaylistImage= "https://peopledotcom.files.wordpress.com/2017/07/chester-bennington-2.jpg" };
//                Playlist playlistThree = new Playlist { PlaylistID = 3, PlaylistName = "Hip hop", PlaylistImage= "http://hdwall.us/thumbnail/music_rock_pop_liverpool_the_beatles_bands_and_band_from_desktop_1600x1200_wallpaper-388697.jpg" };

//                songOne.SongPlaylists.Add(playlistOne);
//                playlistOne.SongPlaylists.Add(songOne);

//                songTwo.SongPlaylists.Add(playlistTwo);
//                playlistTwo.SongPlaylists.Add(songTwo);

//                songThree.SongPlaylists.Add(playlistThree);
//                playlistThree.SongPlaylists.Add(songThree);

//                songFour.SongPlaylists.Add(playlistOne);
//                playlistOne.SongPlaylists.Add(songFour);

//                songFive.SongPlaylists.Add(playlistTwo);
//                playlistTwo.SongPlaylists.Add(songFive);

//                songSix.SongPlaylists.Add(playlistThree);
//                playlistThree.SongPlaylists.Add(songSix);

//                songOne.SongPlaylists.Add(playlistOne);
//                playlistOne.SongPlaylists.Add(songOne);

//                songTwo.SongPlaylists.Add(playlistTwo);
//                playlistTwo.SongPlaylists.Add(songTwo);

//                songThree.SongPlaylists.Add(playlistThree);
//                playlistThree.SongPlaylists.Add(songThree);

//                songs.Add(songOne);
//                songs.Add(songTwo);
//                songs.Add(songThree);
//                songs.Add(songFour);
//                songs.Add(songFive);
//                songs.Add(songSix);

//                playlists.Add(playlistOne);
//                playlists.Add(playlistTwo);
//                playlists.Add(playlistThree);
//            }

//            allData = new ModelViewMusic() { MVSongs = songs, MVPlaylists = playlists };
//        }

//        public List<Song> GetAllSongs()
//        {
//            return songs;
//        }

//        public Playlist GetSpecificPlaylist(int id)
//        {
//            return playlists.Find(e => e.PlaylistID == id);
//        }

//        public Song GetSpecificSong(int id)
//        {
//            return songs.Find(e => e.SongID == id);
//        }



//        public ModelViewMusic GetAllData()
//        {
//            return allData;
//        }


//        public void RenamePlaylist(RenamePlaylistViewModel renamingPlaylist)
//        {
//            Playlist wantedPlaylist = playlists.Find(e => e.PlaylistName == renamingPlaylist.OldNamePlaylist);
//            wantedPlaylist.PlaylistName = renamingPlaylist.NewNamePlaylist;

//            return;
//        }

//        public void DeletePlaylist(string playlistName)
//        {
//            Playlist deletedPlaylist = playlists.FirstOrDefault(e=> e.PlaylistName == playlistName);
//            playlists.Remove(deletedPlaylist);

//            return;
//        }

//        public int GetNewID(string option)
//        {
//            int count = 0, lastID = 0;
//            if(option == "playlist")
//            {
//                count = playlists.Count();
//                lastID = playlists[--count].PlaylistID;
//            }
//            else if(option == "song")
//            {
//                count = songs.Count();
//                lastID = songs[--count].SongID;
//            }

//            lastID++;
//            return lastID;
//        }


//        public IEnumerable<Song> GetAllSongsAZ()
//        {
//            return songs.OrderBy(a => a.NameOfArtist).ThenBy(a => a.NameOfSong).ThenBy(a => a.SongID);
//        }

//        public string GetURL(int id)
//        {
//            return songs.Find(e => e.SongID == id).SongURL;
//        }

//        public void DeleteSongFromPlaylist(DeleteSongFromPlaylistViewModel deletingSongFromPlaylist)
//        {
//            Playlist wantedPlaylist = playlists.Find(a => a.PlaylistID == deletingSongFromPlaylist.PlaylistID);
//            Song wantedSong = songs.Find(a => a.SongID == deletingSongFromPlaylist.SongID);

//            wantedPlaylist.SongPlaylists.Remove(wantedSong);
//            wantedSong.SongPlaylists.Remove(wantedPlaylist);

//            return;
//        }

//        public int GetLastPlaylistID()
//        {
//            Playlist lastPlaylist = playlists[playlists.Count - 1];
//            return lastPlaylist.PlaylistID;
//        }


//        public void DeleteSong(int songId)
//        {
//            Song song = songs.Find(a => a.SongID == songId);
//            songs.Remove(song);
//            RemoveDeletingSongFromPlaylists(song);
//        }

//        public void RemoveDeletingSongFromPlaylists(Song song)
//        {
//            foreach ( var playlist in playlists)
//            {
//                for (int i = 0; i < playlist.SongPlaylists.Count(); i++)
//                {
//                    if (playlist.SongPlaylists[i].SongID == song.SongID)
//                    {
//                        playlist.SongPlaylists.Remove(song);
//                    }
//                }
//            }
//        }


//        public void AddNewSong(Song song)
//        {
//            song.SongID = GetNewID("song");
//            songs.Add(song);
//        }

//        public EditSongViewModel GetEditingSong(int id)
//        {
//            Song song = songs.Find(a => a.SongID == id);

//            EditSongViewModel editingSong = new EditSongViewModel
//            {
//                SongID = id,
//                NameOfSong = song.NameOfSong,
//                NameOfArtist = song.NameOfArtist,
//                Duration = song.Duration,
//                SongURL = song.SongURL,
//                PictureURL = song.PictureURL,
//                FunFact = song.FunFact
                
//            };

//            return editingSong;

//        }

//        /* NAPISI AJAX ZAHTJEV KOJI UKLJUCUJE ID */
//        public void EditSong(EditSongViewModel editedSong)
//        {
//            Song song = songs.Find(a => a.SongID == editedSong.SongID);

//            song.NameOfSong = editedSong.NameOfSong;
//            song.NameOfArtist = editedSong.NameOfArtist;
//            song.Duration = editedSong.Duration;
//            song.SongURL = editedSong.SongURL;
//            song.PictureURL = editedSong.PictureURL;
//            song.FunFact = editedSong.FunFact;

//        }

//        public void AddSongsToPlaylist(AddingSongsToPlaylistViewModel fullDataAddingSongsToPlaylist)
//        {
//            Playlist wantedPlaylist = playlists.Find(a => a.PlaylistID == fullDataAddingSongsToPlaylist.PlaylistID);

//            foreach (var songIdentificator in fullDataAddingSongsToPlaylist.ArrayOfSongAddingToPlaylist)
//            {
//                Song wantedSong = songs.Find(a => a.SongID == songIdentificator);

//                wantedPlaylist.SongPlaylists.Add(wantedSong);
//                wantedSong.SongPlaylists.Add(wantedPlaylist);
//            }

//            return;
//        }

//        /*    HOME CONTROLLER       */
//        public List<Playlist> Get()
//        {
//            return playlists;
//        }

//        public void Add(AddPlaylistViewModel playlist)
//        {
//            Playlist newPlaylist = new Playlist
//            {
//                PlaylistID = GetNewID("playlist"),
//                PlaylistName = playlist.NameOfPlaylist,
//                PlaylistImage = playlist.UrlOfPlaylist
//            };

//            playlists.Add(newPlaylist);
//            return;
//        }
//    }
//}