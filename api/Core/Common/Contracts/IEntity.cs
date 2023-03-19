namespace Core.Common.Contracts;

public interface IEntity<TId>
{
    TId Id { get; }
}