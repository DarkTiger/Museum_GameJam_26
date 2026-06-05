using UnityEngine;

public class EnemyMicrobe : Microbe
{
    Microbe target = null;
    Vector3 nextPosition = Vector3.zero;



    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (nextPosition != Vector3.zero && transform.position != nextPosition)
        {
            transform.position += (transform.position - nextPosition).normalized * Speed * Time.deltaTime;
        }
        else
        {
            nextPosition = new Vector3(Random.Range(-Screen.width, Screen.width), Random.Range(-Screen.height, Screen.height), 0f);
        }
    }


}