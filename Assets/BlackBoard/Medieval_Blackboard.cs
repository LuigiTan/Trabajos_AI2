using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Windows.Speech;

[CreateAssetMenu(fileName = "Medieval Blackboard" ,menuName = "AI/Medieval Blackboard")]
public class MedievalBlackboard:ScriptableObject
{
    private Dictionary<string, object> data = new();

    public void Set<T>(string key, T value)
    {
        //data.TryAdd(key, value);
        data[key] = value;//Esto deberia actualizar el valor si ya existe
    }
    public T Get<T>(string key)
    {
        if (data.TryGetValue(key, out object value))
        {
            return (T)value;
        }
        return default(T);
    }
}
