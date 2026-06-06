using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMicrobe : Microbe
{
    [SerializeField] AudioSource sourceSwim;
    Vector3 targetPosition = Vector3.zero;
    int borderOffset = 24;


    protected void Update()
    {
        base.Update();

        if (Mouse.current.leftButton.isPressed ||
            (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed))
        {
            Vector3 mousePos = Touchscreen.current != null? Touchscreen.current.position.ReadValue() : Mouse.current.position.ReadValue();
            if (mousePos.x - borderOffset > 0f && mousePos.x + borderOffset < Screen.width &&
                mousePos.y - borderOffset > 0f && mousePos.y + borderOffset < Screen.height)
            {
                targetPosition = Camera.main.ScreenToWorldPoint(mousePos);
            }

            if (targetPosition != Vector3.zero &&
            new Vector3(transform.position.x, transform.position.y, 0f) != targetPosition)
            {
                transform.position -= (new Vector3(transform.position.x, transform.position.y, 0f) - new Vector3(targetPosition.x, targetPosition.y, 0f)).normalized * (Speed / transform.localScale.x) * Time.deltaTime;
            
                if (!sourceSwim.isPlaying)
                {
                    sourceSwim.Play();
                }
            }
            else
            {
                sourceSwim.Stop();
            }
        }
        else
        {
            sourceSwim.Stop();
        }
    }

    private void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.PlayerDead();
        }
    }
}
