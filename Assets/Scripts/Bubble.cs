using UnityEngine;

public class Bubble : MonoBehaviour
{
    float maxScale = 0.15f;
    private void Update()
    {
        if (transform.localScale.x < maxScale)
        {
            transform.localScale += Vector3.one * Time.deltaTime * 0.05f;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
