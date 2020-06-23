using System.Collections.Generic;

[System.Serializable]
public class TestData
{
    public List<Test> testData;
}

[System.Serializable]
public class Test
{
    public enum TestType
    {
        SelectAnswer=0,
        TopDown=1,
        Lines=2
    }
    public string name;
    public int timeForQuestionsInSec;
    public TestType typeOfTest;
    public string questionText;
    public List<Answer> answers;
    public List<CorrectAnswer> correctAnswers;
}

[System.Serializable]
public class Answer
{
    public string answerText;
}

[System.Serializable]
public class CorrectAnswer
{
    public string correctAnswerText;
}
