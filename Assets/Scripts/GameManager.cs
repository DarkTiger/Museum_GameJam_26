using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int enemiesCount = 50;
    [SerializeField] Vector2 scaleMinMax = new Vector2(0.1f, 1.5f);
    [SerializeField] EnemyMicrobe[] enemyMicrobes;

    public static GameManager Instance {  get; private set; }
    public List<Microbe> MicrobesList { get; private set; }



    private void Awake()
    {
        Instance = this;
        MicrobesList = new List<Microbe>();
    }

    private void Update()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        if (MicrobesList.Count < enemiesCount)
        { 
            Vector2 position2D = new Vector2(Random.Range(0f, Screen.width), Random.Range(0f, Screen.height));
            Vector3 position3D = Camera.main.ScreenToWorldPoint(position2D);
            position3D.z = 0f;
            float scale = Random.Range(scaleMinMax.x, scaleMinMax.y);

            if (!Physics2D.OverlapCircle(new Vector2(position3D.x, position3D.y), scale))
            {
                EnemyMicrobe enemyMicrobeIntantiate = Instantiate(enemyMicrobes[Random.Range(0, enemyMicrobes.Length)], position3D, Quaternion.Euler(new Vector3(0f, 0f, Random.Range(0f, 360f))));
                enemyMicrobeIntantiate.transform.localScale = Vector3.one * scale;
                MicrobesList.Add(enemyMicrobeIntantiate);
            }
        }
    }

    public void EnemyDestroyed(Microbe microbe)
    {
        MicrobesList.Remove(microbe);
    }
}
