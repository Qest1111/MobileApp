using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public abstract class DataController : MonoBehaviour
{
    [HideInInspector]
    public string Path;

    public string GetJSONFile => PlayerPrefs.GetString(Path, "{}");

    public void SetJSONFile(string text) {
        PlayerPrefs.SetString(Path, text);
        PlayerPrefs.Save();
    }

    public void AwakeInit()
    {
        InitJson(GetJSONFile);
    }

    public abstract void InitJson(string json);
}
