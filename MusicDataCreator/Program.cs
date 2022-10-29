using MusicDataCreator;

var source = "D:\\sanmusic_dane.txt";
var dest = "D:\\sanmusic.json";
var parser = new FileParser(source);
var songs = parser.GetSongs();
var writer = new FileWriter(dest, songs);
writer.SaveFile();