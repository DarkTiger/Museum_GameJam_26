using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [SerializeField] AudioSource sourceStart;

    public static SceneManagement Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
    }

    public void LoadGameLevel()
    {
        sourceStart.Play();

        StartCoroutine(LoadGameLevelCO());
    }

    IEnumerator LoadGameLevelCO()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Intro");
    }
}
