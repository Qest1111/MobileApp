using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using UnityEngine.UI;

public class DragContainer : MonoBehaviour, IDropHandler
{
    public static DragContainer instance;
    void Awake()
    {
        instance = this;
    }

    public GameObject DropParent;

    public GameObject EmptyElement;

    private List<GameObject> _elements = new List<GameObject>();

    private void Start()
    {
        foreach (Transform item in DropParent.transform)
            if (item.GetComponent<AnswerElement>())
                _elements.Add(item.gameObject);
    }

    public void OnObjectStartDrag(GameObject obj)
    {
        if (_elements.Contains(obj))
        {
            _elements.Remove(obj);
            _dragging = obj;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null || !eventData.pointerDrag.GetComponent<DragComponent>())
            return;

        SetElement(eventData.pointerDrag);        
    }

    public void SetElement(GameObject CurrentCopy)
    {
        CurrentCopy.transform.SetParent(DropParent.transform);
        CurrentCopy.GetComponent<Image>().raycastTarget = true;

        int NeedIndex = _elements.Count(x => x.transform.position.y > _dragging.transform.position.y);
        CurrentCopy.transform.SetSiblingIndex(NeedIndex);
        EmptyElement.transform.SetSiblingIndex(int.MaxValue);
        _elements.Add(CurrentCopy);

        _dragging = null;
    }

    private GameObject _dragging = null;

    void Update()
    {
        if(_dragging!=null)
        EmptyElement.transform.SetSiblingIndex(_elements.Count(x => x.transform.position.y > _dragging.transform.position.y));
    }
}
