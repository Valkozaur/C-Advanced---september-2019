using System;
using System.Runtime.CompilerServices;

namespace _4.OnlineRadioDatabase
{
    public class Song
    {
        private const string NameErrorMessage = "{0} name should be between 3 and {1} symbols.";
        private const string LengthOfSongErrorMessage = "Song {0} should be between 0 and {1}.";

        private const int MaxArtistNameSymbols = 20;
        private const int MaxSongNameSymbols = 30;

        private const int MaxSongMinutes = 14;
        private const int MaxSongSeconds = 59;

        private string artist;
        private string name;
        private int minutes;
        private int seconds;

        public static decimal TotalTimeInSeconds { get; private set; }

        public Song(string artist, string name, string length)
        {
            this.Artist = artist;
            this.Name = name;

            var splitLength = ValidateLength(length);
            var minutes = int.Parse(splitLength[0]);
            var seconds = int.Parse(splitLength[1]);

            this.Minutes = minutes;
            this.Seconds = seconds;
            TotalTimeInSeconds += this.minutes * 60 + this.seconds;
        }

        public string Artist
        {
            get => this.artist;
            set
            {
                this.LengthValidation(value, MaxArtistNameSymbols, nameof(this.Artist));

                this.artist = value;
            }
        }

        public string Name
        {
            get => this.name;
            set
            {
                this.LengthValidation(value, MaxSongNameSymbols, "Song");

                this.name = value;
            }
        }

        public int Minutes
        {
            get => this.minutes;
            set
            {
                if (value < 0 || value > 14)
                {
                    throw new InvalidSongMinutesException(string.Format(LengthOfSongErrorMessage, nameof(this.minutes), MaxSongMinutes));
                }

                this.minutes = value;
            }

        }

        public int Seconds
        {
            get => this.seconds;
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new InvalidSongSecondsException(string.Format(LengthOfSongErrorMessage, nameof(this.seconds), MaxSongSeconds));
                }

                this.seconds = value;
            }

        }

        private void LengthValidation(string value, int maxLenght, string caller)
        {
            if (value.Length < 3 || value.Length > 20)
            {
                throw new InvalidArtistNameException(string.Format(NameErrorMessage, caller, maxLenght));
            }
        }

        private string[] ValidateLength(string length)
        {
            var splitLength = length
                .Split(":");


            if (splitLength.Length == 2)
            {
                var isMinutes = int.TryParse(splitLength[0], out int minutes);
                var isSeconds = int.TryParse(splitLength[1], out int seconds);

                if (!isMinutes || !isSeconds)
                {
                    throw new InvalidSongLengthException("Invalid song length.");
                }

                return splitLength;
            }
            else
            {
                throw new InvalidSongLengthException("Invalid song length.");
            }

        }
    }
}
