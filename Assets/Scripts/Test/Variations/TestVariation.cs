using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TestVariation : MonoBehaviour
{
    public Test.TestType Type;

    public GameObject CanvasObject;

    public virtual void Init()
    {
        CanvasObject.SetActive(true);
    }

    public abstract void InitAnswers(List<Answer> answers);

    public abstract float GetEndResult();
}
