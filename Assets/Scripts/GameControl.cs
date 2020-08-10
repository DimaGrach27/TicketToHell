using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static bool death;
    public static bool finishLevel;
    public AudioSource buttomStart;
    public AudioSource audiomMainMenu;

    private void Start()
    {
        death = false;
        finishLevel = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            QuitTheGame();
        if (Input.GetKeyDown(KeyCode.R))
            ReloadScene();
        if (death)
            Invoke("ReloadScene", 2);
        if (finishLevel)
            Invoke("LoadNextScene", 2);
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        buttomStart.Play();
        audiomMainMenu.Stop();
        Invoke("LoadNextScene", 2.5f);
    }
}
