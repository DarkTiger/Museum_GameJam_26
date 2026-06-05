using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }
    public Microbe[] Microbes { get; private set; }


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateMicrobes();
    }

    public void UpdateMicrobes()
    {
        Microbes = FindObjectsByType<Microbe>();
    }
}
