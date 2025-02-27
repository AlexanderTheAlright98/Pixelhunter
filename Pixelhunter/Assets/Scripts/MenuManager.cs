using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void Nextlevel()
    {
        SceneManager.LoadScene(2);
    }
}
