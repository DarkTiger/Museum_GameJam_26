using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagementGame : MonoBehaviour
{
   public static SceneManagementGame Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Intro")
        {
            LoadCreditsLevel();
        }
        else
        {
            LoadGameLevel();
        }
    }

    public void LoadGameLevel()
    {
        StartCoroutine(LoadGameLevelCO());
    }

    IEnumerator LoadGameLevelCO()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("Game");
    }

    public void LoadCreditsLevel()
    {
        StartCoroutine(LoadCreditsLevelCO());
    }

    IEnumerator LoadCreditsLevelCO()
    {
        yield return new WaitForSeconds(15f);
        SceneManager.LoadScene("Credits");
    }
}
