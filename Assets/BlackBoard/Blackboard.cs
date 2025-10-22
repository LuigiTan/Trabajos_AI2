using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Windows.Speech;

public class Blackboard 
{
    private Dictionary<string, object> data = new();

    public void Set<T>(string key, T value)
    {
        data.TryAdd(key, value);
    }
    public T Get<T>(string key)
    {
        if(data.TryGetValue(key, out object value))
        {
            return (T)value;
        }
        return default(T);
    }
}
