namespace CP.FluentlyPersistent.Web.Models.Domain
{
    public abstract class Entity : IPersistable
    {
        public virtual int Id { get; set; }
    }

    public interface IPersistable
    {
    }

    public interface IComponent
    {
    }
}