using UnityEngine;

public class TogleObject : MonoBehaviour
{
    [SerializeField] private bool _isHide = false;
    [SerializeField] private GameObject _target;

    public GameObject Target
    {
        get => _target;
        set => _target = value;
    }

    public void Toggle()
    {
        _target.SetActive(_isHide);
        _isHide = !_isHide;
    }
}
