using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{

    public RectTransform prefab;
    public RectTransform content;
    private RoundData cuttrnttest;

    public void UpdateItems()
    {
        int modelsCount = 0;
        StartCoroutine(GetItems(modelsCount, results => OnReceivedModels(results)));
    }

    void OnReceivedModels(LoadLevelData[] models)
    {
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        foreach (var model in models)
        {
            var instance = GameObject.Instantiate(prefab.gameObject) as GameObject;
            instance.transform.SetParent(content, false);
            InitializeItemView(instance, model);
        }
    }

    void InitializeItemView(GameObject viewGameObject, LoadLevelData model)
    {
        TestItemView view = new TestItemView(viewGameObject.transform);
        view.titleText.text = model.title;
        view.clickButton.GetComponentInChildren<Text>().text = model.buttonText;
    }

    IEnumerator GetItems(int count, System.Action<LoadLevelData[]> callback)
    {
        yield return new WaitForSeconds(1f);
        var results = new LoadLevelData[count];
        for (int i = 0; i < count; i++)
        {
            results[i] = new LoadLevelData();
            results[i].title = "Item " + i;
            results[i].buttonText = "Button " + i;
            results[i].testNumber = "Number " + i;
        }

        callback(results);
    }

    public class TestItemView
    {
        public Text titleText;
        public Button clickButton;
        public Text testNumberText;

        public TestItemView(Transform rootView)
        {
            titleText = rootView.Find("TitleText").GetComponent<Text>();
            clickButton = rootView.Find("ClickButton").GetComponent<Button>();
            testNumberText = rootView.Find("TestNumberText").GetComponent<Text>();
        }
    }
}