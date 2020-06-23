using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDataController : MonoBehaviour
{
    public static bool Inited = false;
    public static TestDataController instance;
    private void Awake()
    {
        if (!Inited)
        {
            Inited = true;
            instance = this;
            DontDestroyOnLoad(gameObject);
            InitJson();
        }
        else
            Destroy(gameObject);
    }

    public TextAsset JSONFile;

    public void InitJson()
    {
        Data = JsonUtility.FromJson<TestData>(JSONFile.text);
    }

    public static TestData Data;
}
