using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsController : MonoBehaviour
{
    public GameObject StatPrefab,StatContainer;

    private void Start()
    {
        LoadStats();
    }

    private void LoadStats()=>SavedDataController.Data.saveData.ForEach(data => Instantiate(StatPrefab, StatContainer.transform).GetComponent<StatsElement>().Init(data));
}
