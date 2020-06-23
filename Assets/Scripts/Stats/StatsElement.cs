using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsElement : MonoBehaviour
{
    public Text DateTimeText, ResultText,NameText;
    
    public void Init(SaveData data)
    {
        DateTimeText.text = $"{data.Date}\n{data.Time}";
        NameText.text = data.name;
        ResultText.text = data.Mark == 100 ? "Выполнен успешно" : "Провален";
        ResultText.text += $"\n({Mathf.Round(data.Mark)}%)";
    }
}
