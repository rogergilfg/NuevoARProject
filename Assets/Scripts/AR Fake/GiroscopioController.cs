using UnityEngine;

public class GiroscopioController : MonoBehaviour
{

    [SerializeField] private Transform cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    private void LateUpdate()
    {
        if(SystemInfo.supportsGyroscope == true)
        {
            Quaternion inputGyro = Input.gyro.attitude;

            cam.rotation = new Quaternion(inputGyro.x, inputGyro.y, -inputGyro.z, -inputGyro.w);

            Quaternion correccionGiro = Quaternion.Euler(90, 0, 0);

            cam.rotation = correccionGiro * new Quaternion(inputGyro.x, inputGyro.y, -inputGyro.z, -inputGyro.w);
        }
    }
}
