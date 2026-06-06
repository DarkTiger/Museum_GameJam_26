using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txtFps;
    [SerializeField] Image imgFillBar;

    public static CanvasMenu Instance { get; private set; }

    private int frameCount = 0;
    private float timeElapsed = 0f;
    private float currentFPS = 0f;


    private void Awake()
    {
        Instance = this;
    }

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

    public void UpdateGoal(float current, float max)
    {
        imgFillBar.fillAmount = current / max;
    }
}
