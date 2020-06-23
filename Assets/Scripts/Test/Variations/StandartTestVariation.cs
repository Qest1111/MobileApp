using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class StandartTestVariation : TestVariation
{
    public List<Button> AnswerButtons = new List<Button>();

    public override float GetEndResult()
    {
        float trueAnswers = SelectTestController.CurrentTest.correctAnswers.Count(x => _selectedAnswers.Count(z => z.answerText == x.correctAnswerText) != 0);
        float falseAnswers = _selectedAnswers.Count(x => SelectTestController.CurrentTest.correctAnswers.Count(z=>z.correctAnswerText==x.answerText)==0);

        return Mathf.Max(((trueAnswers-falseAnswers)/SelectTestController.CurrentTest.correctAnswers.Count)*100,0);
    }

    public override void InitAnswers(List<Answer> answers)
    {
        AnswerButtons.ForEach(x => x.gameObject.SetActive(false));

        for(int i=0;i<answers.Count;i++)
        {
            Button CurrentButton = AnswerButtons[i];
            CurrentButton.gameObject.SetActive(true);
            CurrentButton.transform.Find("Text").GetComponent<Text>().text = answers[i].answerText;
            CurrentButton.GetComponent<AnswerElement>().CurrentAnswer = answers[i];
            CurrentButton.onClick.AddListener(() => {
                OnAnswerSelected(CurrentButton.GetComponent<AnswerElement>());
            });
        }
    }

    private List<Answer> _selectedAnswers = new List<Answer>();

    public void OnAnswerSelected(AnswerElement sender)
    {
        if(_selectedAnswers.Contains(sender.CurrentAnswer))
        {
            _selectedAnswers.Remove(sender.CurrentAnswer);
            sender.GetComponent<Image>().color = Color.white;
        }
        else
        {
            _selectedAnswers.Add(sender.CurrentAnswer);
            sender.GetComponent<Image>().color = Color.gray;
        }
    }
}
