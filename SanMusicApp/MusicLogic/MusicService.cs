using Newtonsoft.Json;
using SanMusicCommon;

namespace SanMusicApp.MusicLogic
{
    public class MusicService : IMusicService
    {
        public MusicService()
        {
            GetAllSongs();
            Random = new Random();
        }

        private IEnumerable<Song> AllSongs { get; set; }
        private Random Random { get; set; }

        private void GetAllSongs()
        {
            var path = "wwwroot\\data\\sanmusic.json";
            var json = File.ReadAllText(path);
            AllSongs = JsonConvert.DeserializeObject<IEnumerable<Song>>(json);
        }


        public IEnumerable<string> GetCategories()
        {
            return AllSongs.Select(x => x.Genre).Distinct().OrderBy(x => x);
        }

        public IEnumerable<ShortSong> GetRandomSongs()
        {
            return AllSongs.OrderBy(x => Random.Next()).Take(6).Select(x => Map(x));
        }

        public Song GetSongById(string id)
        {
            return AllSongs.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<ShortSong> GetSongsByCategory(string category)
        {
            return AllSongs.Where(x => x.Genre == category).Select(x => Map(x));
        }

        public IEnumerable<ShortSong> GetSongsByLength(int min, int max)
        {
            return AllSongs.Where(x => x.LenghInMinutes >= min 
                    && x.LenghInMinutes <= max).Select(x => Map(x));
        }

        public IEnumerable<ShortSong> SearchByTitleOrArtist(string pharase)
        {
           return AllSongs.Where(x => x.Artist.Contains(pharase) || x.Title.Contains(pharase)).Select(x => Map(x));
        }

        private ShortSong Map(Song song)
        {
            return new ShortSong
            {
                Id= song.Id,
                Artist= song.Artist,
                Title= song.Title,
                Cover = song.Image
            };
        }
    }
}
