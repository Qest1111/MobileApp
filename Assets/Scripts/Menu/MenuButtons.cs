using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    public void ClickPlay()
    {
        SceneLoader.instance.LoadScene(3);
    }

    public void ClickStat()
    {
        SceneLoader.instance.LoadScene(2);
    }

    public void ClickExit()
    {
        Application.Quit();
    }
}
