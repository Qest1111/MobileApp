﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectableAnswerTarget : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
       if(eventData.pointerDrag!=null&&eventData.pointerDrag.GetComponent<SelectableAnswerElement>())
            eventData.pointerDrag.GetComponent<SelectableAnswerElement>().CurrentSelectedAnswer = GetComponent<AnswerElement>();
    }
}
