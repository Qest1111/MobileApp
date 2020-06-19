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
            Debug.Log("Добро пожаловать: " + sv.name + "\nВы в классе: " + sv.grade);
        }
        else namePan.SetActive(true);
    }

    public void CheckName(string name)
    {
        if (!string.IsNullOrEmpty(name) && name.Length >= 3)
        {
            sv.name = name;
            Debug.Log("Ваш логин: " + name);
        }
        else Debug.Log("Введите нормальный логин!");
    }
    public void CheckGrade(string grade)
    {
        if (!string.IsNullOrEmpty(grade) && grade.Length > 0)
        {
            sv.grade = grade;
            Debug.Log("Ваш класс: " + grade);
        }
        else Debug.Log("Введите нормальный класс!");
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause) File.WriteAllText(path, JsonUtility.ToJson(sv));
    }
    private void OnApplicationQuit()
    {
        File.WriteAllText(path, JsonUtility.ToJson(sv));
    }
    public void Regisration()
    {
        namePan.SetActive(false);
    }

}
[Serializable]
public class Save
{
    public string name;
    public string grade;
}