using System.Collections.Generic;
using UnityEngine;

public class Microbe : MonoBehaviour
{
    protected float Speed = 1;
    protected float RotationSpeed = 1;
    protected SpriteRenderer SpriteRenderer;
    protected List<Microbe> MicrobesList;

    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
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

    protected void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.gameObject.TryGetComponent(out Microbe microbe))
        //{
        //    MicrobesList.Remove(microbe);
        //}
    }
}
