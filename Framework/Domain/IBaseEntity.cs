namespace Framework.Domain
{
    public interface IBaseEntity<T>
    {
        public T Id { get; set; }
    }
}
