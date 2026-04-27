using UnityEngine;

public class GiroscopioController : MonoBehaviour
{

    [SerializeField] private Transform cam;
    [SerializeField] private float sensibility;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Input.gyro.enabled = true;
        Input.gyro.updateInterval = 0.0167f;
    }


    private void LateUpdate()
    {
        if(SystemInfo.supportsGyroscope == true)
        {
            Quaternion inputGyro = Input.gyro.attitude;

            Quaternion correccionGiro = Quaternion.Euler(90, 0, 0);
            cam.rotation = correccionGiro * new Quaternion(inputGyro.x, inputGyro.y, -inputGyro.z, -inputGyro.w);
        }
    }
}
