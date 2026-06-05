using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMicrobe : Microbe
{
    Microbe target = null;
    Vector3 nextPosition = Vector3.zero;
    float nextTimer = 0;
    float timer = 0;
    Vector2 timerLimit = new Vector2 (2.5f, 7.5f);
    Vector2 position2D;
    Vector3 position3D;


    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (timer <= nextTimer)
        {
            if (nextPosition != Vector3.zero && Vector3.Distance(transform.position,nextPosition) > 0.1f)
            {
                transform.position += (nextPosition - transform.position).normalized * Speed * Time.deltaTime;
            }
            else
            {
                FindNextPosition();
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

    private void FindNextPosition()
    {
        position2D = new Vector2 (Random.Range(0, Screen.width),Random.Range(0, Screen.height));
        position3D = Camera.main.ScreenToWorldPoint(position2D);
        nextPosition = new Vector3(Random.Range(-position3D.x, position3D.x), Random.Range(-position3D.y, position3D.y), 0f);
        if (Vector3.Distance(nextPosition, transform.position) < 5f)
        {
            FindNextPosition();
        }
    }

    private float NextTimer()
    {
        nextTimer = Random.Range(timerLimit.x, timerLimit.y);
        return nextTimer;
    }



}