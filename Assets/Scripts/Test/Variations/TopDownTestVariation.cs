using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TopDownTestVariation : TestVariation
{
    public List<GameObject> AnswerObjects = new List<GameObject>(); 

    public override float GetEndResult()
    {
        List<AnswerElement> CurrentAnswers = AnswerObjects.OrderBy(x => x.transform.GetSiblingIndex()).Select(x => x.GetComponent<AnswerElement>()).ToList();

        float trueAnswers = 0;
        float falseAnswers = 0;

        for(int i=0;i<CurrentAnswers.Count;i++)
        {
            if (CurrentAnswers[i].CurrentAnswer.answerText == SelectTestController.CurrentTest.correctAnswers[i].correctAnswerText)
                trueAnswers += 1;
            else
                falseAnswers += 1;
        }

        return Mathf.Max(((trueAnswers - falseAnswers) / SelectTestController.CurrentTest.correctAnswers.Count) * 100, 0);
    }

    public override void InitAnswers(List<Answer> answers)
    {
        AnswerObjects.ForEach(x => x.SetActive(false));
        for(int i=0;i<answers.Count;i++)
        {
            AnswerObjects[i].transform.Find("Text").GetComponent<Text>().text = answers[i].answerText;
            AnswerObjects[i].GetComponent<AnswerElement>().CurrentAnswer = answers[i];
            AnswerObjects[i].SetActive(true);
        }
    }
}
