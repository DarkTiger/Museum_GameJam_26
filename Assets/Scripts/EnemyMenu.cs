using UnityEngine;

public class EnemyMenu : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManagement.Instance.LoadGameLevel();
        Destroy(gameObject);
    }
}
