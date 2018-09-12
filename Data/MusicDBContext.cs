using Microsoft.EntityFrameworkCore;
using mnRelations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mnRelations.Data
{
    public class MusicDBContext : DbContext
    {
        public MusicDBContext(DbContextOptions options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SongPlaylist>()
                .HasKey(sp => new { sp.SongID, sp.PlaylistID });

            modelBuilder.Entity<SongPlaylist>()
                .HasOne(songPlaylist => songPlaylist.Song)
                .WithMany(song => song.SongPlaylists)
                .HasForeignKey(songPLaylist => songPLaylist.SongID);

            modelBuilder.Entity<SongPlaylist>()
                .HasOne(songPlaylist => songPlaylist.Playlist)
                .WithMany(playlist => playlist.SongPlaylists)
                .HasForeignKey(songPlaylist => songPlaylist.PlaylistID);
        }

        public DbSet<Song> Songs { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        //public DbSet<SongPlaylist> SongPlaylists { get; set; }
    }
}
