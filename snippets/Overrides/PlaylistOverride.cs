using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace CP.FluentlyPersistent.Web.Models.Domain
{
    public class PlaylistOverride : IAutoMappingOverride<Playlist>
    {
        public void Override(AutoMapping<Playlist> mapping)
        {
            mapping.HasManyToMany(x => x.Tracks).Inverse().Table("PlaylistTrack").ForeignKeyConstraintNames(
                "FK_PlaylistTrackPlaylistId", "FK_PlaylistTrackTrackId");
        }
    }
}