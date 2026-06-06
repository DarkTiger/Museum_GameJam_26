using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public static SceneManagement Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void LoadGameLevel()
    {
        SceneManager.LoadScene("Game");
    }
}
