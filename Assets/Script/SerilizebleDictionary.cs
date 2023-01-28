using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SerilizebleDictionary<TKey ,TValue> : ISerializationCallbackReceiver, IEnumerable<KeyValuePair<TKey, TValue>>
{
    [SerializeField] private List<TKey> _keys = new List<TKey>();
    [SerializeField] private List<TValue> _values = new List<TValue>();

    public Dictionary<TKey, TValue> Dictionary = new Dictionary<TKey, TValue>();
    public SerilizebleDictionary(){}
    public SerilizebleDictionary(SerilizebleDictionary<TKey, TValue> dict)
    {
        _keys = dict._keys;
        _values = dict._values;
    }

    public void OnAfterDeserialize()
    {
        for(int i = 0; i != Mathf.Min(_keys.Count, _values.Count); i++)
            Dictionary.Add(_keys[i], _values[i]);
    }

    public void OnBeforeSerialize()
    {
        _keys.Clear();
        _values.Clear();

        foreach (var keyValue in Dictionary)
        {
            _keys.Add(keyValue.Key);
            _values.Add(keyValue.Value);
        }
    }

    public void OnGUI()
    {
        foreach(var keyValue in Dictionary)
            GUILayout.Label($"Key: {keyValue.Key} Value: {keyValue.Value}");
    }

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => Dictionary.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => Dictionary.GetEnumerator();
}
