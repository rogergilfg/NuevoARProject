using UnityEngine;
using UnityEngine.UI;

public class GetCameraImage : MonoBehaviour

{

    [SerializeField] private RawImage backgroundTexture;

    private WebCamTexture cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        WebCamDevice[] realCameras = WebCamTexture.devices;

        for(int i = 0; i < realCameras.Length; i++)
        {
            Debug.Log(realCameras[i].name);
            if (realCameras[i].isFrontFacing == false)
            {
                cam = new WebCamTexture(realCameras[i].name, Screen.width, Screen.height);
            }
        }

        cam.Play();
        backgroundTexture.texture = cam;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
