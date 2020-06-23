using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTestController : MonoBehaviour
{
    public static Test CurrentTest;

    public GameObject SelectTestPrefab, SelectTestContainer;

    private void Start()
    {
        LoadTests();
    }

    private void LoadTests() => TestDataController.Data.testData.ForEach(data =>Instantiate(SelectTestPrefab,SelectTestContainer.transform).GetComponent<SelectTestElement>().Init(data));
}
