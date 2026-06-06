using TMPro;
using UnityEngine;

public class CanvasMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txtFps;

    private int frameCount = 0;
    private float timeElapsed = 0f;
    private float currentFPS = 0f;

    void Update()
    {
        frameCount++;
        timeElapsed += Time.unscaledDeltaTime;

        // Update the text only after the interval has passed
        if (timeElapsed >= 0.1f)
        {
            currentFPS = frameCount / timeElapsed;

            // Mathf.CeilToInt rounds up to the nearest whole number (e.g., 59.2 -> 60)
            txtFps.text = $"FPS: {Mathf.CeilToInt(currentFPS)}";

            // Reset counters for the next interval
            frameCount = 0;
            timeElapsed = 0f;
        }
    }
}
