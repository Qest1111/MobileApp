using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class QuestUI : MonoBehaviour
{
    public Text QuestText, TimerText;
    public GameObject QuestCanvasObject;

    public void Init(Test data)
    {
        QuestText.text = data.questionText;
        InitTimer(data.timeForQuestionsInSec);
    }

    public void InitTimer(int secs)
    {
        TimerText.text = TimeSpan.FromSeconds(secs).ToString();
    }
}
