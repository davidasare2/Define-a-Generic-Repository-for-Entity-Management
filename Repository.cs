public class Repository<T>
{
    private readonly List<T> _items = new List<T>();

    public void Add(T item) => _items.Add(item);

    public List<T> GetAll() => new List<T>(_items);

    public T? GetById(Func<T, bool> predicate) => _items.FirstOrDefault(predicate);

    public bool Remove(Func<T, bool> predicate)
    {
        var item = GetById(predicate);
        return item != null && _items.Remove(item);
    }
}