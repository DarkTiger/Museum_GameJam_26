using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMicrobe : Microbe
{
    Microbe target = null;
    Vector3 nextPosition = Vector3.zero;
    float nextTimer = 0;
    float timer = 0;
    Vector2 timerLimit = new Vector2 (7.5f, 15f);
    Vector2 position2D;
    Vector3 position3D;


    void Update()
    {
        Move();
        Vector3 direction = (nextPosition - transform.position).normalized;
        transform.up = Vector3.Slerp(transform.up, direction, RotationSpeed*Time.deltaTime);
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



}