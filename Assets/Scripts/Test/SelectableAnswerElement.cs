using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectableAnswerElement : MonoBehaviour , IDragHandler,IEndDragHandler,IBeginDragHandler
{
    private LineRenderer _lineRenderer;

    public AnswerElement CurrentCorrectAnswer, CurrentSelectedAnswer = null;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.enabled = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _lineRenderer.SetPosition(0, (Vector2)Camera.main.ScreenToWorldPoint(transform.Find("LineStartPoint").transform.position));
        _lineRenderer.enabled = false;
        CurrentSelectedAnswer = null;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _lineRenderer.enabled = true;
        _lineRenderer.SetPosition(1, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(CurrentSelectedAnswer!=null)
        {
            _lineRenderer.enabled = true;
            _lineRenderer.SetPosition(1, (Vector2)Camera.main.ScreenToWorldPoint(CurrentSelectedAnswer.transform.Find("LineEndPoint").position));
        }
        else
            _lineRenderer.enabled = false;
    }
}
