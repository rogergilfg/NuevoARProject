using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    public void Salir()
    {
        Time.timeScale = 1.0f;
        AudioManager.instance.StopMusic();
        SceneManager.LoadScene("MainMenu");
    }

    public void ARFake()
    {
        AudioManager.instance.StopMusic();
        SceneManager.LoadScene("ARFake");
    }

    public void ARTracking()
    {
        AudioManager.instance.StopMusic();
        SceneManager.LoadScene("AR_Tracking");
    }

    public void TrackingSurface()
    {
        AudioManager.instance.StopMusic();
        SceneManager.LoadScene("TrackingSurface");
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void Replay()
    {
        Time.timeScale = 1.0f;
        AudioManager.instance.StopMusic();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
