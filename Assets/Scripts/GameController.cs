using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Globalization;
using System;
using System.IO;



public class GameController : MonoBehaviour
{
    public SimpleObjectPool answerButtonObjectPool;
    public Text questionText;
    public Text scoreDisplay;
    public Text timeRemainingDisplay;
    public Transform answerButtonParent;

    public GameObject questionDisplay;
    public GameObject roundEndDisplay;
    public Text highScoreDisplay;

    private DataController dataController;
    private RoundData currentRoundtest;
    private QuestionData[] questionPool;

    private bool isRoundActive = false;
    private float timeRemaining;
    private int playerMark;
    private int questionIndex;
    private List<GameObject> answerButtonGameObjects = new List<GameObject>();

    void Start()
    {
        dataController = FindObjectOfType<DataController>();                               

        currentRoundtest = dataController.GetCurrentRoundtest();                           
        questionPool = currentRoundtest.questions;                                           

        timeRemaining = currentRoundtest.timeLimitInSeconds;                                
        UpdateTimeRemainingDisplay();
        playerMark = 0;
        questionIndex = 0;

        ShowQuestion();
        isRoundActive = true;
    }

    void Update()
    {
        if (isRoundActive)
        {
            timeRemaining -= Time.deltaTime;                                               
            if (timeRemaining <= 0f)                                                        
            {
                EndRound();
            }
        }
    }

    void ShowQuestion()
    {
        RemoveAnswerButtons();

        QuestionData questionData = questionPool[questionIndex];                            
        questionText.text = questionData.questionText;                                        
        for (int i = 0; i < questionData.answers.Length; i++)                                
        {
            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();            
            answerButtonGameObjects.Add(answerButtonGameObject);
            answerButtonGameObject.transform.SetParent(answerButtonParent);
            answerButtonGameObject.transform.localScale = Vector3.one;

            AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            answerButton.SetUp(questionData.answers[i]);                                   
        }
    }

    void RemoveAnswerButtons()
    {
        while (answerButtonGameObjects.Count > 0)                                          
        {
            answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
            answerButtonGameObjects.RemoveAt(0);
        }
    }

    public void AnswerButtonClicked(bool isCorrect)
    {

      // string path;
      //  path = Path.Combine(Application.persistentDataPath, "Save.json");

        if (isCorrect)
        {
                  
            playerMark =1;                   
            scoreDisplay.text = playerMark.ToString();

        }
        else                                                                               
        {
            playerMark = 0;

            EndRound();
        }
    }

    private void UpdateTimeRemainingDisplay()
    {
        timeRemainingDisplay.text = Mathf.Round(timeRemaining).ToString();
    }

    public void EndRound()
    {
        isRoundActive = false;


        questionDisplay.SetActive(false);
        roundEndDisplay.SetActive(true);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MenuScreen");
    }
}