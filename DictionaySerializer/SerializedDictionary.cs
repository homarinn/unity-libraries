using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializedDictionary<K, V> : Dictionary<K, V>, ISerializationCallbackReceiver
{
    public virtual K DefaultKey => default;

    [System.Serializable]
    internal class KeyValue
    {
        public K Key;
        public V Value;

        public KeyValue(K key, V value)
        {
            Key = key;
            Value = value;
        }
    }
    [SerializeField] List<KeyValue> itemList = new List<KeyValue>();

    void ISerializationCallbackReceiver.OnAfterDeserialize()
    {
        Clear();
        foreach (var item in itemList)
        {
            this[ContainsKey(item.Key) ? DefaultKey : item.Key] = item.Value;
        }
    }

    void ISerializationCallbackReceiver.OnBeforeSerialize()
    {
    }
}

[System.Serializable]
public class SerializedDictionary<V> : SerializedDictionary<string, V>
{
    public override string DefaultKey => string.Empty;
}

[System.Serializable]
public class SerializedDictionaryC<K, V> : SerializedDictionary<K, V> where K : new()
{
    public override K DefaultKey => new();
}
