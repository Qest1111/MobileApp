using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;                                                       

public class DataController : MonoBehaviour
{
    private RoundData[] allData;
    
  

    private string gameDataFileName = "TestData.json";

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        LoadGameData();

     

        SceneManager.LoadScene("MenuScreen");
    }

    public RoundData GetCurrentRoundtest()
    {

        return allData[0];
    }

    private void LoadGameData()
    {
        string filePath = Path.Combine(Application.persistentDataPath, gameDataFileName);

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            GameData loadedData = JsonUtility.FromJson<GameData>(dataAsJson);
            allData = loadedData.allData;

        }
        else
        {
            Debug.LogError("Where is my data?");
        }
    }
}