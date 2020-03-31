namespace _4.OnlineRadioDatabase
{
    using System;

    public class InvalidSongException : Exception
    {
        public InvalidSongException()
        {
        }

        public InvalidSongException(string message)
            : base(message)
        {
        }

        public InvalidSongException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class InvalidArtistNameException : InvalidSongException
    {
        public InvalidArtistNameException()
        {
        }

        public InvalidArtistNameException(string message)
            : base(message)
        {
        }

        public InvalidArtistNameException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class InvalidSongNameException : InvalidSongException
    {
        public InvalidSongNameException()
        {
        }

        public InvalidSongNameException(string message)
            : base(message)
        {
        }

        public InvalidSongNameException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class InvalidSongLengthException : InvalidSongException
    {
        public InvalidSongLengthException()
        {
        }

        public InvalidSongLengthException(string message)
            : base(message)
        {
        }

        public InvalidSongLengthException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class InvalidSongMinutesException : InvalidSongLengthException
    {
        public InvalidSongMinutesException()
        {
        }

        public InvalidSongMinutesException(string message)
            : base(message)
        {
        }

        public InvalidSongMinutesException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class InvalidSongSecondsException : InvalidSongLengthException
    {
        public InvalidSongSecondsException()
        {
        }

        public InvalidSongSecondsException(string message)
            : base(message)
        {
        }

        public InvalidSongSecondsException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
