using System;

namespace Framework.Domain
{
    public interface IEntity<T> : IBaseEntity<T>
    {

    }

    public interface IEntity : IEntity<Guid>
    {

    }
}
