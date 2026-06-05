using UnityEngine;

public class EnemyMicrobe : Microbe
{
    Microbe target = null;


    void SearchTarget()
    {
        Microbe[] microbes = GameMaker.Instance.Microbes;

        for (int i = 0; i < microbes.Length; i++)
        {
            Microbe microbe = microbes[i];
            if (microbe != this)
            {
                if (microbe.transform.localScale.magnitude < (transform.localScale.magnitude * 0.9f))
                {

                }
            }
        }
    }

    void Update()
    {
        if (!target)
        {
            SearchTarget();
        }

        if (target)
    }


}