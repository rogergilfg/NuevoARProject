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
}
