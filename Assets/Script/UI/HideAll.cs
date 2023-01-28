using UnityEngine;

public class HideAll : MonoBehaviour
{
    private SerilizebleDictionary<int, GameObject> _targets;

    [SerializeField] private bool _isHide = false;

    private void Start()
    {
        _targets = WorldObjectList.Singleton.Objects;
    }

    public void Toggle()
    {
        foreach(var target in _targets)
        {
            target.Value.SetActive(_isHide);
        }
        _isHide = !_isHide;
    }
}
