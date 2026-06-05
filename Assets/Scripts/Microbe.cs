using UnityEngine;

public class Microbe : MonoBehaviour
{
    protected SpriteRenderer SpriteRenderer;

    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }
}
