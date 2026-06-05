using UnityEngine;

public class GameMaker : MonoBehaviour
{
    public static GameMaker Instance {  get; private set; }
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
