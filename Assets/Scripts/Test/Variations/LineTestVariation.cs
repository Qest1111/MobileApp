using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class LineTestVariation : TestVariation
{
    public List<GameObject> LeftAnswers = new List<GameObject>(),RightAnswers=new List<GameObject>();

    public override float GetEndResult()
    {
        List<SelectableAnswerElement> CurrentAnswers = LeftAnswers.Where(x=>x.gameObject.activeSelf).Select(x=>x.GetComponent<SelectableAnswerElement>()).ToList();

        float trueAnswers = CurrentAnswers.Count(x=>x.CurrentCorrectAnswer==x.CurrentSelectedAnswer);
        float falseAnswers = CurrentAnswers.Count(x => x.CurrentCorrectAnswer != x.CurrentSelectedAnswer&&x.CurrentSelectedAnswer!=null);

        return Mathf.Max(((trueAnswers - falseAnswers) / SelectTestController.CurrentTest.correctAnswers.Count) * 100, 0);
    }

    public override void InitAnswers(List<Answer> answers)
    {
        LeftAnswers.ForEach(x => x.SetActive(false));
        RightAnswers.ForEach(x => x.SetActive(false));

        answers = new List<Answer>(SelectTestController.CurrentTest.answers);
        for(int i=0;i<answers.Count;i++)
        {
            LeftAnswers[i].transform.Find("Text").GetComponent<Text>().text = answers[i].answerText;
            LeftAnswers[i].GetComponent<SelectableAnswerElement>().CurrentCorrectAnswer = RightAnswers[i].GetComponent<AnswerElement>();
            LeftAnswers[i].SetActive(true);

            RightAnswers[i].transform.Find("Text").GetComponent<Text>().text = SelectTestController.CurrentTest.correctAnswers[i].correctAnswerText;
            RightAnswers[i].SetActive(true);
        }

        RandomizeObjects(LeftAnswers);
        RandomizeObjects(RightAnswers);
    }

    private void RandomizeObjects(List<GameObject> target)=> target.ForEach(x => x.transform.SetSiblingIndex(Random.Range(0, target.Count)));
}
