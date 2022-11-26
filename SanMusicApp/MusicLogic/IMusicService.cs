using SanMusicCommon;

namespace SanMusicApp.MusicLogic
{
    public interface IMusicService
    {
        IEnumerable<ShortSong> GetRandomSongs();
        IEnumerable<ShortSong> SearchByTitleOrArtist(string pharase);
        IEnumerable<ShortSong> GetSongsByCategory(string category);
        IEnumerable<ShortSong> GetSongsLength(int min, int max);
        IEnumerable<string> GetCategories();
        Song GetSongById(string id);
    }
}
