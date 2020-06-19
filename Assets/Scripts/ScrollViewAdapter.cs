using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScrollViewAdapter : MonoBehaviour
{

    public RectTransform prefarb;
    public Text countText;
    public RectTransform content;

    private DataController dataController;

    void Start()
    {
        dataController = FindObjectOfType<DataController>();                    

        int modelsCount = dataController.allData.Length; ;
        //  int.TryParse(countText.text, out modelsCount);
        StartCoroutine(GetItems(modelsCount, results => OnReceivedModels(results)));
    }

    void OnReceivedModels(TestItemModel[] models)
    {
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        foreach (var model in models)
        {
            var instance = GameObject.Instantiate(prefarb.gameObject) as GameObject;
            instance.transform.SetParent(content, false);
            InitializeItemView(instance, model);
        }
    }

    void InitializeItemView(GameObject viewGameObject, TestItemModel model)
    {
        TestItemView view = new TestItemView(viewGameObject.transform);
        view.titleText.text = model.title;
        view.numberText.text = model.number;
        view.clickButton.GetComponentInChildren<Text>().text = model.buttonText;
        view.clickButton.onClick.AddListener(
            () =>
            {
                int level;
                level = Int32.Parse(view.numberText.text);
                dataController.round = level;

                UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
                Debug.Log(view.titleText.text + " is clicked!");
            }
        );
    }

    IEnumerator GetItems(int count, System.Action<TestItemModel[]> callback)
    {
        yield return new WaitForSeconds(0f);
        var results = new TestItemModel[count];

    

        for (int i = 0; i < count; i++)
        {
            results[i] = new TestItemModel();
            results[i].title = "Задание " + i;
            results[i].buttonText ="Начать тестирование";
            results[i].number = "" + i;
        }

        callback(results);
    }

    public class TestItemView
    {
        public Text titleText;
        public Button clickButton;
        public Text numberText;

        public TestItemView(Transform rootView)
        {
            titleText = rootView.Find("TitleText").GetComponent<Text>();
            numberText = rootView.Find("NumberText").GetComponent<Text>();
            clickButton = rootView.Find("ClickButton").GetComponent<Button>();
        }
    }

    public class TestItemModel
    {
        public string title;
        public string buttonText;
        public string number;
    }
}