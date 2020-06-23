using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndUI : MonoBehaviour
{
    public Text ResultText;
    public Button NextTestButton;
    public GameObject EndCanvasObject;

    public void Init(float result)
    {
        EndCanvasObject.SetActive(true);
        ResultText.text = result == 100 ? "Тест выполнен успешно" : "Тест провален";
        if (TestDataController.Data.testData.IndexOf(SelectTestController.CurrentTest) == TestDataController.Data.testData.Count - 1)
            NextTestButton.interactable = false;
    }
}
