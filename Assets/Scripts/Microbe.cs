using System.Collections.Generic;
using UnityEngine;

public class Microbe : MonoBehaviour
{
    public float Speed = 1;
    public float RotationSpeed = 1;
    public float GrowMultiplier = 0.1f;
    protected SpriteRenderer SpriteRenderer;
    protected List<Microbe> MicrobesList = new List<Microbe>();
    float targetScale = 0f;

    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (targetScale > 0f && transform.localScale.x != targetScale)
        {
            transform.localScale = new Vector3(targetScale, targetScale, targetScale);//Vector3.Lerp(transform.localScale, new Vector3(targetScale, targetScale, targetScale), 500f * Time.deltaTime);
        }
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Microbe microbe))
        {
            if (!MicrobesList.Contains(microbe))
            {
                MicrobesList.Add(microbe);
            }
        }
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Microbe microbe))
        {
            if (microbe.transform.localScale.magnitude < transform.localScale.magnitude)
            {
                targetScale = transform.localScale.x + (microbe.transform.localScale.x * GrowMultiplier);
                MicrobesList.Remove(microbe);
                GameManager.Instance.EnemyDestroyed(microbe);
                Destroy(microbe.gameObject);
            }
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.gameObject.TryGetComponent(out Microbe microbe))
        //{
        //    MicrobesList.Remove(microbe);
        //}
    }
}
