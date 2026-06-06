using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    [SerializeField] GameObject bubblePrefab;
    float timer;
    float delay = 0.05f;

    private void Update()
    {
        if (timer < delay)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnObjects();
            timer = 0;
            delay = Random.Range(0.05f, 0.15f);
        }
    }
    void SpawnObjects()
    {
        Vector2 position2D = new Vector2(Random.Range(0f, Screen.width), Random.Range(0f, Screen.height));
        Vector3 position3D = Camera.main.ScreenToWorldPoint(position2D);
        position3D.z = 0f;
        Instantiate(bubblePrefab, position3D, Quaternion.identity);
        
    }
}
