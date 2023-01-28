using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectOpacity : MonoBehaviour
{
    [SerializeField] private List<Renderer> _renderers;

    private GameObject[] _selectedObject;

    private void Start()
    {
        SelectedObjectList.Singleton.OnChanged += GetMaterials;
    }

    private void GetMaterials()
    {
        _selectedObject = SelectedObjectList.Singleton.ObjectList.Dictionary.Values.ToArray();
        foreach (var i in _selectedObject)
        {
            print(i);
        }
        _renderers.Clear();
        foreach (var ren in _selectedObject)
            _renderers.Add(ren.GetComponent<Renderer>());
    }
    public void SliderAlpha(float sliderValue)
    {
        foreach(var ren in _renderers)
        {
            Color color = ren.material.color;
            color.a = sliderValue;
            ren.material.color = color;
        }
    }
}
