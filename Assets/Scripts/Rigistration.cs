using UnityEngine;
using System.IO;
using System;

public class Registration : MonoBehaviour
{
    public GameObject namePan;

    private Save sv = new Save();
    private string path;

    private void Start()
    {
        path = Path.Combine(Application.persistentDataPath, "Save.json");

        if (File.Exists(path))
        {
            sv = JsonUtility.FromJson<Save>(File.ReadAllText(path));
        }
        else namePan.SetActive(true);
    }

    public void CheckLogin(string login)
    {
        if (!string.IsNullOrEmpty(login) && login.Length >= 3)
        {
            sv.login = login;
        }
        else Debug.Log("Введите нормальное имя!");
    }
    public void CheckaClass(string aclass)
    {
        sv.aclass = int.Parse(aclass);
    }
    private void OnApplicationPause(bool pause)
    {
        if (pause) File.WriteAllText(path, JsonUtility.ToJson(sv));
    }
    private void OnApplicationQuit()
    {
        File.WriteAllText(path, JsonUtility.ToJson(sv));
    }
}
[Serializable]
public class Save
{
    public string login;
    public int aclass;
}