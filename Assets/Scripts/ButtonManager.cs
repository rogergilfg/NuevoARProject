using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    public void Salir()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ARFake()
    {
        SceneManager.LoadScene("ARFake");
    }

    public void ARTracking()
    {
        SceneManager.LoadScene("AR_Tracking");
    }

    public void TrackingSurface()
    {
        SceneManager.LoadScene("TrackingSurface");
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
