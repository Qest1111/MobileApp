using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;

public class DataController : MonoBehaviour 
{
	public RoundData[] allData;
    public RoundData RoundData;
    public int round;
    private string gameDataFileName = "TestData.json";
    string filePath;


    void Start()
    {
        DontDestroyOnLoad(gameObject);

        LoadGameData();


        SceneManager.LoadScene("MenuScreen");
    }

    public RoundData GetCurrentRoundData()
    {
     
        if (round == allData.Length)
        {
            round--;
        }
        return allData[round];
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
            Debug.LogError("Where's my TestData!?");
        }
    }
}