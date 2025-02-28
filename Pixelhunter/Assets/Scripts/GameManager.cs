using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [Header("Clicking")]
    public int objectsToFind;
    public int misclicks;
    bool objectClickedInThisFrame;

    [Header("Timer")]
    public float startTime;
    float currentTime;
    bool timerOn;
    public TMP_Text timerText;

    [Header("UI/Gameplay Elements")]
    public GameObject gameOverlay;
    public GameObject gameOverScreen;
    public GameObject levelWonScreen;
    public GameObject objectList;
    public GameObject backgroundObject;

    [Header("SFX")]
    public AudioSource sfxAudioSource;
    public AudioClip correctSFX;
    public AudioClip wrongSFX;

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
        sfxAudioSource.PlayOneShot(correctSFX);
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
        if (Input.GetMouseButtonDown(0) && misclicks < 4 && !objectClickedInThisFrame && objectsToFind > 0)
        {
            misclicks++;
            sfxAudioSource.PlayOneShot(wrongSFX);
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
