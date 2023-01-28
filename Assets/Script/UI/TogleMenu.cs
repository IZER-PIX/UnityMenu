using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogleMenu : MonoBehaviour
{
    [SerializeField] private bool _isHide = false;
    [SerializeField] private GameObject _menu;

    private void Awake()
    {
        _menu = GameObject.FindGameObjectWithTag("Menu");
    }

    public void Toggle()
    {
        _isHide = !_isHide;
        _menu.SetActive(_isHide);
    }
}
