using CrossCutting.Contract.Configuration;

namespace CrossCutting.Configuration;

public class Configurator : IConfigurator
{
    private readonly Dictionary<string, object> _items;

    public Configurator()
    {
        _items = new Dictionary<string, object>();
    }

    public TItem Get<TItem>(string key)
    {
        return (TItem)_items[key];
    }

    public void Set(string key, object value)
    {
        _items[key] = value;
    }
}