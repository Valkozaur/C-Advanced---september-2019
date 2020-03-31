namespace _4.OnlineRadioDatabase
{
    using System.Collections.Generic;

    public class Repository
    {
        private List<Song> database;

        public Repository()
        {
            this.database = new List<Song>();
        }

        public List<Song> Database => this.database;

        public string AddSong(Song song)
        { 
            database.Add(song);
            return "Song added.";
        }
    }
}
