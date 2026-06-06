using UnityEngine;

public class LimitMap : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Microbe microbe))
        {
            GameManager.Instance.EnemyDestroyed(microbe);
            Destroy(microbe.gameObject);
        }
    }
}
