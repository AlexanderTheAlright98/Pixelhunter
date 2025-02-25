using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public int objectsToFind;
    public int misclicks;
    bool objectClickedInThisFrame;

    public float startTime;
    float currentTime;
    bool timerOn;
    public TMP_Text timerText;

    public GameObject gameOverlay, gameOverScreen, levelWonScreen, objectList, backgroundObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerOn = true;
        currentTime = startTime;
        gameOverlay.SetActive(true);
    }
    public void ObjectClicked()
    {
        misclicks = 0;
        objectsToFind--;
        objectClickedInThisFrame = true;
    }
    void Update()
    {
        if (timerOn)
        {
            currentTime -= Time.deltaTime;
            timerText.text = currentTime.ToString("f2");
        }
        if (Input.GetMouseButtonDown(0) && misclicks < 4 && !objectClickedInThisFrame)
        {
            misclicks++;
        }
        if (misclicks == 4)
        {
            StartCoroutine(TooManyMisclicks());
        }
        if (currentTime <= 0)
        {
            GameOver();
        }
        if (objectsToFind == 0)
        {
            YouWin();
        }

        objectClickedInThisFrame = false;
    }
    void GameOver()
    {
        gameOverlay.SetActive(false);
        backgroundObject.SetActive(false);
        objectList.SetActive(false);
        gameOverScreen.SetActive(true);
        timerOn = false;
    }
    void YouWin()
    {
        gameOverlay.SetActive(false);
        levelWonScreen.SetActive(true);
        timerOn = false;
    }
    IEnumerator TooManyMisclicks()
    {
        misclicks = 0;
        currentTime -= 5;
        timerText.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        timerText.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        timerText.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        timerText.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        timerText.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        timerText.color = Color.white;
    }
}
