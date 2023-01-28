using System;
using UnityEngine;
using UnityEngine.UI;

public class SelectAllObject : MonoBehaviour
{
    [SerializeField] private bool _isSelected = false;
    [SerializeField] private Toggle _toggleUI;


    private void Awake()
    {
        _toggleUI = GetComponent<Toggle>();
    }

    public void TogleSelection() // работает один почему-то раз :/
    {
        _isSelected = !_isSelected;
        _toggleUI.isOn = _isSelected;
        print(_toggleUI.isOn);
        if (_isSelected == true)
            SelectedObjectList.Singleton.AddAllObjects();
        else
            SelectedObjectList.Singleton.RemoveAllObjects();
    }
}
