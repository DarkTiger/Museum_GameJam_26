using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMicrobe : Microbe
{
    Vector3 targetPosition = Vector3.zero;
    int borderOffset = 24;


    protected void Update()
    {
        base.Update();

        if (Mouse.current.leftButton.isPressed)
        {
            Vector3 mousePos = Mouse.current.position.ReadValue();
            if (mousePos.x - borderOffset > 0f && mousePos.x + borderOffset < Screen.width &&
                mousePos.y - borderOffset > 0f && mousePos.y + borderOffset < Screen.height)
            {
                targetPosition = Camera.main.ScreenToWorldPoint(mousePos);
            }

            if (targetPosition != Vector3.zero &&
            new Vector3(transform.position.x, transform.position.y, 0f) != targetPosition)
            {
                transform.position -= (new Vector3(transform.position.x, transform.position.y, 0f) - new Vector3(targetPosition.x, targetPosition.y, 0f)).normalized * Speed * Time.deltaTime;
            }
        }
    }
}
