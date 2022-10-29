using SanMusicCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDataCreator
{
    internal class FileParser
    {
        private readonly string path;

        public FileParser(string path)
        {
            this.path = path;
        }

        public List<Song> GetSongs()
        {
            Console.WriteLine();
            Console.WriteLine(" Rozpoczynam parsowanie pliku ...");
            var result = new List<Song>();
            var lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                if (!string.IsNullOrEmpty(line) && !string.IsNullOrWhiteSpace(line))
                {
                    var parts = line.Split("\t");
                    if (parts.Length == 8)
                    {
                        result.Add(CreateSong(parts));
                    }
                }
            }

            Console.WriteLine($" Utworzono {result.Count} utworów");
            return result;
        }

        private Song CreateSong(string[] parts)
        {
            //string napis = "";
            //var x = 5;
            //if (x == 5)
            //{
            //    napis = "pięć";
            //}
            //else
            //{
            //    napis = "nie pięć";
            //}

            //string napis2 = x == 5 ? "pięć" : "nie pięć"; 


            return new Song
            {
                Id = Guid.NewGuid().ToString(),
                Artist = parts[0],
                Title = parts[1],
                ReleaseYear = int.Parse(parts[2]),
                LenghtInSeconds = int.Parse(parts[3]),
                Image = parts[5],
                Url = parts[6],
                Genre = parts[7],
            };
        }
    }
}
