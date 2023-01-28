using System;
using System.Collections.Generic;
using UnityEngine;

public class SelectedObjectList : MonoBehaviour
{
    public event Action OnChanged;

    [SerializeField] private SerilizebleDictionary<int, GameObject> _selectedObjects;
 
    public SerilizebleDictionary<int, GameObject> ObjectList 
    { 
        get => _selectedObjects;
    }
    public static SelectedObjectList Singleton { get; private set; }

    private void Awake()
    {
        Singleton = this;
    }

    public void AddAllObjects()
    {
        var temp = WorldObjectList.Singleton.Objects.Dictionary;
        _selectedObjects.Dictionary = new Dictionary<int, GameObject>(temp);
        
        OnChanged?.Invoke();
    }
    public void RemoveAllObjects()
    {
        _selectedObjects.Dictionary.Clear();
        OnChanged?.Invoke();
    }
    public void AddObject(int index, GameObject obj)
    {
        _selectedObjects.Dictionary.Add(index, obj);
        OnChanged?.Invoke();
    }
    public void RemoveObject(int index)
    {
        _selectedObjects.Dictionary.Remove(index);
        OnChanged?.Invoke();
    }
}
