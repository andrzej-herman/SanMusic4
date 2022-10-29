using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanMusicCommon
{
    public class Song
    {
        public string Id { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public int LenghtInSeconds { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
        public string Genre { get; set; }
        public int LenghInMinutes => Convert.ToInt32(LenghtInSeconds / 60);
    }
}
