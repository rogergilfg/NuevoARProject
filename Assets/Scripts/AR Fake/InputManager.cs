using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private UIController uiController;

    [Header("SFX")]
    [SerializeField] private AudioClip rayo;

    [Header("Particulas")]
    [SerializeField] private GameObject particulasPingu;

    private Camera arCamera;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        arCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update corriendo");

        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
         
            Debug.Log("Input detectado");
            AudioManager.instance.PlaySFX(rayo, 0.4f, false, arCamera.transform.position);
            Vector2 touchPosition = Input.touchCount > 0
                ? Input.GetTouch(0).position
                : (Vector2)Input.mousePosition;

            Ray ray = arCamera.ScreenPointToRay(touchPosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                GameObject particulas = Instantiate(particulasPingu, hit.point , Quaternion.identity);
                Destroy(particulas, 1f);

                if (hit.transform.gameObject.CompareTag("Enemy"))
                {
                    uiController.AddKill();
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
}
