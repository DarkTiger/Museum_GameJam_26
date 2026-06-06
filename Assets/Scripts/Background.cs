using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] int cloudsCount = 5;
    [SerializeField] GameObject cloudPrefab;

    public static Background Instance { get; private set; }
    public List<GameObject> CloudsList = new List<GameObject>();


    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (CloudsList.Count < 5)
        {
            GameObject cloudIntantiated = Instantiate(cloudPrefab, new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), 0f), Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));
            cloudIntantiated.transform.localScale = Vector3.one * Random.Range(0.25f, 1f);
            CloudsList.Add(cloudIntantiated);
        }
    }
}
