using UnityEngine;

public class UIObjectList : MonoBehaviour
{
    [SerializeField] private SerilizebleDictionary<int, GameObject> _objects;

    public SerilizebleDictionary<int, GameObject> Objects
    {
        get => _objects;
        private set => _objects = value;
    }
    public static UIObjectList Singleton { get; private set; }
    
    private void Awake()
    {
        Singleton = this;
        _objects = new SerilizebleDictionary<int, GameObject>();
    }
    private void Update()
    {
        WorldObjectList.Singleton.OnAddedToWorld += (int index, GameObject obj) =>
        {
            if (!_objects.Dictionary.ContainsKey(index))
                _objects.Dictionary.Add(index, obj);
        };
    }
}