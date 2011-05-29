using System.Collections.Generic;

namespace CP.FluentlyPersistent.Core.Domain
{
    
    public class Artist : Entity
    {
        public virtual string Name { get; set; }
        public virtual IList<Album> Albums { get; set; }
    }

    public class Album : Entity
    {
        public virtual string Title { get; set; }
        public virtual IList<Track> Tracks { get; set; }
    }

    public class Track : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Composer { get; set; }

        public virtual Genre Genre { get; set; }

        public virtual MediaType MediaType { get; set; }
        public virtual int Milliseconds { get; set; }
        public virtual int Bytes { get; set; }
    }

    public class Playlist : Entity
    {
        public virtual string Name { get; set; }
        public virtual IList<Track> Tracks { get; set; }
    }


    public class Genre : Entity
    {
        public virtual string Name { get; set; }
    }

    public class MediaType : Entity
    {
        public virtual string Name { get; set; }
    
}