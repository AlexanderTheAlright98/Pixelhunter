using UnityEngine;
using TMPro;

public class ClickController : MonoBehaviour
{
    public int misclicks;

    public float startTime;
    float currentTime;
    bool timerOn;
    public TMP_Text timerText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerOn = true;
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            currentTime -= Time.deltaTime;
            timerText.text = currentTime.ToString("f2");
        }
        if (Input.GetMouseButtonDown(0))
        {
            misclicks++;
        }
        if (misclicks == 4)
        {
            currentTime -= 2;
            misclicks = 0;
        }
        if (currentTime <= 0)
        {
            timerOn = false;
            timerText.text = "TIME UP!";
        }
    }
}
