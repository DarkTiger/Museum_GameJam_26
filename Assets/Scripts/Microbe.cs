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
    [SerializeField] GameObject attackVFXPrefab;
    [SerializeField] AudioSource sourceEating;
    public AudioSource sourceAhhh;


    private void Awake()
    {
        SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        SpriteRenderer.color = new Color(0f, 0f, 0f, 0f);
    }

    protected void Update()
    {
        if (targetScale > 0f && transform.localScale.x != targetScale)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(targetScale, targetScale, targetScale), 5f * Time.deltaTime);
        }

        SpriteRenderer.color = new Color(1f, 1f, 1f, Mathf.Lerp(SpriteRenderer.color.a, 1f, 10f * Time.deltaTime));
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
        //if (!(collision.collider is CircleCollider2D)) return;

        if (collision.gameObject.TryGetComponent(out Microbe microbe))
        {
            if (microbe.transform.localScale.magnitude < transform.localScale.magnitude)
            {
                if (this is PlayerMicrobe)
                {
                    GameManager.Instance.AddGoal();
                }

                GameObject attackVFX = Instantiate(attackVFXPrefab, microbe.transform.position, Quaternion.identity);
                attackVFX.transform.localScale = Vector3.one * 0.1f;
                Destroy(attackVFX, 2f);
                targetScale = transform.localScale.x + (microbe.transform.localScale.x * GrowMultiplier);
                MicrobesList.Remove(microbe);
                GameManager.Instance.EnemyDestroyed(microbe);
                Destroy(microbe.gameObject);
                sourceEating.Play();
            }
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Microbe microbe))
        {
            MicrobesList.Remove(microbe);
        }
    }
}
