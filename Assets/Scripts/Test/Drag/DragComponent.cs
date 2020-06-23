using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragComponent : MonoBehaviour ,IDragHandler,IBeginDragHandler,IEndDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        DragContainer.instance.OnObjectStartDrag(gameObject);
        transform.SetParent(GameObject.FindGameObjectWithTag("DragCanvas").transform);
        GetComponent<Image>().raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (transform.parent == GameObject.FindGameObjectWithTag("DragCanvas").transform)
            DragContainer.instance.SetElement(gameObject);
    }
}
