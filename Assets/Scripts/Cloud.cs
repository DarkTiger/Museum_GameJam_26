using UnityEngine;

public class Cloud : MonoBehaviour
{
    Vector3 targetPos;
    private void Start()
    {
        targetPos = transform.position * -1;
    }

    void Update()
    {
        transform.position -= (transform.position - targetPos).normalized * transform.localScale.x * 2f * Time.deltaTime;
        
        if (Vector3.Distance(transform.position, targetPos) < 0.01f)
        {
            Background.Instance.CloudsList.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
