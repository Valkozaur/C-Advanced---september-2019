namespace _4.OnlineRadioDatabase
{
using System;


    public class Program
    {
        public static void Main()
        {
            var database = new Repository();
            var numberOfSongsToAdd = int.Parse(Console.ReadLine());

            for (var i = 0; i < numberOfSongsToAdd; i++)
            {
                try
                {
                    var songsInput = Console.ReadLine()
                        .Split(";");

                    if (songsInput.Length == 3)
                    {
                        var artist = songsInput[0];
                        var songName = songsInput[1];
                        var minAndSec = songsInput[2];

                        var song = new Song(artist, songName, minAndSec);
                        Console.WriteLine(database.AddSong(song));
                    }
                    else
                    {
                        throw new InvalidSongException("Invalid song.");
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            Console.WriteLine($"Songs added: {database.Database.Count}");

            var timespan = TimeSpan.FromSeconds((double)Song.TotalTimeInSeconds);
            Console.WriteLine(string.Format($"Playlist length: {timespan.Hours}h {timespan.Minutes}m {timespan.Seconds}s"));
        }
    }
}
