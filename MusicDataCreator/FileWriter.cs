using Newtonsoft.Json;
using SanMusicCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MusicDataCreator
{
    internal class FileWriter
    {
        private readonly string path;
        private readonly List<Song> songs;

        public FileWriter(string path, List<Song> songs)
        {
            this.path = path;
            this.songs = songs;
        }

        public void SaveFile()
        {
            Console.WriteLine();
            Console.WriteLine(" Trwa zapis pliku ...");
            var json = JsonConvert.SerializeObject(songs);
            File.WriteAllText(path, json);
        }
    }
}
