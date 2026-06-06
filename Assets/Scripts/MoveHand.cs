using UnityEngine;

public class MoveHand : MonoBehaviour
{
    [SerializeField]Transform start, end;
    [SerializeField] float speed = 1f;

    private void Update()
    {
        transform.position = transform.position += (end.position - transform.position).normalized * speed * Time.deltaTime;
        if (Vector3.Distance(transform.position,end.position)<0.5f)
        {
            transform.position = start.position;
        }
    }

}
