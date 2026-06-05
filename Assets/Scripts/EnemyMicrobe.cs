using UnityEngine;

public class EnemyMicrobe : Microbe
{
    Microbe target = null;
    Vector3 nextPosition = Vector3.zero;
    float nextTimer = 0;
    float timer = 0;
    Vector2 timerLimit = new Vector2 (0.5f, 5f);


    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (timer <= nextTimer)
        {
            if (nextPosition != Vector3.zero && transform.position != nextPosition)
            {
                transform.position += (transform.position - nextPosition).normalized * Speed * Time.deltaTime;
            }
            else
            {
                nextPosition = new Vector3(Random.Range(-Screen.width, Screen.width), Random.Range(-Screen.height, Screen.height), 0f);
            }
            timer += Time.deltaTime;
        }
        else
        {
            nextPosition = new Vector3(Random.Range(-Screen.width, Screen.width), Random.Range(-Screen.height, Screen.height), 0f);
            timer = 0;
            nextTimer = NextTimer();
        }
        
    }
    private float NextTimer()
    {
        nextTimer = Random.Range(timerLimit.x, timerLimit.y);
        return nextTimer;
    }



}