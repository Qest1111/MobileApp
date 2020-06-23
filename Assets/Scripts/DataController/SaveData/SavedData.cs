using System.Collections.Generic;

[System.Serializable]
public class SavedData
{
    public List<SaveData> saveData = new List<SaveData>();
}

[System.Serializable]
public class SaveData
{
    public string name;
    public string Date;
    public string Time;
    public float Mark;
}
