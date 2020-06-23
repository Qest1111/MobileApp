using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedDataController : DataController
{
    public static bool Inited = false;
    public static SavedDataController instance;
    private void Awake()
    {
        if (!Inited)
        {
            Inited = true;
            instance = this;
            DontDestroyOnLoad(gameObject);
            Path = "savedData";
            AwakeInit();
        }
        else
            Destroy(gameObject);
    }

    public override void InitJson(string json)
    {
        Data = JsonUtility.FromJson<SavedData>(json);
    }

    public void AddStat(SaveData data)
    {
        Data.saveData.Add(data);
        SetJSONFile(JsonUtility.ToJson(Data));
    }

    public static SavedData Data;
}
