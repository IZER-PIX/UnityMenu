using System;
using UnityEngine;
using UnityEngine.UI;

public class SelectObject : MonoBehaviour
{
    [SerializeField] private bool _isSelected = false;
    [SerializeField] private ObjectPanel _target;
    [SerializeField] private Toggle _toggleUI;

    public bool IsSelected 
    { 
        get => _isSelected;
        private set => _isSelected = value;
    }
    public ObjectPanel Target
    { 
        get => _target;
        set => _target = value;
    }
    public static SelectObject Singleton { get; private set; }

    private void Awake()
    {
        Singleton = this;
        _toggleUI = GetComponent<Toggle>();
    }
    public void TogleSelection()
    {
        _isSelected = !_isSelected;
        _toggleUI.isOn = _isSelected;

        if (_isSelected == true)
            SelectedObjectList.Singleton.AddObject(_target.Index, _target.Target);
        else
            SelectedObjectList.Singleton.RemoveObject(_target.Index);
    }
}
