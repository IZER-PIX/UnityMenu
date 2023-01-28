using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPanel : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private TextMeshProUGUI _text;

    private int _index;
    private GameObject _panel;
    private SelectObject _selectObject;
    private TogleObject _togleObject;

    public GameObject Panel 
    { 
        get => _panel; 
        set => _panel = gameObject;
    }
    public GameObject Target 
    { 
        get => _target;
        set => _target = value; 
    }
    public int Index 
    { 
        get => _index;
        set => _index = value;
    }
    public TextMeshProUGUI Text
    {
        get => _text;
        set => _text = value;
    }

    private void Awake()
    {
        _selectObject = GetComponentInChildren<SelectObject>();
        _togleObject  = GetComponentInChildren<TogleObject>();
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Start()
    {
        _selectObject.Target = this;
        _togleObject.Target = _target;
        _text.text = _target.name;
    }
}
