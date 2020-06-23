using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class TestController : MonoBehaviour
{
    public List<TestVariation> Variations = new List<TestVariation>();

    public QuestUI QuestGraphics;
    public EndUI EndGraphics;

    private TestVariation _currentVariation;

    private void Start()
    {
        InitTest(SelectTestController.CurrentTest);
    }

    private void InitTest(Test test)
    {
        QuestGraphics.Init(test);
        StartCoroutine(TestTimer(test.timeForQuestionsInSec));

        _currentVariation = Variations.First(x => x.Type == test.typeOfTest);
        _currentVariation.Init();
        _currentVariation.InitAnswers(GetRandomizedList(test.answers));
    }

    private IEnumerator TestTimer(int secs)
    {
        QuestGraphics.InitTimer(secs);
        yield return new WaitForSecondsRealtime(1f);
        if (secs != 1)
            StartCoroutine(TestTimer(secs - 1));
        else
            OnClickAcceptAnswer();
    }

    public void OnClickAcceptAnswer()
    {
        StopAllCoroutines();
        _currentVariation.CanvasObject.SetActive(false);
        QuestGraphics.QuestCanvasObject.SetActive(false);
        SavedDataController.instance.AddStat(new SaveData() {name = SelectTestController.CurrentTest.name,Mark=_currentVariation.GetEndResult(),Date=DateTime.Now.ToShortDateString(),Time=DateTime.Now.ToShortTimeString() });
        EndGraphics.Init(_currentVariation.GetEndResult());
    }

    public void OnClickNextTestButton()
    {
        SelectTestController.CurrentTest = TestDataController.Data.testData[TestDataController.Data.testData.IndexOf(SelectTestController.CurrentTest) + 1];
        SceneLoader.instance.ReloadScene();
    }

    public void OnClickRestart()
    {
        SceneLoader.instance.ReloadScene();
    }

    private List<Answer> GetRandomizedList(List<Answer> value)
    {
        List<Answer> result = new List<Answer>();

        foreach (var item in value)
            result.Insert(UnityEngine.Random.Range(0, result.Count), item);

        return result;
    }
}
