using System;
using UnityEngine;

public class WorldObjectList : MonoBehaviour
{
    public event Action<int ,GameObject> OnAddedToWorld;

    [SerializeField] private SerilizebleDictionary<int, GameObject> _objects;

    public SerilizebleDictionary<int, GameObject> Objects
    {
        get => _objects;
    }
    public static WorldObjectList Singleton { get; private set; }

    private void Awake()
    {
        Singleton = this;

        var tempObjs = GameObject.FindGameObjectsWithTag("obj");
        _objects = new SerilizebleDictionary<int, GameObject>();

        for (int i = 0; i < tempObjs.Length; i++)
            _objects.Dictionary.Add(i, tempObjs[i]);

        for (int i = 0; i < _objects.Dictionary.Count; i++)
        {
            if (_objects.Dictionary[i].GetComponent<SetVisible>() == null)
                _objects.Dictionary[i].AddComponent<SetVisible>();
        }
    }
    private void Update()
    {
        foreach(var obj in _objects)
            OnAddedToWorld?.Invoke(obj.Key, _objects.Dictionary[obj.Key]);
    }
}
