using UnityEngine;
using UnityEngine.UI;

public class ScrollVievManager : MonoBehaviour
{
    [SerializeField] private ObjectPanel _panel;
    [SerializeField] private RectTransform _content;

    private void Start()
    {
        WorldObjectList.Singleton.OnAddedToWorld += (int index, GameObject gObj) =>
        {
            if (!UIObjectList.Singleton.Objects.Dictionary.ContainsKey(index))
            {
                UIObjectList.Singleton.Objects.Dictionary.Add(index, gObj);
                CreatePanel(gObj, index);
            }
        };
    }
    
    private void CreatePanel(GameObject target, int index)
    {
        var panel = Instantiate(_panel, _content);
        panel.Target = target;
        panel.Index = index;
    }
}