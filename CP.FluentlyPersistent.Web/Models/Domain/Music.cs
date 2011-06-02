using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CP.FluentlyPersistent.Web.Models.Domain
{
    public class Album : Entity
    {
        [Required]
        public virtual Artist Artist { get; set; }

        [StringLength(160)]
        public virtual string Title { get; set; }

        public virtual IList<Track> Tracks { get; set; }
    }

    public class Artist : Entity
    {
        [StringLength(120)]
        public virtual string Name { get; set; }

        public virtual IList<Album> Albums { get; set; }
    }

    public class Track : Entity
    {
        [Required, StringLength(200)]
        public virtual string Name { get; set; }

        [StringLength(220)]
        public virtual string Composer { get; set; }

        public virtual Genre Genre { get; set; }

        [Required]
        public virtual MediaType MediaType { get; set; }

        [Required]
        public virtual int Milliseconds { get; set; }

        public virtual int Bytes { get; set; }

        public virtual decimal UnitPrice { get; set; }
    }

    public class Playlist : Entity
    {
        [StringLength(120)]
        public virtual string Name { get; set; }

        public virtual IList<Track> Tracks { get; set; }

    }

    public class Genre : Entity
    {
        [StringLength(120)]
        public virtual string Name { get; set; }
    }

    public class MediaType : Entity
    {
        [StringLength(120)]
        public virtual string Name { get; set; }
    }
}