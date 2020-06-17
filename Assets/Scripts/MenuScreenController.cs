using UnityEngine;

public class MenuScreenController : MonoBehaviour
{
	public void StartGame()
	{
        UnityEngine.SceneManagement.SceneManager.LoadScene("LoadLevel");
	}

    public void Quit()
    {
        Application.Quit();
    }
}