using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class EnemyMicrobe : Microbe
{
    Microbe target = null;
    Microbe bigTarget = null;
    Vector3 nextPosition = Vector3.zero;
    float nextTimer = 0;
    float timer = 0;
    Vector2 timerLimit = new Vector2 (7.5f, 15f);
    Vector2 position2D;
    Vector3 position3D;
    Vector3 direction;


    protected void Update()
    {
        base.Update();

        Move();
    }

    private void Move()
    {
        if (target == null)
        {
            if (bigTarget == null)
            {
                if (timer <= nextTimer)
                {
                    if (nextPosition != Vector3.zero && Vector3.Distance(transform.position, nextPosition) > 0.1f)
                    {
                        direction = (nextPosition - transform.position).normalized;
                        transform.position += (nextPosition - transform.position).normalized * Speed * Time.deltaTime;
                    }
                    else
                    {
                        FindNextPosition();
                        timer = 0;
                        nextTimer = NextTimer();
                    }
                    timer += Time.deltaTime;
                }
                else
                {
                    FindNextPosition();
                    timer = 0;
                    nextTimer = NextTimer();
                }
            }
            else
            {
                direction = (transform.position - bigTarget.transform.position).normalized;
                transform.position += (transform.position - bigTarget.transform.position).normalized * Speed * Time.deltaTime;
                if (Vector3.Distance(transform.position, bigTarget.transform.position) > 2.5f)
                {
                    bigTarget = null;
                }
            }
        }
        else
        {
            direction = (target.transform.position - transform.position).normalized;
            transform.position += (target.transform.position - transform.position).normalized * Speed * Time.deltaTime;
        }

        transform.up = Vector3.Slerp(transform.up, direction, RotationSpeed * Time.deltaTime);
    }

    private void FindNextPosition()
    {
        position2D = new Vector2 (Random.Range(0, Screen.width),Random.Range(0, Screen.height));
        position3D = Camera.main.ScreenToWorldPoint(position2D);
        nextPosition = new Vector3(Random.Range(-position3D.x, position3D.x), Random.Range(-position3D.y, position3D.y), 0f);
        if (Vector3.Distance(nextPosition, transform.position) < 2f)
        {
            FindNextPosition();
        }
    }

    private float NextTimer()
    {
        nextTimer = Random.Range(timerLimit.x, timerLimit.y);
        return nextTimer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        foreach (Microbe item in MicrobesList)
        {
            if (item.transform.localScale.x > transform.localScale.x)
            {
                target = null;
                bigTarget = item;
                break;
            }
            else
            {
                if (target == null)
                {
                    target = item;
                }
                else
                {
                    if (Vector3.Distance(transform.position, target.transform.position) > Vector3.Distance(transform.position, item.transform.position))
                    {
                        target = item;
                    }
                }
            }
        }
    }
}