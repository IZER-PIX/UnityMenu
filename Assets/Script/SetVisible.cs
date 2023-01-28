using System;
using System.Collections.Generic;
using UnityEngine;

public class SetVisible : MonoBehaviour
{
    public event Action<bool> Visible;

    [SerializeField] private GameObject _target;

    public GameObject Target
    {
        get => _target;
    }

    private void Awake()
    {
        _target = gameObject;
    }

    public void ToggleVisible()
    {
        if(_target.activeSelf != true)
            _target.SetActive(true);
        else
            _target.SetActive(false);

        Visible(_target.activeSelf);
    }
}
