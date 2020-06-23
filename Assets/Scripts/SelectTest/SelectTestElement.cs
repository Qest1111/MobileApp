using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectTestElement : MonoBehaviour
{
    public Button StartButton;
    public Text TestNameText;

    public void Init(Test data)
    {
        TestNameText.text = data.name;
        StartButton.onClick.AddListener(() => {
            SelectTestController.CurrentTest = data;
            SceneLoader.instance.LoadScene(4);
        });
    }
}
